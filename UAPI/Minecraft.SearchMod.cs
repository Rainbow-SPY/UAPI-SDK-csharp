using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Minecraft
    {
        /// <summary>
        /// 搜索 MC Mod/插件
        /// </summary>
        /// <param name="query">搜索关键词，也可使用别名 q。</param>
        /// <param name="source">搜索来源，默认 all。</param>
        /// <param name="type">资源类型过滤，例如 mod 或 plugin。</param>
        /// <param name="limit">每个来源返回的最大条数，默认 10，最大 50。</param>
        /// <param name="entich">是否补全下载直链与作者名，默认 true；传 false 可降低延迟。</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.MinecraftSearchMods"/></returns>
        /// <exception cref="General.UAPIServiceUnavailable"></exception>
        public static async Task<Type.MinecraftSearchMods> SearchMods(string query,
            Type.MinecraftSearchMods.Source source = Type.MinecraftSearchMods.Source.all, string type = "",
            int limit = 10,
            bool entich = true, string Authentication = "")
        {
            var (result, statuscode) = await Interface.GetResult<Type.MinecraftSearchMods>(
                $"{Interface._UAPI_Request_Url}game/minecraft/mods?query={query}&source={source.ToString()}&type={type}&enrich={entich}",
                Interface.SendRequestType.GET, "", "application/json", Authentication);
            var list = Interface.IsGetSuccessful(result, "id", statuscode,
                new General.UAPIServiceUnavailable(), "Clipzy.GetClipzyData");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}