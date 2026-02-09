using System;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    /// <summary>
    /// 热榜
    /// </summary>
    public partial class hotboard
    {
        internal const string _Request_Url = @"https://uapis.cn/api/v1/misc/hotboard/";

        /// <summary>
        /// 获取网易云音乐歌曲的热榜
        /// </summary>
        /// <returns></returns>
        public static async Task<NeteaseType> GetNeteaseMusicHotboard()
        {
            var (result, statusCode) = await Interface.GetResult<NeteaseType>($"{_Request_Url}?type=netease-music");
            if (!Interface.IsGetSuccessful<NeteaseType>(result, "none", statusCode,
                    new Hotboard.HotboardUpstreamServiceError(), "Netease-Music Hotboard"))
                LogLibraries.WriteLog.Error("请求失败, 请重试!");
            return result;
        }
    }
}