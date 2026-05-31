using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 对文本的相关处理
    /// </summary>
    public partial class Text
    {
        /// <summary>
        /// 敏感词分析的类
        /// </summary>
        public partial class SensitiveWords
        {
            /// <summary>
            /// 快速检测审查敏感词 (POST) 
            /// </summary>
            /// <param name="text">指定要审查的文本</param>
            /// <param name="AuthenticationAPITokenKey">API Token Key</param>
            /// <returns><see cref="FastType"/> 对象</returns>
            public static async Task<FastType> CheckFast(string text, string AuthenticationAPITokenKey = "")
            {
                var (result, statuscode) = await Interface.GetResult<FastType>(
                    $"{Interface._UAPI_Request_Url}text/profanitycheck", Interface.SendRequestType.POST,
                    $"{{\"text\": \"{text}\"}}", "application/json", AuthenticationAPITokenKey);
                var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                    "CheckSensitiveWordsFast");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class FastType : TypeInterface
        {
            /// <summary>
            /// 返回的敏感词状态
            /// </summary>
            [JsonProperty("status")]
            public string status { get; set; }

            /// <summary>
            /// 原始文本是否通过审查
            /// </summary>
            [JsonIgnore]
            public bool IsSuccessful => status == "ok";

            /// <summary>
            /// 原始文本
            /// </summary>
            [JsonProperty("original_text")]
            public string original_text { get; set; }

            /// <summary>
            /// 脱敏后的文本
            /// </summary>
            [JsonProperty("masked_text")]
            public string masked_text { get; set; }

            /// <summary>
            /// 敏感词的 List
            /// </summary>
            [JsonProperty("forbidden_words")]
            public List<string> forbidden_words { get; set; }
        }
    }
}