using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 
        /// </summary>
        public class DNSType : Interface.TypeInterface
        {
            /// <summary>
            /// 
            /// </summary>
            public class RecordsItem
            {
                /// <summary>
                /// 记录在表的IP
                /// </summary>
                [JsonProperty("target")]
                public string target { get; set; }
            }

            /// <summary>
            /// 查询的主机
            /// </summary>
            [JsonProperty("domain")]
            public string domain { get; set; }

            /// <summary>
            /// 查询的DNS类型
            /// </summary>
            [JsonProperty("type")]
            public string type { get; set; }

            /// <summary>
            /// 查询到的记录
            /// </summary>
            [JsonProperty("records")]
            public List<RecordsItem> records { get; set; }
        }
    }
}