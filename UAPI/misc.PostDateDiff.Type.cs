using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 计算两个日期之间的差值返回的Json属性列表
        /// </summary>
        public class DateDiffType : Interface.TypeInterface
        {
            /// <summary>
            /// 总天数
            /// </summary>
            [JsonProperty("days")]
            public long days { get; set; }

            /// <summary>
            /// 总小时数
            /// </summary>
            [JsonProperty("hours")]
            public long hours { get; set; }

            /// <summary>
            /// 总分钟数
            /// </summary>
            [JsonProperty("minutes")]
            public long minutes { get; set; }

            /// <summary>
            /// 总秒数
            /// </summary>
            [JsonProperty("seconds")]
            public long seconds { get; set; }

            /// <summary>
            /// 总周数
            /// </summary>
            [JsonProperty("weeks")]
            public long weeks { get; set; }

            /// <summary>
            /// 人性化显示格式
            /// </summary>
            [JsonProperty("human_readable")]
            public string human_readable { get; set; }
        }
    }
}