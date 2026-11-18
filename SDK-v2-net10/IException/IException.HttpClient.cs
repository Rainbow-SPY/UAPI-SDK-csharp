namespace UAPI.v2.IException;

public interface IException
{
    internal string Pin(Exception? _ex, UPSModel Package, string Name, string? cause, UPSException _exp = default) =>
        $"UAPI SDK 在请求时发生了 {Name} 异常{(cause is null ? "" : $" , {cause}")}:\r\n" +
        $"Original Exception: {_ex?.Message ?? "null"}\r\n" +
        $"{(_exp.ErrorCode is null ? "" : $"ErrorCode: {_exp.ErrorCode}")}\r\n" +
        $"\r\nDetected Type: {Package.T}\r\n" +
        $"Request Info: \r\n" +
        $"\tRequest Type: {Package.type}\r\n" +
        $"\tAuthentication API (SHA-256): {Package.AuthenticationAPIKey}\r\n" +
        $"\tEndpoint: {Package.EndpointUrl}\r\n" +
        $"\tPOST Content: {Package.postContent ?? "null"}\r\n" +
        $"\tMedia Head Value: {Package.contentType}\r\n" +
        $"\r\n" +
        $"Origin StackTrace: \r\n{_ex?.StackTrace ?? "null"}\r\n" +
        $"{(_ex?.InnerException is null ? $"" : $"\r\nOrigin Inner Exception: \r\n{_ex.InnerException.Message}\r\n" +
                                                $"\r\nOrigin Inner StackTrace: \r\n{_ex.InnerException.StackTrace}")}";

    public class HttpClientRequestException(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "HttpClientRequestException", cause, _exp);
    }

    public class DNSResolutionError(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "DNSResolutionException", cause, _exp);
    }

    public class NetworkSocketNotAvailable(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "NetworkSocketNotAvailable", cause, _exp);
    }

    public class SocketConnectionRefused(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "SocketConnectionRefused", cause, _exp);
    }

    public class SocketConnectionTimeOut(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "SocketConnectionTimeOut", cause, _exp);
    }

    public class EmptyResponseData(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "EmptyResponseData", cause, _exp);
    }

    public class TLSHandShakeError(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "TLSHandShakeError", cause, _exp);
    }

    public class RemoteConnectionError(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "RemoteConnectionError", cause, _exp);
    }

    public class InvalidOrBadResponse(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "RemoteConnectionError", cause, _exp);
    }

    public class CTSTaskTimeout(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "CancellationTokenSourceTaskTimeout", cause, _exp);
    }

    public class UnknowException(UPSModel package, UPSException _exp, Exception? ex, string? cause)
        : Exception(ex?.Message, ex), IException
    {
        private readonly Exception? _ex = ex;
        private UPSModel Package { get; } = package;

        public override string ToString() =>
            Pin(_ex, Package, "UnknowException", cause, _exp);
    }
}