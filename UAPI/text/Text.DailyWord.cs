using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UAPI.IException;
using static Rox.Runtimes.LogLibraries;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 每日单词
        /// </summary>
        /// <param name="lang">语种，目前支持 en，默认 en。</param>
        /// <param name="cat">词库范围：all/cet4/cet6/ielts/toefl/gre，默认 all。</param>
        /// <param name="count">返回数量，1-20，默认 1。</param>
        /// <param name="date">日期，格式 YYYY-MM-DD，作为每日单词的种子基准。</param>
        /// <param name="seed">固定种子，结果可复现；不可与 date 同时使用。</param>
        /// <param name="example">是否返回例句，默认 true。</param>
        /// <param name="phonetic">是否返回音标，默认 true。</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="DailyWord"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException"></exception>
        public static async Task<DailyWord> GetDailyWord(string lang = "en",
            DailyWord.CategoryEnum cat = DailyWord.CategoryEnum.all, int count = 1, string date = "", int seed = 0,
            bool example = true, bool phonetic = true, string Authentication = "")
        {
            var (result, statuscode) = await GetResult<DailyWord>(
                $"{_UAPI_Request_Url}daily/word?lang={lang}&category={cat.ToString()}&count={count}&date={date}&seed={seed}&example={example}&phonetic={phonetic}"
                , SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "", statuscode, new General.UAPIUnknowException(),
                "Text.GetDailyWord");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary />
        public class DailyWord : TypeInterface
        {
            /// <summary />
            public enum CategoryEnum
            {
                /// <summary />
                all,

                /// <summary>全国大学英语四级</summary>
                cet4,

                /// <summary>全国大学英语六级</summary>
                cet6,

                /// <summary>国际英语语言测试系统</summary>
                ielts,

                /// <summary>托福网络考试</summary>
                toefi,

                /// <summary>研究生入学考试</summary>
                gre
            }

            /// <summary />
            public class ExamplesItem
            {
                /// <summary>
                /// 例句示例语句
                /// </summary>
                [JsonProperty("text")]
                public string text { get; set; }

                /// <summary>
                /// 例句示例翻译
                /// </summary>
                [JsonProperty("translation")]
                public string translation { get; set; }
            }

            /// <summary />
            public class WordsItem
            {
                /// <summary>
                /// 单词
                /// </summary>
                [JsonProperty("word")]
                public string Word { get; set; }

                /// <summary>
                /// 语言
                /// </summary>
                [JsonProperty("language")]
                public string Language { get; set; }

                /// <summary>
                /// 音标
                /// </summary>
                [JsonProperty("phonetic")]
                public string Phonetic { get; set; }

                /// <summary>
                /// 词义
                /// </summary>
                [JsonProperty("translation")]
                public string Translation { get; set; }

                /// <summary>
                /// 英词义
                /// </summary>
                [JsonProperty("definition")]
                public string Definition { get; set; }

                /// <summary>
                /// 柯林斯词典
                /// </summary>
                [JsonProperty("collins")]
                public int Collins { get; set; }

                /// <summary>
                /// 收录此单词的考试
                /// </summary>
                [JsonProperty("categories")]
                public List<string> Categories { get; set; }

                /// <summary>
                /// 例句
                /// </summary>
                [JsonProperty("examples")]
                public List<ExamplesItem> ExamplesList { get; set; }
            }

            /// <summary>
            /// 查询的日期
            /// </summary>
            [JsonProperty("date")]
            public string Date { get; set; }

            /// <summary>
            /// 查询的语言
            /// </summary>
            [JsonProperty("language")]
            public string Language { get; set; }

            /// <summary>
            /// 查询的目录
            /// </summary>
            [JsonProperty("category")]
            public string Category { get; set; }

            /// <summary>
            /// 指定查询的种子
            /// </summary>
            [JsonProperty("seed")]
            public int Seed { get; set; }

            /// <summary>
            /// 返回数量
            /// </summary>
            [JsonProperty("count")]
            public int Count { get; set; }

            /// <summary>
            /// 返回的单词
            /// </summary>
            [JsonProperty("words")]
            public List<WordsItem> WordsList { get; set; }
        }
    }
}