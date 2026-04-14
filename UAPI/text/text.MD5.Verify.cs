using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 验证文本的哈希值是否符合预期
        /// </summary>
        /// <param name="_hash">指定要验证的文本哈希值</param>
        /// <param name="_text">指定要验证的文本</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="VerifyMD5"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException"></exception>
        public static async Task<VerifyMD5> VerifyMD5(string _hash, string _text, string Authentication = "")
        {
            var (result, statuscode) = await Interface.GetResult<VerifyMD5>(
                $"{Interface._UAPI_Request_Url}text/md5/verify",
                Interface.SendRequestType.POST, JsonConvert.SerializeObject(new { hash = _hash, text = _text }),
                "application/json", Authentication);
            var list = Interface.IsGetSuccessful(result, "hash or text", statuscode, new General.UAPIUnknowException(),
                "Text.VerifyMD5");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// MD5是否验证成功
        /// </summary>
        /// <param name="_hash">指定要验证的文本哈希值</param>
        /// <param name="_text">指定要验证的文本</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>bool</returns>
        public static async Task<bool> IsMD5VerifySuccessful(string _hash, string _text, string Authentication = "") =>
            (await
                VerifyMD5(_hash, _text, Authentication)).IsMatchSuccessful;
    }

    public partial class Type
    {
        /// <summary/>
        public class VerifyMD5 : TypeInterface
        {
            /// <summary>
            /// MD5 是否匹配成功
            /// </summary>
            [JsonProperty("match")]
            public bool IsMatchSuccessful { get; set; }
        }
    }
}