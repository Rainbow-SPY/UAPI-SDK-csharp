using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Text
    {
        public partial class SensitiveWords
        {
            /// <summary>
            /// 分析敏感词 (GET), 仅支持单个字符串, 要使用字符串数组请使用 <see cref="SensitiveWords.Analyze"/>
            /// </summary>
            /// <param name="text">指定要识别的敏感词</param>
            /// <param name="AuthenticationAPITokenKey">API Token Key</param>
            /// <returns><see cref="AnalyzeType"/> 对象</returns>
            /// <exception cref="General.UAPIUnknowException">未识别的异常</exception>
            public static async Task<AnalyzeType> GetCheck(string text, string AuthenticationAPITokenKey = "")
            {
                var (result, statuscode) = await Interface.GetResult<AnalyzeType>(
                    $"{Interface._UAPI_Request_Url}sensitive-word/analyze-query?keyword={text}",
                    AuthenticationAPITokenKey);
                var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                    "SensitiveWords.GetCheck");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }
        }
    }
}