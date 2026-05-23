using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 获取从 UAPI 到指定主机的延迟
        /// </summary>
        /// <param name="host">指定要查询的主机</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="PingType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException"></exception>
        public static async Task<PingType> GetPingDelay(string host, string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<PingType>($"{Interface._UAPI_Request_Url}network/ping?host={host}",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "host", statuscode, new General.UAPIUnknowException(),
                "GetPingDelay");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}