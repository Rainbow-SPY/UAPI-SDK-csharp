using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 检查指定的主机在微信网页中的访问情况
        /// </summary>
        /// <param name="domain">指定的主机</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WeixinDomainType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<WeixinDomainType> CheckDomainInWeixin(string domain, string Authentication)
        {
            var (result, statuscode) =
                await Interface.GetResult<WeixinDomainType>(
                    $"{Interface._UAPI_Request_Url}network/wxdomain?domain={domain}", Authentication);
            var list = Interface.IsGetSuccessful(result, "domain", statuscode, new General.UAPIUnknowException(),
                "CheckDomainInWeixin");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}