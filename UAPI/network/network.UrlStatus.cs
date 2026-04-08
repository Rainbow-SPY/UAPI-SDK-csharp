using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 检查Url的可访问状态
        /// </summary>
        /// <param name="Url">要体检的Url</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="UrlStatusType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<UrlStatusType> CheckUrlStatus(string Url, string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<UrlStatusType>($"{Interface._UAPI_Request_Url}network/urlstatus?url={Url}");
            var list = Interface.IsGetSuccessful(result, "Url", statuscode, new General.UAPIUnknowException(),
                "CheckUrlStatus");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}