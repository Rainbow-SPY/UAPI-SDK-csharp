using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;
using static Rox.Text.Json;

namespace UAPI
{
    /// <summary>
    /// UAPI常规方法接口
    /// </summary>
    public partial class Interface
    {
        /// <summary>
        /// 公共API 获取请求
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl) where T : class
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(requestUrl))
                    {
                        var statusCode = (int)response.StatusCode;
                        var responseData = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(responseData))
                        {
                            LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http,
                                _void_value_null("HttpClient", "Content"));
                            return (null, statusCode);
                        }

                        LogLibraries.WriteLog.Info(LogLibraries.LogKind.Json, "压缩 Json");
                        var compressedJson = CompressJson(responseData);
                        var result = JsonConvert.DeserializeObject<T>(compressedJson);
                        return (result, statusCode);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http,
                    $"HttpClient 请求失败, 请检查您的网络连接或反馈工单给工作人员: {e.Message} - {e.StackTrace}");
                return (null, -1);
            }
            catch (Exception e)
            {
                LogLibraries.WriteLog.Error(_Exception_With_xKind("GetResult<T>()", e));
                return (null, -1);
            }
        }

        /// <summary>
        /// 检查是否请求成功, 并根据返回值执行制定操作
        /// </summary>
        /// <param name="Type">指定为继承 <see cref="Interface.Hotboard.HotboardInterface"/> 的公共类</param>
        /// <param name="NullValue">当返回值为 400 时的提示参数</param>
        /// <param name="StatusCode"><see cref="HttpStatusCode"/> 返回值</param>
        /// <param name="_Exception">指定为继承 <see cref="System.Exception"/> 的自定义异常</param>
        /// <param name="_Error_Type">出现异常的类别</param>
        /// <param name="Error_Code">(可选) 错误代码</param>
        /// <typeparam name="T">指定为继承 <see cref="Interface.Hotboard.HotboardInterface"/> 的公共类</typeparam>
        /// <returns><see langword="bool"/> 类型的返回状态<br/>当请求成功时(200) 会返回 <see langword="true"/> , 反之则返回 <see langword="false"/> 或 <see langword="throw"/> 异常</returns>
        /// <exception cref="General.UAPIServerDown">UAPI 请求源服务器异常</exception>
        /// <exception cref="UAPI.IException.github.GithubAPIServiceError"></exception>
        internal static bool IsGetSuccessful<T>(T Type, string NullValue, int StatusCode, Exception _Exception,
            string _Error_Type,
            string Error_Code = "")
            where T : TypeInterface
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty(NullValue)}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty(NullValue)}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw new General.UAPIServerDown();

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw _Exception;
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
    }
}