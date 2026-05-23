using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class UrlStatusType : TypeInterface
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