using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 转换时间戳返回的Json属性列表
        /// </summary>
        public class TimestampType : Interface.TypeInterface
        {
            /// <summary>
            /// 输入的值
            /// </summary>
            [JsonProperty("input")]
            public string input { get; set; }

            /// <summary>
            /// 转换的类型
            /// </summary>
            [JsonProperty("type")]
            public string type { get; set; }

            /// <summary>
            /// Unix 时间戳
            /// </summary>
            [JsonProperty("unix_timestamp")]
            public long unix_timestamp { get; set; }

            /// <summary>
            /// UTC+0:00 (世界协调时间) 格式的字符串
            /// </summary>
            [JsonProperty("datetime_utc")]
            public string datetime_utc { get; set; }

            /// <summary>
            /// 以IP地址推断的世界协调时间的本地时间, 在中国一般指北京时间 UTC +8:00.
            /// </summary>
            [JsonProperty("datetime_local")]
            public string datetime_local { get; set; }
        }
    }
}