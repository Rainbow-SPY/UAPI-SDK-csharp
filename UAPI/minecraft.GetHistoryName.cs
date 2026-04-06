using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// 查询Minecraft玩家的历史昵称
        /// </summary>
        /// <param name="_param">昵称或UUID</param>
        /// <exception cref="UAPI.IException.minecraft.MojangAPIServiceError()"> Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</exception>
        /// <param name="searchType">指定以何种方式查询</param>
        /// <param name="Authentication">API Token</param>
        /// <returns></returns>
        public static async Task<HistoryType> GetHistoryName(string _param, SearchType searchType,
            string Authentication = "")
        {
            var (result, statusCode) = await Interface.GetResult<HistoryType>(
                $"{Interface._UAPI_Request_Url}game/minecraft/historyid?{searchType.ToString().ToLower()}={_param}",
                Authentication);
            var list = Interface.IsGetSuccessful(result, "name_or_uuid", statusCode,
                new IException.minecraft.MojangAPIServiceError(), "Mojang",
                IException.minecraft._Mojang_API_Service_Error);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败,请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 查询方式
        /// </summary>
        public enum SearchType
        {
            /// <summary>
            /// 以UUID查找
            /// </summary>
            UUID,

            /// <summary>
            /// 以昵称查找
            /// </summary>
            Name
        }
    }
}