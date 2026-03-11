using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 获取 bilibili 视频评论区
        /// </summary>
        /// <param name="oid">目标评论区的ID。对于视频，这通常就是它的 aid/bvid </param>
        /// <param name="sort">排序方式。支持 0/time(按时间)、1/like(按点赞)、2/reply(按回复数)、3/hot/hottest/最热(按最热)。默认为 0/time。</param>
        /// <param name="ps">每页获取的评论数量，范围是1到20。默认为 20。</param>
        /// <param name="pn">要获取的页码，从1开始。默认为 1。</param>
        /// <param name="Authentication">API Token</param>
        /// <returns><see cref="RepliesListType"/> 对象</returns>
        public static async Task<RepliesListType> GetRepliesList(string oid, string sort = "0", int ps = 20, int pn = 1,
            string Authentication = "")
        {
            var (result, statusCode) = await Interface.GetResult<RepliesListType>(
                $"{requestUrl_Main}replies?oid={oid}&sort={sort}&ps={ps}&pn={pn}", Authentication);
            if (!Interface.IsGetSuccessful(result, "oid", statusCode, new IException.bilibili.BilibiliServiceError(),
                    "bilibili replies", IException.bilibili._Bilibili_Service_Error))
                LogLibraries.WriteLog.Error("请求错误, 请重试");
            return result;
        }
    }
}