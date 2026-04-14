using Newtonsoft.Json;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class AIText : TypeInterface
    {
        /// <summary>
        /// 返回的消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 返回的详细数据
        /// </summary>
        [JsonProperty("data")]
        public DataItem Data { get; set; }

        /// <summary>
        /// 处理时长
        /// </summary>
        [JsonProperty("performance")]
        public PerformanceItem Performance { get; set; }

        /// <summary>
        /// 是否为批量处理
        /// </summary>
        [JsonProperty("is_batch")]
        public bool IsBatchProcessing { get; set; }

        /// <summary>
        /// 返回的详细数据
        /// </summary>
        public class DataItem
        {
            /// <summary>
            /// 翻译之后的文本
            /// </summary>
            [JsonProperty("translated_text")]
            public string TranslatedText { get; set; }
        }

        /// <summary>
        /// 处理时长
        /// </summary>
        public class PerformanceItem
        {
            /// <summary>
            /// 耗时时长
            /// </summary>
            [JsonProperty("processing_time_ms")]
            public int ProcessingTime { get; set; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Style
    {
        /// <summary>
        /// 口语化
        /// </summary>
        casual,

        /// <summary>
        /// 专业商务
        /// </summary>
        professional,

        /// <summary>
        /// 学术正式
        /// </summary>
        academic,

        /// <summary>
        /// 文学艺术
        /// </summary>
        literary,

        /// <summary>
        /// null
        /// </summary>
        None
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Context
    {
        /// <summary>
        /// 通用, 默认
        /// </summary>
        general,

        /// <summary>
        /// 商务
        /// </summary>
        business,

        /// <summary>
        /// 技术
        /// </summary>
        technical,

        /// <summary>
        /// 医疗
        /// </summary>
        medical,

        /// <summary>
        /// 法律
        /// </summary>
        legal,

        /// <summary>
        /// 市场营销
        /// </summary>
        marketing,

        /// <summary>
        /// 娱乐
        /// </summary>
        entertainment,

        /// <summary>
        /// 教育
        /// </summary>
        education,

        /// <summary>
        /// 新闻
        /// </summary>
        news
    }
}