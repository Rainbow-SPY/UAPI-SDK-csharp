using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 程序员历史上的今天返回的Json属性列表
        /// </summary>
        public class HistoryTodayType : Interface.TypeInterface
        {
            /// <summary>
            /// 事件类型
            /// </summary>
            public class EventsItem
            {
                /// <summary>
                /// 年
                /// </summary>
                [JsonProperty("year")]
                public int year { get; set; }

                /// <summary>
                /// 月
                /// </summary>
                [JsonProperty("month")]
                public int month { get; set; }

                /// <summary>
                /// 日
                /// </summary>
                [JsonProperty("day")]
                public int day { get; set; }

                /// <summary>
                /// 标题
                /// </summary>
                [JsonProperty("title")]
                public string title { get; set; }

                /// <summary>
                /// 描述
                /// </summary>
                [JsonProperty("description")]
                public string description { get; set; }

                /// <summary>
                /// 类型
                /// </summary>
                [JsonProperty("category")]
                public string category { get; set; }

                /// <summary>
                /// 标签
                /// </summary>
                [JsonProperty("tags")]
                public List<string> tags { get; set; }

                /// <summary>
                /// 重要等级
                /// </summary>
                [JsonProperty("importance")]
                public int importance { get; set; }

                /// <summary>
                /// 数据源
                /// </summary>
                [JsonProperty("source")]
                public string source { get; set; }
            }

            /// <summary>
            /// 今日日期
            /// </summary>
            [JsonProperty("date")]
            public string date { get; set; }

            /// <summary>
            /// 事件
            /// </summary>
            [JsonProperty("events")]
            public List<EventsItem> events { get; set; }
        }
    }
}