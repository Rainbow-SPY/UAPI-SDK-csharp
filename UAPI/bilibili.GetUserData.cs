//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 22:02
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for redirecting Bilibili API through a third-party interface.
//  Now Play:       Ave Mujica - アヴェムジカ (Ave Mujica)

using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class bilibili
    {
        public static async Task<UserType> GetUserData(string uid)
        {
            var (result, statuscode) = await Interface.GetResult<UserType>($"{requestUrl_Main}userinfo?uid={uid}");
            var a = IsGetSuccessful(result, statuscode);
            if (!a) LogLibraries.WriteLog.Info("请求错误,请重试");
            return result;
        }

        private static bool IsGetSuccessful(UserType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("uid")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}");
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}");
                    throw new IException.General.UAPIServerDown();
                case 404:
                    LogLibraries.WriteLog.Warning("未找到用户");
                    break;
                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"bilibili API请求错误, 错误代码: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.code} - {Type.details}");
                    throw new IException.bilibili.BilibiliServiceError();
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制限制请求, 因 请求量过大.");
                    break;
                case -1:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    break;
                default:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Http, "未知错误");
                    break;
            }

            return false;
        }
    }
}