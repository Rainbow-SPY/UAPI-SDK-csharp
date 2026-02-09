using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// 查询Minecraft游戏服务器
        /// </summary>
        /// <param name="server">服务器的IP地址或域名</param>
        /// <returns><see cref="ServerType"/> 对象</returns>
        public static async Task<ServerType> GetServerStatus(string server) => await GetServerStatus(server, -1);

        /// <summary>
        /// 查询Minecraft游戏服务器
        /// </summary>
        /// <param name="server">服务器的IP地址或域名</param>
        /// <param name="port">端口号</param>
        /// <returns><see cref="ServerType"/> 对象</returns>
        public static async Task<ServerType> GetServerStatus(string server, int port = 25565)
        {
            var (result, statusCode) = await Interface.GetResult<ServerType>(
                $"https://uapis.cn/api/v1/game/minecraft/serverstatus?server={server}{(port == -1 ? "" : $":{port}")}");
            if (!Interface.IsGetSuccessful<ServerType>(result, "server", statusCode,
                    new IException.minecraft.MojangAPIServiceError(), "Mojang",
                    IException.minecraft._Mojang_API_Service_Error)) LogLibraries.WriteLog.Error("请求失败,请重试!");
            return result;
        }
    }
}