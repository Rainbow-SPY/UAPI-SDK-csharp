using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;
using static UAPI.Interface;

namespace UAPI
{
    public partial class API
    {
        /// <summary>
        /// 查询UAPI的 API HPS
        /// </summary>
        /// <returns></returns>
        public static async Task<HealthType> HealthPlatformStatus()
        {
            var (result, statusCode) = await GetResult<HealthType>($"https://uapis.cn/api/status/health");
            var list = IsGetSuccessful(result, "", statusCode, new General.UAPIServerDown(),
                "Health");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误,请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}