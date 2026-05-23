using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class PingType : TypeInterface
        {
            /// <summary>
            /// 测试的主机
            /// </summary>
            [JsonProperty("host")]
            public string Host { get; set; }

            /// <summary>
            /// 解析的IP地址
            /// </summary>
            [JsonProperty("ip")]
            public string IP { get; set; }

            /// <summary>
            /// 主机所在国家/地区
            /// </summary>
            [JsonProperty("location")]
            public string Location { get; set; }

            /// <summary>
            /// 最大延迟
            /// </summary>
            [JsonProperty("max")]
            public double MaxDelay { get; set; }

            /// <summary>
            /// 平均延迟
            /// </summary>
            [JsonProperty("avg")]
            public double AverageDelay { get; set; }

            /// <summary>
            /// 最小延迟
            /// </summary>
            [JsonProperty("min")]
            public double MinDelay { get; set; }
        }
    }
}