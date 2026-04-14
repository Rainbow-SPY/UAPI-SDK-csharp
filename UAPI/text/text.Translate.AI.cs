using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texts">待翻译的文本内容。最大长度10,000 字符</param>
        /// <param name="Language">目标语言代码。请从支持的语言列表中选择一个语言代码</param>
        /// <param name="source_Language">源语言代码，可选。如果不指定，系统会自动检测源语言。</param>
        /// <param name="style">翻译风格，可选。支持casual(随意口语化)、professional(专业商务，默认)、academic(学术正式)、literary(文学艺术)</param>
        /// <param name="Context">翻译上下文场景，可选。支持general(通用，默认)、business(商务)、technical(技术)、medical(医疗)、legal(法律)、marketing(市场营销)、entertainment(娱乐)、education(教育)、news(新闻)</param>
        /// <param name="preserve_Format">是否保留原文格式，包括换行、缩进等</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <returns><see cref="AIText"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<AIText> AITranslate(string texts, SupportLanguages Language, string source_Language = "",
            Style style = Style.None, Context Context = Context.general, bool preserve_Format = false,
            string AuthenticationAPITokenKey = "")
        {
            var _lan = Language == SupportLanguages.@is
                ? "is"
                : Language.ToString().Replace('_', '-');
            var (result, statuscode) = await Interface.GetResult<AIText>(
                $"{Interface._UAPI_Request_Url}ai/translate?target_lang={_lan}", Interface.SendRequestType.POST,
                JsonConvert.SerializeObject(new
                {
                    text = texts,
                    source_language = source_Language,
                    style = style.ToString(),
                    context = Context,
                    preserve_format = preserve_Format
                }),
                "application/json", AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                "Text.AITranslate");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}