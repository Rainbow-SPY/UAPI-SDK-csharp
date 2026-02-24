using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
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
            var (result, statusCode) = await Interface.GetResult<DateDiffType>("https://uapis.cn/api/v1/misc/date-diff",
                Interface.SendRequestType.POST,
                $@"{{ ""start_date"": ""{start_date}"",""end_date"": ""{end_date}"",""format"": ""{format}"" }}");
            if (!Interface.IsGetSuccessful(result, "start_date or end_date", statusCode,
                    new General.UAPIUnknowException(), "PostDateDiff", IException.General._UAPI_Unknown_Exception))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}