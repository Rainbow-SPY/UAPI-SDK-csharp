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
        /// 获取指定文本的MD5
        /// </summary>
        /// <param name="text">指定要计算MD5的文本</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <returns><see cref="MD5Type"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<MD5Type> GetCalculateMD5(string text, string AuthenticationAPITokenKey = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<MD5Type>($"{Interface._UAPI_Request_Url}text/md5", AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                "Text.CalculateMD5");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 获取指定文本的MD5
        /// </summary>
        /// <param name="texts">指定要计算MD5的文本</param>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <returns><see cref="MD5Type"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<MD5Type> POSTCalculateMD5(string texts, string AuthenticationAPITokenKey = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<MD5Type>($"{Interface._UAPI_Request_Url}text/md5",
                    Interface.SendRequestType.POST, JsonConvert.SerializeObject(new
                    {
                        text = texts
                    }), "application/json", AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, "text", statuscode, new General.UAPIUnknowException(),
                "Text.CalculateMD5");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 
        /// </summary>
        public class MD5Type : TypeInterface
        {
            /// <summary>
            /// 计算后的MD5
            /// </summary>
            [JsonProperty("md5")]
            public string MD5 { get; set; }
        }
    }
}