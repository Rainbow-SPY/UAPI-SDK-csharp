using System.Threading.Tasks;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    /// <summary>
    /// 查询Epic Games相关功能
    /// </summary>
    public partial class EpicGames
    {
        /// <summary>
        /// 获取当前Epic Games的免费游戏
        /// </summary>
        private static readonly string _au = "Epic Games";

        /// <summary>
        /// 请求Epic Games 当前免费游戏的方法
        /// </summary>
        /// <returns><see cref="EpicType"/> 对象</returns>
        public static async Task<EpicType> GetDataJson()
        {
            const string requestUrl = @"https://uapis.cn/api/v1/game/epic-free";
            var (result, statuscode) = await Interface.GetResult<EpicType>(requestUrl);
            if (!Interface.IsGetSuccessful(result, "", statuscode,
                    new IException.EpicGames.EpicGamesServerError("Epic Online Services 免费游戏服务器不可用"), "Epic Games"))
                WriteLog.Error("请求失败, 请重试");
            foreach (var game in result.data)
            {
                WriteLog.Info(_au, $"游戏唯一ID {game.id}");
                WriteLog.Info(_au, $"游戏名: {game.title}");
                WriteLog.Info(_au, $"当前是否免费? {(game.is_free_now ? "Free" : "UnKnow")}");
                WriteLog.Info(_au, $"免费开始的时间: {game.free_start}");
                WriteLog.Info(_au, $"免费结束的时间: {game.free_end}");
                WriteLog.Info(_au, $"游戏封面的URL: {game.cover}");
                WriteLog.Info(_au, $"免费结束的时间戳: {game.free_end_at}");
                WriteLog.Info(_au, $"详情页: {game.link}");
                WriteLog.Info(_au, $"游戏介绍: {game.description}");
            }

            return result;
        }
    }
}