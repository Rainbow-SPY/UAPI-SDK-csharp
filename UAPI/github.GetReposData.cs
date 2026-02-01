using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    /// <summary>
    /// 查询github相关数据
    /// </summary>
    public partial class github
    {
        internal const string _UAPI_Request_Url = @"https://uapis.cn/api/v1/github/";

        /// <summary>
        /// 获取github仓库数据
        /// </summary>
        /// <param name="owner_and_repo">所有者+仓库(owner/repo)</param>
        /// <returns><see cref="ReposType"/> 对象</returns>
        public static async Task<ReposType> GetReposData(string owner_and_repo)
        {
            var (result, statusCode) =
                await Interface.GetResult<ReposType>($"{_UAPI_Request_Url}repo?repo={owner_and_repo}");
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
                        $"{_value_Not_Is_NullOrEmpty("owner_and_repo")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("owner_and_repo")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    throw new IException.General.UAPIServerDown();

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"Github 上游 API请求错误, {_ERROR_CODE}: {IException.github._Github_ServiceError}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"Github 上游 API请求错误, {_ERROR_CODE}: {IException.github._Github_ServiceError}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    throw new IException.github.GithubAPIServiceError();
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    LogLibraries.MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    LogLibraries.WriteLog.Warning("未找到用户");
                    LogLibraries.MessageBox_I.Warning("未找到用户", _ERROR);
                    break;
                case -1:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    LogLibraries.MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    break;
                default:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http, "未知错误");
                    LogLibraries.MessageBox_I.Error("发生了未知错误",_ERROR);
                    break;
            }

            return false;
        }
    }
}