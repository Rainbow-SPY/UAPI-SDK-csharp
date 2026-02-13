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
        /// <returns></returns>
        public static async Task<HistoryType> GetHistoryName(string _param, SearchType searchType)
        {
            var (result, statusCode) = await Interface.GetResult<HistoryType>(
                $"https://uapis.cn/api/v1/game/minecraft/historyid?{searchType.ToString().ToLower()}={_param}");
            if (!Interface.IsGetSuccessful(result, "name_or_uuid", statusCode,
                    new IException.minecraft.MojangAPIServiceError(), "Mojang",
                    IException.minecraft._Mojang_API_Service_Error))
                LogLibraries.WriteLog.Error("请求失败,请重试!");
            return result;
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
            Name,
        }
    }
}