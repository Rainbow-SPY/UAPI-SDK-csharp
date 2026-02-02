//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 18:18
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for catch any exceptions from QQ API through a third-party interface.
//  Now Play:       Ave Mujica - KiLLKiSS

namespace UAPI.IException
{
    /// <summary>
    /// QQ综合相关异常
    /// </summary>
    public class QQ
    {
        internal const string _QQ_Service_Error = @"QQ_Service_Error;HttpClient return 502";

        /// <summary>
        /// QQ 在线API服务错误或无法请求
        /// </summary>
        public class QQServiceError : System.Exception
        {
            /// <summary>
            /// QQ 在线API服务错误或无法请求
            /// </summary>
            /// <param name="message"></param>
            public QQServiceError(string message) : base(message)
            {
            }

            /// <summary>
            /// QQ 在线API服务错误或无法请求
            /// </summary>
            public QQServiceError(string message, System.Exception inner) : base(message, inner)
            {
            }

            /// <summary>
            /// QQ 在线API服务错误或无法请求
            /// </summary>
            public QQServiceError() : base()
            {
            }
        }
    }
}