using System.Security.Authentication;

namespace UAPI.v2.Core;

/// <summary>
/// 统一 HttpClient 实例接口
/// </summary>
public interface IHttpClient
{
    [Obsolete("因 ServicePointManager 在.net 10已过时, 正在寻找更好的方案")]
    internal static HttpClientHandler CreateOptimizedHttpClientHandler()
    {
        Info("创建 HttpClientHandler 实例", "HttpClient");

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
            SslProtocols = SslProtocols.None,
            UseProxy = false
        };
    }

    internal static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() =>
    {
        var client = new HttpClient(CreateOptimizedHttpClientHandler(), disposeHandler: false)
        {
            DefaultRequestHeaders =
            {
                ExpectContinue = false,
            },
            Timeout = Timeout.InfiniteTimeSpan
        };
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) UAPI-Client/1.0");
        client.DefaultRequestHeaders.Accept.ParseAdd("application/json, text/plain, */*");
        // client.DefaultRequestHeaders.ConnectionClose = true;

        return client;
    });
}