using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Misc
    {
        /// <summary>
        /// 计算两个时间/日期之间的差值
        /// </summary>
        /// <param name="start_date">开始时间/日期</param>
        /// <param name="end_date">结束时间/日期</param>
        /// <param name="format">时间格式, 默认为 YYYY-MM-DD</param>
        /// <returns><see cref="DateDiffType"/> 对象</returns>
        public static async Task<DateDiffType> PostDateDiff(string start_date, string end_date,
            string format = "YYYY-MM-DD")
        {
            var (result, statusCode) = await Interface.GetResult<DateDiffType>(
                $"{Interface._UAPI_Request_Url}misc/date-diff", Interface.SendRequestType.POST,
                $@"{{ ""start_date"": ""{start_date}"",""end_date"": ""{end_date}"",""format"": ""{format}"" }}");
            var list = Interface.IsGetSuccessful(result, "start_date or end_date", statusCode,
                new General.UAPIUnknowException(), "PostDateDiff", Core._UAPI_Unknown_Exception);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 计算两个日期之间的差值返回的Json属性列表
        /// </summary>
        public class DateDiffType : TypeInterface
        {
            /// <summary>
            /// 总天数
            /// </summary>
            [JsonProperty("days")]
            public long Days { get; set; }

            /// <summary>
            /// 总小时数
            /// </summary>
            [JsonProperty("hours")]
            public long Hours { get; set; }

            /// <summary>
            /// 总分钟数
            /// </summary>
            [JsonProperty("minutes")]
            public long Minutes { get; set; }

            /// <summary>
            /// 总秒数
            /// </summary>
            [JsonProperty("seconds")]
            public long Seconds { get; set; }

            /// <summary>
            /// 总周数
            /// </summary>
            [JsonProperty("weeks")]
            public long Weeks { get; set; }

            /// <summary>
            /// 人性化显示格式
            /// </summary>
            [JsonProperty("human_readable")]
            public string HumanReadable { get; set; }
        }
    }
}