using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 获取单词元信息
        /// </summary>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WordMetaData"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException"></exception>
        public static async Task<WordMetaData> GetWordMetaData(string Authentication = "")
        {
            var (result, statuscode) = await GetResult<WordMetaData>($"{_UAPI_Request_Url}daily/word/meta"
                , SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "", statuscode, new General.UAPIUnknowException(),
                "Text.GetWordMetaData");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary />
        public class WordMetaData : TypeInterface
        {
            /// <summary />
            public class Categories
            {
                /// <summary>
                /// 所有收录单词
                /// </summary>
                [JsonProperty("all")]
                public int all { get; set; }

                /// <summary>
                /// 全国大学英语四级收录单词
                /// </summary>
                [JsonProperty("cet4")]
                public int cet4 { get; set; }

                /// <summary>
                /// 全国大学英语六级收录单词
                /// </summary>
                [JsonProperty("cet6")]
                public int cet6 { get; set; }

                /// <summary>
                /// 研究生入学考试收录单词
                /// </summary>
                [JsonProperty("gre")]
                public int gre { get; set; }

                /// <summary>
                /// 国际英语语言测试系统收录单词
                /// </summary>
                [JsonProperty("ielts")]
                public int ielts { get; set; }

                /// <summary>
                /// 托福网络考试
                /// </summary>
                [JsonProperty("toefl")]
                public int toefl { get; set; }
            }

            /// <summary />
            public class Source
            {
                /// <summary>
                /// 单词源
                /// </summary>
                [JsonProperty("dictionary")]
                public string DictionarySource { get; set; }

                /// <summary>
                /// 单词示例
                /// </summary>
                [JsonProperty("examples")]
                public string Examples { get; set; }
            }

            /// <summary />
            public class LanguagesItem
            {
                /// <summary>
                /// 支持的语言
                /// </summary>
                [JsonProperty("language")]
                public string language { get; set; }

                /// <summary>
                /// 单词总量
                /// </summary>
                [JsonProperty("total")]
                public int total { get; set; }

                /// <summary>
                /// 各个词典的单词量
                /// </summary>
                [JsonProperty("categories")]
                public Categories categories { get; set; }

                /// <summary>
                /// 单词源
                /// </summary>
                [JsonProperty("source")]
                public Source source { get; set; }
            }

            /// <summary />
            [JsonProperty("languages")]
            public List<LanguagesItem> languages { get; set; }
        }
    }
}