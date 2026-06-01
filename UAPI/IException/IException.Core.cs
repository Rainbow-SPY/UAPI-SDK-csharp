using System;
using static UAPI.Type;

namespace UAPI.IException
{
    /// <summary>
    /// 响应体核心异常
    /// </summary>
    public class Core
    {
        internal const string API_ERROR =
            "HttpClient 500/502;API_ERROR;Upstream Error or internal error;unknow error exception";

        #region 404

        internal const string AVATAR_NOT_FOUND = "HttpClient 404;AVATAR_NOT_FOUND;Not Found Resource";
        internal const string NOT_FOUND = "HttpClient 404;NOT_FOUND;Not Found Resource";
        internal const string NO_MATCH = "HttpClient 404;NO_MATCH;Not Matched Result";
        internal const string NO_TRACKING_DATA = "HttpClient 404;NO_TRACKING_DATA;Not Found Any Tracking Data";
        internal const string RECOGNITION_FAILED = "HttpClient 404;RECOGNITION_FAILED;Not analyzed successfully";

        internal const string TIMEZONE_NOT_FOUND =
            "HttpClient 404;TIMEZONE_NOT_FOUND;Not Found Timezone;Search Timezone Failed";

        internal const string UNSUPPORTED_CARRIER = "HttpClient 404;UNSUPPORTED_CARRIER;Unsupported Carrier Error";

        #endregion

        #region 400

        internal const string CONVERSION_FAILED = "HttpClient 400;CONVERSION_FAILED;Convert Failed";

        internal const string FILE_REQUIRED =
            "HttpClient 400;FILE_REQUIRED;Upload File interface failed when any-file required";

        internal const string INVALID_PARAMETER = "HttpClient 400;INVALID_PARAMETER;Invalid parameter";
        internal const string INVALID_PARAMS = "HttpClient 400;INVALID_PARAMS;Invalid parameter";

        internal const string UNSUPPORTED_FORMAT =
            "HttpClient 400;UNSUPPORTED_FORMAT;File or Text or Params Format Unsupported";

        #endregion

        #region 500

        internal const string FILE_OPEN_ERROR = "HttpClient 500;FILE_OPEN_ERROR;Read File or Open Failed";

        /// <summary>
        /// 服务器处理文件时发生未知的异常
        /// </summary>
        public class FileOpenFailed : Exception
        {
            /// <inheritdoc cref="FileOpenFailed" />
            public FileOpenFailed()
            {
            }

            /// <inheritdoc cref="FileOpenFailed" />
            public FileOpenFailed(string message) : base(message)
            {
            }

            /// <inheritdoc cref="FileOpenFailed" />
            public FileOpenFailed(string message, Exception inner) : base(message, inner)
            {
            }
        }

        internal const string PHONE_INFO_FAILED = "HttpClient 500;PHONE_INFO_FAILED;Upstream Search Failed;";
        internal const string INTERNAL_SERVER_ERROR = "HttpClient 500;INTERNAL_SERVER_ERROR;Internal Server Error";

        #endregion


        internal const string INSUFFICIENT_CREDITS = "HttpClient 402;INSUFFICIENT_CREDITS;Account Credit empty";

        internal const string REQUEST_ENTITY_TOO_LARGE =
            "HttpClient 413;REQUEST_ENTITY_TOO_LARGE;Request Entity Too Large than Limit";

        internal const string SERVICE_BUSY = "HttpClient 429;SERVICE_BUSY;RateLimit Exceeded;Too Many Requests";

        internal const string VISITOR_MONTHLY_QUOTA_EXHAUSTED =
            "HttpClient 429;VISITOR_MONTHLY_QUOTA_EXHAUSTED;Free Credits empty";


        internal const string UNAUTHORIZED =
            "HttpClient 401;UNAUTHORIZED;Unauthorized Token or Permission;Verify Failed";


        internal const string _UAPI_Unknown_Exception = "UAPI_Unknown_Exception";


        internal const string _UAPI_Service_Unavailable = "SERVICE_UNAVAILABLE;HttpClient return 503";

        internal const string JSON_SERIALIZATION_ERROR = "JSON_SERIALIZATION_ERROR; Json serialization failed";

        internal static string GetErrorOrCode<T>(T Type) where T : TypeInterface =>
            Type.code ?? Type.error;

        internal static string GetMessageOrDetails<T>(T Type) where T : TypeInterface =>
            Type.message ?? Type.details;

        internal static string GetFailedReportDetails<T>(T Type) where T : TypeInterface
        {
            var typeHeaders = Type.Headers;
            return $"Request-ID: {typeHeaders.RequestID}" +
                   $"\n\tTime: {typeHeaders.Date}" +
                   "\n\tDetails:" +
                   $"\n\t\tRequested Credits:{typeHeaders.RequestedCredits}" +
                   $"\n\t\tCredits Charged: {typeHeaders.CreditsCharged} " +
                   $"{(typeHeaders.CreditsCharged == typeHeaders.RequestedCredits ? "" : $"Cause: {(typeHeaders.IsCacheHalfPrice ? "HIT Half-Price" : "")}")}" +
                   $"\n\t\tCredits Status: {typeHeaders.DebitStatus.ToString()}" +
                   $"\n\t\tSource Where:{(typeHeaders.IsVisitor ? "Visitor" : "Billing")}";
        }
    }
}