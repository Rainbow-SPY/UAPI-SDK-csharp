using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class QQ
    {
        /// <summary>
        /// 获取QQ群公开摘要
        /// </summary>
        /// <param name="group_id">QQ群组ID</param>
        /// <returns><see cref="GroupType"/> 对象</returns>
        public static async Task<GroupType> GetGroupData(string group_id)
        {
            var (result, statusCode) =
                await Interface.GetResult<GroupType>($"{_UAPI_Request_Url}groupinfo?group_id={group_id}");
            var b = IsGetSuccessful(result, statusCode);
            if (!b)
                LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请重试");
            return result;
        }

        private static bool IsGetSuccessful(GroupType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("group_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.error} - {Type.details}");
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type.error} - {Type.details}");
                    throw new IException.General.UAPIServerDown();

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"QQ API请求错误, 错误代码: {IException.QQ._QQ_Service_Error}, 错误信息: {Type.error} - {Type.details}");
                    throw new IException.QQ.QQServiceError();
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制限制请求, 因 请求量过大.");
                    break;
                case 404:
                    LogLibraries.WriteLog.Warning("未找到用户");
                    break;
                case -1:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    break;
                default:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Http, "未知错误");
                    break;
            }

            return false;
        }
    }
}