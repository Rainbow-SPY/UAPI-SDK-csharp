using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class github
    {
        public const string _UAPI_Request_Url = @"https://uapis.cn/api/v1/github/";

        public static async Task<ReposType> GetReposData(string owner_and_repos)
        {
            var (result, statusCode) =
                await Interface.GetResult<ReposType>($"{_UAPI_Request_Url}repo?repo={owner_and_repos}");
            var a = IsGetSuccessful(result, statusCode);
            if (!a)
                LogLibraries.WriteLog.Error("请求失败,请重试");
            return result;
        }

        internal static bool IsGetSuccessful(ReposType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}");
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}");
                    throw new IException.General.UAPIServerDown();

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"Github 上游 API请求错误, 错误代码: {IException.github._Github_ServiceError}, 错误信息: {Type.code} - {Type.details}");
                    throw new IException.github.GithubAPIServiceError();
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