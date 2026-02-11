using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 热榜列表的Json属性的公共属性列表
        /// </summary>
        public class Hotboard
        {
            /// <summary>
            /// 热榜顶级公共属性基类
            /// </summary>
            public class HotboardInterface : TypeInterface
            {
                /// <summary>
                /// 查询到的热榜类型（公共属性）
                /// </summary>
                public string type { get; set; }

                /// <summary>
                /// 热榜更新时间（公共属性）
                /// </summary>
                public string update_time_str => update_time_ISO8601.Contains("T")
                    ? FormatISO8601TimeToLocal(update_time_ISO8601)
                    : update_time_ISO8601;

                /// <summary>
                /// 热榜更新时间（公共属性）
                /// </summary>
                [JsonProperty("update_time")]
                public string update_time_ISO8601 { get; set; }

                /// <summary>
                /// 热榜列表（公共属性，列表项为公共基类）
                /// </summary>
                public List<MainLists> list { get; set; }
            }

            /// <summary>
            /// 热榜列表项公共属性基类
            /// </summary>
            public class MainLists
            {
                /// <summary>
                /// 序列数字（公共属性）
                /// </summary>
                public int index { get; set; }

                /// <summary>
                /// 标题（公共属性）
                /// </summary>
                public string title { get; set; }

                /// <summary>
                /// 链接（公共属性）
                /// </summary>
                public string url { get; set; }

                /// <summary>
                /// 热度值（公共属性）
                /// </summary>
                public string hot_value { get; set; }
            }
        }
    }
}