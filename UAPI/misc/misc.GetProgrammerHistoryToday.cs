using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

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
            var list = Interface.IsGetSuccessful(result, "none", statusCode, new General.UAPIUnknowException(),
                "GetProgrammerHistoryToday");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}