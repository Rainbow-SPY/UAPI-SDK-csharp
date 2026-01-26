using System;

namespace UAPI.IException
{
    public static partial class bilibili
    {
        public const string _Bilibili_Service_Error = "bilibili_Service_Error;HttpClient return 502;";
        /// <summary>
        /// bilibili API错误或无法请求
        /// </summary>
        public class BilibiliServiceError : Exception
        {
            /// <summary>
            /// bilibili API错误或无法请求
            /// </summary>
            public BilibiliServiceError() : base()
            {
            }

            /// <summary>
            /// bilibili API错误或无法请求
            /// </summary>
            public BilibiliServiceError(string message) : base(message)
            {
            }

            /// <summary>
            /// bilibili API错误或无法请求
            /// </summary>
            public BilibiliServiceError(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}