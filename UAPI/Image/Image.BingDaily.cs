using static Rox.Runtimes.LogLibraries;
using static UAPI.Interface;
using static UAPI.Type;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UAPI.IException;

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
            var url = $"{_UAPI_Request_Url}image/bing-daily/history?resolution={resolution.ToString().Remove(0, 1)}&page={page}&page_size={pageSize}&format=json";
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

    public partial class Type
    {
        /// <summary/>
        public class BingDailyType : TypeInterface
        {
            /// <summary/>
            public enum Format
            {
                /// <summary>
                /// 返回图片二进制
                /// </summary>
                image,

                /// <summary>
                /// 302重定向到图像二进制 (返回仍然是 <see langword="byte[]"/> )
                /// </summary>
                redirect
            }

            /// <summary/>
            public enum Resolutions
            {
                /// <summary/>
                _4K,

                /// <summary/>
                _1080P
            }

            /// <summary>
            /// 图像的日期
            /// </summary>
            [JsonProperty("date")]
            public string Date { get; set; }

            /// <summary>
            /// 区域
            /// </summary>
            [JsonProperty("market")]
            public string MarketLanguage { get; set; }

            /// <summary>
            /// 图片标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 子标题
            /// </summary>
            [JsonProperty("subtitle")]
            public string Subtitle { get; set; }

            /// <summary>
            /// 子标题
            /// </summary>
            [JsonProperty("headline")]
            public string Headline { get; set; }

            /// <summary>
            /// 图像描述
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// 版权所有者
            /// </summary>
            [JsonProperty("copyright")]
            public string Copyright { get; set; }

            /// <summary>
            /// 版权详情链接
            /// </summary>
            [JsonProperty("copyright_link")]
            public string CopyrightLink { get; set; }

            /// <summary/>
            [JsonProperty("quiz_id")]
            public string quiz_id { get; set; }

            /// <summary>
            /// 分辨率
            /// </summary>
            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            /// <summary>
            /// 图像的原始URL
            /// </summary>
            [JsonProperty("image_url")]
            public string Link { get; set; }

            /// <summary>
            /// 图像的4K分辨率地址URL
            /// </summary>
            [JsonProperty("image_url_4k")]
            public string Link_4K { get; set; }

            /// <summary>
            /// 图像的1080P分辨率地址URL
            /// </summary>
            [JsonProperty("image_url_1080")]
            public string Link_1080P { get; set; }

            /// <summary>
            /// 拉取时间
            /// </summary>
            [JsonProperty("fetched_at")]
            public string FetchTime_ISO8601 { get; set; }

            /// <summary>
            /// 最后的更新时间
            /// </summary>
            [JsonProperty("updated_at")]
            public string LastUpdateTime_ISO8601 { get; set; }

            /// <summary>
            /// 小知识问答（仅历史列表返回）
            /// </summary>
            [JsonProperty("trivia")]
            public BingTriviaType Trivia { get; set; }
        }

        /// <summary>
        /// 必应每日壁纸小知识问答
        /// </summary>
        public class BingTriviaType
        {
            /// <summary>
            /// 问题
            /// </summary>
            [JsonProperty("question")]
            public string Question { get; set; }

            /// <summary>
            /// 选项列表
            /// </summary>
            [JsonProperty("options")]
            public System.Collections.Generic.List<BingTriviaOptionType> Options { get; set; }
        }

        /// <summary>
        /// 必应每日壁纸小知识问答选项
        /// </summary>
        public class BingTriviaOptionType
        {
            /// <summary>
            /// 选项标识（A、B、C）
            /// </summary>
            [JsonProperty("bullet")]
            public string Bullet { get; set; }

            /// <summary>
            /// 选项文本
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// 选项链接
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        /// <summary>
        /// 必应壁纸历史列表响应
        /// </summary>
        public class BingDailyHistoryType : TypeInterface
        {
            /// <summary>
            /// 分辨率
            /// </summary>
            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            /// <summary>
            /// 历史壁纸列表
            /// </summary>
            [JsonProperty("items")]
            public System.Collections.Generic.List<BingDailyType> Items { get; set; }

            /// <summary>
            /// 分页信息
            /// </summary>
            [JsonProperty("pagination")]
            public BingDailyPaginationType Pagination { get; set; }
        }

        /// <summary>
        /// 必应壁纸历史分页信息
        /// </summary>
        public class BingDailyPaginationType
        {
            /// <summary>
            /// 当前页码
            /// </summary>
            [JsonProperty("page")]
            public int Page { get; set; }

            /// <summary>
            /// 每页数量
            /// </summary>
            [JsonProperty("page_size")]
            public int PageSize { get; set; }

            /// <summary>
            /// 总记录数
            /// </summary>
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
}