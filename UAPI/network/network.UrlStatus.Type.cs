using Newtonsoft.Json;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 
        /// </summary>
        public class UrlStatusType : Interface.TypeInterface
        {
            /// <summary>
            /// 查询的 Url
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// 返回的状态码
            /// </summary>
            [JsonProperty("status")]
            public int StatusCode { get; set; }
        }
    }
}