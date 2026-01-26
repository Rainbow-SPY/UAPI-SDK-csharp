using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<LiveRoomType> GetLiveRoomStatus()
        {
            return null;

            async Task<LiveRoomType> AsID(string mid)
            {
                var (LiveRoomStatus, statusCode) =
                    await GetResult<LiveRoomType>($@"{requestUrl_Main}/liveroom?mid={mid}");
            }

            async Task<LiveRoomType> AsLiveroomID(string room_id)
            {
                var (LiveRoomStatus, statusCode) =
                    await GetResult<LiveRoomType>($@"{requestUrl_Main}/liveroom?room_id={room_id}");
                IsGetSuccessful(LiveRoomStatus, statusCode);
            }
        }

        internal static bool IsGetSuccessful(LiveRoomType Type, int StatusCode)
        {
            switch (StatusCode)
            {
                case 400:
                    WriteLog.Error(LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.error} - {Type.details}");
                    MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.error} - {Type.details}",
                        _ERROR);
                    return false;
                case 500:
                    WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {}, 错误信息: {Type.error} - {Type.details}");

                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"bilibili API请求错误, 错误代码: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.error} - {Type.details}");

                    throw new IException.bilibili.BilibiliServiceError();
            }
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
                        WriteLog.Info(LogKind.Json, "反序列化 Json 对象");
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(compressedJson);
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