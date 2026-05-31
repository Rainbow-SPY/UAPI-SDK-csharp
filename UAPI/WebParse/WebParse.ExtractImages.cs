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
    /// <summary/>
    public partial class WebParse
    {
        /// <summary>
        /// 提取网页图片 (GET)
        /// </summary>
        /// <param name="url">网页 URL</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WebParseExtractImagesType"/> 对象</returns>
        public static async Task<WebParseExtractImagesType> GetWebPageImages(string url,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url cannot be null or empty", nameof(url));

            var (result, statuscode) = await GetResult<WebParseExtractImagesType>(
                $"{_UAPI_Request_Url}webparse/extractimages?url={Uri.EscapeDataString(url)}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "url", statuscode,
                new General.UAPIUnknowException(), "WebParse.GetWebPageImages");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 网页图片提取类型
        /// </summary>
        public class WebParseExtractImagesType : TypeInterface
        {
            /// <summary>
            /// 实际解析的网页地址
            /// </summary>
            [JsonProperty("page_url")]
            public string PageUrl { get; set; }

            /// <summary>
            /// 页面中提取到的图片链接列表
            /// </summary>
            [JsonProperty("image_urls")]
            public List<string> ImageUrls { get; set; }
        }
    }
}
