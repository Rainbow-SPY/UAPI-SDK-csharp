using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        /// 提交网页转 Markdown 任务 (POST)
        /// </summary>
        /// <param name="url">需要转换的网页 URL</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WebParseToMarkdownType"/> 对象</returns>
        public static async Task<WebParseToMarkdownType> PostWebToMarkdownAsync(string url,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url cannot be null or empty", nameof(url));

            var (result, statuscode) = await GetResult<WebParseToMarkdownType>(
                $"{_UAPI_Request_Url}web/tomarkdown/async?url={Uri.EscapeDataString(url)}",
                SendRequestType.POST, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "url", statuscode,
                new General.UAPIUnknowException(), "WebParse.PostWebToMarkdownAsync");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 查询网页转 Markdown 任务结果 (GET)
        /// </summary>
        /// <param name="taskId">任务 ID（由提交接口返回）</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WebParseToMarkdownType"/> 对象</returns>
        public static async Task<WebParseToMarkdownType> GetWebToMarkdownResult(string taskId,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(taskId))
                throw new ArgumentException("taskId cannot be null or empty", nameof(taskId));

            var (result, statuscode) = await GetResult<WebParseToMarkdownType>(
                $"{_UAPI_Request_Url}web/tomarkdown/async/{Uri.EscapeDataString(taskId)}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "taskId", statuscode,
                new General.UAPIUnknowException(), "WebParse.GetWebToMarkdownResult");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 网页转 Markdown 类型
        /// </summary>
        public class WebParseToMarkdownType : TypeInterface
        {
            /// <summary>
            /// 任务唯一标识符
            /// </summary>
            [JsonProperty("task_id")]
            public string TaskId { get; set; }

            /// <summary>
            /// 任务状态（queued / processing / completed / failed）
            /// </summary>
            [JsonProperty("status")]
            public string Status { get; set; }

            /// <summary>
            /// 要转换的 URL
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// 网页标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 任务创建时间（ISO 8601）
            /// </summary>
            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            /// <summary>
            /// 任务完成时间（ISO 8601）
            /// </summary>
            [JsonProperty("completed_at")]
            public string CompletedAt { get; set; }

            /// <summary>
            /// 进度百分比（0-100）
            /// </summary>
            [JsonProperty("progress")]
            public int Progress { get; set; }

            /// <summary>
            /// 提示信息
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// 转换耗时（毫秒）
            /// </summary>
            [JsonProperty("duration_ms")]
            public long DurationMs { get; set; }

            /// <summary>
            /// Markdown 转换结果
            /// </summary>
            [JsonProperty("result")]
            public MarkdownResultBody Result { get; set; }
        }

        /// <summary>
        /// Markdown 结果数据
        /// </summary>
        public class MarkdownResultBody
        {
            /// <summary>
            /// 转换后的 Markdown 文本
            /// </summary>
            [JsonProperty("markdown")]
            public string Markdown { get; set; }

            /// <summary>
            /// 结果大小（字节）
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }
        }
    }
}
