using System.Diagnostics.CodeAnalysis;

namespace UAPI.v2.Core;

public struct UPSException(string code, string error, string message)
{
    public bool IsRequestSuccessfully = false;
    public int? ErrorCode;
    public string? ErrorMessage;
    public int StatusCode;
    public required UPSModel Model;
    public Headers headers;

    public string? Code = code;
    public string? Error = error;
    public string Message = message;
    public string? Details;
    public Exception? InnerException;
    public Exception? OriginalException;
    public object? result;

    public UPSException(UPSModel model, string code, string error, string message) : this(code, error, message) =>
        Model = model;
}