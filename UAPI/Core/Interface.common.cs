using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;
using static Rox.Text.Json;
using static UAPI.IException.Core;
using static UAPI.Type;

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
        public const string _UAPI_Request_Url = "https://uapis.cn/api/v1/";

        internal const string _2UAPI_Request_Url = "https://b1.uapis.cn/api/v1/";

        /// 泛型缓存容器
        private static readonly Dictionary<System.Type, PropertyInfo> _headersPropertyCache =
            new Dictionary<System.Type, PropertyInfo>();

        private static readonly object _cacheLock = new object();


        /// <summary>
        /// 公共API 获取请求
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <param name="type">请求的方式</param>
        /// <param name="postContent">POST 请求内容</param>
        /// <param name="contentType">POST请求内容类型</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <exception cref="JsonSerializationException"><see cref="Newtonsoft.Json"/> 反序列化失败</exception>
        /// <exception cref="HttpRequestException"><see cref="HttpClient"/> 请求失败</exception>
        /// <exception cref="ArgumentNullException">传参异常</exception>
        /// <exception cref="AmbiguousMatchException">当绑定到成员导致多个成员匹配绑定条件时引发的异常。</exception>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl,
            SendRequestType type = SendRequestType.GET, object postContent = null,
            string contentType = "application/json", string AuthenticationAPITokenKey = "") where T : class
        {
            var targetUrl = requestUrl;
            var rawBodyType = GetRawBodyType(typeof(T));

            WriteLog.Info(LogKind.Http, "配置 ServicePointManager 连接参数");

            try
            {
                var response = await SendApiRequestWithFallbackAsync(
                    requestUrl,
                    type,
                    postContent,
                    contentType,
                    AuthenticationAPITokenKey);

                WriteLog.Info(LogKind.Http,
                    $"{_SEND_REQUEST}: {(type == SendRequestType.GET ? "GET" : "POST")} {targetUrl}");
                if (response == null)
                    throw new HttpRequestException("请求失败, 因为 response 为 null");

                if (rawBodyType != null &&
                    rawBodyType != typeof(string) &&
                    rawBodyType != typeof(byte[]))
                {
                    throw new NotSupportedException($"BodyResult<TBody> 不支持的 Body 类型: {rawBodyType.FullName}");
                }

                var (httpResponseMessage, responseData) = await ReadBodyOrRetryBackupAsync(
                    response,
                    requestUrl,
                    type,
                    postContent,
                    contentType,
                    AuthenticationAPITokenKey,
                    rawBodyType);

                response = httpResponseMessage;

                using (response)
                {
                    var Headers = BuildResponseHeaders(response);

                    WriteLog.Info("ToDictionary", "响应标头转换为字典");
                    WriteLog.Info(LogKind.Json, "序列化字典");
                    WriteLog.Info(LogKind.Json, "反序列化字典");

                    var statusCode = (int)response.StatusCode;
                    WriteLog.Info(LogKind.Http, $"获取 Http 响应代码: {statusCode}");
                    WriteLog.Info(LogKind.Http, $"异步读取响应内容, Type: {responseData?.GetType().Name}");
                    if (responseData == null)
                    {
                        WriteLog.Error(LogKind.Http,
                            _void_value_null("GetResult<T>.HttpClient", "Content"));
                        return (null, statusCode);
                    }

                    T result;

                    try
                    {
                        if (rawBodyType != null)
                        {
                            result = Activator.CreateInstance<T>();

                            var resultProperty = typeof(T).GetProperty(
                                "Result",
                                BindingFlags.Instance | BindingFlags.Public);

                            resultProperty?.SetValue(result, responseData);

                            WriteLog.Info(LogKind.Http,
                                $"原始响应 Body 已写入 {typeof(T).Name}.Result, BodyType: {rawBodyType.Name}");
                        }
                        else
                        {
                            WriteLog.Info(LogKind.Json, "压缩 Json");

                            result = JsonConvert.DeserializeObject<T>(
                                CompressJson((string)responseData),
                                new JsonSerializerSettings
                                {
                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                });

                            WriteLog.Info(LogKind.Json, "反序列化Json");
                        }

                        SetHeaders(result, Headers);
                    }
                    catch (JsonSerializationException ex)
                    {
                        WriteLog.Error(LogKind.Json,
                            $"JSON反序列化失败！类型：{typeof(T).FullName}，错误：{ex.Message}，堆栈：{ex.StackTrace}");
                        return (null, -3);
                    }

                    return (result, statusCode);
                }
            }
            catch (TaskCanceledException e)
            {
                WriteLog.Error(LogKind.Http,
                    $"HttpClient 请求超时或被取消: {e.Message} - {e.StackTrace}");
                return (null, -2);
            }
            catch (HttpRequestException e)
            {
                WriteLog.Error(LogKind.Http,
                    $"HttpClient 请求失败, 请检查您的网络连接或反馈工单给工作人员: {e.Message} - {e.StackTrace}");
                return (null, -2);
            }
            catch (Exception e)
            {
                WriteLog.Error(LogKind.Exception, _Exception_With_xKind("GetResult<T>()", e));
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
            string AuthenticationAPITokenKey = "") where T : class =>
            await GetResult<T>(requestUrl, SendRequestType.GET, "",
                "application/json", AuthenticationAPITokenKey);

        /// <summary>
        /// 请求方式
        /// </summary>
        public enum SendRequestType
        {
            /// <summary>
            /// GET
            /// </summary>
            GET,

            /// <summary>
            /// POST
            /// </summary>
            POST
        }

        /// <summary>
        /// 检查是否请求成功, 并根据返回值执行制定操作
        /// </summary>
        /// <param name="Type">指定为继承 <see cref="TypeInterface"/> 的公共类</param>
        /// <param name="NullValue">当返回值为 400 时的提示参数</param>
        /// <param name="StatusCode"><see cref="HttpStatusCode"/> 返回值</param>
        /// <param name="_Exception">指定为继承 <see cref="System.Exception"/> 的自定义异常</param>
        /// <param name="_Error_Type">出现异常的类别</param>
        /// <param name="Error_Code">(可选) 错误代码</param>
        /// <typeparam name="T">指定为继承 <see cref="TypeInterface"/> 的公共类</typeparam>
        /// <returns><see langword="bool"/> 类型的返回状态<br/>当请求成功时(200) 会返回 <see langword="true"/> , 反之则返回 <see langword="false"/> 或 <see langword="throw"/> 异常</returns>
        /// <exception cref="General.UAPIServerDown">UAPI 请求源服务器异常</exception>
        /// <exception cref="UnauthorizedAccessException">未经授权的操作引发的异常</exception>
        /// <exception cref="_Exception">指定为继承 <see cref="System.Exception"/> 的自定义异常</exception>
        internal static FailedList IsGetSuccessful<T>(T Type, string NullValue, int StatusCode,
            Exception _Exception,
            string _Error_Type, string Error_Code = "") where T : TypeInterface
        {
            var list = new FailedList
            {
                StatusCode = StatusCode,
                IsRequestSuccessfully = false
            };
            if (Type != null)
                return priCheck(Type, NullValue, StatusCode, _Exception, _Error_Type, Error_Code, list);
            list.FailedReason = "Type = null";
            return list;
        }

        private static FailedList priCheck<T>(T Type, string NullValue, int StatusCode, Exception _Exception,
            string _Error_Type, string Error_Code, FailedList list) where T : TypeInterface
        {
            switch (StatusCode)
            {
                case 200:
                    WriteLog.Info(LogKind.Network, "请求成功");
                    list.IsRequestSuccessfully = true;
                    return list;
                case 302:
                    WriteLog.Info(LogKind.Network, "链接已重定向, 请求成功");
                    list.IsRequestSuccessfully = true;
                    return list;
                case 400:
                    switch (GetErrorOrCode(Type))
                    {
                        case "CONVERSION_FAILED":
                            WriteLog.Error(
                                $"传递的参数 {NullValue ?? "%s"} 在转换时失败! \n\t{_ERROR_CODE}: {CONVERSION_FAILED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                            MessageBox_I.Error(
                                $"传递的参数 {NullValue ?? "%s"} 在转换时失败! \n\t{_ERROR_CODE}: {CONVERSION_FAILED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}",
                                "CONVERSION_FAILED");
                            list.FailedReason = CONVERSION_FAILED;
                            break;
                        case "FILE_REQUIRED":
                            WriteLog.Error(
                                $"{NullValue ?? "%s"} 缺少文件参数, 没有找到上传的文件! \n\t{_ERROR_CODE}: {FILE_REQUIRED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                            MessageBox_I.Error(
                                $"{NullValue ?? "%s"} 缺少文件参数, 没有找到上传的文件! \n\t{_ERROR_CODE}: {FILE_REQUIRED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}",
                                "FILE_REQUIRED");
                            list.FailedReason = FILE_REQUIRED;
                            break;
                        case "INVALID_PARAMETER":
                            WriteLog.Error(
                                $"{NullValue ?? "%s"} 参数校验失败!\n\t{_ERROR_CODE}: {INVALID_PARAMETER}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                            MessageBox_I.Error(
                                $"{NullValue ?? "%s"} 参数校验失败!\n\t{_ERROR_CODE}: {INVALID_PARAMETER}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}",
                                "INVALID_PARAMETER");
                            list.FailedReason = INVALID_PARAMETER;
                            break;
                        case "INVALID_PARAMS":
                            WriteLog.Error(
                                $"{NullValue ?? "%s"} 参数校验失败!\n\t{_ERROR_CODE}: {INVALID_PARAMS}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                            MessageBox_I.Error(
                                $"{NullValue ?? "%s"} 参数校验失败!\n\t{_ERROR_CODE}: {INVALID_PARAMS}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}",
                                "INVALID_PARAMS");
                            list.FailedReason = INVALID_PARAMS;
                            break;
                        case "UNSUPPORTED_FORMAT":
                            WriteLog.Error(
                                $"{NullValue ?? "%s"} 的文件、文本或参数格式不支持!\n\t{_ERROR_CODE}: {UNSUPPORTED_FORMAT}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                            MessageBox_I.Error(
                                $"{NullValue ?? "%s"} 的文件、文本或参数格式不支持!\n\t{_ERROR_CODE}: {UNSUPPORTED_FORMAT}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "UNSUPPORTED_FORMAT");
                            list.FailedReason = UNSUPPORTED_FORMAT;
                            break;
                    }

                    return list;
                case 401:
                    WriteLog.Error("UnAuthorized",
                        $"未经授权的操作!\n\t{_ERROR_CODE}: {UNAUTHORIZED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                    list.FailedException = new UnauthorizedAccessException("未经授权的操作");
                    list.FailedReason = UNAUTHORIZED;
                    return list;
                case 402:
                    WriteLog.Error(
                        $"账户积分不足, 无法完成请求!\n\t{_ERROR_CODE}: {INSUFFICIENT_CREDITS}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                    MessageBox_I.Error(
                        $"账户积分不足, 无法完成请求!\n\t{_ERROR_CODE}: {INSUFFICIENT_CREDITS}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                        "INSUFFICIENT_CREDITS");
                    list.FailedReason = INSUFFICIENT_CREDITS;
                    return list;
                case 403:
                    WriteLog.Warning(LogKind.Network,
                        $"您已被限制请求, 因 请求量过大!\n\t:{_ERROR_CODE}: HttpClient 403, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                    MessageBox_I.Warning(
                        $"您已被限制请求, 因 请求量过大!\n\t:{_ERROR_CODE}: HttpClient 403, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                        _ERROR);
                    list.FailedReason = "Too Much Request";
                    return list;
                case 404:
                    switch (GetErrorOrCode(Type))
                    {
                        case "AVATAR_NOT_FOUND":
                            WriteLog.Error(
                                $"未找到 {NullValue ?? "%s"} 请求的头像资源!\n\t{_ERROR_CODE}: {AVATAR_NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"未找到 {NullValue ?? "%s"} 请求的头像资源!\n\t{_ERROR_CODE}: {AVATAR_NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "AVATAR_NOT_FOUND");
                            list.FailedReason = AVATAR_NOT_FOUND;
                            break;
                        case "NOT_FOUND":
                            WriteLog.Error(
                                $"未找到 {NullValue ?? "%s"} 请求的资源!\n\t{_ERROR_CODE}: {NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"未找到 {NullValue ?? "%s"} 请求的资源!\n\t{_ERROR_CODE}: {NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "NOT_FOUND");
                            list.FailedReason = NOT_FOUND;
                            break;
                        case "NO_MATCH":
                            WriteLog.Warning(
                                $"没有查询到 {NullValue ?? "%s"} 相关的结果!\n\t{_ERROR_CODE}: {NO_MATCH}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Warning(
                                $"没有查询到 {NullValue ?? "%s"} 相关的结果!\n\t{_ERROR_CODE}: {NO_MATCH}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "NO_MATCH");
                            list.FailedReason = NO_MATCH;
                            break;
                        case "NO_TRACKING_DATA":
                            WriteLog.Warning(
                                $"没有查询到 {NullValue ?? "%s"} 的物流轨迹!\n\t{_ERROR_CODE}: {NO_TRACKING_DATA}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Warning(
                                $"没有查询到 {NullValue ?? "%s"} 的物流轨迹!\n\t{_ERROR_CODE}: {NO_TRACKING_DATA}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "NO_TRACKING_DATA");
                            list.FailedReason = NO_TRACKING_DATA;
                            break;
                        case "RECOGNITION_FAILED":
                            WriteLog.Error(
                                $"{NullValue ?? "%s"} 识别失败!\n\t{_ERROR_CODE}: {RECOGNITION_FAILED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"{NullValue ?? "%s"} 识别失败!\n\t{_ERROR_CODE}: {RECOGNITION_FAILED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "RECOGNITION_FAILED");
                            list.FailedReason = RECOGNITION_FAILED;
                            break;
                        case "TIMEZONE_NOT_FOUND":
                            WriteLog.Error(
                                $"时区查询失败! 请确认 {NullValue ?? "%s"} 是标准合法的 IANA 时区数据库名称\n\t{_ERROR_CODE}: {TIMEZONE_NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"时区查询失败! 请确认 {NullValue ?? "%s"} 是标准合法的 IANA 时区数据库名称\n\t{_ERROR_CODE}: {TIMEZONE_NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "TIMEZONE_NOT_FOUND");
                            list.FailedReason = TIMEZONE_NOT_FOUND;
                            break;
                        case "UNSUPPORTED_CARRIER":
                            WriteLog.Error(
                                $"不支持的物流公司! 请确认 {NullValue ?? "%s"} 是存在的物流公司名称\n\t{_ERROR_CODE}: {UNSUPPORTED_CARRIER}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"不支持的物流公司! 请确认 {NullValue ?? "%s"} 是存在的物流公司名称\n\t{_ERROR_CODE}: {UNSUPPORTED_CARRIER}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "UNSUPPORTED_CARRIER");
                            list.FailedReason = UNSUPPORTED_CARRIER;
                            break;
                    }

                    return list;
                case 413:
                    WriteLog.Error(
                        $"请求量过大, 可能是由于 {NullValue ?? "%s"} 的上传体积过大!\n\t{_ERROR_CODE}: {REQUEST_ENTITY_TOO_LARGE}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                    MessageBox_I.Error(
                        $"请求量过大, 可能是由于 {NullValue ?? "%s"} 的上传体积过大!\n\t{_ERROR_CODE}: {REQUEST_ENTITY_TOO_LARGE}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                        "REQUEST_ENTITY_TOO_LARGE");
                    list.FailedReason = REQUEST_ENTITY_TOO_LARGE;
                    return list;
                case 429:
                    switch (GetErrorOrCode(Type))
                    {
                        case "SERVICE_BUSY":
                            WriteLog.Error(
                                $"因请求量太大, 限制了您的请求!\n\t{_ERROR_CODE}: {SERVICE_BUSY}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"因请求量太大, 限制了您的请求!\n\t{_ERROR_CODE}: {SERVICE_BUSY}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "SERVICE_BUSY");
                            list.FailedReason = SERVICE_BUSY;
                            break;
                        case "VISITOR_MONTHLY_QUOTA_EXHAUSTED":
                            WriteLog.Error(
                                $"访客额度已消耗殆尽! 请尝试购买资源包或等待下个免费额度重置时间.\n\t{_ERROR_CODE}: {VISITOR_MONTHLY_QUOTA_EXHAUSTED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"访客额度已消耗殆尽! 请尝试购买资源包或等待下个免费额度重置时间.\n\t{_ERROR_CODE}: {VISITOR_MONTHLY_QUOTA_EXHAUSTED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "VISITOR_MONTHLY_QUOTA_EXHAUSTED");
                            list.FailedReason = VISITOR_MONTHLY_QUOTA_EXHAUSTED;
                            break;
                        default:
                            WriteLog.Error(
                                $"未知错误, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}\n\tHttpClient return 429");
                            MessageBox_I.Error(
                                $"未知错误, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}\n\tHttpClient return 429",
                                _ERROR);
                            list.FailedReason = "HttpClient return 429";
                            list.FailedException = _Exception;
                            break;
                    }

                    return list;
                case 500:
                    switch (GetErrorOrCode(Type))
                    {
                        case "FILE_OPEN_ERROR":
                            WriteLog.Error(
                                $"服务器处理文件 {NullValue ?? "%s"} 时发生未知的异常, 请联系管理员解决问题!\n\t{_ERROR_CODE}: {FILE_OPEN_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"服务器处理文件 {NullValue ?? "%s"} 时发生未知的异常, 请联系管理员解决问题!\n\t{_ERROR_CODE}: {FILE_OPEN_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "FILE_OPEN_ERROR");
                            list.FailedReason = FILE_OPEN_ERROR;
                            list.FailedException = new FileOpenFailed();
                            return list;
                        case "PHONE_INFO_FAILED":
                            WriteLog.Error(
                                $"手机号归属地查询失败或上游服务查询失败, 请确认 {NullValue ?? "%s"} 参数为中国大陆地区合法的11位手机号!\n\t{_ERROR_CODE}: {PHONE_INFO_FAILED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"手机号归属地查询失败或上游服务查询失败, 请确认 {NullValue ?? "%s"} 参数为中国大陆地区合法的11位手机号!\n\t{_ERROR_CODE}: {PHONE_INFO_FAILED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                "PHONE_INFO_FAILED");
                            list.FailedReason = PHONE_INFO_FAILED;
                            return list;
                        default:
                            WriteLog.Error(
                                $"服务器内部错误, 请联系管理员或反馈工单, {_ERROR_CODE}: {INTERNAL_SERVER_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            MessageBox_I.Error(
                                $"服务器内部错误, 请联系管理员或反馈工单, {_ERROR_CODE}: {INTERNAL_SERVER_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                                _ERROR);
                            list.FailedException = new General.UAPIServerDown(
                                $"服务器内部错误, 请联系管理员或反馈工单, {_ERROR_CODE}: {INTERNAL_SERVER_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                            list.FailedReason = INTERNAL_SERVER_ERROR;
                            return list;
                    }

                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"{_Error_Type ?? "%s"} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                    MessageBox_I.Error(
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                        _ERROR);
                    list.FailedException = _Exception;
                    list.FailedReason = "Upstream Error";
                    return list;
                case 503:
                    WriteLog.Error(
                        $"当前指定的服务 {_Error_Type ?? "%s"} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {_UAPI_Service_Unavailable},错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                    MessageBox_I.Error(
                        $"当前指定的服务 {_Error_Type ?? "%s"} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {_UAPI_Service_Unavailable},错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}",
                        _ERROR);
                    list.FailedException = new General.UAPIServiceUnavailable(
                        $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {_UAPI_Service_Unavailable},错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                    list.FailedReason = _UAPI_Service_Unavailable;
                    return list;
                case -1:
                    WriteLog.Error(LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    list.FailedReason = "Request Failed";
                    return list;
                case -2:
                    WriteLog.Error(LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员\n\t错误原因: 基础性请求出错或请求的任务超时被取消");
                    MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员\n\t错误原因: 基础性请求出错或请求的任务超时被取消", _ERROR);
                    list.FailedException = new HttpRequestException("");
                    list.FailedReason = "Http Request Failed";
                    return list;
                case -3:
                    WriteLog.Error(LogKind.Json,
                        $"JSON反序列化失败！请重试或反馈工单给工作人员, {_ERROR_CODE}: {JSON_SERIALIZATION_ERROR}\n\t错误原因: JSON 反序列化失败");
                    MessageBox_I.Error(
                        $"JSON反序列化失败！请重试或反馈工单给工作人员, {_ERROR_CODE}: {JSON_SERIALIZATION_ERROR}\n\t错误原因: JSON 反序列化失败",
                        _ERROR);
                    list.FailedException = new JsonSerializationException();
                    list.FailedReason = JSON_SERIALIZATION_ERROR;
                    return list;
                default:
                    WriteLog.Error(LogKind.Http, "未知错误");
                    MessageBox_I.Error("发生了未知错误", _ERROR);
                    list.FailedException = _Exception;
                    list.FailedReason = _UNKNOW_ERROR;
                    return list;
            }
        }

        internal static FailedList IsGetBytesSuccessful(BodyResult<byte[]> result, string NullValue, int StatusCode,
            Exception _Exception,
            string ErrorType, string Error_Code = "")
        {
            var list = new FailedList
            {
                StatusCode = StatusCode,
                IsRequestSuccessfully = false,
                Result = result.Result
            };
            if (result.Result != null)
                return priCheck(list, NullValue, StatusCode, _Exception, ErrorType, Error_Code, list);
            list.FailedReason = "result = null";
            return list;
        }

        internal static FailedList IsGetStringSuccessful(BodyResult<string> result, string NullValue, int StatusCode,
            Exception _Exception, string ErrorType, string Error_Code = "")
        {
            var list = new FailedList
            {
                StatusCode = StatusCode,
                IsRequestSuccessfully = false,
                Result = result.Result
            };
            if (result.Result != null)
                return priCheck(list, NullValue, StatusCode, _Exception, ErrorType, Error_Code, list);
            list.FailedReason = "result = null";
            return list;
        }


        #region Request Core

        private static string SwitchToBackupUrl(string originalUrl)
        {
            if (originalUrl.StartsWith(_UAPI_Request_Url))
                return _2UAPI_Request_Url + originalUrl.Substring(_UAPI_Request_Url.Length);

            WriteLog.Warning(LogKind.Http, $"requestUrl {originalUrl} 不包含基础前缀，无法切换到备用地址");
            return originalUrl;
        }

        private static async Task<(HttpResponseMessage Response, object Body)> ReadBodyOrRetryBackupAsync(
            HttpResponseMessage response,
            string requestUrl,
            SendRequestType type,
            object postContent,
            string contentType,
            string authenticationApiTokenKey,
            System.Type rawBodyType)
        {
            try
            {
                // 主站 body 最多等 15 秒
                return (response, await ReadResponseBodyAsync(
                    response,
                    rawBodyType,
                    TimeSpan.FromSeconds(15)));
            }
            catch (Exception ex) when (
                ex is HttpRequestException ||
                ex is IOException ||
                ex is TaskCanceledException ||
                ex is TimeoutException ||
                ex.InnerException is IOException)
            {
                var innerMessage = ex.InnerException == null
                    ? ""
                    : $" InnerException: {ex.InnerException.Message}";

                WriteLog.Warning(
                    LogKind.Http,
                    $"响应头已返回 {(int)response.StatusCode}，但读取响应 Body 失败，准备切换备用站: {ex.Message}{innerMessage}");

                var backupUrl = SwitchToBackupUrl(requestUrl);
                response.Dispose();

                if (backupUrl == requestUrl)
                    throw;

                var backupResponse = await SendApiRequestOnceAsync(
                    _httpClient.Value,
                    backupUrl,
                    type,
                    postContent,
                    contentType,
                    authenticationApiTokenKey,
                    TimeSpan.FromSeconds(30));

                try
                {
                    // 备用站 body 最多等 30 秒
                    return (backupResponse, await ReadResponseBodyAsync(
                        backupResponse,
                        rawBodyType,
                        TimeSpan.FromSeconds(30)));
                }
                catch
                {
                    backupResponse.Dispose();
                    throw;
                }
            }
        }

        private static async Task<object> ReadResponseBodyAsync(
            HttpResponseMessage response,
            System.Type rawBodyType,
            TimeSpan timeout)
        {
            if (response.Content == null)
                return rawBodyType == typeof(byte[]) ? (object)Array.Empty<byte>() : string.Empty;

            Task<object> readTask;

            if (rawBodyType == typeof(byte[]))
                readTask = response.Content
                    .ReadAsByteArrayAsync()
                    .ContinueWith<object>(t => t.Result);
            else
                readTask = response.Content
                    .ReadAsStringAsync()
                    .ContinueWith<object>(t => t.Result);

            var completedTask = await Task.WhenAny(readTask, Task.Delay(timeout));

            if (completedTask != readTask)
                throw new TimeoutException($"读取响应 Body 超时，已等待 {timeout.TotalSeconds} 秒");

            return await readTask;
        }

        private static Response.Headers BuildResponseHeaders(HttpResponseMessage response) =>
            JsonConvert.DeserializeObject<Response.Headers>(
                JsonConvert.SerializeObject(response.Headers
                    .Concat(response.Content?.Headers ?? Enumerable.Empty<KeyValuePair<string, IEnumerable<string>>>())
                    .GroupBy(h => h.Key, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(
                        g => g.Key,
                        g => string.Join(",", g.SelectMany(x => x.Value)))),
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });


        private static System.Type GetRawBodyType(System.Type resultType)
        {
            while (resultType != null && resultType != typeof(object))
            {
                if (resultType.IsGenericType &&
                    resultType.GetGenericTypeDefinition() == typeof(BodyResult<>))
                    return resultType.GetGenericArguments()[0];

                resultType = resultType.BaseType;
            }

            return null;
        }

        private static void SetHeaders<T>(T result, Response.Headers Headers) where T : class
        {
            switch (result)
            {
                case null:
                    return;
                case TypeInterface typeInterface:
                    typeInterface.Headers = Headers;
                    WriteLog.Info(LogKind.Reflection, $"成功给 {result.GetType().Name} 赋值 Headers 属性");
                    return;
            }

            var headerType = result.GetType();
            PropertyInfo headersProperty;

            var headerTypeName = headerType.Name;
            lock (_cacheLock)
            {
                if (!_headersPropertyCache.TryGetValue(headerType, out headersProperty))
                {
                    headersProperty = headerType.GetProperty("Headers");

                    if (headersProperty != null &&
                        headersProperty.PropertyType == typeof(Response.Headers))
                    {
                        _headersPropertyCache[headerType] = headersProperty;
                        WriteLog.Info(LogKind.Reflection,
                            $"缓存 {headerTypeName} 的 Headers 属性信息");
                    }
                    else
                    {
                        _headersPropertyCache[headerType] = null;
                    }
                }
            }

            if (headersProperty != null)
            {
                headersProperty.SetValue(result, Headers);
                WriteLog.Info(LogKind.Reflection, $"成功给 {headerTypeName} 赋值 Headers 属性");
            }
            else
            {
                WriteLog.Warning(LogKind.Reflection,
                    $"{headerTypeName} 不存在有效的 Headers 属性（属性不存在或类型不匹配）");
            }
        }

        // 静态 HttpClient 实例
        internal static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient(CreateOptimizedHttpClientHandler(), disposeHandler: false)
            {
                // 不使用 HttpClient 全局 Timeout，改用每次请求独立 CancellationTokenSource
                Timeout = Timeout.InfiniteTimeSpan
            };

            client.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) UAPI-Client/1.0");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json, text/plain, */*");
            // client.DefaultRequestHeaders.ConnectionClose = true;

            return client;
        });

        internal static async Task<HttpResponseMessage> SendApiRequestWithFallbackAsync(
            string requestUrl,
            SendRequestType type,
            object postContent,
            string contentType,
            string authenticationApiTokenKey)
        {
            var httpClient = _httpClient.Value;

            try
            {
                WriteLog.Info(LogKind.Http, $"尝试主站请求: {requestUrl}");

                return await SendApiRequestOnceAsync(
                    httpClient,
                    requestUrl,
                    type,
                    postContent,
                    contentType,
                    authenticationApiTokenKey,
                    TimeSpan.FromSeconds(15));
            }
            catch (TaskCanceledException ex)
            {
                WriteLog.Warning(LogKind.Http, $"主站请求超时，准备切换备用站: {ex.Message}");
            }
            catch (HttpRequestException ex)
            {
                WriteLog.Warning(LogKind.Http, $"主站请求失败，准备切换备用站: {ex.Message}");
            }
            catch (WebException ex)
            {
                WriteLog.Warning(LogKind.Http, $"主站网络异常，准备切换备用站: {ex.Message}");
            }

            var backupUrl = SwitchToBackupUrl(requestUrl);

            if (backupUrl == requestUrl)
                throw new HttpRequestException($"主站请求失败，且无法切换备用站: {requestUrl}");

            WriteLog.Warning(LogKind.Downloader, $"切换到备用站点: {backupUrl}");

            return await SendApiRequestOnceAsync(
                httpClient,
                backupUrl,
                type,
                postContent,
                contentType,
                authenticationApiTokenKey,
                TimeSpan.FromSeconds(30));
        }

        private static async Task<HttpResponseMessage> SendApiRequestOnceAsync(
            HttpClient httpClient,
            string url,
            SendRequestType type,
            object postContent,
            string contentType,
            string authenticationApiTokenKey,
            TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource(timeout);
            using var request =
                new HttpRequestMessage(type == SendRequestType.GET
                    ? HttpMethod.Get
                    : HttpMethod.Post, url);
            request.Version = HttpVersion.Version11;
            // request.Headers.ConnectionClose = true;

            if (!string.IsNullOrEmpty(authenticationApiTokenKey))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", authenticationApiTokenKey);
                var encryptedToken = BitConverter.ToString(SHA256.Create()
                        .ComputeHash(Encoding.UTF8.GetBytes(authenticationApiTokenKey.Trim())))
                    .Replace("-", "").ToLower();
                WriteLog.Info(LogKind.Http, $"Bearer SHA256: {encryptedToken}");
            }

            if (type != SendRequestType.POST)
                return await httpClient.SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token);

            switch (postContent)
            {
                case HttpContent client:
                    request.Content = client;
                    WriteLog.Info("postContent is HttpContent");
                    break;
                case string str:
                    request.Content = new StringContent(
                        str,
                        Encoding.UTF8,
                        contentType ?? "application/json"
                    );
                    WriteLog.Info(
                        $"postContent is string,auto build new StringContent,add ContentType: {contentType}");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                    break;
                case byte[] bytes:
                {
                    request.Content = new ByteArrayContent(bytes);
                    WriteLog.Info(
                        $"postContent is byte[], new ByteArrayContent: {bytes.Length}, new MediaTypeHeaderValue({contentType})");
                    if (!string.IsNullOrWhiteSpace(contentType))
                    {
                        request.Content.Headers.ContentType =
                            new MediaTypeHeaderValue(contentType);
                    }

                    break;
                }
                default:
                {
                    if (postContent != null)
                    {
                        WriteLog.Info("postContent is null,auto serialize content");
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(postContent),
                            Encoding.UTF8,
                            contentType ?? "application/json"
                        );
                        request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                    }

                    break;
                }
            }

            // 关键：只等响应头，不先把整个 body 缓冲完。
            // 某些网络下 body 阶段卡住时，GetAsync 默认会直接超时。
            return await httpClient.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead,
                cts.Token);
        }

        // 优化 HttpClientHandler 配置
        internal static HttpClientHandler CreateOptimizedHttpClientHandler()
        {
            WriteLog.Info(LogKind.Http, "创建优化的 HttpClientHandler 实例");

            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.Expect100Continue = false;

            // 让系统选择 TLS。不要强行启用 TLS 1.0 / 1.1。
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            return new HttpClientHandler
            {
                AllowAutoRedirect = true,
                UseCookies = false,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                MaxConnectionsPerServer = 20,

                // 让系统自己协商 TLS，避免移动热点/运营商网络下 TLS 握手异常
                SslProtocols = SslProtocols.None,

                // 如果你没有明确使用系统代理，建议先关掉。
                // 某些环境下代理自动发现会拖慢甚至卡死请求。
                UseProxy = false
            };
        }

        #endregion
    }
}