using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 
        /// </summary>
        public class PortScanType : TypeInterface
        {
            /// <summary>
            /// 扫描的IP
            /// </summary>
            [JsonProperty("ip")]
            public string IP { get; set; }

            /// <summary>
            /// 扫描的端口
            /// </summary>
            [JsonProperty("port")]
            public int Port { get; set; }

            /// <summary>
            /// 端口状态
            /// </summary>
            [JsonProperty("port_status")]
            public string PortStatus { get; set; }

            /// <summary>
            /// 端口是否打开
            /// </summary>
            [JsonIgnore]
            public bool IsPortOpen => PortStatus == "open";

            /// <summary>
            /// 扫描使用的协议
            /// </summary>
            [JsonProperty("protocol")]
            public string Protocol { get; set; }
        }
    }
}