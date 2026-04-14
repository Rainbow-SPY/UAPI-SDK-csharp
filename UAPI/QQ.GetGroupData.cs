using System.Threading.Tasks;
using Rox.Runtimes;
using static UAPI.Type;

namespace UAPI
{
    public partial class QQ
    {
        /// <summary>
        /// 获取QQ群公开摘要
        /// </summary>
        /// <param name="group_id">QQ群组ID</param>
        /// <param name="AuthenticationAPITokenKey">API Token</param>
        /// <exception cref="UAPI.IException.QQ.QQServiceError()">QQ 上游服务发生异常, 这可能是他们的服务暂时中断</exception>
        /// <returns><see cref="GroupType"/> 对象</returns>
        public static async Task<GroupType> GetGroupData(string group_id, string AuthenticationAPITokenKey = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<GroupType>(
                    $"{Interface._UAPI_Request_Url}social/qq/groupinfo?group_id={group_id}",
                    AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "group_id", statusCode,
                new IException.QQ.QQServiceError(), "QQ",
                IException.QQ._QQ_Service_Error);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                    $"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}