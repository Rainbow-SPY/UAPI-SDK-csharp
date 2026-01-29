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
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    public partial class QQ
    {
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
            var b = IsGetSuccessful(result, statusCode);
            if (!b) WriteLog.Error(LogKind.Http, "请求失败, 请重试");
            return result;
        }

        private static bool IsGetSuccessful(UserType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 200:
                    WriteLog.Info(LogKind.Network, $"请求成功");
                    return true;
                case 400:
                    WriteLog.Error(LogKind.Network, $"无效的请求, 缺少必要的参数");
                    break;
                case 404:
                    WriteLog.Error(LogKind.Network, $"获取QQ用户信息失败或用户不存在");
                    break;
                case 500:
                    WriteLog.Error(LogKind.Network,
                        $"服务器内部错误。在请求QQ数据时发生了未知问题, 错误代码: {General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.message}");
                    MessageBox_I.Error(
                        $"服务器内部错误。在请求QQ数据时发生了未知问题, 错误代码: {General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.message}",
                        _ERROR);
                    throw new General.UAPIServerDown();
                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"QQ上游服务异常, 错误代码: {IException.QQ._QQ_Service_Error}, 错误信息: {Type.code} - {Type.message}");
                    throw new IException.QQ.QQServiceError();
                default:
                    WriteLog.Error(LogKind.Network, $"未知异常, 请联系管理员, 错误代码: {_UNKNOW_ERROR}");
                    throw new General.UAPIUnknowException();
            }

            return false;
        }
    }
}