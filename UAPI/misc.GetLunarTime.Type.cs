using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 查询农历时间返回的Json属性列表
        /// </summary>
        public class LunarTimeType : Interface.TypeInterface
        {
            /// <summary>
            /// 原始 ts 入参
            /// </summary>
            [JsonProperty("query_timestamp")]
            public string query_timestamp { get; set; }

            /// <summary>
            /// 原始 timezone 入参
            /// </summary>
            [JsonProperty("query_timezone")]
            public string query_timezone { get; set; }

            /// <summary>
            /// 解析后的时区
            /// </summary>
            [JsonProperty("timezone")]
            public string timezone { get; set; }

            /// <summary>
            /// 本地化时间，格式 YYYY-MM-DD HH:mm:ss
            /// </summary>
            [JsonProperty("datetime")]
            public string datetime { get; set; }

            /// <summary>
            /// RFC3339 时间格式
            /// </summary>
            [JsonProperty("datetime_rfc3339")]
            public string datetime_rfc3339 { get; set; }

            /// <summary>
            /// 秒级 Unix 时间戳
            /// </summary>
            [JsonProperty("timestamp_unix")]
            public decimal timestamp_unix { get; set; }

            /// <summary>
            /// 星期英文
            /// </summary>
            [JsonProperty("weekday")]
            public string weekday { get; set; }

            /// <summary>
            /// 星期中文
            /// </summary>
            [JsonProperty("weekday_cn")]
            public string weekday_cn { get; set; }

            /// <summary>
            /// 农历年份（数字）
            /// </summary>
            [JsonProperty("lunar_year")]
            public int lunar_year { get; set; }

            /// <summary>
            /// 农历月份（数字）
            /// </summary>
            [JsonProperty("lunar_month")]
            public int lunar_month { get; set; }

            /// <summary>
            /// 农历日期（数字）
            /// </summary>
            [JsonProperty("lunar_day")]
            public int lunar_day { get; set; }

            /// <summary>
            /// 是否闰月
            /// </summary>
            [JsonProperty("is_leap_month")]
            public bool is_leap_month { get; set; }

            /// <summary>
            /// 农历年份中文表示
            /// </summary>
            [JsonProperty("lunar_year_cn")]
            public string lunar_year_cn { get; set; }

            /// <summary>
            /// 农历月份中文表示
            /// </summary>
            [JsonProperty("lunar_month_cn")]
            public string lunar_month_cn { get; set; }

            /// <summary>
            /// 农历日期中文表示
            /// </summary>
            [JsonProperty("lunar_day_cn")]
            public string lunar_day_cn { get; set; }

            /// <summary>
            /// 干支年
            /// </summary>
            [JsonProperty("ganzhi_year")]
            public string ganzhi_year { get; set; }

            /// <summary>
            /// 干支月
            /// </summary>
            [JsonProperty("ganzhi_month")]
            public string ganzhi_month { get; set; }

            /// <summary>
            /// 干支日
            /// </summary>
            [JsonProperty("ganzhi_day")]
            public string ganzhi_day { get; set; }

            /// <summary>
            /// 生肖
            /// </summary>
            [JsonProperty("zodiac")]
            public string zodiac { get; set; }

            /// <summary>
            /// 节气，无则为空字符串
            /// </summary>
            [JsonProperty("solar_term")]
            public string solar_term { get; set; }

            /// <summary>
            /// 农历节日数组
            /// </summary>
            [JsonProperty("lunar_festivals")]
            public List<string> lunar_festivals { get; set; }

            /// <summary>
            ///  公历节日数组
            /// </summary>
            [JsonProperty("solar_festivals")]
            public List<string> solar_festivals { get; set; }
        }
    }
}