using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 使用指定的协议扫描指定主机的指定端口
        /// </summary>
        /// <param name="host">扫描的主机</param>
        /// <param name="port">扫描的端口</param>
        /// <param name="protocol">扫描的协议</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="PortScanType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<PortScanType> ScanPort(string host, int port, string protocol = "tcp",
            string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<PortScanType>(
                    $"{Interface._UAPI_Request_Url}network/portscan?host={host}&port={port}&protocol={protocol}",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "host or port", statuscode, new General.UAPIUnknowException(),
                "ScanPort");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}