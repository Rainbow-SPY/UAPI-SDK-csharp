using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 
        /// </summary>
        public class WeixinDomainType : TypeInterface
        {
            /// <summary>
            /// 查询的主机
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// 状态类型
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// 是否可用
            /// </summary>
            [JsonIgnore]
            public bool IsAvailable => Type != null && Type == "ok";

            /// <summary>
            /// 状态标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }
}