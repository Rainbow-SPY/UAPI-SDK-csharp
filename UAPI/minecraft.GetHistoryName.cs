using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// 查询Minecraft玩家的历史昵称
        /// </summary>
        /// <param name="_param">昵称或UUID</param>
        /// <param name="searchType">指定以何种方式查询</param>
        /// <returns></returns>
        public static async Task<HistoryType> GetHistoryName(string _param, SearchType searchType)
        {
            var (result, statusCode) = await Interface.GetResult<HistoryType>(
                $"https://uapis.cn/api/v1/game/minecraft/historyid?{searchType.ToString().ToLower()}={_param}");
            if (!IsGetSuccessful(result, statusCode)) LogLibraries.WriteLog.Error("请求失败,请重试!");
            return result;
        }

        internal static bool IsGetSuccessful(HistoryType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("name_or_uuid")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("name_or_uuid")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}",
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
                        $"Mojang 上游 API请求错误, {_ERROR_CODE}: {IException.minecraft._Mojang_API_Service_Error}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"Mojang 上游 API请求错误, {_ERROR_CODE}: {IException.minecraft._Mojang_API_Service_Error}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    throw new IException.minecraft.MojangAPIServiceError();
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
                    LogLibraries.MessageBox_I.Error("发生了未知错误", _ERROR);
                    break;
            }

            return false;
        }


        /// <summary>
        /// 查询方式
        /// </summary>
        public enum SearchType
        {
            /// <summary>
            /// 以UUID查找
            /// </summary>
            UUID,

            /// <summary>
            /// 以昵称查找
            /// </summary>
            Name,
        }
    }
}