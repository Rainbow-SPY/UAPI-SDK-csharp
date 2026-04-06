using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class hotboard
    {
        /// <summary>
        /// 获取bilibili热榜信息
        /// </summary>
        /// <returns><see cref="bilibiliType"/> 对象</returns>
        public static async Task<bilibiliType> GetBilibiliHotboard(string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<bilibiliType>($"{Interface._UAPI_Request_Url}misc/hotboard?type=bilibili", Authentication);
            var list = Interface.IsGetSuccessful(result, "", statusCode, new IException.bilibili.BilibiliServiceError(),
                "bilibili", IException.bilibili._Bilibili_Service_Error);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}