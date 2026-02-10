using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 查询UAPI平台系统状态
        /// </summary>
        /// <returns></returns>
        public static async Task<HealthType> APIHealthStatus()
        {
            var (result, statusCode) = await GetResult<HealthType>("https://uapis.cn/api/status/health");
            if (!IsGetSuccessful(result, "", statusCode, new General.UAPIServerDown(),
                    "Health"))
                LogLibraries.WriteLog.Error("请求错误,请重试");
            return result;
        }
    }
}