using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    /// <summary>
    /// 热榜
    /// </summary>
    public partial class Hotboard
    {
        /// <summary>
        /// 获取网易云音乐歌曲的热榜
        /// </summary>
        /// <returns></returns>
        public static async Task<NeteaseType> GetNeteaseMusicHotboard(string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<NeteaseType>(
                    $"{Interface._UAPI_Request_Url}misc/hotboard/?type=netease-music", Authentication);
            var list = Interface.IsGetSuccessful(result, "none", statusCode,
                new IException.Hotboard.HotboardUpstreamServiceError(), "Netease-Music Hotboard");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}