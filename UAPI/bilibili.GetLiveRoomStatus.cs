//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 4:38
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for redirecting Bilibili API through a third-party interface.
//  Now Play:       MyGO!!!!! - 春日影 (MyGO!!!!! ver.)

using System.Threading.Tasks;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    /// <summary>
    /// bilibili 系列的接口
    /// </summary>
    public partial class bilibili
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public const string requestUrl_Main = @"https://uapis.cn/api/v1/social/bilibili/";

        public class GetLiveRoomStatus
        {
            /// <summary>
            /// 使用用户 UID 作为形参请求B站直播间数据
            /// </summary>
            /// <param name="mid">用户的 UID</param>
            /// <returns><see cref="LiveRoomType"/> 对象</returns>
            public static async Task<LiveRoomType> AsID(string mid) => await GetLiveRoomStatus_Main(mid, null);

            /// <summary>
            /// 使用直播间ID作为形参请求B站直播间的数据
            /// </summary>
            /// <param name="room_id">直播间ID</param>
            /// <returns><see cref="LiveRoomType"/> 对象</returns>
            public static async Task<LiveRoomType> AsLiveroomID(string room_id) =>
                await GetLiveRoomStatus_Main(null, room_id);
        }

        private static async Task<LiveRoomType> GetLiveRoomStatus_Main(string mid, string room_id)
        {
            var (LiveRoomStatus, statusCode) =
                await Interface.GetResult<LiveRoomType>(
                    $@"{requestUrl_Main}liveroom?{(mid == null ? "" : $"mid={mid}")}{(room_id == null ? "" : $"room_id={room_id}")}");
            var a = IsGetSuccessful(LiveRoomStatus, statusCode);
            if (!a) WriteLog.Error(LogKind.Network, "请求失败, 请重试");

            return LiveRoomStatus;
        }


        internal static bool IsGetSuccessful(LiveRoomType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    WriteLog.Error(LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.error} - {Type.details}");
                    break;
                case 500:
                    WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type.error} - {Type.details}");
                    throw new IException.General.UAPIServerDown();

                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"bilibili API请求错误, 错误代码: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.error} - {Type.details}");
                    throw new IException.bilibili.BilibiliServiceError();
                case 200:
                    WriteLog.Info(LogKind.Network, "请求成功");
                    return true;
                case 403:
                    WriteLog.Warning(LogKind.Network, "您已被限制限制请求, 因 请求量过大.");
                    break;
                case 404:
                    WriteLog.Warning("未找到用户");
                    break;
                case -1:
                    WriteLog.Error(LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    break;
                default:
                    WriteLog.Warning(LogKind.Http, "未知错误");
                    break;
            }

            return false;
        }
    }
}