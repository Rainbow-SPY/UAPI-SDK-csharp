using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;
using static UAPI.Type.AESAdvancedType;
using static UAPI.Type.AESAdvancedType.EncryptMode;
using static UAPI.Type.AESAdvancedType.format;
using static UAPI.Type.AESAdvancedType.padding;

namespace UAPI
{
    public partial class Text
    {
        public partial class AES
        {
            /// <summary>
            /// 使用AES 高级加密加密指定的文本
            /// </summary>
            /// <param name="_text">指定要加密的文本</param>
            /// <param name="_key">加密密钥（支持任意长度）</param>
            /// <param name="_mode">
            /// 加密方式, 可选 <see cref="GCM"/> 或 <see cref="CBC"/> 或 <see cref="ECB"/> 或 <see cref="CTR"/> 或 <see cref="OFB"/> 或 <see cref="CFB"/>, 默认为 <see cref="GCM"/></param>
            /// <param name="_padding">填充方式, 可选 <see cref="PKCS7"/> 或 <see cref="ZERO"/> 或 <see cref="NONE"/>, 默认 <see cref="PKCS7"/></param>
            /// <param name="_iv">自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数</param>
            /// <param name="_format">输出格式, 可选 <see cref="base64"/> 或 <see cref="hex"/>, 默认 <see cref="base64"/></param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="AESAdvancedType.Type"/>对象</returns>
            /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
            public static async Task<AESAdvancedType.Type> AdvancedEncrypt(string _text, string _key,
                EncryptMode _mode = GCM, padding _padding = PKCS7, string _iv = "", format _format = base64,
                string Authentication = "")
            {
                var (result, statuscode) = await GetResult<AESAdvancedType.Type>(
                    $"{_UAPI_Request_Url}text/aes/encrypt-advanced", SendRequestType.POST,
                    JsonConvert.SerializeObject(new
                    {
                        text = _text,
                        key = _key,
                        mode = _mode,
                        padding = _padding,
                        iv = _iv,
                        format = _format
                    }), "application/json", Authentication);
                var list = IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                    "Text.AES.AdvancedEncrypt");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }

            /// <summary>
            /// 使用 AES 高级加密加密指定的文本, 直接返回加密完的文本, 可等待
            /// </summary>
            /// <param name="_text">指定要加密的文本</param>
            /// <param name="_key">加密密钥（支持任意长度）</param>
            /// <param name="_mode">
            /// 加密方式, 可选 <see cref="GCM"/> 或 <see cref="CBC"/> 或 <see cref="ECB"/> 或 <see cref="CTR"/> 或 <see cref="OFB"/> 或 <see cref="CFB"/>, 默认为 <see cref="GCM"/></param>
            /// <param name="_padding">填充方式, 可选 <see cref="PKCS7"/> 或 <see cref="ZERO"/> 或 <see cref="NONE"/>, 默认 <see cref="PKCS7"/></param>
            /// <param name="_iv">自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数</param>
            /// <param name="_format">输出格式, 可选 <see cref="base64"/> 或 <see cref="hex"/>, 默认 <see cref="base64"/></param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>加密完的文本</returns>
            public static async Task<string> ReturnedAdvancedEncryptedText(string _text, string _key,
                EncryptMode _mode = GCM, padding _padding = PKCS7, string _iv = "", format _format = base64,
                string Authentication = "") =>
                (await AdvancedEncrypt(_text, _key, _mode, _padding, _iv, _format, Authentication)).EncryptedText;

            /// <summary>
            /// 使用 AES 高级加密解密指定的文本
            /// </summary>
            /// <param name="_text">指定要解密的文本</param>
            /// <param name="_key">加密密钥（支持任意长度, 必须与加密时相同）</param>
            /// <param name="_mode">
            /// 加密方式, 可选, 必须与加密时相同 <see cref="GCM"/> 或 <see cref="CBC"/> 或 <see cref="ECB"/> 或 <see cref="CTR"/> 或 <see cref="OFB"/> 或 <see cref="CFB"/>, 默认为 <see cref="GCM"/></param>
            /// <param name="_padding">填充方式, 可选, 必须与加密时相同 <see cref="PKCS7"/> 或 <see cref="ZERO"/> 或 <see cref="NONE"/>, 默认 <see cref="PKCS7"/></param>
            /// <param name="_iv">自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="AESDecryptType"/>对象</returns>
            /// <exception cref="General.UAPIUnknowException"></exception>
            public static async Task<AESDecryptType> AdvancedDecrypt(string _text, string _key,
                EncryptMode _mode = GCM, padding _padding = PKCS7, string _iv = "",
                string Authentication = "")
            {
                var (result, statuscode) = await GetResult<AESDecryptType>(
                    $"{_UAPI_Request_Url}text/aes/decrypt-advanced", SendRequestType.POST,
                    JsonConvert.SerializeObject(new
                    {
                        text = _text,
                        key = _key,
                        mode = _mode,
                        padding = _padding,
                        iv = _iv
                    }), "application/json", Authentication);
                var list = IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                    "Text.AES.AdvancedDecrypt");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }

            /// <summary>
            /// 使用 AES 高级加密解密指定的文本, 直接返回解密后的文本, 可等待
            /// </summary>
            /// <param name="_text">指定要解密的文本</param>
            /// <param name="_key">加密密钥（支持任意长度, 必须与加密时相同）</param>
            /// <param name="_mode">
            /// 加密方式, 可选, 必须与加密时相同 <see cref="GCM"/> 或 <see cref="CBC"/> 或 <see cref="ECB"/> 或 <see cref="CTR"/> 或 <see cref="OFB"/> 或 <see cref="CFB"/>, 默认为 <see cref="GCM"/></param>
            /// <param name="_padding">填充方式, 可选, 必须与加密时相同 <see cref="PKCS7"/> 或 <see cref="ZERO"/> 或 <see cref="NONE"/>, 默认 <see cref="PKCS7"/></param>
            /// <param name="_iv">自定义IV（可选，Base64编码，16字节）。GCM模式无需此参数</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>解密后的文本</returns>
            public static async Task<string> ReturnedAdvancedDecryptText(string _text, string _key,
                EncryptMode _mode = GCM, padding _padding = PKCS7, string _iv = "",
                string Authentication = "") =>
                (await AdvancedDecrypt(_text, _key, _mode, _padding, _iv, Authentication)).DecryptedText;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class AESAdvancedType
        {
            /// <summary/>
            public enum EncryptMode
            {
                /// <summary/>
                GCM,

                /// <summary/>
                CBC,

                /// <summary/>
                ECB,

                /// <summary/>
                CTR,

                /// <summary/>
                OFB,

                /// <summary/>
                CFB
            }

            /// <summary/>
            public enum padding
            {
                /// <summary/>
                PKCS7,

                /// <summary/>
                ZERO,

                /// <summary/>
                NONE
            }

            /// <summary/>
            public enum format
            {
                /// <summary/>
                base64,

                /// <summary/>
                hex
            }

            /// <summary/>
            public class Type : TypeInterface
            {
                /// <summary>
                /// 加密后的文本
                /// </summary>
                [JsonProperty("ciphertext")]
                public string EncryptedText { get; set; }

                /// <summary>
                /// 加密方式
                /// </summary>
                [JsonProperty("mode")]
                public string Mode { get; set; }

                /// <summary>
                /// 填充方式
                /// </summary>
                [JsonProperty("padding")]
                public string Padding { get; set; }
            }
        }
    }
}