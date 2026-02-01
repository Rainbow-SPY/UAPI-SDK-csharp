using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UAPI.IException;
using static UAPI.Steam.SteamID;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    /// <summary>
    /// Steam用户信息查询, 但是新版本
    /// </summary>
    public partial class Steam
    {
        /// <summary>
        /// 新版请求Steam Web API Json的方法
        /// </summary>
        /// <param name="SteamID"> 其中一种的 <see cref="SteamIDType"/></param>
        /// <exception cref="UAPI.IException.github.GithubAPIServiceError">Github上游服务异常</exception>
        /// <exception cref="UAPI.IException.General.UAPIServerDown">UAPI服务错误</exception>
        /// <returns><see cref="SteamType"/> 对象</returns>
        public static async Task<SteamType> GetUserData(string SteamID) => await GetUserData(SteamID, null);

        /// <summary>
        /// 新版请求Steam Web API Json的方法
        /// </summary>
        /// <param name="SteamID"> 其中一种的 <see cref="SteamIDType"/></param>
        /// <param name="key">Steam Web API Key</param>
        /// <exception cref="UAPI.IException.github.GithubAPIServiceError">Github上游服务异常</exception>
        /// <exception cref="UAPI.IException.General.UAPIServerDown">UAPI服务错误</exception>
        /// <returns><see cref="SteamType"/> 对象</returns>
        public static async Task<SteamType> GetUserData(string SteamID, string key)
        {
            if (string.IsNullOrEmpty(SteamID))
            {
                WriteLog.Error(LogKind.System,
                    $"{_value_Not_Is_NullOrEmpty(nameof(SteamID))}, 错误代码: {_String_NullOrEmpty}");
                MessageBox_I.Error($"{_value_Not_Is_NullOrEmpty(nameof(SteamID))}, 错误代码: {_String_NullOrEmpty}",
                    "Error");
                return null;
            }

            var _p = "";
            if (SteamID.StartsWith("https://steamcommunity.com/"))
                _p = SteamID.Substring(28);
            else if (SteamID.StartsWith("http://steamcommunity.com/"))
                _p = SteamID.Substring(27);
            else if (SteamID.StartsWith("steamcommunity.com/"))
                _p = SteamID.Substring(20);

            switch (Identifier(SteamID))
            {
                case SteamIDType.SteamID:
                    WriteLog.Info(LogKind.Regex, "输入的SteamID为: SteamID");
                    return await SendQueryMessage("steamid", SteamID, key);
                case SteamIDType.SteamID32:
                case SteamIDType.SteamID3:
                    WriteLog.Info(LogKind.Regex,
                        $"输入的SteamID为: {(Identifier(SteamID) == SteamIDType.SteamID3 ? "SteamID3" : "好友代码")}");
                    return await SendQueryMessage("id3", SteamID, key);
                case SteamIDType.SteamID64:
                    WriteLog.Info(LogKind.Regex, "输入的SteamID为: SteamID64");
                    return await SendQueryMessage("steamid", SteamID, key);
                case SteamIDType.Invalid:
                default:
                    if (!string.IsNullOrEmpty(_p))
                    {
                        WriteLog.Info(LogKind.Regex, $"正在解析个人主页链接: {SteamID}");
                        switch (ExtractSteamID(SteamID))
                        {
                            case null:
                                WriteLog.Error(LogKind.Json, $"无法解析SteamID64, 错误代码: {_Json_Parse_SteamID64}");
                                MessageBox_I.Error($"无法解析SteamID64, 错误代码: {_Json_Parse_SteamID64}", _ERROR);
                                return null;
                            default:
                                if (ExtractSteamID(SteamID) == _Regex_Match_Unknow_Exception)
                                {
                                    WriteLog.Error(LogKind.Regex,
                                        $"{_Exception_With_xKind("Regex")}, 返回的错误代码: {_Regex_Match_Unknow_Exception} ");
                                    return null;
                                }
                                else if (ExtractSteamID(SteamID) == _Regex_Match_Not_Found_Any)
                                {
                                    WriteLog.Error(LogKind.Regex,
                                        $"未匹配到任何 正则表达式 , 返回的错误代码: {_Regex_Match_Not_Found_Any}");
                                    return null;
                                }

                                return await SendQueryMessage("steamid", ExtractSteamID(SteamID),
                                    key); //解析SteamID64
                        }
                    }
                    else
                        return await SendQueryMessage("steamid", SteamID, key);
            }
        }

        internal static bool IsGetSuccessful(SteamType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    WriteLog.Error(LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("owner_and_repo")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}");
                    MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("owner_and_repo")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    break;
                case 401: //未经授权
                    WriteLog.Error(LogKind.Network,
                        $"API返回响应: 认证失败。你提供的 Steam Web API Key 无效或已过期，或者你没有提供 Key。请检查你的 Key. 错误代码: {_Steam_Server_UnAuthenticated}");
                    MessageBox_I.Error(
                        $"API返回响应: 认证失败。你提供的 Steam Web API Key 无效或已过期，或者你没有提供 Key。请检查你的 Key. 错误代码: {_Steam_Server_UnAuthenticated}",
                        _ERROR);
                    throw new IException.Steam.UnAuthenticatedSteamKey();
                case 500:
                    WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}");
                    MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    throw new General.UAPIServerDown();

                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"API返回响应: 上游服务错误, 在向 Steam 的官方 API 请求数据时遇到了问题, 这可能是他们的服务暂时中断，请稍后重试, 错误代码: {_Steam_Service_Error}");
                    MessageBox_I.Error(
                        $"API返回响应: 上游服务错误, 在向 Steam 的官方 API 请求数据时遇到了问题, 这可能是他们的服务暂时中断，请稍后重试, 错误代码: {_Steam_Service_Error}",
                        _ERROR);
                    throw new IException.Steam.SteamServiceError();
                case 200:
                    WriteLog.Info(LogKind.Network, "请求成功");
                    return true;
                case 403:
                    WriteLog.Warning(LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    WriteLog.Error(LogKind.Network,
                        $"API返回响应: Steam账户不存在或完全私密了个人资料, 错误代码: {_Steam_Not_Found_Account}");
                    MessageBox_I.Error($"API返回响应: Steam账户不存在或完全私密了个人资料, 错误代码: {_Steam_Not_Found_Account}", _ERROR);
                    break;
                case -1:
                    WriteLog.Error(LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    break;
                default:
                    WriteLog.Error(LogKind.Http, "未知错误");
                    MessageBox_I.Error("发生了未知错误", _ERROR);
                    break;
            }

            return false;
        }

        private static async Task<SteamType> SendQueryMessage(string Type, string SteamID64, string key)
        {
            var requestUrl =
                $"https://uapis.cn/api/v1/game/steam/summary?{Type}={SteamID64}{(!string.IsNullOrEmpty(key) ? $"&key={key}" : "")}";
            var (result, statusCode) = await Interface.GetResult<SteamType>(requestUrl);
            if (!IsGetSuccessful(result, statusCode))
                WriteLog.Error("请求失败,请重试");
            return result;
        }

        /// <summary>
        /// 使用 <see cref="Match"/> 正则表达式匹配 SteamID
        /// </summary> 
        /// <param name="url"> Steam 个人主页链接</param>
        /// <returns> <see cref="string"/> 格式的文本</returns>
        internal static string ExtractSteamID(string url)
        {
            try
            {
                // 正则表达式匹配自定义 ID
                const string customIdPattern = @"\/id\/([^\/]+)";
                // 正则表达式匹配 17 位数字 ID
                const string numericIdPattern = @"\/profiles\/(\d{17})";

                // 尝试匹配自定义 ID
                WriteLog.Info(LogKind.Regex, "正则表达式匹配自定义ID");
                var customIdMatch = Regex.Match(url, customIdPattern);
                if (customIdMatch.Success)
                {
                    WriteLog.Info(LogKind.Regex, $"返回正则表达式匹配值: {customIdMatch.Groups[1].Value} ");
                    return customIdMatch.Groups[1].Value; // 返回自定义 ID
                }

                // 尝试匹配 17 位数字 ID
                WriteLog.Info(LogKind.Regex, $"正则表达式匹配17位ID");
                var numericIdMatch = Regex.Match(url, numericIdPattern);
                if (numericIdMatch.Success)
                {
                    if (numericIdMatch.Groups[1].Value.Length != 17)
                    {
                        WriteLog.Error(LogKind.System, $"SteamID64不满足17位唯一标识符!, 错误代码: {Not_Allow_17_SteamID64}");
                        MessageBox_I.Error($"SteamID64不满足17位唯一标识符!, 错误代码: {Not_Allow_17_SteamID64}", _ERROR);
                        return Not_Allow_17_SteamID64;
                    }

                    WriteLog.Info(LogKind.Regex, _Return_xKind_value("正则表达式", numericIdMatch.Groups[1].Value));
                    return numericIdMatch.Groups[1].Value; // 返回 17 位数字 ID
                }

                // 如果未匹配到任何 ID，返回 null
                WriteLog.Error(LogKind.Regex, $"未匹配到任何ID , 错误代码: {_Regex_Match_Not_Found_Any}");
                return _Regex_Match_Not_Found_Any;
            }
            catch (Exception e)
            {
                WriteLog.Error(LogKind.Regex,
                    $"{_Exception_With_xKind("正则表达式", e)}, 错误代码: {_Regex_Match_Unknow_Exception}");
                MessageBox_I.Error($"{_Exception_With_xKind("正则表达式", e)}, 错误代码: {_Regex_Match_Unknow_Exception}",
                    _ERROR);
                return _Regex_Match_Unknow_Exception;
            }
        }
    }
}