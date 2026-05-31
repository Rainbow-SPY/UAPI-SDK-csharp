using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// Ping 我的 IP, 返回检测到的IP地址
        /// <remarks>注意! IPv6 Ping失败为已知问题, 请耐心等待修复</remarks>
        /// </summary>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <returns><see cref="PingMyIPType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<PingMyIPType> PingMyIP(string AuthenticationAPITokenKey)
        {
            var (result, statuscode) =
                await Interface.GetResult<PingMyIPType>($"{Interface._UAPI_Request_Url}network/pingmyip",
                    AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, null, statuscode, new General.UAPIUnknowException(),
                "PingMyIP");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class PingMyIPType : TypeInterface
        {
            /// <summary>
            /// Ping到的IP地址
            /// </summary>
            [JsonProperty("client_ip")]
            public string IP { get; set; }

            /// <summary>
            /// 是否Ping成功
            /// </summary>
            [JsonProperty("ping_successful")]
            public bool IsPingSuccessful { get; set; }

            /// <summary>
            /// 返回的消息
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}