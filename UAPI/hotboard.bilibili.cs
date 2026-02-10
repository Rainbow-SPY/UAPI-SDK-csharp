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
        public static async Task<bilibiliType> GetBilibiliHotboard()
        {
            var (result, statusCode) = await Interface.GetResult<bilibiliType>($"{_Request_Url}?type=bilibili");
            if (!Interface.IsGetSuccessful(result, "", statusCode, new IException.bilibili.BilibiliServiceError(),
                    "bilibili", IException.bilibili._Bilibili_Service_Error))
                LogLibraries.WriteLog.Error("请求失败, 请重试!");
            return result;
        }
    }
}