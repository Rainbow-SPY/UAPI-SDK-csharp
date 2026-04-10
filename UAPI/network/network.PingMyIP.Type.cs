using Newtonsoft.Json;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 
        /// </summary>
        public class PingMyIPType : Interface.TypeInterface
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