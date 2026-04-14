using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 查询指定日期、月份或年份的万年历与节假日信息返回的Json属性列表
        /// </summary>
        public class HolidayCalendarType : TypeInterface
        {
            /// <summary>
            /// 请求参数回显
            /// </summary>
            public class QueryParam
            {
                /// <summary>
                /// 日视图查询参数, date 模式下为 YYYY-MM-DD，其余模式下为空字符串
                /// </summary>
                [JsonProperty("date")]
                public string Date { get; set; }

                /// <summary>
                /// 节日筛选类型
                /// </summary>
                [JsonProperty("holiday_type")]
                public string HolidayType { get; set; }

                /// <summary>
                /// 是否开启前后最近节日查询
                /// </summary>
                [JsonProperty("include_nearby")]
                public bool SearchNearbyInclude { get; set; }

                /// <summary>
                /// 月视图查询参数, month 模式下为 YYYY-MM，其余模式下为空字符串
                /// </summary>
                [JsonProperty("month")]
                public string Month { get; set; }

                /// <summary>
                /// 前后最近节日返回数量上限
                /// </summary>
                [JsonProperty("nearby_limit")]
                public int NearbyLimit { get; set; }

                /// <summary>
                /// 实际生效的时区
                /// </summary>
                [JsonProperty("timezone")]
                public string Timezone { get; set; }

                /// <summary>
                /// 年视图查询参数, year 模式下为 YYYY，其余模式下为空字符串
                /// </summary>
                [JsonProperty("year")]
                public string Year { get; set; }
            }

            /// <summary>
            /// 统计摘要
            /// </summary>
            public class Summaries
            {
                /// <summary>
                /// 查询范围内总天数
                /// </summary>
                [JsonProperty("total_days")]
                public int TotalDaysCount { get; set; }

                /// <summary>
                /// 查询范围内周末天数
                /// </summary>
                [JsonProperty("weekend_days")]
                public int WeekendDaysCount { get; set; }

                /// <summary>
                /// 查询范围内工作日天数（含法定调休上班）
                /// </summary>
                [JsonProperty("workdays")]
                public int WorkdaysCount { get; set; }

                /// <summary>
                /// 查询范围内休息日天数（含周末和法定休假）
                /// </summary>
                [JsonProperty("rest_days")]
                public int RestDaysCount { get; set; }

                /// <summary>
                /// 按 <see cref="QueryParam.HolidayType"/> 过滤后的节日事件总数
                /// </summary>
                [JsonProperty("holiday_events")]
                public int HolidayEventsCount { get; set; }

                /// <summary>
                /// 法定休假日天数
                /// </summary>
                [JsonProperty("legal_rest_days")]
                public int LegalRestDaysCount { get; set; }

                /// <summary>
                /// 法定调休上班天数
                /// </summary>
                [JsonProperty("legal_workdays")]
                public int LegalWorkdaysCount { get; set; }
            }

            /// <summary>
            /// 日期明细列表
            /// </summary>
            public class DaysItem
            {
                /// <summary>
                /// 公历日期（YYYY-MM-DD）
                /// </summary>
                [JsonProperty("date")]
                public string Date { get; set; }

                /// <summary>
                /// 公历年份
                /// </summary>
                [JsonProperty("year")]
                public int Year { get; set; }

                /// <summary>
                /// 公历月份
                /// </summary>
                [JsonProperty("month")]
                public int Month { get; set; }

                /// <summary>
                /// 公历日期（天）
                /// </summary>
                [JsonProperty("day")]
                public int Day { get; set; }

                /// <summary>
                /// 星期中文
                /// </summary>
                [JsonProperty("weekday_cn")]
                public string Weekday { get; set; }

                /// <summary>
                /// 是否为周末
                /// </summary>
                [JsonProperty("is_weekend")]
                public bool IsWeekend { get; set; }

                /// <summary>
                /// 是否为工作日（含法定调休上班日）
                /// </summary>
                [JsonProperty("is_workday")]
                public bool IsWorkday { get; set; }

                /// <summary>
                /// 是否为休息日
                /// </summary>
                [JsonProperty("is_rest_day")]
                public bool IsRestDay { get; set; }

                /// <summary>
                /// 当天是否存在节日、节气或法定事件
                /// </summary>
                [JsonProperty("is_holiday")]
                public bool IsHoliday { get; set; }

                /// <summary>
                /// 法定节假日名称，无则为空或不返回
                /// </summary>
                [JsonProperty("legal_holiday_name")]
                public string LegalHolidayName { get; set; }

                /// <summary>
                /// 法定假日类型：rest 或 workday_adjust
                /// </summary>
                [JsonProperty("legal_holiday_type")]
                public string LegalHolidayType { get; set; }

                /// <summary>
                /// 公历节日名称。有值时返回
                /// </summary>
                [JsonProperty("solar_festival")]
                public string SolarFestival { get; set; }

                /// <summary>
                /// 农历节日名称。有值时返回
                /// </summary>
                [JsonProperty("lunar_festival")]
                public string LunarFestival { get; set; }

                /// <summary>
                /// 节气名称。有值时返回农历年份（数字）
                /// </summary>
                [JsonProperty("solar_term")]
                public string SolarTerm { get; set; }

                /// <summary>
                /// 农历年份（数字）
                /// </summary>
                [JsonProperty("lunar_year")]
                public int LunarYear { get; set; }

                /// <summary>
                /// 农历月份（数字）
                /// </summary>

                [JsonProperty("lunar_month")]
                public int LunarMonth { get; set; }

                /// <summary>
                /// 农历日期（数字）
                /// </summary>

                [JsonProperty("lunar_day")]
                public int LunarDay { get; set; }

                /// <summary>
                /// 农历月份中文名称
                /// </summary>

                [JsonProperty("lunar_month_name")]
                public string LunarMonthName { get; set; }

                /// <summary>
                /// 农历日期中文名称
                /// </summary>

                [JsonProperty("lunar_day_name")]
                public string LunarDayName { get; set; }

                /// <summary>
                /// 干支年
                /// </summary>

                [JsonProperty("ganzhi_year")]
                public string GanzhiYear { get; set; }

                /// <summary>
                /// 干支月
                /// </summary>
                [JsonProperty("ganzhi_month")]
                public string GanzhiMonth { get; set; }

                /// <summary>
                /// 干支日
                /// </summary>
                [JsonProperty("ganzhi_day")]
                public string GanzhiDay { get; set; }
            }

            /// <summary>
            /// 事件列表
            /// </summary>
            public class EventsItem
            {
                /// <summary>
                /// 事件日期（YYYY-MM-DD）
                /// </summary>
                [JsonProperty("date")]
                public string Date { get; set; }

                /// <summary>
                /// 事件名称
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }

                /// <summary>
                /// 事件类型
                /// </summary>
                [JsonProperty("type")]
                public string Type { get; set; }

                /// <summary>
                /// 仅 <see cref="Type"/> = legal_workday_adjust 场景才会返回
                /// </summary>
                [JsonProperty("is_workday")]
                public bool IsWorkday { get; set; }
            }

            /// <summary>
            /// 当前查询日期之前最近的节日列表（按时间倒序）
            /// </summary>
            public class PreviousItem
            {
                /// <summary>
                /// 聚合日期
                /// </summary>
                [JsonProperty("date")]
                public string Date { get; set; }

                /// <summary>
                /// 该日期上的节日事件列表
                /// </summary>
                [JsonProperty("events")]
                public List<EventsItem> Events { get; set; }
            }

            /// <summary>
            /// 前后最近节日，仅 include_nearby=true 且 date 模式返回
            /// </summary>
            public class NearbyHoliday
            {
                /// <summary>
                /// 当前查询日期之前最近的节日列表（按时间倒序）
                /// </summary>
                [JsonProperty("previous")]
                public List<PreviousItem> Previous { get; set; }

                /// <summary>
                /// 当前查询日期之后最近的节日列表（按时间正序）
                /// </summary>
                [JsonProperty("next")]
                public List<PreviousItem> Next { get; set; }
            }

            /// <summary>
            /// 查询模式
            /// </summary>
            [JsonProperty("mode")]
            public string Mode { get; set; }

            /// <summary>
            /// 请求参数回显
            /// </summary>
            [JsonProperty("query")]
            public QueryParam Query { get; set; }

            /// <summary>
            /// 统计摘要
            /// </summary>
            [JsonProperty("summary")]
            public Summaries Summary { get; set; }

            /// <summary>
            /// 日期明细列表
            /// </summary>
            [JsonProperty("days")]
            public List<DaysItem> Days { get; set; }

            /// <summary>
            /// 节日事件列表
            /// </summary>
            [JsonProperty("holidays")]
            public List<EventsItem> Holidays { get; set; }

            /// <summary>
            /// 前后最近节日，仅 include_nearby=true 且 date 模式返回
            /// </summary>
            [JsonProperty("nearby")]
            public NearbyHoliday Nearby { get; set; }
        }
    }
}