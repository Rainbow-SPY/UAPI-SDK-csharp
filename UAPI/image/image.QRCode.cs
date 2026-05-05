using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Image
    {
        /// <summary/>
        public class QRCode
        {
            public static async Task<byte[]> GetBytes(string _text, int size = 256,
                bool transparent = false, string FrontColor = "#000000", string BackgroundColor = "#FFFFFF",
                string Authentication = "") =>
                (await Interface.GetBytesResult(
                    $"{Interface._UAPI_Request_Url}image/qrcode" +
                    $"?text={_text}&size={size}&format=image" +
                    $"&transparent={transparent.ToString()}&fgcolor=%23{FrontColor.Substring(1)}&bgcolor=%23{BackgroundColor.Substring(1)}",
                    Interface.SendRequestType.GET, "", "application/json", Authentication)).Result;

            public static async Task<Type.QRCodeType> GetJson(string _text, int size = 256,
                Type.QRCodeType.Format _format = Type.QRCodeType.Format.Json,
                bool transparent = false, string FrontColor = "#000000", string BackgroundColor = "#FFFFFF",
                string Authentication = "")
            {
                var (result, statuscode) = await Interface.GetResult<Type.QRCodeType>(
                    $"{Interface._UAPI_Request_Url}image/qrcode" +
                    $"?text={_text}&size={size}&format={_format.ToString().ToLower()}" +
                    $"&transparent={transparent.ToString()}&fgcolor=%23{FrontColor.Substring(1)}&bgcolor=%23{BackgroundColor.Substring(1)}",
                    Interface.SendRequestType.GET, "", "application/json", Authentication);
                var list = Interface.IsGetSuccessful(result, "_text", statuscode, new General.UAPIUnknowException(),
                    "Image.QRCode.GetJson");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class QRCodeType : TypeInterface
        {
            private string _base64;

            /// <summary>
            /// 二维码的 Base64 编码
            /// </summary>
            [JsonProperty("qrcode_base64")]
            public string Base64
            {
                get => _base64;
                set => _base64 = value.Substring(17);
            }

            /// <summary>
            /// 二维码的 URL 地址
            /// </summary>
            [JsonProperty("qrcode_url")]
            public string URL { get; set; }

            /// <summary>
            /// 二维码内容
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary/>
            public enum Format
            {
                /// <summary/>
                Json,

                /// <summary/>
                Json_Url
            }
        }
    }
}