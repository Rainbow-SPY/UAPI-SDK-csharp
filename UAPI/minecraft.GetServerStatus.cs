using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// 查询Minecraft游戏服务器
        /// </summary>
        /// <param name="server">服务器的IP地址或域名</param>
        /// <param name="Authentication">API Token</param>
        /// <exception cref="UAPI.IException.minecraft.MojangAPIServiceError()"> Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</exception>
        /// <returns><see cref="ServerType"/> 对象</returns>
        public static async Task<ServerType> GetServerStatus(string server, string Authentication = "") =>
            await GetServerStatus(server, -1, Authentication);

        /// <summary>
        /// 查询Minecraft游戏服务器
        /// </summary>
        /// <param name="server">服务器的IP地址或域名</param>
        /// <exception cref="UAPI.IException.minecraft.MojangAPIServiceError()"> Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</exception>
        /// <returns><see cref="ServerType"/> 对象</returns>
        public static async Task<ServerType> GetServerStatus(string server) => await GetServerStatus(server, -1, "");

        /// <summary>
        /// 查询Minecraft游戏服务器
        /// </summary>
        /// <param name="server">服务器的IP地址或域名</param>
        /// <param name="port">端口号</param>
        /// <param name="Authentication">API Token</param>
        /// <exception cref="UAPI.IException.minecraft.MojangAPIServiceError()"> Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</exception>
        /// <returns><see cref="ServerType"/> 对象</returns>
        public static async Task<ServerType> GetServerStatus(string server, int port = 25565,
            string Authentication = "")
        {
            var (result, statusCode) = await Interface.GetResult<ServerType>(
                $"{Interface._UAPI_Request_Url}game/minecraft/serverstatus?server={server}{(port == -1 ? "" : $":{port}")}",
                Authentication);
            if (!Interface.IsGetSuccessful(result, "server", statusCode,
                    new IException.minecraft.MojangAPIServiceError(), "Mojang",
                    IException.minecraft._Mojang_API_Service_Error)) LogLibraries.WriteLog.Error("请求失败,请重试!");
            return result;
        }
    }
}