using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rox.Runtimes;
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;
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
        public const string _UAPI_Request_Url = "https://uapis.cn/api/v1/";

        internal const string _2UAPI_Request_Url = "https://b1.uapis.cn/api/v1/";

        /// 泛型缓存容器
        private static readonly Dictionary<Type, PropertyInfo> _headersPropertyCache =
            new Dictionary<Type, PropertyInfo>();

        private static readonly object _cacheLock = new object();

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
        /// <exception cref="ArgumentNullException">传参异常</exception>
        /// <exception cref="AmbiguousMatchException">当绑定到成员导致多个成员匹配绑定条件时引发的异常。</exception>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(
            string requestUrl, SendRequestType type = SendRequestType.GET, string postContent = "",
            string contentType = "application/json", string AuthenticationAPITokenKey = "") where T : class
        {
            var targetUrl = requestUrl;

            #region PingTest

            var res = await Network_I.PingAsync("uapis.cn");
            var tempFile = Path.GetTempFileName();
            if (res.IsSuccess)
                try
                {
                    WriteLog.Info(LogKind.Downloader, "尝试下载 uapis.cn:443 界面资源...");
                    using (var webClient = new WebClient())
                        await webClient.DownloadFileTaskAsync(new Uri("https://uapis.cn:443"), tempFile);
                }
                catch (WebException)
                {
                    WriteLog.Warning(LogKind.Downloader, "无法连接到 uapis.cn, 切换到备用站点使用");
                    targetUrl = SwitchToBackupUrl(requestUrl);
                }
                finally
                {
                    // 清理临时文件
                    if (File.Exists(tempFile))
                        try
                        {
                            File.Delete(tempFile);
                        }
                        catch (IOException ex)
                        {
                            WriteLog.Warning(LogKind.File, $"清理临时文件失败: {_Exception_With_xKind("File.Delete", ex)}");
                        }
                }
            else
            {
                WriteLog.Warning(LogKind.Downloader, "uapis.cn Ping 失败, 切换到备用站点使用");
                targetUrl = SwitchToBackupUrl(requestUrl);
            }

            #endregion

            WriteLog.Info(LogKind.Http, "配置 ServicePointManager 连接参数");
            try
            {
                var httpClient = _httpClient.Value;
                WriteLog.Info(LogKind.Http, "新建 HttpClient 实例");
                if (!string.IsNullOrEmpty(AuthenticationAPITokenKey))
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AuthenticationAPITokenKey);
                    //       httpClient.DefaultRequestHeaders.Add("Bearer", AuthenticationAPITokenKey);
                    WriteLog.Info(LogKind.Http,
                        $"添加请求头: {AuthenticationAPITokenKey.Substring(0, 6)}");
                }

                var response = type == SendRequestType.GET
                    ? await httpClient.GetAsync(targetUrl)
                    : await httpClient.PostAsync(targetUrl,
                        new StringContent(postContent, Encoding.UTF8, contentType));
                WriteLog.Info(LogKind.Http,
                    $"{_SEND_REQUEST}: {(type == SendRequestType.GET ? "GET" : "POST")} {targetUrl}");
                using (response)
                {
                    var Headers = JsonConvert.DeserializeObject<Response.Headers>(
                        JsonConvert.SerializeObject(response.Headers.ToDictionary(h => h.Key,
                            h => string.Join(",", h.Value))), new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        });
                    WriteLog.Info("ToDictionary", "响应标头转换为字典");
                    WriteLog.Info(LogKind.Json, "序列化字典");
                    WriteLog.Info(LogKind.Json, "反序列化字典");
                    var statusCode = (int)response.StatusCode;
                    WriteLog.Info(LogKind.Http, $"获取 Http 响应代码: {statusCode}");
                    var responseData = await response.Content.ReadAsStringAsync();
                    WriteLog.Info(LogKind.Http, "异步读取响应内容");
                    if (string.IsNullOrEmpty(responseData))
                    {
                        WriteLog.Error(LogKind.Http,
                            _void_value_null("GetResult<T>.HttpClient", "Content"));
                        return (null, statusCode);
                    }

                    WriteLog.Info(LogKind.Json, "压缩 Json");
                    T result = null;
                    try
                    {
                        result = JsonConvert.DeserializeObject<T>(CompressJson(responseData),
                            new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            });

                        if (result != null)
                        {
                            var headerType = result.GetType();
                            PropertyInfo headersProperty;
                            // 加锁保证缓存线程安全
                            lock (_cacheLock)
                                // 优先从缓存获取，避免重复反射
                                if (!_headersPropertyCache.TryGetValue(headerType, out headersProperty))
                                {
                                    // 反射获取 Headers 属性
                                    headersProperty = headerType.GetProperty("Headers");
                                    // 验证属性存在且类型匹配后再缓存
                                    if (headersProperty != null &&
                                        headersProperty.PropertyType == typeof(Response.Headers))
                                    {
                                        _headersPropertyCache[headerType] = headersProperty;
                                        WriteLog.Info(LogKind.Reflection,
                                            $"缓存 {headerType.FullName} 的 Headers 属性信息");
                                    }
                                    else
                                        // 若属性不存在/类型不匹配，缓存null避免重复检查
                                        _headersPropertyCache[headerType] = null;
                                }

                            // 若缓存中存在有效属性则赋值
                            if (headersProperty != null)
                            {
                                headersProperty.SetValue(result, Headers);
                                WriteLog.Info(LogKind.Reflection, $"成功给 {headerType.FullName} 赋值 Headers 属性");
                            }
                            else
                                WriteLog.Warning(LogKind.Reflection,
                                    $"{headerType.FullName} 不存在有效的 Headers 属性（属性不存在或类型不匹配）");
                        }

                        WriteLog.Info(LogKind.Json, "反序列化Json");
                    }
                    catch (JsonSerializationException ex)
                    {
                        WriteLog.Error(LogKind.Json,
                            $"JSON反序列化失败！类型：{typeof(T).FullName}，错误：{ex.Message}，堆栈：{ex.StackTrace}");
                    }

                    return (result, statusCode);
                }
            }
            catch (HttpRequestException e)
            {
                WriteLog.Error(LogKind.Http,
                    $"HttpClient 请求失败, 请检查您的网络连接或反馈工单给工作人员: {e.Message} - {e.StackTrace}");
                return (null, -1);
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
        /// 公共API 获取请求, 访客请求API, 无 Authentication API Token Key
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <exception cref="JsonSerializationException"><see cref="Newtonsoft.Json"/> 反序列化失败</exception>
        /// <exception cref="HttpRequestException"><see cref="HttpClient"/> 请求失败</exception>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl) where T : class => await
            GetResult<T>(requestUrl, SendRequestType.GET);

        internal enum SendRequestType
        {
            GET,
            POST
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
            string _Error_Type, string Error_Code = "") where T : TypeInterface
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 200:
                    WriteLog.Info(LogKind.Network, "请求成功");
                    return true;
                case 400:
                    WriteLog.Error(LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty(NullValue)}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty(NullValue)}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    break;
                case 401:
                    WriteLog.Error("UnAuthorized", "未经授权的操作");
                    throw new UnauthorizedAccessException("未经授权的操作");
                case 429:
                    WriteLog.Error("Too Many Requests",
                        $"因请求量太大, 限制了您的请求, 错误代码: 429 Too Many Requests, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    MessageBox_I.Error(
                        $"因请求量太大, 限制了您的请求, 错误代码: 429 Too Many Requests, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    break;
                case 403:
                    WriteLog.Warning(LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    WriteLog.Warning("未找到用户");
                    MessageBox_I.Warning("未找到用户", _ERROR);
                    break;
                case 500:
                    WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw new General.UAPIServerDown(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Server_Down}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");

                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    MessageBox_I.Error(
                        $"{_Error_Type} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw _Exception;
                case 503:
                    WriteLog.Error(
                        $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Service_Unavailable},错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
                    MessageBox_I.Error(
                        $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Service_Unavailable},错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}",
                        _ERROR);
                    throw new General.UAPIServiceUnavailable(
                        $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {General._UAPI_Service_Unavailable},错误信息: {Type.code ?? Type.code ?? ""} - {Type.details}");
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

        private static string SwitchToBackupUrl(string originalUrl)
        {
            if (originalUrl.StartsWith(_UAPI_Request_Url))
                return _2UAPI_Request_Url + originalUrl.Substring(_UAPI_Request_Url.Length);

            WriteLog.Warning(LogKind.Http, $"requestUrl {originalUrl} 不包含基础前缀，无法切换到备用地址");
            return originalUrl;
        }

        // 静态 HttpClient 实例
        private static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() =>
            new HttpClient(CreateOptimizedHttpClientHandler(), disposeHandler: false)
            {
                Timeout = TimeSpan.FromSeconds(10)
            });

        // 优化 HttpClientHandler 配置
        internal static HttpClientHandler CreateOptimizedHttpClientHandler()
        {
            WriteLog.Info(LogKind.Http, "创建优化的 HttpClientHandler 实例");
            // 关闭 Nagle 算法
            ServicePointManager.UseNagleAlgorithm = false;
            // 关闭 100-Continue 握手
            ServicePointManager.Expect100Continue = false;

            return new HttpClientHandler
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                // 连接池配置
                MaxConnectionsPerServer = 100,
                // TLS 配置）
                SslProtocols = SslProtocols.Tls12 |
                               SslProtocols.Tls11 |
                               SslProtocols.Tls
            };
        }
    }
}