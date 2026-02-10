using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    /// <summary>
    /// Minecraft 相关请求
    /// </summary>
    public partial class minecraft
    {
        internal const string requestUrl = @"https://uapis.cn/api/v1/game/minecraft/userinfo";

        /// <summary>
        /// 获取 Minecraft 正版 Mojang 账号的数据
        /// </summary>
        /// <param name="username">Minecraft 用户名</param>
        /// <returns><see cref="UserType"/> 对象</returns>
        public static async Task<UserType> GetUserData(string username)
        {
            var (result, statusCode) = await Interface.GetResult<UserType>($"{requestUrl}?username={username}");
            if (!Interface.IsGetSuccessful(result, "owner_and_repo", statusCode,
                    new IException.minecraft.MojangAPIServiceError(), "Mojang",
                    IException.minecraft._Mojang_API_Service_Error))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}