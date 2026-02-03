using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 查询UAPI平台系统状态
        /// </summary>
        /// <returns></returns>
        public static async Task<HealthType> APIHealthStatus()
        {
            var (result, statusCode) = await GetResult<HealthType>("https://uapis.cn/api/status/health");
            if (!IsGetSuccessful(result, statusCode))
                LogLibraries.WriteLog.Error("请求错误,请重试");
            return result;
        }

        internal static bool IsGetSuccessful(HealthType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}");
                    LogLibraries.MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}",
                        _ERROR);
                    throw new IException.General.UAPIServerDown();
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    LogLibraries.MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                default:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http, "未知错误");
                    LogLibraries.MessageBox_I.Error("发生了未知错误", _ERROR);
                    break;
            }

            return false;
        }
    }
}