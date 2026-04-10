using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Text
    {
        public partial class SensitiveWords
        {
            /// <summary>
            /// </summary>
            public class AnalyzeType : Interface.TypeInterface
            {
                /// <summary>
                /// 返回的数组
                /// </summary>
                public class ResultsItem
                {
                    /// <summary>
                    /// 原始传入文本
                    /// </summary>
                    [JsonProperty("k")]
                    public string OriginalText { get; set; }

                    /// <summary>
                    /// 此文本是否安全
                    /// </summary>
                    [JsonIgnore]
                    public bool IsSafe => Level == "safe";

                    /// <summary>
                    /// 文本的敏感判断
                    /// </summary>
                    [JsonProperty("label")]
                    public string Status { get; set; }

                    /// <summary>
                    /// 风险分类
                    /// </summary>
                    [JsonProperty("category")]
                    public string Level { get; set; }

                    /// <summary>
                    /// 置信度
                    /// </summary>
                    [JsonProperty("confidence")]
                    public double Confidence { get; set; }
                }

                /// <summary>
                /// 返回的数组
                /// </summary>
                [JsonProperty("results")]
                public List<ResultsItem> Results { get; set; }

                /// <summary>
                /// 成功分析的敏感词总数
                /// </summary>
                [JsonProperty("total")]
                public int Total { get; set; }
            }
        }
    }
}