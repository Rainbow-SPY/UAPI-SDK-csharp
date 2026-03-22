using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    /// <summary>
    /// 查询github相关数据
    /// </summary>
    public partial class github
    {
        /// <summary>
        /// 获取github仓库数据
        /// </summary>
        /// <param name="owner_and_repo">所有者+仓库(owner/repo)</param>
        /// <param name="Authentication">API Token</param>
        /// <exception cref="UAPI.IException.github.GithubAPIServiceError()">Github 上游服务异常, 这可能是他们的服务暂时中断.</exception>
        /// <returns><see cref="ReposType"/> 对象</returns>
        public static async Task<ReposType> GetReposData(string owner_and_repo, string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<ReposType>($"{Interface._UAPI_Request_Url}github/repo?repo={owner_and_repo}",
                    Authentication);
            if (!Interface.IsGetSuccessful(result, "owner_and_repo", statusCode,
                    new IException.github.GithubAPIServiceError(), "Github", IException.github._Github_ServiceError))
                LogLibraries.WriteLog.Error("请求失败,请重试");
            return result;
        }
    }
}