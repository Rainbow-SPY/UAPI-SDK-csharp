using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class NSFWType : TypeInterface
        {
            /// <summary>
            /// 违规内容置信度，0-1 之间，越高表示越可能违规
            /// </summary>
            [JsonProperty("nsfw_score")]
            public double NSFWScore { get; set; }

            /// <summary>
            /// 正常内容置信度，0-1 之间，与 nsfw_score 互补
            /// </summary>
            [JsonProperty("normal_score")]
            public double NormalScore { get; set; }

            /// <summary>
            /// 是否判定为违规内容
            /// </summary>
            [JsonProperty("is_nsfw")]
            public bool IsNSFWContent { get; set; }

            /// <summary>
            /// 内容标签
            /// </summary>
            [JsonProperty("label")]
            public string Label { get; set; }

            /// <summary>
            /// 处理建议
            /// </summary>
            [JsonProperty("suggestion")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Actions Suggestion { get; set; }

            /// <summary>
            /// 处理建议
            /// </summary>
            public enum Actions
            {
                /// <summary>
                /// 可直接放行
                /// </summary>
                Pass,

                /// <summary>
                /// 存在风险, 需要人工复查
                /// </summary>
                Review,

                /// <summary>
                /// 高风险内容, 建议直接拦截
                /// </summary>
                Block
            }

            /// <summary>
            /// 风险等级
            /// </summary>
            public enum Level
            {
                /// <summary>
                /// 低风险
                /// </summary>
                Low,

                /// <summary>
                /// 中风险
                /// </summary>
                Medium,

                /// <summary>
                /// 高风险
                /// </summary>
                High
            }

            /// <summary>
            /// 风险等级
            /// </summary>
            [JsonProperty("risk_level")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Level RiskLevel { get; set; }

            /// <summary>
            /// 模型对当前判断的整体置信度
            /// </summary>
            [JsonProperty("confidence")]
            public double confidence { get; set; }

            /// <summary>
            /// 模型推理耗时，单位毫秒
            /// </summary>
            [JsonProperty("inference_time_ms")]
            public double SeekTime { get; set; }
        }
    }
}