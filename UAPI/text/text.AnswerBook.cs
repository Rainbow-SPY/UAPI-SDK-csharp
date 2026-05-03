using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    public partial class Text
    {
        /// <summary>
        /// 提问并获得随机的神秘答案
        /// </summary>
        /// <param name="_question">指定要提出的问题</param>
        /// <param name="requestType">请求方式, <see cref="SendRequestType.GET"/> or <see cref="SendRequestType.POST"/></param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="AnswerType"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<AnswerType> AskAnswerBook(string _question, SendRequestType requestType,
            string Authentication = "")
        {
            var (result, statuscode) =
                await GetResult<AnswerType>(
                    $"{_UAPI_Request_Url}/text/answerbook/ask{(requestType == SendRequestType.GET ? $"?question={_question}" : string.Empty)}",
                    requestType,
                    requestType == SendRequestType.POST
                        ? JsonConvert.SerializeObject(new
                        {
                            question = _question
                        })
                        : "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "_question", statuscode, new General.UAPIUnknowException(),
                "Text.AskAnswerBook");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class AnswerType : TypeInterface
        {
            /// <summary>
            /// 问题
            /// </summary>
            [JsonProperty("question")]
            public string Question { get; set; }

            /// <summary>
            /// 答案
            /// </summary>
            [JsonProperty("answer")]
            public string Answer { get; set; }
        }
    }
}