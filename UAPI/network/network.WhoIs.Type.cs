using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 
        /// </summary>
        public class WhoIsType : TypeInterface
        {
            /// <summary>
            /// 域名信息
            /// </summary>
            public class DomainClass
            {
                /// <summary>
                /// 域名在注册商 / 注册局的唯一标识 ID
                /// </summary>
                [JsonProperty("id")]
                public string ID { get; set; }

                /// <summary>
                /// 完整域名
                /// </summary>
                [JsonProperty("domain")]
                public string FullDomain { get; set; }

                /// <summary>
                /// 国际化域名的 Punycode 编码
                /// <remarks>如果是中文域名，会显示对应的 ASCII 编码</remarks>
                /// </summary>
                [JsonProperty("punycode")]
                public string PunyCode { get; set; }

                /// <summary>
                /// 域名主体
                /// <remarks>指主机名</remarks>
                /// </summary>
                [JsonProperty("name")]
                public string HostName { get; set; }

                /// <summary>
                /// 域名后缀
                /// <remarks>指顶级域名</remarks>
                /// </summary>
                [JsonProperty("extension")]
                public string HostExtension { get; set; }

                /// <summary>
                ///  域名状态
                /// </summary>
                [JsonProperty("status")]
                public List<string> Status { get; set; }

                /// <summary>
                /// 域名服务器（DNS）
                /// </summary>
                [JsonProperty("name_servers")]
                public List<string> DNS_Servers { get; set; }

                /// <summary>
                /// 域名注册时间（北京时间）
                /// </summary>
                [JsonProperty("created_date")]
                public string CreatedDate_UTC8 { get; set; }

                /// <summary>
                /// 域名注册时间（UTC 标准时间）
                /// </summary>
                [JsonProperty("created_date_in_time")]
                public string CreatedDate_UTC0 { get; set; }

                /// <summary>
                /// 域名到期时间（北京时间）
                /// </summary>
                [JsonProperty("expiration_date")]
                public string ExpirationDate_UTC8 { get; set; }

                /// <summary>
                /// 域名到期时间（UTC 标准时间）
                /// </summary>
                [JsonProperty("expiration_date_in_time")]
                public string ExpirationDate_UTC0 { get; set; }
            }

            /// <summary>
            /// 注册商信息
            /// </summary>
            public class RegistrarClass
            {
                /// <summary>
                /// 域名注册商名称
                /// <remarks>负责该域名注册、管理的服务商（即域名购买的平台主体）</remarks>
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }
            }

            /// <summary>
            /// 注册人信息
            /// </summary>
            public class RegistrantClass
            {
                /// <summary>
                ///  注册人 / 注册主体名称
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }

                /// <summary>
                /// 注册人联系邮箱
                /// </summary>
                [JsonProperty("email")]
                public string email { get; set; }
            }

            /// <summary>
            /// 
            /// </summary>
            public class WhoisClass
            {
                /// <summary>
                /// 域名信息
                /// </summary>
                [JsonProperty("domain")]
                public DomainClass Domain { get; set; }

                /// <summary>
                /// 注册商信息
                /// </summary>
                [JsonProperty("registrar")]
                public RegistrarClass Registrar { get; set; }

                /// <summary>
                /// 注册人信息
                /// </summary>
                [JsonProperty("registrant")]
                public RegistrantClass Registrant { get; set; }
            }

            /// <summary>
            /// WhoIs信息
            /// </summary>
            [JsonProperty("whois")]
            public WhoisClass Whois { get; set; }
        }
    }
}