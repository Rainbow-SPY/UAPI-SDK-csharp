using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;

namespace UAPI
{
    /// <summary/>
    public partial class Image
    {
        /// <summary>
        /// 获取每日新闻图片 (GET)
        /// </summary>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>新闻图片二进制 (JPEG)</returns>
        public static async Task<byte[]> GetDailyNews(string Authentication = "")
        {
            var (result, statuscode) = await GetBytesResult(
                $"{_UAPI_Request_Url}daily/news-image",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetBytesSuccessful(result, "", statuscode,
                new General.UAPIUnknowException(), "Image.GetDailyNews");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }
}
