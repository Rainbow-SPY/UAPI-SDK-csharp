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
        /// <summary>
        /// 获取bilibili用户的相关公开数据
        /// </summary>
        /// <param name="uid">bilibili UUID</param>
        /// <returns><see cref="UserType"/> 对象</returns>
        public static async Task<UserType> GetUserData(string uid)
        {
            var (result, statuscode) = await Interface.GetResult<UserType>($"{requestUrl_Main}userinfo?uid={uid}");
            if (!Interface.IsGetSuccessful<UserType>(result, "uid", statuscode, new IException.bilibili.BilibiliServiceError(),
                    "bilibili", IException.bilibili._Bilibili_Service_Error)) LogLibraries.WriteLog.Info("请求错误,请重试");
            return result;
        }
    }
}