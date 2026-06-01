using System.Threading.Tasks;
using UAPI.IException;
using static Rox.Runtimes.LogLibraries;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>图像处理接口</summary>
    public partial class Image
    {
        #region BingDaily MetaJsonData

        private static async Task<BingDailyType> GetBingDailyMetaJsonData(string date, bool random = false,
            BingDailyType.Resolutions resolution = BingDailyType.Resolutions._4K, string Authentication = "")
        {
            var (result, statuscode) = await GetResult<BingDailyType>(
                $"{_UAPI_Request_Url}image/bing-daily?date={date}&random={random}&resolution={resolution.ToString().Remove(0, 1)}&format=json",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "", statuscode, new General.UAPIUnknowException(), "Image.GetBingDaily");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 获取必应每日壁纸
        /// </summary>
        /// <param name="date">指定获取日期的当天壁纸, 为空则返回今天的壁纸</param>
        /// <param name="resolutions">指定返回图像的分辨率, 默认4K, 可选 1080P</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="BingDailyType"/>对象</returns>
        public static async Task<BingDailyType> GetBingDailyMetaJsonData(string date,
            BingDailyType.Resolutions resolutions = BingDailyType.Resolutions._4K,
            string Authentication = "")
            => await GetBingDailyMetaJsonData(date, false, resolutions, Authentication);

        /// <summary>
        /// 获取必应每日壁纸
        /// </summary>
        /// <param name="random">指定是否每次请求随机返回一张历史壁纸。false则默认返回今天的壁纸</param>
        /// <param name="resolutions">指定返回图像的分辨率, 默认4K, 可选 1080P</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="BingDailyType"/>对象</returns>
        public static async Task<BingDailyType> GetBingDailyMetaJsonData(bool random = false,
            BingDailyType.Resolutions resolutions = BingDailyType.Resolutions._4K, string Authentication = "")
            => await GetBingDailyMetaJsonData("", random, resolutions, Authentication);

        #endregion

        #region BingDaily Image byte[]

        private static async Task<byte[]> GetBingDailyImage(string date, bool random = false,
            BingDailyType.Resolutions resolution = BingDailyType.Resolutions._4K,
            BingDailyType.Format _format = BingDailyType.Format.image, string Authentication = "")
        {
            var (result, statuscode) = await GetBytesResult(
                $"{_UAPI_Request_Url}image/bing-daily?date={date}&random={random}&resolution={resolution.ToString().Remove(0, 1)}&format={_format.ToString()}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetBytesSuccessful(result, "date", statuscode,
                new General.UAPIUnknowException(), "Image.GetBingDailyImage");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }

        /// <summary>
        /// 获取必应每日壁纸
        /// </summary>
        /// <param name="date">指定获取日期的当天壁纸, 为空则返回今天的壁纸</param>
        /// <param name="resolutions">指定返回图像的分辨率, 默认4K, 可选 1080P</param>
        /// <param name="_format">指定返回的格式, 默认二进制byte[], 可选302重定向后的图片URL的二进制byte[]</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="BingDailyType"/>对象</returns>
        public static async Task<byte[]> GetBingDailyImage(string date,
            BingDailyType.Resolutions resolutions = BingDailyType.Resolutions._4K,
            BingDailyType.Format _format = BingDailyType.Format.image,
            string Authentication = "")
            => await GetBingDailyImage(date, false, resolutions, _format, Authentication);

        /// <summary>
        /// 获取必应每日壁纸
        /// </summary>
        /// <param name="random">指定是否每次请求随机返回一张历史壁纸。false则默认返回今天的壁纸</param>
        /// <param name="resolutions">指定返回图像的分辨率, 默认4K, 可选 1080P</param>
        /// <param name="_format">指定返回的格式, 默认二进制byte[], 可选302重定向后的图片URL的二进制byte[]</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="BingDailyType"/>对象</returns>
        public static async Task<byte[]> GetBingDailyImage(bool random = false,
            BingDailyType.Resolutions resolutions = BingDailyType.Resolutions._4K,
            BingDailyType.Format _format = BingDailyType.Format.image, string Authentication = "")
            => await GetBingDailyImage("", random, resolutions, _format, Authentication);

        #endregion

        #region BingDaily History

        /// <summary>
        /// 获取必应每日壁纸历史列表
        /// </summary>
        /// <param name="date">指定日期精确查询 (YYYY-MM-DD)，传此参数时 page/pageSize 不生效</param>
        /// <param name="resolution">指定返回图像的分辨率，默认 4K</param>
        /// <param name="page">页码，默认 1</param>
        /// <param name="pageSize">每页数量，默认 30，最大 100</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="BingDailyHistoryType"/> 对象</returns>
        public static async Task<BingDailyHistoryType> GetBingDailyHistory(string date = "",
            BingDailyType.Resolutions resolution = BingDailyType.Resolutions._4K,
            int page = 1, int pageSize = 30, string Authentication = "")
        {
            var url =
                $"{_UAPI_Request_Url}image/bing-daily/history?resolution={resolution.ToString().Remove(0, 1)}&page={page}&page_size={pageSize}&format=json";
            if (!string.IsNullOrWhiteSpace(date))
                url += $"&date={date}";

            var (result, statuscode) = await GetResult<BingDailyHistoryType>(
                url,
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "date", statuscode, new General.UAPIUnknowException(),
                "Image.GetBingDailyHistory");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        #endregion
    }
}