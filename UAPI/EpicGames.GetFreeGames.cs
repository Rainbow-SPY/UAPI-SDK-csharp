using System.Threading.Tasks;
using static Rox.Runtimes.LocalizedString;
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
            var a = IsGetSuccessful(result, statuscode);
            if (!a) WriteLog.Error("请求失败, 请重试");
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

        internal static bool IsGetSuccessful(EpicType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 500:
                    WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.message}");
                    MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.message}",
                        _ERROR);
                    throw new IException.General.UAPIServerDown();

                case 502:
                    WriteLog.Error(LogKind.Network, $"Epic Games 免费游戏服务暂时不可用，请稍后再试");
                    throw new IException.EpicGames.EpicGamesServerError(
                        "Epic Online Services 免费游戏服务器不可用");
                case 200:
                    WriteLog.Info(LogKind.Network, "请求成功");
                    return true;
                case 403:
                    WriteLog.Warning(LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    WriteLog.Warning("未找到用户");
                    MessageBox_I.Warning("未找到用户", _ERROR);
                    break;
                case -1:
                    WriteLog.Error(LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    break;
                default:
                    WriteLog.Error(LogKind.Http, "未知错误");
                    MessageBox_I.Error("发生了未知错误", _ERROR);
                    break;
            }

            return false;
        }
    }
}