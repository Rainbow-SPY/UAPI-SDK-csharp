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
        /// 获取加密后的 Base 64 编码文本
        /// </summary>
        /// <param name="texts"></param>
        /// <param name="AuthenticationAPITokenKey">API Token Ke</param>
        /// <returns><see cref="DecryptedType"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<EncryptType> EncryptBase64(string texts, string AuthenticationAPITokenKey = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<EncryptType>($"{Interface._UAPI_Request_Url}text/base64/encode",
                    Interface.SendRequestType.POST, JsonConvert.SerializeObject(new
                    {
                        texts
                    }), AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                "Text.EncryptBase64");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 
        /// </summary>
        public class EncryptType : TypeInterface
        {
            /// <summary>
            /// 加密过的 Base64 字符串
            /// </summary>
            [JsonProperty("encoded")]
            public string EncryptedText { get; set; }
        }

        /// <summary>
        /// 获取解密后的 Base 64 编码文本
        /// </summary>
        /// <param name="texts">指定要解密的 Bas64</param>
        /// <param name="AuthenticationAPITokenKey">API Token Ke</param>
        /// <returns><see cref="DecryptedType"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<DecryptedType> DecryptBase64(string texts, string AuthenticationAPITokenKey = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<DecryptedType>($"{Interface._UAPI_Request_Url}text/base64/decode",
                    Interface.SendRequestType.POST, JsonConvert.SerializeObject(new
                    {
                        text = texts
                    }), "application/json",
                    AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                "Text.EncryptBase64");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 
        /// </summary>
        public class DecryptedType : TypeInterface
        {
            /// <summary>
            /// 加密过的 Base64 字符串
            /// </summary>
            [JsonProperty("encoded")]
            public string DecryptedText { get; set; }
        }
    }
}