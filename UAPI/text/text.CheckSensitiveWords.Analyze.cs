using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Text
    {
        public partial class SensitiveWords
        {
            /// <summary>
            /// 分析审查敏感词并返回对象
            /// </summary>
            /// <param name="text">分析的敏感词</param>
            /// <param name="AuthenticationAPITokenKey">API Token Key</param>
            /// <returns><see cref="SensitiveAnalyzeType"/> 对象</returns> 
            /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
            public static async Task<SensitiveAnalyzeType> Analyze(string[] text, string AuthenticationAPITokenKey = "")
            {
                var (result, statuscode) = await Interface.GetResult<SensitiveAnalyzeType>(
                    $"{Interface._UAPI_Request_Url}sensitive-word/analyze", Interface.SendRequestType.POST,
                    JsonConvert.SerializeObject(new { keywords = text }), "application/json",
                    AuthenticationAPITokenKey);
                var list = Interface.IsGetSuccessful(result, "text[]", statuscode, new General.UAPIUnknowException(),
                    "SensitiveWords.Analyze");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }
        }
    }
}