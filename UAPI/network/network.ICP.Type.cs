using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 
        /// </summary>
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