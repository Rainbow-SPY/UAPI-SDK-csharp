using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UAPI.IException;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 转换类 API 接口
        /// </summary>
        public class Convert
        {
            /// <summary>
            /// 不同文本格式之间转换
            /// </summary>
            /// <param name="_text">指定要转换的源文本</param>
            /// <param name="From">源格式</param>
            /// <param name="To">目标格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="Type.ConvertType"/>对象</returns>
            public static async Task<Type.ConvertType> Converter(string _text, Format From, Format To,
                string Authentication = "",
                object option = null)
            {
                var (result, statuscode) = await Interface.GetResult<Type.ConvertType>(
                    $"{Interface._UAPI_Request_Url}text/convert", Interface.SendRequestType.POST,
                    JsonConvert.SerializeObject(new
                    {
                        text = _text,
                        from = From.ToString(),
                        to = To.ToString(),
                        option = option?.ToString()
                    }), "application/json", Authentication);
                var list = Interface.IsGetSuccessful(result, "_text", statuscode, new General.UAPIUnknowException(),
                    "Text.Convert.Converter");
                if (!list.IsRequestSuccessfully)
                    WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }

            /// <summary>
            /// 将任意格式的数据转换为文本
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToText(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.plain, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 Base64
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToBase64(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.base64, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为十六进制 (不带 - , 小写字母+数字)
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToHex(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.hex, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 URL 编码
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToURL(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.url, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 Unicode 转义字符
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToUnicode(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.unicode, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为二进制字节数据, 返回字节数组
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<byte[]> AnyToBinaryBytes(string _text, Format From,
                object option = null, string Authentication = "")
                => Encoding.Default.GetBytes(
                    (await Converter(_text, From, Format.binary, Authentication, option)).Result);

            /// <summary>
            /// 将任意格式的数据转换为二进制字节数据, 返回字符串
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToBinaryString(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.binary, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 MD5 哈希值
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToMD5(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.md5, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 SHA1 哈希值
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToSHA1(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.sha1, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 SHA256 哈希值
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToSHA256(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.sha256, Authentication, option)).Result;

            /// <summary>
            /// 将任意格式的数据转换为 SHA512 哈希值
            /// </summary>
            /// <param name="_text">指定要转换的文本</param>
            /// <param name="From">指定要转换的文本的原格式</param>
            /// <param name="option">预留, 未投入使用</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns>转换后的格式的文本</returns>
            public static async Task<string> AnyToSHA512(string _text, Format From,
                object option = null, string Authentication = "")
                => (await Converter(_text, From, Format.sha512, Authentication, option)).Result;

            /// <summary/>
            public enum Format
            {
                /// <summary>
                /// 纯文本
                /// </summary>
                plain,

                /// <summary>
                /// base64 编码
                /// </summary>
                base64,

                /// <summary>
                /// 十六进制
                /// </summary>
                hex,

                /// <summary>
                /// URL 编码
                /// </summary>
                url,

                /// <summary>
                /// HTML 实体
                /// </summary>
                html,

                /// <summary>
                /// Unicode 转义
                /// </summary>
                unicode,

                /// <summary>
                /// 二进制
                /// </summary>
                binary,

                /// <summary>
                /// MD5 哈希值
                /// </summary>
                md5,

                /// <summary>
                /// SHA1 哈希值
                /// </summary>
                sha1,

                /// <summary>
                /// SHA256 哈希值
                /// </summary>
                sha256,

                /// <summary>
                /// SHA512 哈希值
                /// </summary>
                sha512
            }
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class ConvertType : TypeInterface
        {
            /// <summary>
            /// 结果
            /// </summary>
            [JsonProperty("result")]
            public string Result { get; set; }

            /// <summary>
            /// 源格式
            /// </summary>
            [JsonProperty("from")]
            public string From { get; set; }

            /// <summary>
            /// 目标格式
            /// </summary>
            [JsonProperty("to")]
            public string To { get; set; }

            /// <summary>
            /// 结果长度
            /// </summary>
            [JsonProperty("length")]
            public long Length { get; set; }

            /// <summary>
            /// 额外提示信息
            /// </summary>
            [JsonProperty("info")]
            public string info { get; set; }
        }
    }
}