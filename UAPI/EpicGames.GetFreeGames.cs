using System.Threading.Tasks;
using static Rox.Runtimes.LogLibraries;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 查询Epic Games相关功能
    /// </summary>
    public class EpicGames
    {
        /// <summary>
        /// 获取当前Epic Games的免费游戏
        /// </summary>
        private const string _au = "Epic Games";

        /// <summary>
        /// 请求Epic Games 当前免费游戏的方法
        /// </summary>
        /// <returns><see cref="EpicType"/> 对象</returns>
        public static async Task<EpicType> GetDataJson(string AuthenticationAPITokenKey = "")
        {
            var requestUrl = $"{Interface._UAPI_Request_Url}game/epic-free";
            var (result, statuscode) = await Interface.GetResult<EpicType>(requestUrl, AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "", statuscode,
                new IException.EpicGames.EpicGamesServerError("Epic Online Services 免费游戏服务器不可用"), "Epic Games");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error("请求失败, 请重试");
            if (result.DataList == null) return list.FailedException != null ? throw list.FailedException : result;
            foreach (var game in result.DataList)
            {
                WriteLog.Info(_au, $"游戏唯一ID {game.ID}");
                WriteLog.Info(_au, $"游戏名: {game.Title}");
                WriteLog.Info(_au, $"当前是否免费? {(game.IsFreeNow ? "Free" : "UnKnow")}");
                WriteLog.Info(_au, $"免费开始的时间: {game.FreeStartTime}");
                WriteLog.Info(_au, $"免费结束的时间: {game.EndFreeTime}");
                WriteLog.Info(_au, $"游戏封面的URL: {game.CoverImageUrl}");
                WriteLog.Info(_au, $"免费结束的时间戳: {game.EndFreeTimeUnix}");
                WriteLog.Info(_au, $"详情页: {game.Link}");
                WriteLog.Info(_au, $"游戏介绍: {game.Description}");
            }

            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}