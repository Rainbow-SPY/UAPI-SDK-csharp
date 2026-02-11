//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 4:38
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for catch any exceptions from Bilibili API and itself through a third-party interface.
//  Now Play:       トゲナシトゲアリ (TOGENASHI TOGEARI) - 空の箱 (井芹仁菜、河原木桃香)

using System;

namespace UAPI.IException
{
    /// <summary>
    /// UAPI平台综合常见异常
    /// </summary>
    public class General
    {
        internal const string _UAPI_Unknown_Exception = "UAPI_Unknown_Exception";

        internal const string _UAPI_Server_Down =
            "UAPI_Server_Down;HttpClient return 500;";

        /// <summary>
        /// 未知异常, 请联系管理员或反馈工单 <see href="https://uapis.cn/docs/getting-started/about-us"/>
        /// </summary>
        public class UAPIUnknowException : Exception
        {
            /// <summary>
            /// 未知异常, 请联系管理员或反馈工单 <see href="https://uapis.cn/docs/getting-started/about-us"/>
            /// </summary>
            public UAPIUnknowException()
            {
            }

            /// <summary>
            /// 未知异常, 请联系管理员或反馈工单 <see href="https://uapis.cn/docs/getting-started/about-us"/>
            /// </summary>
            public UAPIUnknowException(
                string message = @"未知异常, 请联系管理员或反馈工单: https://uapis.cn/docs/getting-started/about-us") : base(message)
            {
            }

            /// <summary>
            /// 未知异常, 请联系管理员或反馈工单 <see href="https://uapis.cn/docs/getting-started/about-us"/>
            /// </summary>
            public UAPIUnknowException(string message, Exception inner) : base(message, inner)
            {
            }
        }

        /// <summary>
        /// UAPI服务异常
        /// </summary>
        public class UAPIServerDown : Exception
        {
            /// <summary>
            /// UAPI服务异常
            /// </summary>
            public UAPIServerDown()
            {
            }

            /// <summary>
            /// UAPI服务异常
            /// </summary>
            public UAPIServerDown(string message) : base(message)
            {
            }

            /// <summary>
            /// UAPI服务异常
            /// </summary>
            public UAPIServerDown(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}