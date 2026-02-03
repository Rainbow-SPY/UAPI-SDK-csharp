//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 22:46
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for redirecting Bilibili API through a third-party interface.
//  Now Play:       Ave Mujica - KiLLKiSS


using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 查询B站用户的稿件
        /// </summary>
        /// <param name="mid">用户的 UID</param>
        /// <param name="keywords">查询关键字</param>
        /// <param name="orderby">以何种方式排列</param>
        /// <param name="ps">每页的条数,默认20</param>
        /// <param name="pn">页码,默认1</param>
        /// <returns><see cref="ArchiveType"/> 对象</returns>
        public static async Task<ArchiveType> GetArchives(string mid,
            ArchivesSearchType orderby = ArchivesSearchType.Pubdate, string keywords = "",
            int ps = 20, int pn = 1)
        {
            var (result, statusCode) = await Interface.GetResult<ArchiveType>(
                $"{requestUrl_Main}archives?mid={mid}&orderby={orderby}&ps={ps}&pn={pn}&keywords={keywords}");
            if (!IsGetSuccessful(result, statusCode)) LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }

        /// <summary>
        /// 以何种方式查询
        /// </summary>
        public enum ArchivesSearchType
        {
            /// <summary>
            /// 以最新投稿排列
            /// </summary>
            Pubdate,

            /// <summary>
            /// 以播放量最高排列
            /// </summary>
            Views
        }

        private static bool IsGetSuccessful(ArchiveType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("mid 或 room_id")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, 错误代码: {IException.General._UAPI_Server_Down}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    throw new IException.General.UAPIServerDown();

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"bilibili API请求错误, 错误码: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.code} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"bilibili API请求错误, 错误码: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.code} - {Type.details}",
                        _ERROR);
                    throw new IException.bilibili.BilibiliServiceError();
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制限制请求, 因 请求量过大.");
                    LogLibraries.MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    LogLibraries.WriteLog.Warning("未找到用户");
                    LogLibraries.MessageBox_I.Warning("未找到用户", _ERROR);
                    break;
                case -1:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    LogLibraries.MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    break;
                default:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http, "未知错误");
                    LogLibraries.MessageBox_I.Error("发生了未知错误", _ERROR);
                    break;
            }

            return false;
        }
    }
}