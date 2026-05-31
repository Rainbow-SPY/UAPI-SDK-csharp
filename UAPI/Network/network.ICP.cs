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
    
    public partial class Type
    {
        /// <summary/>
        public class ICPType : TypeInterface
        {
            /// <summary>
            /// 返回的状态码
            /// </summary>
            [JsonProperty("code")]
            public string Code { get; set; }

            /// <summary>
            /// 查询的IP
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// ICP备案号
            /// </summary>
            [JsonProperty("serviceLicence")]
            public string ServiceLicence { get; set; }

            /// <summary>
            /// 主办单位名称
            /// </summary>
            [JsonProperty("unitName")]
            public string UnitName { get; set; }

            /// <summary>
            /// 主办单位的性质 (企业/个人)
            /// </summary>
            [JsonProperty("natureName")]
            public string NatureName { get; set; }

            /// <summary>
            /// 返回的消息
            /// </summary>
            [JsonProperty("msg")]
            public string msg { get; set; }
        }
    }

}