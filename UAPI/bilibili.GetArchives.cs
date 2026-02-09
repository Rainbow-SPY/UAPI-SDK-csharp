//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 22:46
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for redirecting Bilibili API through a third-party interface.
//  Now Play:       Ave Mujica - KiLLKiSS


using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 查询B站用户的稿件
        /// </summary>
        /// <param name="mid">用户的 UID</param>
        /// <param name="keywords">查询关键字</param>
        /// <param name="orderby">以何种方式排列</param>
        /// <param name="ps">每页的条数,默认20</param>
        /// <param name="pn">页码,默认1</param>
        /// <returns><see cref="ArchiveType"/> 对象</returns>
        public static async Task<ArchiveType> GetArchives(string mid,
            ArchivesSearchType orderby = ArchivesSearchType.Pubdate, string keywords = "",
            int ps = 20, int pn = 1)
        {
            var (result, statusCode) = await Interface.GetResult<ArchiveType>(
                $"{requestUrl_Main}archives?mid={mid}&orderby={orderby}&ps={ps}&pn={pn}&keywords={keywords}");
            if (!Interface.IsGetSuccessful<ArchiveType>(result, "mid 或 room_id", statusCode,
                    new IException.bilibili.BilibiliServiceError(), "bilibili",
                    IException.bilibili._Bilibili_Service_Error))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }

        /// <summary>
        /// 以何种方式查询
        /// </summary>
        public enum ArchivesSearchType
        {
            /// <summary>
            /// 以最新投稿排列
            /// </summary>
            Pubdate,

            /// <summary>
            /// 以播放量最高排列
            /// </summary>
            Views
        }
    }
}