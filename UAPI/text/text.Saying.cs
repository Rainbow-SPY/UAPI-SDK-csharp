using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Saying
    {
        /// <summary>
        /// 获取随心一言
        /// </summary>
        /// <param name="AuthenticationAPITokenKey">API Token Key</param>
        /// <returns><see cref="SayingType"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<SayingType> GetSaying(string AuthenticationAPITokenKey = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<SayingType>($"{Interface._UAPI_Request_Url}saying",
                    AuthenticationAPITokenKey);
            var list = Interface.IsGetSuccessful(result, null, statuscode, new General.UAPIUnknowException(),
                "Saying.GetSaying");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 
        /// </summary>
        public class SayingType : Interface.TypeInterface
        {
            /// <summary>
            /// 随心一言
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}