using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 查询ICP备案信息
        /// </summary>
        /// <param name="domain">要查询的主机</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="ICPType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<ICPType> GetICPInfo(string domain, string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<ICPType>($"{Interface._UAPI_Request_Url}network/icp?domain={domain}",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "domain", statuscode, new General.UAPIUnknowException(),
                "GetICPInfo");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}