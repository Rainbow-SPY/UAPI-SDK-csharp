using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class DNSType : TypeInterface
        {
            /// <summary/>
            public class RecordsItem
            {
                /// <summary>
                /// 记录在表的IP
                /// </summary>
                [JsonProperty("target")]
                public string TargetIP { get; set; }
            }

            /// <summary>
            /// 查询的主机
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// 查询的DNS类型
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// 查询到的记录  
            /// </summary>
            [JsonProperty("records")]
            public List<RecordsItem> Records { get; set; }
        }
    }
}