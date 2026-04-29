using System.Threading.Tasks;
using Newtonsoft.Json;
using UAPI.IException;
using static Rox.Runtimes.LogLibraries;
using static Rox.Runtimes.LocalizedString;
using static UAPI.Type;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// Markdown 相关接口
        /// </summary>
        public class Markdown
        {
            /// <summary>
            /// 将 Markdown 文本转为带样式的 HTML
            /// </summary>
            public class ToHTML
            {
                /// <summary>
                /// 把 Markdown 文本转换成带样式的 HTML
                /// </summary>
                /// <param name="_text">原始 Markdown 字符串，最大不超过 1MB。</param>
                /// <param name="_sanitize">是否开启安全模式，过滤掉用户输入中的风险脚本。默认是 true。</param>
                /// <param name="Authentication">API Token Key</param>
                /// <returns><see cref="Type.MarkdownType"/>对象</returns>
                public static async Task<MarkdownType> ReturnedJson(string _text, bool _sanitize = true,
                    string Authentication = "") =>
                    await GetValue(_text, Format.json, _sanitize, Authentication);

                private static async Task<MarkdownType> GetValue(string _text,
                    Format _format, bool _sanitize = true,
                    string Authentication = "")
                {
                    var (result, statusCode) = await Interface.GetResult<MarkdownType>(
                        $"{Interface._UAPI_Request_Url}text/markdown-to-html",
                        Interface.SendRequestType.POST, JsonConvert.SerializeObject(new
                        {
                            text = _text,
                            format = _format.ToString(),
                            sanitize = _sanitize
                        }), "application/json", Authentication);
                    var failedList = Interface.IsGetSuccessful(result, "text", statusCode,
                        new General.UAPIUnknowException(),
                        "Text.Markdown.ToHTMLReturnedHTMLCode");
                    if (!failedList.IsRequestSuccessfully)
                        WriteLog.Error(
                            $"请求错误, 请重试!\n\t返回值: {failedList.StatusCode}\n\t错误信息: {failedList.FailedReason}");
                    return failedList.FailedException != null ? throw failedList.FailedException : result;
                }

                /// <summary>
                /// 把 Markdown 文本转换成带样式的 HTML
                /// </summary>
                /// <remarks>此方法直接返回 HTML 源代码</remarks>
                /// <param name="_text"></param>
                /// <param name="_sanitize"></param>
                /// <param name="Authentication">API Token Key</param>
                /// <returns>HTML  源代码</returns>
                public static async Task<string> ReturnedHTMLCode(string _text, bool _sanitize = true,
                    string Authentication = "")
                {
                    var targetUrl = $"{Interface._UAPI_Request_Url}text/markdown-to-html";
                    var response = await Interface.SendApiRequestWithFallbackAsync(targetUrl,
                        Interface.SendRequestType.POST, JsonConvert.SerializeObject(new
                        {
                            text = _text,
                            format = "html",
                            sanitize = _sanitize
                        }), "application/json", Authentication);
                    WriteLog.Info(LogKind.Http,
                        $"{_SEND_REQUEST}: POST {targetUrl}");

                    using (response)
                    {
                        var statusCode = (int)response.StatusCode;
                        WriteLog.Info(LogKind.Http, $"获取 Http 响应代码: {statusCode}");
                        var responseData = await response.Content.ReadAsStringAsync();
                        WriteLog.Info(LogKind.Http, "异步读取响应内容");
                        if (!string.IsNullOrEmpty(responseData))
                            return responseData;
                        WriteLog.Error(LogKind.Http,
                            _void_value_null("GetResult<T>.HttpClient", "Content"));
                        return null;
                    }
                }

                /// <summary>
                /// 响应格式。传 json 时返回 JSON 包裹的 HTML 片段；传 html 时直接返回 text/html，并且响应内容会自动带完整的网页结构，适合浏览器预览或直接保存为网页文件。默认是 json。
                /// </summary>
                public enum Format
                {
                    /// <summary/>
                    json,

                    /// <summary/>
                    html
                }
            }

            /// <summary>
            /// 转换为可下载的二进制 PDF 文档
            /// </summary>
            public static async Task<byte[]> ToPDF(string _text, Theme _theme = Theme.github, Size size = Size.A4,
                string Authentication = "")
            {
                var response = await Interface.SendApiRequestWithFallbackAsync(
                    $"{Interface._UAPI_Request_Url}text/markdown-to-pdf", Interface.SendRequestType.POST,
                    JsonConvert.SerializeObject(new
                    {
                        text = _text,
                        theme = _theme.ToString(),
                        paper_size = size.ToString()
                    }), "application/json", Authentication);
                using (response)
                {
                    var statusCode = (int)response.StatusCode;
                    WriteLog.Info(LogKind.Http, $"获取 Http 响应代码: {statusCode}");
                    var responseData = await response.Content.ReadAsByteArrayAsync();
                    WriteLog.Info(LogKind.Http, "异步读取响应内容");
                    if (responseData != null)
                        return responseData;
                    WriteLog.Error(LogKind.Http, _void_value_null("ToPDF", "Content"));
                    return null;
                }
            }
        }

        /// <summary>
        /// 下载PDF的主题样式
        /// </summary>
        public enum Theme
        {
            /// <summary/>
            github,

            /// <summary/>
            minimal,

            /// <summary/>
            light,

            /// <summary/>
            dark
        }

        /// <summary>
        /// 纸张大小
        /// </summary>
        public enum Size
        {
            /// <summary/>
            A4,

            /// <summary/>
            Letter
        }
    }
}