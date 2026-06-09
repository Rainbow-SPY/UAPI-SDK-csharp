using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// Minecraft 相关请求
    /// </summary>
    public partial class Minecraft
    {
        /// <summary>
        /// 获取 Minecraft 正版 Mojang 账号的数据
        /// </summary>
        /// <param name="username">Minecraft 用户名</param>
        /// <param name="Authentication">API Token</param>
        /// <exception cref="UAPI.IException.minecraft.MojangAPIServiceError()"> Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</exception>
        /// <returns><see cref="minecraftUserType"/> 对象</returns>
        public static async Task<minecraftUserType> GetUserData(string username, string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<minecraftUserType>(
                    $"{Interface._UAPI_Request_Url}game/minecraft/userinfo?username={username}", Authentication);
            var list = Interface.IsGetSuccessful(result, "owner_and_repo", statusCode,
                new IException.minecraft.MojangAPIServiceError(), "Mojang",
                IException.minecraft._Mojang_API_Service_Error);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// <see cref="Minecraft.GetUserData"/> 返回的属性列表
        /// </summary>
        public class minecraftUserType : TypeInterface
        {
            /// <summary>
            /// 用户名
            /// </summary>
            [JsonProperty("username")]
            public string UserName { get; set; }

            /// <summary>
            /// 玩家的32位无破折号UUID
            /// </summary>
            [JsonProperty("uuid")]
            public string UUID { get; set; }

            /// <summary>
            /// 玩家当前使用的皮肤图片URL
            /// </summary>
            [JsonProperty("skin_url")]
            public string SkinImageUrl { get; set; }
        }
    }
}