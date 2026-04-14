using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 分析文本的字符数、词数、句子数、段落数和行数
        /// </summary>
        /// <param name="texts">指定要分析的文本</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="AnalyzeType"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<AnalyzeType> AnalyzeText(string texts, string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<AnalyzeType>($"{Interface._UAPI_Request_Url}text/analyze",
                    Interface.SendRequestType.POST, JsonConvert.SerializeObject(new
                    {
                        text = texts
                    }), "application/json", Authentication);
            var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                "Text.AnalyzeText");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 
        /// </summary>
        public class AnalyzeType : Interface.TypeInterface
        {
            /// <summary>
            /// 原始传入文本
            /// </summary>
            [JsonProperty("original_text")]
            public string OriginalText { get; set; }

            /// <summary>
            /// 按 Unicode 字符统计的总字符数（含换行、空格、标点）
            /// </summary>
            [JsonProperty("total_chars_unicode")]
            public int TotalCharsUnicode { get; set; }

            /// <summary>
            /// 文本占用的总字节数
            /// </summary>
            [JsonProperty("total_bytes")]
            public int TotalBytes { get; set; }

            /// <summary>
            /// 中文字符数量
            /// </summary>
            [JsonProperty("chinese_chars")]
            public int ChineseChars { get; set; }

            /// <summary>
            /// 英文字母数量
            /// </summary>
            [JsonProperty("english_letters")]
            public int EnglishLetters { get; set; }

            /// <summary>
            /// 数字字符数量
            /// </summary>
            [JsonProperty("numbers")]
            public int Numbers { get; set; }

            /// <summary>
            /// 标点符号数量
            /// </summary>
            [JsonProperty("punctuation_marks")]
            public int PunctuationMarks { get; set; }

            /// <summary>
            /// 空白字符数量 (空格、换行符等)
            /// </summary>
            [JsonProperty("whitespace_chars")]
            public int WhiteSpaceChars { get; set; }
        }
    }
}