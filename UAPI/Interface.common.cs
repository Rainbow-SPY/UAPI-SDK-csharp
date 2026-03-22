using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        /// UAPI API 基础请求地址
        /// </summary>
        public const string _UAPI_Request_Url = @"https://uapis.cn/api/v1/";
        /// <summary>
        /// 公共API 获取请求
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <param name="postContent">POST 请求内容</param>
        /// <param name="contentType">POST请求内容类型</param>
        /// <param name="type">请求的方式</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <exception cref="JsonSerializationException"><see cref="Newtonsoft.Json"/> 反序列化失败</exception>
        /// <exception cref="HttpRequestException"><see cref="HttpClient"/> 请求失败</exception>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl,
            SendRequestType type = SendRequestType.GET, string postContent = "",
            string contentType = "application/json", string AuthenticationAPITokenKey = "") where T : class
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AuthenticationAPITokenKey);
                    HttpResponseMessage response;
                    if (type == SendRequestType.GET)
                        response = await httpClient.GetAsync(requestUrl);
                    else
                        response = await httpClient.PostAsync(requestUrl,
                            new StringContent(postContent, Encoding.UTF8, contentType));

                    using (response)
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
                        T result = null;
                        try
                        {
                            result = JsonConvert.DeserializeObject<T>(compressedJson,
                                new JsonSerializerSettings
                                {
                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                });
                        }
                        catch (JsonSerializationException ex)
                        {
                            LogLibraries.WriteLog.Error(LogLibraries.LogKind.Json,
                                $"JSON反序列化失败！类型：{typeof(T).FullName}，错误：{ex.Message}，堆栈：{ex.StackTrace}");
                        }

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
        /// 公共API 获取请求
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <exception cref="JsonSerializationException"><see cref="Newtonsoft.Json"/> 反序列化失败</exception>
        /// <exception cref="HttpRequestException"><see cref="HttpClient"/> 请求失败</exception>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl,
            string AuthenticationAPITokenKey = "") where T : class => await
            GetResult<T>(requestUrl, SendRequestType.GET, "", "application/json", AuthenticationAPITokenKey);

        /// <summary>
        /// 公共API 获取请求, 默认为 GET 请求
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <exception cref="JsonSerializationException"><see cref="Newtonsoft.Json"/> 反序列化失败</exception>
        /// <exception cref="HttpRequestException"><see cref="HttpClient"/> 请求失败</exception>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl) where T : class => await
            GetResult<T>(requestUrl, SendRequestType.GET, "", "application/json", "");

      //  internal static async Task<(List<>)>

        internal enum SendRequestType
        {
            GET,
            POST
        }

        internal class Header
        {
            //访客：
            //UAPI-Billing-Source: visitor
            //X-UAPI-Debit-Status: applied | exempt | quota_exhausted | skipped_non_2xx | free_endpoint
            //X-UAPI-Credits-Requested: <本次应扣积分>
            //X-UAPI-Credits-Charged: <本次实际扣掉的积分>
            //X-UAPI-Credits-Exempt: 0 | 1
            //X-UAPI-Quota-Remaining: <访客月剩余额度>
            //X-UAPI-Balance-Remaining: 0
            //X-UAPI-Quota-Active-Buckets: 1
            //X-UAPI-Stop-On-Empty: 1
            //X-RateLimit-Limit: 1500
            //X-RateLimit-Remaining: <访客月剩余额度>
            //X-RateLimit-Reset: <RFC3339 时间>
            //X-RateLimit-Type: visitor
            //
            //有资源包：
            //X-UAPI-Billing-Source: api | web
            //X-UAPI-Debit-Status: applied | exempt | failed | skipped_non_2xx | free_endpoint
            //X-UAPI-Credits-Requested: <本次应扣积分>
            //X-UAPI-Credits-Charged: <本次实际扣掉的积分>
            //X-UAPI-Credits-Exempt: 0 | 1
            //X-UAPI-Quota-Remaining: <所有有效资源包剩余额度总和>
            //X-UAPI-Balance-Remaining: <账户余额>
            //X-UAPI-Quota-Active-Buckets: <当前有效资源包数量>
            //X-UAPI-Stop-On-Empty: 0 | 1
            /// <summary>
            /// 访客/用户(有资源包)
            /// </summary>
            internal string RateLimitType;

            /// <summary>
            /// 访客月剩余额度
            /// </summary>
            internal string Remaining;

            /// <summary>
            /// 访客月免费额度重置的RFC3339时间
            /// </summary>
            internal string RemainingResetTime;

            /// <summary>
            /// 访客每月额度
            /// </summary>
            internal string RateLimit;

            /// <summary>
            /// 本次应扣积分
            /// </summary>
            internal string RequestedCredits;

            /// <summary>
            /// 实际扣除积分
            /// </summary>
            internal string ChargedCredits;

            /// <summary>
            /// 所有有效资源包剩余额度综合
            /// </summary>
            internal string QuotaRemaining;

            /// <summary>
            /// 账户余额
            /// </summary>
            internal string BalanceRemaining;

            internal string QuotaResourcePack;
        }

        /// <summary>
        /// 检查是否请求成功, 并根据返回值执行制定操作
        /// </summary>
        /// <param name="Type">指定为继承 <see cref="Interface.TypeInterface"/> 的公共类</param>
        /// <param name="NullValue">当返回值为 400 时的提示参数</param>
        /// <param name="StatusCode"><see cref="HttpStatusCode"/> 返回值</param>
        /// <param name="_Exception">指定为继承 <see cref="System.Exception"/> 的自定义异常</param>
        /// <param name="_Error_Type">出现异常的类别</param>
        /// <param name="Error_Code">(可选) 错误代码</param>
        /// <typeparam name="T">指定为继承 <see cref="Interface.TypeInterface"/> 的公共类</typeparam>
        /// <returns><see langword="bool"/> 类型的返回状态<br/>当请求成功时(200) 会返回 <see langword="true"/> , 反之则返回 <see langword="false"/> 或 <see langword="throw"/> 异常</returns>
        /// <exception cref="General.UAPIServerDown">UAPI 请求源服务器异常</exception>
        /// <exception cref="UnauthorizedAccessException">未经授权的操作引发的异常</exception>
        /// <exception cref="_Exception">指定为继承 <see cref="System.Exception"/> 的自定义异常</exception>
        internal static bool IsGetSuccessful<T>(T Type, string NullValue, int StatusCode, Exception _Exception,
            string _Error_Type,
            string Error_Code = "")
            where T : TypeInterface
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty(NullValue)}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty(NullValue)}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    break;
                case 401:
                    LogLibraries.WriteLog.Error("UnAuthorized", "未经授权的操作");
                    throw new UnauthorizedAccessException("未经授权的操作");
                case 429:
                    LogLibraries.WriteLog.Error("Too Many Requests",
                        $"因请求量太大, 限制了您的请求, 错误代码: 429 Too Many Requests, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"因请求量太大, 限制了您的请求, 错误代码: 429 Too Many Requests, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    break;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    LogLibraries.MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    LogLibraries.WriteLog.Warning("未找到用户");
                    LogLibraries.MessageBox_I.Warning("未找到用户", _ERROR);
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw new General.UAPIServerDown(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw _Exception;
                case 503:
                    LogLibraries.WriteLog.Error(
                        $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Service_Unavailable},错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Service_Unavailable},错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw new General.UAPIServiceUnavailable();
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