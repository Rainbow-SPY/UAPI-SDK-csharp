using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 翻译指定的文本
        /// </summary>
        /// <param name="Language">指定要翻译的语言代码 (ISO 639-1)</param>
        /// <param name="Text">指定要翻译的文本</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <returns><see cref="TranslateType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<TranslateType> Translate(SupportLanguages Language, string Text,
            string AuthenticationAPITokenKey = "")
        {
            var _lan = Language == SupportLanguages.@is
                ? "is"
                : Language.ToString().Replace('_', '-');

            var (result, statuscode) = await Interface.GetResult<TranslateType>(
                $"{Interface._UAPI_Request_Url}translate/text?to_lang={_lan}",
                Interface.SendRequestType.POST, JsonConvert.SerializeObject(new { text = Text }),
                "application/json", AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "text or Language", statuscode,
                new General.UAPIUnknowException(), "Text.Translate");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}