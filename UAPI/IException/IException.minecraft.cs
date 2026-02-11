using System;

namespace UAPI.IException
{
    /// <summary>
    /// Minecraft综合请求异常
    /// </summary>
    public class minecraft : Exception
    {
        /// <summary></summary>
        public const string _Mojang_API_Service_Error="Mojang API Service Error;Redirect to Microsoft/Xbox or Mojang API Service;HttpClient return 502;Type: UPSTREAM";
        /// <summary>
        /// 在向 Mojang 的官方 API 请求数据时遇到了问题
        /// </summary>
        public class MojangAPIServiceError : Exception
        {
            /// <summary>
            /// 在向 Mojang 的官方 API 请求数据时遇到了问题
            /// </summary>
            /// <returns></returns>
            public MojangAPIServiceError()
            {
            }

            /// <summary>
            /// 在向 Mojang 的官方 API 请求数据时遇到了问题
            /// </summary>
            /// <param name="message"></param>
            public MojangAPIServiceError(string message) : base(message)
            {
            }

            /// <summary>
            /// 在向 Mojang 的官方 API 请求数据时遇到了问题
            /// </summary>
            /// <param name="message"></param>
            /// <param name="inner"></param>
            public MojangAPIServiceError(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}