using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 图片转 Base64
        /// </summary>
        /// <param name="url">指定要转换Base 64 的 图像 Url 地址</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.Base64Type"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<Type.Base64Type> ToBase64(string url, string Authentication = "")
        {
            var (result, statuscode) = await Interface.GetResult<Type.Base64Type>(
                $"{Interface._UAPI_Request_Url}image/tobase64?url={url}", Interface.SendRequestType.GET, "",
                "application/json", Authentication);
            var list = Interface.IsGetSuccessful(result, "url", statuscode, new General.UAPIUnknowException(),
                "Image.ToBase64");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class Base64Type : TypeInterface
        {
            /// <summary>
            /// 转换的 Base64
            /// </summary>
            [JsonProperty("base64")]
            public string Base64 { get; set; }

            /// <summary>
            /// 返回的消息
            /// </summary>
            [JsonProperty("msg")]
            public string Message { get; set; }
        }
    }
}