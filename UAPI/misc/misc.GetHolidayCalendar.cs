using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 查询指定日期、月份或年份的万年历与节假日信息
        /// </summary>
        /// <param name="date">按天查询时填写这个参数，例如查某一天</param>
        /// <param name="month">按月查询时填写这个参数，例如查某个月</param>
        /// <param name="year">按年查询时填写这个参数，例如查某一年</param>
        /// <param name="timezone">时区名称，默认 Asia/Shanghai</param>
        /// <param name="HolidayType">节日筛选类型，默认 all</param>
        /// <param name="include_nearby">是否返回前后最近节日，仅 date 模式生效，默认 false。month/year 模式会忽略此参数</param>
        /// <param name="nearby_limit">返回最近节日数量限制，默认 7，最大 30。仅 date 模式 + include_nearby=true 生效</param>
        /// <param name="Authentication">API Token</param>
        /// <returns><see cref="HolidayCalendarType"/> 对象</returns>
        public static async Task<HolidayCalendarType> GetHolidayCalendar(string date = "", string month = "",
            string year = "", string timezone = "Asia/Shanghai", string HolidayType = "all",
            bool include_nearby = false,
            int nearby_limit = 7, string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<HolidayCalendarType>(
                    $"{Interface._UAPI_Request_Url}misc/holiday-calendar&date={date}&month={month}&year={year}&timezone={timezone}&holiday_type={HolidayType}&include_nearby={include_nearby}&nearby_limit={nearby_limit}",
                    Interface.SendRequestType.GET, "", "application/json", Authentication);
            var list = Interface.IsGetSuccessful(result, "", statuscode, new General.UAPIUnknowException(),
                "GetHolidayCalendar()", Core._UAPI_Unknown_Exception);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}