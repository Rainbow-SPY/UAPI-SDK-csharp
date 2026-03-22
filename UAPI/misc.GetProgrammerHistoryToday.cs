using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 获取程序员历史上的今天的事件
        /// </summary>
        /// <returns><see cref="HistoryTodayType"/> 对象</returns>
        public static async Task<HistoryTodayType> GetProgrammerHistoryToday(string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<HistoryTodayType>($"{Interface._UAPI_Request_Url}history/programmer/today",
                    Authentication);
            if (!Interface.IsGetSuccessful(result, "none", statusCode, new General.UAPIUnknowException(),
                    "GetProgrammerHistoryToday"))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}