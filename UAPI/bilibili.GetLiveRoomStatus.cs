using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;
using static Rox.Text.Json;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public const string requestUrl_Main = @"https://uapis.cn/api/v1/social/bilibili";

        public class GetLiveRoomStatus
        {
            public Task<LiveRoomType> AsID(string mid) => GetLiveRoomStatus_Main(mid, null);

            public Task<LiveRoomType> AsLiveroomID(string room_id) => GetLiveRoomStatus_Main(null, room_id);
        }

        private static async Task<LiveRoomType> GetLiveRoomStatus_Main(string mid, string room_id)
        {
            var (LiveRoomStatus, statusCode) =
                await GetResult<LiveRoomType>(
                    $@"{requestUrl_Main}/liveroom?{(mid == null ? "" : $"mid={mid}")}{(room_id == null ? "" : $"room_id={room_id}")}");
            var a = IsGetSuccessful(LiveRoomStatus, statusCode);
            if (!a)
            {
                WriteLog.Error(LogKind.Network, "请求失败, 请重试");
            }

            return LiveRoomStatus;
        }


        internal static bool IsGetSuccessful(LiveRoomType Type, int StatusCode)
        {
            switch (StatusCode)
            {
                case 400:
                    WriteLog.Error(LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type?.error} - {Type?.details}");
                    break;
                case 500:
                    WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type?.error} - {Type?.details}");
                    throw new IException.General.UAPIServerDown();

                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"bilibili API请求错误, 错误代码: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type?.error} - {Type?.details}");

                    throw new IException.bilibili.BilibiliServiceError();
                case 200:
                    WriteLog.Info(LogKind.Network, "请求成功");
                    return true;
                case 403:
                    WriteLog.Warning(LogKind.Network, "您已被限制限制请求, 因 请求量过大.");
                    break;
            }

            return false;
        }

        public static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl) where T : class
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(requestUrl))
                    {
                        var statusCode = (int)response.StatusCode;
                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox_I.Error($"请求失败: {response.StatusCode}, 错误代码: {_HttpClient_Request_Failed}",
                                _ERROR);
                            return (null, statusCode);
                        }

                        var responseData = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(responseData))
                        {
                            WriteLog.Error(LogKind.Http, _void_value_null("HttpClient", "Content"));
                            return (null, statusCode);
                        }

                        WriteLog.Info(LogKind.Json, "压缩 Json");
                        var compressedJson = CompressJson(responseData);
                        // 新增：反序列化配置（忽略未知字段、空值处理）
                        var jsonSettings = new JsonSerializerSettings
                        {
                            // 忽略JSON中存在但实体类没有的字段
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            // 允许空值
                            NullValueHandling = NullValueHandling.Ignore,
                            // 容错类型转换
                            TypeNameHandling = TypeNameHandling.None
                        };
                        WriteLog.Info(LogKind.Json, "反序列化 Json 对象");
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(compressedJson, jsonSettings);
                        return (result, statusCode);
                    }
                }
            }
            catch (Exception e)
            {
                WriteLog.Error(_Exception_With_xKind("GetResult<T>()", e));
                throw;
            }
        }
    }
}