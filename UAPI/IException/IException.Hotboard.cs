using System;

namespace UAPI.IException
{
    /// <summary>
    /// 热榜请求时常见的异常
    /// </summary>
    public class Hotboard : Exception
    {
        /// <summary>
        /// 在请求 <see langword="%s"/> 上游服务API时发生错误
        /// </summary>
        public class HotboardUpstreamServiceError : Exception
        {
            /// <summary>
            /// 在请求 <see langword="%s"/> 上游服务API时发生错误
            /// </summary>
            public HotboardUpstreamServiceError()
            {
            }

            /// <summary>
            /// 在请求 <see langword="%s"/> 上游服务API时发生错误
            /// </summary>
            /// <param name="message"></param>
            public HotboardUpstreamServiceError(string message = "在请求上游服务API时发生错误") : base(message)
            {
            }

            /// <summary>
            /// 在请求 <see langword="%s"/> 上游服务API时发生错误
            /// </summary>
            /// <param name="_Type"></param>
            public HotboardUpstreamServiceError(Interface.Hotboard.HotboardInterface _Type) : base(
                $"在请求{_Type.type}上游服务API时发生错误")
            {
            }

            /// <summary>
            /// 在请求 <see langword="%s"/> 上游服务API时发生错误
            /// </summary>
            /// <param name="message"></param>
            /// <param name="inner"></param>
            public HotboardUpstreamServiceError(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}