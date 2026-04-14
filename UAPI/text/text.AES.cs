using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// AES 加解密
        /// </summary>
        public partial class AES
        {
            /// <summary>
            /// 使用 AES 加密文本
            /// </summary>
            /// <param name="_key">密钥，长度必须为16、24或 32 字节，对应AES-128/192/256</param>
            /// <param name="_text">指定要加密的文本</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="Type.AESEncryptType"/>对象</returns>
            /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
            public static async Task<Type.AESEncryptType> Encrypt(string _key, string _text, string Authentication = "")
            {
                var (result, statuscode) = await Interface.GetResult<Type.AESEncryptType>(
                    $"{Interface._UAPI_Request_Url}text/aes/encrypt",
                    Interface.SendRequestType.POST, JsonConvert.SerializeObject(new { key = _key, text = _text }),
                    "application/json", Authentication);
                var list = Interface.IsGetSuccessful(result, "key or text", statuscode,
                    new General.UAPIUnknowException(),
                    "AES.Encrypt");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }

            /// <summary>
            /// 使用 AES 加密文本, 直接返回加密后的文本, 可等待
            /// </summary>
            /// <param name="_key">密钥，长度必须为16、24或 32 字节，对应AES-128/192/256</param>
            /// <param name="_text">指定要加密的文本</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>加密后的文本</returns>
            public static async Task<string>
                ReturnEncryptedText(string _key, string _text, string Authentication = "") =>
                (await Encrypt(_key, _text, Authentication)).EncryptedText;

            /// <summary>
            /// 使用 AES 解密文本
            /// </summary>
            /// <param name="_key">密钥，长度必须为16、24或 32 字节，对应AES-128/192/256</param>
            /// <param name="_text">指定要解密的文本</param>
            /// <param name="IV">16字节的IV/Nonce，必须为16个字符</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="Type.AESDecryptType"/>对象</returns>
            /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
            public static async Task<Type.AESDecryptType> Decrypt(string _key, string _text, string IV,
                string Authentication = "")
            {
                var (result, statuscode) = await Interface.GetResult<Type.AESDecryptType>(
                    $"{Interface._UAPI_Request_Url}text/aes/decrypt",
                    Interface.SendRequestType.POST,
                    JsonConvert.SerializeObject(new { key = _key, text = _text, nonce = IV }),
                    "application/json", Authentication);
                var list = Interface.IsGetSuccessful(result, "key or text or IV", statuscode,
                    new General.UAPIUnknowException(),
                    "AES.Decrypt");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }

            /// <summary>
            /// 使用 AES 解密文本, 直接返回解密后的文本, 可等待
            /// </summary>
            /// <param name="_key">密钥，长度必须为16、24或 32 字节，对应AES-128/192/256</param>
            /// <param name="_text">指定要解密的文本</param>
            /// <param name="IV">16字节的IV/Nonce，必须为16个字符</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>解密后的文本</returns>
            public static async Task<string> ReturnDecryptedText(string _key, string _text, string IV,
                string Authentication = "") => (await Decrypt(_key, _text, IV, Authentication)).DecryptedText;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class AESEncryptType : TypeInterface
        {
            /// <summary>
            /// 加密完的文本
            /// </summary>
            [JsonProperty("ciphertext")]
            public string EncryptedText { get; set; }
        }

        /// <summary/>
        public class AESDecryptType : TypeInterface
        {
            /// <summary>
            /// 加密完的文本
            /// </summary>
            [JsonProperty("plaintext")]
            public string DecryptedText { get; set; }
        }
    }
}