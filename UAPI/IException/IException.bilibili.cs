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
//  Now Play:       Ave Mujica - 颜
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