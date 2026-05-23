using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 查询IP的相关信息
        /// </summary>
        /// <param name="ip">指定要查询的IP地址</param>
        /// <param name="IsUseCommercial">是否使用商业数据源</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="IPInfoType"/> 对象</returns>
        public static async Task<IPInfoType> GetIPInfo(string ip, bool IsUseCommercial = false,
            string Authentication = "")
        {
            var (result, statuscode) = await Interface.GetResult<IPInfoType>(
                $"{Interface._UAPI_Request_Url}network/ipinfo?ip={ip}{(IsUseCommercial ? "&source=commercial" : "")}",
                Authentication);
            var list = Interface.IsGetSuccessful(result, "ip", statuscode, new General.UAPIUnknowException(),
                "GetIPInfo");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}