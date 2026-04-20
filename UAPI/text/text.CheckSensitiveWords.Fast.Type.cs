using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class FastType : TypeInterface
        {
            /// <summary>
            /// 返回的敏感词状态
            /// </summary>
            [JsonProperty("status")]
            public string status { get; set; }

            /// <summary>
            /// 原始文本是否通过审查
            /// </summary>
            [JsonIgnore]
            public bool IsSuccessful => status == "ok";

            /// <summary>
            /// 原始文本
            /// </summary>
            [JsonProperty("original_text")]
            public string original_text { get; set; }

            /// <summary>
            /// 脱敏后的文本
            /// </summary>
            [JsonProperty("masked_text")]
            public string masked_text { get; set; }

            /// <summary>
            /// 敏感词的 List
            /// </summary>
            [JsonProperty("forbidden_words")]
            public List<string> forbidden_words { get; set; }
        }
    }
}