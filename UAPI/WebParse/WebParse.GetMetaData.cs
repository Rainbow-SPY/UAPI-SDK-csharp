using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 网页解析 - Web 页面元数据与内容提取接口
    /// </summary>
    public partial class WebParse
    {
        /// <summary>
        /// 提取网页元数据 (GET)
        /// </summary>
        /// <param name="url">网页 URL</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WebParseMetaDataType"/> 对象</returns>
        public static async Task<WebParseMetaDataType> GetWebPageMetadata(string url,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url cannot be null or empty", nameof(url));

            var (result, statuscode) = await GetResult<WebParseMetaDataType>(
                $"{_UAPI_Request_Url}webparse/metadata?url={Uri.EscapeDataString(url)}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "url", statuscode,
                new General.UAPIUnknowException(), "WebParse.GetWebPageMetadata");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 网页元数据类型
        /// </summary>
        public class WebParseMetaDataType : TypeInterface
        {
            /// <summary>
            /// 实际解析的网页地址
            /// </summary>
            [JsonProperty("page_url")]
            public string PageUrl { get; set; }

            /// <summary>
            /// 网页标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 网页描述
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// 关键词列表
            /// </summary>
            [JsonProperty("keywords")]
            public List<string> Keywords { get; set; }

            /// <summary>
            /// 网站图标 URL
            /// </summary>
            [JsonProperty("favicon_url")]
            public string FaviconUrl { get; set; }

            /// <summary>
            /// 页面语言
            /// </summary>
            [JsonProperty("language")]
            public string Language { get; set; }

            /// <summary>
            /// 作者
            /// </summary>
            [JsonProperty("author")]
            public string Author { get; set; }

            /// <summary>
            /// 发布时间
            /// </summary>
            [JsonProperty("published_time")]
            public string PublishedTime { get; set; }

            /// <summary>
            /// 规范 URL
            /// </summary>
            [JsonProperty("canonical_url")]
            public string CanonicalUrl { get; set; }

            /// <summary>
            /// 生成工具
            /// </summary>
            [JsonProperty("generator")]
            public string Generator { get; set; }

            /// <summary>
            /// Open Graph 元数据（键值对，如 og:title、og:image 等）
            /// </summary>
            [JsonProperty("open_graph")]
            public Dictionary<string, string> OpenGraph { get; set; }
        }
    }
}
