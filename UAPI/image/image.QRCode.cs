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
#pragma warning disable CS1584
            /// <summary>
            /// 获取二维码的二进制图片数据
            /// </summary>
            /// <param name="_text">你希望编码到二维码中的任何文本内容，比如一个URL、一段话或者一个JSON字符串。</param>
            /// <param name="size">二维码图片的边长（正方形），单位是像素。有效范围是 256 到 2048 之间。</param>
            /// <param name="transparent">是否使用透明背景。启用后生成的 PNG 图片将具有 alpha 通道，背景透明</param>
            /// <param name="FrontColor">二维码前景色（即二维码本身的颜色），使用十六进制格式。</param>
            /// <param name="BackgroundColor">二维码背景色，使用十六进制格式。当 transparent=true 时此参数会被忽略</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="byte[]"/></returns>
            /// <exception cref="General.UAPIUnknowException()">未知的异常</exception>
#pragma warning restore CS1584
            public static async Task<byte[]> GetBytes(string _text, int size = 256,
                bool transparent = false, string FrontColor = "#000000", string BackgroundColor = "#FFFFFF",
                string Authentication = "")
            {
                var (result, statuscode) = await Interface.GetBytesResult(
                    $"{Interface._UAPI_Request_Url}image/qrcode" +
                    $"?text={_text}&size={size}&format=image" +
                    $"&transparent={transparent.ToString()}&fgcolor=%23{FrontColor.Substring(1)}&bgcolor=%23{BackgroundColor.Substring(1)}",
                    Interface.SendRequestType.GET, "", "application/json", Authentication);
                var list = Interface.IsGetBytesSuccessful(result, "_text", statuscode,
                    new General.UAPIUnknowException(), "QRCode.GetBytes");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result.Result;
            }

            /// <summary>
            /// 获取二维码的Json源数据
            /// </summary>
            /// <param name="_text">你希望编码到二维码中的任何文本内容，比如一个URL、一段话或者一个JSON字符串。</param>
            /// <param name="size">二维码图片的边长（正方形），单位是像素。有效范围是 256 到 2048 之间。</param>
            /// <param name="_format">指定响应内容的格式。可选值为 `image`, `json`, `json_url`。</param>
            /// <param name="transparent">是否使用透明背景。启用后生成的 PNG 图片将具有 alpha 通道，背景透明</param>
            /// <param name="FrontColor">二维码前景色（即二维码本身的颜色），使用十六进制格式。</param>
            /// <param name="BackgroundColor">二维码背景色，使用十六进制格式。当 transparent=true 时此参数会被忽略</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="Type.QRCodeType"/></returns>
            /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
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