namespace UAPI.v2.Core;

public struct UPSModel(string endpointUrl, HttpClient httpClient)
{
    public string EndpointUrl = endpointUrl;
    public HttpClient _httpClient = httpClient;
    public readonly Dictionary<string, Type> _dir = new();
    public RequestType type;
    public object? postContent = null;
    public string? AuthenticationAPIKey;
    public string? contentType;
    public readonly Type? T;
}