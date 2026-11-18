namespace UAPI.v2.Core;

public class ISendAPIAsync : IHttpClient, IException.IException
{
    public const string _Request_Url = "https://uapis.cn/api/v1/";
    public static UPSModel package = new UPSModel();

    public UPSException _exp = new()
    {
        Model = package
    };

    /// 泛型缓存容器
    private static readonly Dictionary<Type, PropertyInfo> _headersPropertyCache =
        new Dictionary<System.Type, PropertyInfo>();

    public static readonly object _cacheLock = new();

    public async Task<T> RequestAsync<T>(string EndpointUrl, Dictionary<UPSParams, Type> _params,
        RequestType type = RequestType.GET,
        object? postContent = null, string contentType = "application/json",
        string? AuthenticationAPIKey = null)
        where T : class
    {
        var rawBodyType = GetRawBodyType(typeof(T));
        package._dir.Add("EndpointUrl", typeof(string));
        package._dir.Add("RequestType", typeof(RequestType));
        package._dir.Add("postContent", typeof(object));
        package._dir.Add("contentType", typeof(string));
        package._dir.Add("AuthenticationAPIKey", typeof(string));
        foreach (var i in _params)
        {
            // In => await RequestAsync(+ new _params())
            // => new UPSParams() *Contain ^TKey & TValue
            // => 
            package._dir.Add($"{i.Key}", i.Key.TKey?.GetType() ?? throw new InvalidOperationException());
            package._dir.Add($"{i.Value}", i.Key.TValue?.GetType() ?? throw new InvalidOperationException());
        }

        /*
        var package = new UPSModel(httpClient: _httpClient.Value,
            endpointUrl: EndpointUrl, type: type, t: typeof(T), postContent: postContent, contentType: contentType);
        var _exp = new UPSException(model: package);
        */
        package = new UPSModel
        {
            _httpClient = _httpClient.Value,
            EndpointUrl = EndpointUrl,
            type = type,
            AuthenticationAPIKey = AuthenticationAPIKey,
            postContent = postContent,
            contentType = contentType
        };
        try
        {
            Info($"Try request {EndpointUrl}");
            Info($"Send Request {EndpointUrl} as {(type is RequestType.GET ? "GET" : "POST")}: {EndpointUrl}");
            var response = await SendMessageRequest(package);
            Info($"Async Read Response, Type {response}", "Http");
            var data = response.Content == null
                ? rawBodyType == typeof(byte[])
                    ? Array.Empty<byte>()
                    : string.Empty
                : rawBodyType == typeof(byte[])
                    ? await response.Content.ReadAsByteArrayAsync().ContinueWith<object>(t => t.Result)
                    : await response.Content.ReadAsStringAsync().ContinueWith<object>(t => t.Result);
            using (response)
            {
                Info("Analyze Response", "Http");
                var Headers = JsonConvert.DeserializeObject<Headers>(JsonConvert.SerializeObject(response.Headers
                        .Concat(response.Content?.Headers ??
                                Enumerable.Empty<KeyValuePair<string, IEnumerable<string>>>())
                        .GroupBy(h => h.Key, StringComparer.OrdinalIgnoreCase)
                        .ToDictionary(g => g.Key, g => string.Join(",", g.SelectMany(x => x.Value)))),
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                Info("Serialize Response", "Http");
                _exp.StatusCode = (int)response.StatusCode;
                Info($"Get StatusCode {_exp.StatusCode}", "Http");

                if (data is null)
                {
                    var ex = new IException.IException.EmptyResponseData(package, _exp, null,
                        "返回了空的响应体数据, 因为 $responseRawData 为 null");
                    _exp.OriginalException = ex;
                    Error("Empty response", "Http");
                    throw ex;
                }

                T result;
                if (rawBodyType is not null)
                {
                    result = Activator.CreateInstance<T>();

                    var resultProperty = typeof(T).GetProperty("Result", BindingFlags.Instance | BindingFlags.Public);

                    resultProperty?.SetValue(result, data);

                    Info($"Response Body written in {typeof(T).Name}.Result, BodyType: {rawBodyType}");
                }
                else
                {
                    Info("Compress Response", "Http");

                    result = JsonConvert.DeserializeObject<T>(
                        JsonConvert.SerializeObject((string)data, Formatting.None), new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        })!;

                    Info("Deserialize Response", "Http");
                }

                SetHeaders(result, Headers);
                return result;
            }
        }
        catch (HttpRequestException e) when (e.InnerException is SocketException sce)
        {
            _exp.OriginalException = e;
            _exp.InnerException = e.InnerException;
            throw sce.SocketErrorCode switch
            {
                SocketError.HostNotFound => new IException.IException.DNSResolutionError(package, _exp, e,
                    "DNS 解析失败, 请检查您的网络或反馈工单给工作人员"),
                SocketError.NetworkDown or SocketError.NetworkUnreachable => new
                    IException.IException.NetworkSocketNotAvailable(package,
                        _exp, e, "网络不可用, 请检查您的网络或反馈工单给工作人员"),
                SocketError.ConnectionRefused => new IException.IException.SocketConnectionRefused(package, _exp, e,
                    "连接被拒绝, 请检查您的网络或反馈工单给工作人员"),
                SocketError.TimedOut => new IException.IException.SocketConnectionTimeOut(package, _exp, e,
                    "连接超时,请检查您的网络或反馈工单给工作人员"),
                _ => new IException.IException.UnknowException(package, _exp, e, "未知异常")
            };
        }
        catch (HttpRequestException e)
            when (e.HttpRequestError is HttpRequestError.NameResolutionError)
        {
            _exp.Error = e.HttpRequestError.ToString();
            _exp.Details = e.StackTrace;
            throw new IException.IException.DNSResolutionError(package, _exp, e, "DNS解析失败, 请检查您的网络连接或反馈工单给工作人员");
        }
        catch (HttpRequestException e)
            when (e.HttpRequestError is HttpRequestError.ConnectionError)
        {
            _exp.Error = e.HttpRequestError.ToString();
            _exp.Details = e.StackTrace;
            throw new IException.IException.RemoteConnectionError(package, _exp, e, "远程端点连接失败, 请检查您的网络连接或反馈工单给工作人员");
        }
        catch (HttpRequestException e)
            when (e.HttpRequestError is HttpRequestError.SecureConnectionError)
        {
            _exp.Error = e.HttpRequestError.ToString();
            _exp.Details = e.StackTrace;
            throw new IException.IException.TLSHandShakeError(package, _exp, e, "TLS握手失败, 请检查您的网络连接或反馈工单给工作人员");
        }
        catch (HttpRequestException e)
            when (e.HttpRequestError is HttpRequestError.InvalidResponse)
        {
            throw new IException.IException.InvalidOrBadResponse(package, _exp, e,
                "接收到了无效或格式错误的响应, 请检查您的网络连接或反馈工单给工作人员");
        }
        catch (HttpRequestException e)
        {
            throw new IException.IException.HttpClientRequestException(package, _exp, e, "请求失败, 请检查您的网络连接或反馈工单给工作人员");
        }
        catch (TaskCanceledException e)
        {
            throw new IException.IException.CTSTaskTimeout(package, _exp, e, "任务进行超时, 请检查您的网络连接或反馈工单给工程师.");
        }
    }

