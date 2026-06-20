using System.Collections.Generic;
using UAPI.Extensions;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 热榜列表的Json属性的公共属性列表
        /// </summary>
        public class Hotboard
        {
            /// <summary/>
            public class HotboardInterface : TypeInterface
            {
                /// <summary>
                /// 查询到的热榜类型
                /// </summary>
                [JsonProperty("type")]
                public string Type { get; set; }

                /// <summary>
                /// 热榜更新时间
                /// </summary>
                public string UpdateTime_Str => UpdateTime_ISO8601.Contains("T")
                    ? UpdateTime_ISO8601.FormatISO8601TimeToLocal()
                    : UpdateTime_ISO8601;

                /// <summary>
                /// 热榜更新时间
                /// </summary>
                [JsonProperty("update_time")]
                public string UpdateTime_ISO8601 { get; set; }

                /// <summary>
                /// 热榜列表
                /// </summary>
                [JsonProperty("list")]
                public List<MainLists> List { get; set; }
            }

            /// <summary>
            /// 热榜列表项
            /// </summary>
            public class MainLists
            {
                /// <summary>
                /// 序列数字
                /// </summary>
                [JsonProperty("index")]
                public int Index { get; set; }

                /// <summary>
                /// 标题
                /// </summary>
                [JsonProperty("title")]
                public string Title { get; set; }

                /// <summary>
                /// 链接
                /// </summary>
                [JsonProperty("url")]
                public string Url { get; set; }

                /// <summary>
                /// 热度值
                /// </summary>
                [JsonProperty("hot_value")]
                public string HotValue { get; set; }
            }
        }
    }
}