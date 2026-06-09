using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    public partial class Steam
    {
        /// <summary>
        /// 查询 Steam 游戏服务器
        /// </summary>
        /// <param name="appid">指定要进行查询的Steam AppID</param>
        /// <param name="query">查询的关键词</param>
        /// <param name="count">根据关键词返回的服务器数量</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="SteamServers"/> 对象</returns>
        /// <exception cref="UAPI.IException.Steam.SteamServiceError"></exception>
        public static async Task<SteamServers> FindServers(string appid, string query, int count,
            string Authentication = "")
        {
            var (result, statuscode) = await Interface.GetResult<SteamServers>(
                $"{Interface._UAPI_Request_Url}game/steam/servers?appid={appid}&query={query}&limit={count}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "id", statuscode,
                new IException.Steam.SteamServiceError(), "Steam.FindServers");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        // 扩展方法
        /// <summary>
        /// 通过 Steam 启动连接到游戏服务器
        /// </summary>
        /// <param name="ip">游戏服务器的IP地址</param>
        /// <param name="port">游戏服务器的端口</param>
        public static void StartSteamLink(string ip, string port) =>
            new Process
            {
                StartInfo =
                {
                    UseShellExecute = false, FileName = "explorer.exe", Arguments = $"steam://connect/{ip}:{port}"
                }
            }.Start();
    }
}