//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 18:31
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for redirecting QQ API through a third-party interface.
//  Now Play:       Ave Mujica - 颜

using System.Threading.Tasks;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    /// <summary>
    /// QQ相关请求
    /// </summary>
    public partial class QQ
    {
        /// <summary>
        /// UAPI公用请求API地址
        /// </summary>
        public const string _UAPI_Request_Url = @"https://uapis.cn/api/v1/social/qq/";

        /// <summary>
        /// 获取QQ用户公开摘要
        /// </summary>
        /// <param name="qq">QQ号</param>
        /// <returns><see cref="UserType"/> 对象</returns>
        public static async Task<UserType> GetUserData(string qq)
        {
            if (string.IsNullOrEmpty(qq))
            {
                WriteLog.Error("GetUserData", $"{_value_Not_Is_NullOrEmpty("QQ")}, 错误代码: {_String_NullOrEmpty}");
                return null;
            }

            var (result, statusCode) = await Interface.GetResult<UserType>($"{_UAPI_Request_Url}userinfo?qq={qq}");
            if (!Interface.IsGetSuccessful(result, "qq", statusCode, new IException.QQ.QQServiceError(),
                    "QQ", IException.QQ._QQ_Service_Error))
                WriteLog.Error(LogKind.Http, "请求失败, 请重试");
            return result;
        }
    }
}