using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary/>
    public partial class IConvert
    {
        /// <summary/>
        public static class Image
        {
            /// <inheritdoc cref="UAPI.Image.PostSVGConvertToBitImage"/>
            public static async Task<byte[]> ToSVG(byte[] svg,
                SVGConvertType.SVGFormat format = SVGConvertType.SVGFormat.png,
                int? width = null, int? height = null,
                int quality = 90,
                string Authentication = "") =>
                await UAPI.Image.PostSVGConvertToBitImage(svg, format, width, height, quality, Authentication);
        }

        /// <summary>
        /// 网页转 Markdown（提交任务并等待结果）
        /// </summary>
        /// <param name="url">需要转换的网页 URL</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>转换后的 Markdown 文本</returns>
        public static async Task<string> WebToMarkdown(string url,
            string Authentication = "")
        {
            var task = await WebParse.PostWebToMarkdownAsync(url, Authentication);

            // 轮询等待任务完成
            var retries = 0;
            while (task.Status == "queued" || task.Status == "processing")
            {
                if (retries++ >= 30)
                    throw new General.UAPIUnknowException("转换任务超时");

                await Task.Delay(1000);
                task = await WebParse.GetWebToMarkdownResult(task.TaskId, Authentication);
            }

            if (task.Status == "failed")
                throw new General.UAPIUnknowException($"转换任务失败: {task.Message}");

            return task.Result?.Markdown ?? "";
        }

        /// <summary>
        /// Unix 时间戳转日期时间 (GET)
        /// </summary>
        /// <param name="time">Unix 时间戳（10位或13位）或标准日期字符串（如 2023-10-27 10:30:00）</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="UnixTimeConvertType"/> 对象</returns>
        public static async Task<UnixTimeConvertType> UnixToTimedate(string time,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(time))
                throw new ArgumentException("time cannot be null or empty", nameof(time));

            var (result, statuscode) = await GetResult<UnixTimeConvertType>(
                $"{_UAPI_Request_Url}convert/unixtime?time={Uri.EscapeDataString(time)}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "time", statuscode,
                new General.UAPIUnknowException(), "IConvert.UnixToTimedate");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// JSON 格式化 (POST)
        /// </summary>
        /// <param name="json">需要格式化的原始 JSON 字符串</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>格式化后的 <see cref="JsonConvertType"/> 对象</returns>
        public static async Task<JsonConvertType> FormatJson(string json,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("json cannot be null or empty", nameof(json));

            var requestBody = new { content = json };
            var jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

            var (result, statuscode) = await GetResult<JsonConvertType>(
                $"{_UAPI_Request_Url}convert/json",
                SendRequestType.POST, jsonBody, "application/json", Authentication);
            var list = IsGetSuccessful(result, "json", statuscode,
                new General.UAPIUnknowException(), "IConvert.FormatJson");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// Unix 时间戳转换类型
        /// </summary>
        public class UnixTimeConvertType : TypeInterface
        {
            /// <summary>
            /// 标准格式（YYYY-MM-DD HH:mm:ss）的日期时间字符串
            /// </summary>
            [JsonProperty("datetime")]
            public string DateTime { get; set; }

            /// <summary>
            /// 转换后的 10 位秒级 Unix 时间戳
            /// </summary>
            [JsonProperty("timestamp")]
            public int Timestamp { get; set; }
        }

        /// <summary>
        /// JSON 格式化类型
        /// </summary>
        public class JsonConvertType : TypeInterface
        {
            /// <summary>
            /// 格式化后的 JSON 字符串，带有标准缩进和换行
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }
}