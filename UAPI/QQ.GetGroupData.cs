using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class QQ
    {
        /// <summary>
        /// 获取QQ群公开摘要
        /// </summary>
        /// <param name="group_id">QQ群组ID</param>
        /// <exception cref="UAPI.IException.QQ.QQServiceError()">QQ 上游服务发生异常, 这可能是他们的服务暂时中断</exception>
        /// <returns><see cref="GroupType"/> 对象</returns>
        public static async Task<GroupType> GetGroupData(string group_id)
        {
            var (result, statusCode) =
                await Interface.GetResult<GroupType>($"{_UAPI_Request_Url}groupinfo?group_id={group_id}");
            if (!Interface.IsGetSuccessful(result, "group_id", statusCode,
                    new IException.QQ.QQServiceError(), "QQ",
                    IException.QQ._QQ_Service_Error))
                LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请重试");
            return result;
        }
    }
}