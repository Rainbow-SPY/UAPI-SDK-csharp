using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// DNS解析查询
        /// </summary>
        /// <param name="domain">指定要查询的主机</param>
        /// <param name="DNSRecordType">选择查询DNS的类型</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="DNSType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException"></exception>
        public static async Task<DNSType> LookUpDNS(string domain, DNSRecordType DNSRecordType,
            string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<DNSType>(
                    $"{Interface._UAPI_Request_Url}network/dns?domain={domain}&type={DNSRecordType.ToString()}",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "domain", statuscode, new General.UAPIUnknowException(),
                "LookUpDNS");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DNSRecordType
        {
            /// <summary>
            /// IPv4
            /// </summary>
            A,

            /// <summary>
            /// IPv6
            /// </summary>
            AAAA,

            /// <summary>
            /// 别名记录
            /// </summary>
            CNAME,

            /// <summary>
            /// 邮件服务器
            /// </summary>
            MX,

            /// <summary>
            /// 域名服务器
            /// </summary>
            NS,

            /// <summary>
            /// 文本记录
            /// </summary>
            TXT
        }
    }
}