    public async Task<T> GetRequestAsync<T>(string EndpointUrl, string AuthenticationAPITokenKey = "") where T : class
        => await RequestAsync<T>(EndpointUrl, AuthenticationAPIKey: AuthenticationAPITokenKey);

    public async Task<T> PostRequestAsync<T>(string requestUrl, object? postContent,
        string AuthenticationAPITokenKey = "") where T : class
        => await RequestAsync<T>(requestUrl, RequestType.POST, postContent: postContent,
            AuthenticationAPIKey: AuthenticationAPITokenKey);

    internal static async Task<HttpResponseMessage> SendMessageRequest(UPSModel _package)
    {
        Info("初始化 CRI...", "CRI");

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        using var request =
            new HttpRequestMessage(_package.type == RequestType.GET ? HttpMethod.Get : HttpMethod.Post,
                _package.EndpointUrl);
        request.Version = HttpVersion.Version11;

        if (!string.IsNullOrEmpty(_package.AuthenticationAPIKey))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _package.AuthenticationAPIKey);
            var ecToken = Convert
                .ToHexStringLower(SHA3_256.HashData(Encoding.UTF8.GetBytes(_package.AuthenticationAPIKey.Trim())))
                .Replace("-", "");
            Info("Load API Key: " + ecToken, "Http");
        }

        if (_package.type is not RequestType.POST)
            return await _httpClient.Value.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token);

        switch (_package.postContent)
        {
            case HttpContent client:
                request.Content = client;
                Info("Detected $postContent as HttpContent");
                break;
            case string str:
                request.Content = new StringContent(str, Encoding.UTF8, _package.contentType ?? "application/json");
                Info("Detected #string type, auto build new StringContent");
                request.Content.Headers.ContentType =
                    new MediaTypeHeaderValue(_package.contentType ?? "application/json");
                break;
            case byte[] bytes:
                request.Content = new ByteArrayContent(bytes);
                Info(
                    $"Detected $postContent as ByteArray,new ByteArrayContent {bytes.Length},new MediaTypeHeaderValue({_package.contentType})");
                request.Content.Headers.ContentType =
                    new MediaTypeHeaderValue(_package.contentType ?? "application/json");
                break;
            default:
                if (_package.postContent is not null)
                {
                    Info("Detected $postContent as #Object,auto serialize content");
                    request.Content = new StringContent(JsonConvert.SerializeObject(_package.postContent),
                        Encoding.UTF8,
                        _package.contentType ?? "application/json");
                    request.Content.Headers.ContentType =
                        new MediaTypeHeaderValue(_package.contentType ?? "application/json");
                }

                break;
        }

        return await _httpClient.Value.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token);
    }

    private static Type? GetRawBodyType(Type ResultType) =>
        ResultType == typeof(byte[]) || ResultType == typeof(string) ? ResultType : null;

    private void SetHeaders<T>(T result, Headers Headers) where T : class
    {
        switch (result)
        {
            case null:
                return;
            case UPSException:
                _exp.headers = Headers;
                Info($"成功给 {result.GetType().Name} 赋值 Headers 属性", "Reflection");
                return;
        }

        var headerType = result.GetType();
        PropertyInfo? headersProperty;

        var headerTypeName = headerType.Name;
        lock (_cacheLock)
            if (!_headersPropertyCache.TryGetValue(headerType, out headersProperty))
            {
                headersProperty = headerType.GetProperty("Headers");

                if (headersProperty is not null &&
                    headersProperty.PropertyType == typeof(Headers))
                {
                    _headersPropertyCache[headerType] = headersProperty;
                    Info($"缓存 {headerTypeName} 的 Headers 属性信息", "Reflection");
                }
                else
                    _headersPropertyCache[headerType] = null!;
            }

        if (headersProperty is not null)
        {
            headersProperty.SetValue(result, Headers);
            Info($"成功给 {headerTypeName} 赋值 Headers 属性", "Reflection");
        }
        else
            Warning($"{headerTypeName} 不存在有效的 Headers 属性（属性不存在或类型不匹配）", "Reflection");
    }
}