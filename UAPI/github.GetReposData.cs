using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    /// <summary>
    /// 查询github相关数据
    /// </summary>
    public partial class github
    {
        internal const string _UAPI_Request_Url = @"https://uapis.cn/api/v1/github/";

        /// <summary>
        /// 获取github仓库数据
        /// </summary>
        /// <param name="owner_and_repo">所有者+仓库(owner/repo)</param>
        /// <returns><see cref="ReposType"/> 对象</returns>
        public static async Task<ReposType> GetReposData(string owner_and_repo)
        {
            var (result, statusCode) =
                await Interface.GetResult<ReposType>($"{_UAPI_Request_Url}repo?repo={owner_and_repo}");
            if (!Interface.IsGetSuccessful(result, "owner_and_repo", statusCode,
                    new IException.github.GithubAPIServiceError(), "Github", IException.github._Github_ServiceError))
                LogLibraries.WriteLog.Error("请求失败,请重试");
            return result;
        }
    }
}