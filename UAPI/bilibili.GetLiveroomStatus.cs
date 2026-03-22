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
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    /// <summary>
    /// bilibili 系列的接口
    /// </summary>
    public partial class bilibili
    {
        /// <summary>
        /// 获取bilibili直播间的信息
        /// </summary>
        public class GetLiveroomStatus
        {
            /// <summary>
            /// 使用用户 UID 作为形参请求B站直播间数据
            /// </summary>
            /// <param name="mid">用户的 UID</param>
            /// <param name="Authentication">API Token</param>
            /// <returns><see cref="LiveroomType"/> 对象</returns>
            public static async Task<LiveroomType> AsID(string mid, string Authentication = "") =>
                await GetLiveroomStatus_Main(mid, null, Authentication);

            /// <summary>
            /// 使用直播间ID作为形参请求B站直播间的数据
            /// </summary>
            /// <param name="room_id">直播间ID</param>
            /// <param name="Authentication">API Token</param>
            /// <returns><see cref="LiveroomType"/> 对象</returns>
            public static async Task<LiveroomType> AsLiveroomID(string room_id, string Authentication = "") =>
                await GetLiveroomStatus_Main(null, room_id, Authentication);
        }

        private static async Task<LiveroomType> GetLiveroomStatus_Main(string mid, string room_id,
            string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<LiveroomType>(
                    $@"{Interface._UAPI_Request_Url}social/bilibili/liveroom?{(mid != null ? $"mid={mid}" : $"room_id={room_id}")}",
                    Authentication);
            if (!Interface.IsGetSuccessful(result, "mid 或 room_id", statusCode,
                    new IException.bilibili.BilibiliServiceError(), "bilibili",
                    IException.bilibili._Bilibili_Service_Error))
                WriteLog.Error(LogKind.Network, $"请求失败, 请重试, 返回值: {statusCode}");
            return result;
        }
    }
}