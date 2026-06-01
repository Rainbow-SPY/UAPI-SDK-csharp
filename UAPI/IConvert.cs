using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;
using static UAPI.Text.Convert;

namespace UAPI
{
    /// <summary/>
    public class IConvert
    {
        /// <summary/>
        public class Image
        {
            /// <inheritdoc cref="UAPI.Image.PostSVGConvertToBitImage"/>
            public static async Task<byte[]> PostSVGConvertToBitImage(byte[] svg,
                SVGConvertType.SVGFormat format = SVGConvertType.SVGFormat.png,
                int? width = null, int? height = null,
                int quality = 90,
                string Authentication = "") =>
                await UAPI.Image.PostSVGConvertToBitImage(svg, format, width, height, quality, Authentication);
        }

        /// <summary/>
        public class Text
        {
            /// <inheritdoc cref="UAPI.Text.Convert.Converter" />
            public static async Task<ConvertType> Converter(string _text, Format From, Format To,
                string Authentication = "",
                object option = null) => await UAPI.Text.Convert.Converter(_text, From, To, option, Authentication);

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToText" />
            public static async Task<string> AnyToText(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToText(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.Converter" />
            public static async Task<string> AnyToBase64(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToBase64(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToHex" />
            public static async Task<string> AnyToHex(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToHex(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToURL" />
            public static async Task<string> AnyToURL(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToURL(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToUnicode" />
            public static async Task<string> AnyToUnicode(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToUnicode(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToBinaryBytes" />
            public static async Task<byte[]> AnyToBinaryBytes(string _text, Format From,
                object option = null, string Authentication = "")
                => Encoding.Default.GetBytes(
                    (await UAPI.Text.Convert.AnyToBase64(_text, From, option, Authentication)).Result);

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToBinaryString" />
            public static async Task<string> AnyToBinaryString(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToBinaryString(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToMD5" />
            public static async Task<string> AnyToMD5(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToMD5(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToSHA1" />
            public static async Task<string> AnyToSHA1(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToSHA1(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToSHA256" />
            public static async Task<string> AnyToSHA256(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToSHA256(_text, From, option, Authentication)).Result;

            /// <inheritdoc cref="UAPI.Text.Convert.AnyToSHA512" />
            public static async Task<string> AnyToSHA512(string _text, Format From,
                object option = null, string Authentication = "")
                => (await UAPI.Text.Convert.AnyToSHA512(_text, From, option, Authentication)).Result;
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
            var jsonBody = JsonConvert.SerializeObject(requestBody);

            var (result, statuscode) = await GetResult<JsonConvertType>(
                $"{_UAPI_Request_Url}convert/json",
                SendRequestType.POST, jsonBody, "application/json", Authentication);
            var list = IsGetSuccessful(result, "json", statuscode,
                new General.UAPIUnknowException(), "IConvert.FormatJson");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 识别int播放量/点赞量等并格式化，仅支持万(w)单位，返回字符串
        /// </summary>
        /// <param name="_Count">原始int播放量/点赞量等数据</param>
        /// <returns>格式化后的播放数字符串(如1234→"1234"，15000→"1.5万")</returns>
        public static string FormatPlayCount(int _Count) =>
            _Count >= 10000 ? $"{(double)_Count / 10000:0.##}万" : _Count.ToString();

        /// <summary>
        /// 识别Unix时间戳并转换为字符串
        /// </summary>
        /// <param name="_time">时间戳</param>
        /// <returns>字符串格式的时间(YYYY-MM-DD)</returns>
        public static string FormatUnixTime(object _time) => DateTime.TryParse(_time.ToString(),
            CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
            out var dt)
            ? dt.ToString("yyyy-MM-dd")
            : string.Empty;

        /// <summary>
        /// 将ISO 8601格式(YYYY-MM-DDTHH:mm:ss[.fff]Z)的UTC时间转换为本地时间
        /// 兼容带毫秒(.fff)和不带毫秒的两种格式
        /// </summary>
        /// <param name="iso8601Time">ISO 8601 格式的时间字符串(带Z后缀，可含毫秒)</param>
        /// <returns>格式化后的本地时间字符串，格式：yyyy-M-d dddd</returns>
        /// <exception cref="ArgumentException">输入时间字符串格式无效/为空时抛出</exception>
        public static string FormatISO8601TimeToLocal(string iso8601Time)
        {
            if (string.IsNullOrWhiteSpace(iso8601Time))
                throw new ArgumentException("输入的ISO 8601时间字符串不能为空", nameof(iso8601Time));
            return DateTime.TryParseExact(
                iso8601Time,
                // 同时支持带毫秒和不带毫秒的ISO 8601 格式
                new[] { "yyyy-MM-dd'T'HH:mm:ss.fffZ", "yyyy-MM-dd'T'HH:mm:ssZ" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal,
                out var utcTime)
                ? utcTime.ToLocalTime().ToString("yyyy-M-d dddd", CultureInfo.CurrentCulture)
                : throw new ArgumentException(
                    $"无效的ISO 8601时间格式：{iso8601Time}，请确保格式为 YYYY-MM-DDTHH:mm:ss[.fff]Z",
                    nameof(iso8601Time));
        }

        /// <summary>
        /// 识别总长时间并转换为HH:MM:SS格式的字符串
        /// </summary>
        /// <param name="_time">时间 (秒)</param>
        /// <returns>HH:MM:SS 格式的时间字符串</returns>
        public static string FormatSecondsTime(int _time) => _time < 0
            ? "00:00:00"
            : $"{(_time / 3600 == 0 ? "00" : (_time / 3600).ToString())}";
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