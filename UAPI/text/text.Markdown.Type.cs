using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class MarkdownType : TypeInterface
        {
            /// <summary/>
            public class Data
            {
                /// <summary>
                /// HTML 源代码
                /// </summary>
                [JsonProperty("html")]
                public string HTMLCode { get; set; }
            }

            /// <summary>
            /// 返回的数据
            /// </summary>
            [JsonProperty("data")]
            public Data DataResult { get; set; }
        }
    }
}