using System.Threading.Tasks;

namespace UAPI
{
    /// <summary>
    /// Minecraft 相关请求
    /// </summary>
    public partial class minecraft
    {
        internal const string requestUrl = @"https://uapis.cn/api/v1/game/minecraft/userinfo";

        public static async Task<UserType> GetUserData(string username)
        {
            var (result, statusCode) = await Interface.GetResult<UserType>($"{requestUrl}?username={username}");
            
        }
    }
}