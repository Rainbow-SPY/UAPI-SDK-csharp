using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 世界时间的Json返回属性列表
        /// </summary>
        public class WorldTimeType : Interface.TypeInterface
        {
            /// <summary>
            /// 查询的时区
            /// </summary>
            [JsonProperty("query")]
            public string query { get; set; }

            /// <summary>
            /// 时区
            /// </summary>
            [JsonProperty("timezone")]
            public string timezone { get; set; }

            /// <summary>
            /// 查询时区的当前时间
            /// </summary>
            [JsonProperty("datetime")]
            public string datetime { get; set; }

            /// <summary>
            /// 星期
            /// </summary>
            [JsonProperty("weekday")]
            public string weekday { get; set; }

            /// <summary>
            /// 查询时区的当前 Unix 时间
            /// </summary>
            [JsonProperty("timestamp_unix")]
            public long timestamp_unix { get; set; }

            /// <summary>
            /// 时区秒数偏移量, 3600 x $UTC, 以北京时间 UTC+8为例: 3600 x 8 = 28800
            /// </summary>
            [JsonProperty("offset_seconds")]
            public int offset_seconds { get; set; }

            /// <summary>
            /// 查询时区的偏移字符串值, 例: (UTC8)
            /// </summary>
            [JsonProperty("offset_string")]
            public string offset_string { get; set; }
        }
    }
}