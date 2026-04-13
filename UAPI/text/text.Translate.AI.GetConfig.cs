using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 
        /// </summary>
        public class ConfigType : Interface.TypeInterface
        {
            /// <summary>
            /// 支持的场景
            /// </summary>
            public class ContextsItem
            {
                /// <summary>
                /// 代码
                /// </summary>
                [JsonProperty("code")]
                public string Code { get; set; }

                /// <summary>
                /// 描述
                /// </summary>
                [JsonProperty("description")]
                public string Description { get; set; }

                /// <summary>
                /// 名称
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }
            }

            /// <summary>
            /// 支持的语言
            /// </summary>
            public class LanguagesItem
            {
                /// <summary>
                /// 支持的语言代码
                /// </summary>
                [JsonProperty("code")]
                public string Code { get; set; }

                /// <summary>
                /// 名称
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }

                /// <summary>
                /// 本地化的语言示例
                /// </summary>
                [JsonProperty("native")]
                public string i18nExample { get; set; }
            }

            /// <summary>
            /// 支持的数据
            /// </summary>
            public class Data
            {
                /// <summary>
                /// 支持的场景
                /// </summary>
                [JsonProperty("contexts")]
                public List<ContextsItem> Contexts { get; set; }

                /// <summary>
                /// 支持的语言
                /// </summary>
                [JsonProperty("languages")]
                public List<LanguagesItem> Languages { get; set; }

                /// <summary>
                /// 支持的样式
                /// </summary>
                [JsonProperty("styles")]
                public List<ContextsItem> Styles { get; set; }
            }

            /// <summary>
            /// 性能要求
            /// </summary>
            public class PerformanceItem
            {
                /// <summary>
                /// 批量翻译是否可用
                /// </summary>
                [JsonProperty("batch_translation_available")]
                public bool IsBatchTranslationAvailable { get; set; }

                /// <summary>
                /// 最大批量处理数量
                /// </summary>
                [JsonProperty("max_batch_size")]
                public int MaxBatchSize { get; set; }

                /// <summary>
                /// 最大处理文本量
                /// </summary>
                [JsonProperty("max_text_length")]
                public int MaxTextLength { get; set; }
            }

            /// <summary>
            /// 支持的数据
            /// </summary>
            [JsonProperty("data")]
            public Data data { get; set; }

            /// <summary>
            /// 返回的消息
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// 性能要求
            /// </summary>
            [JsonProperty("performance")]
            public PerformanceItem Performance { get; set; }
        }
    }
}