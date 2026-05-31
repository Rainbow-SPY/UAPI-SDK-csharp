using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Random
    {
        /// <summary>
        /// 生成随机不同格式的字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="stringType">构成字符串的方式</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="RandomStringType"/>对象</returns>
        /// <exception cref="General.UAPIUnknowException">未知的异常</exception>
        public static async Task<RandomStringType> GetString(int length, RandomStringType.StringType stringType,
            string Authentication = "")
        {
            var (result, statuscode) =
                await Interface.GetResult<RandomStringType>(
                    $"{Interface._UAPI_Request_Url}/random/string?length={length}&type={stringType.ToString()}",
                    Interface.SendRequestType.GET, "", "application/json", Authentication);
            var list = Interface.IsGetSuccessful(result, "length or stringType", statuscode,
                new General.UAPIUnknowException(), "random.GetString");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class RandomStringType : TypeInterface
        {
            /// <summary>
            /// 返回的随机文本
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary/>
            public enum StringType
            {
                /// <summary>
                /// 纯数字
                /// </summary>
                numeric,

                /// <summary>
                /// 小写
                /// </summary>
                lower,

                /// <summary>
                /// 大写
                /// </summary>
                upper,

                /// <summary>
                /// 大小写字母
                /// </summary>
                alpha,

                /// <summary>
                /// 字母+数字
                /// </summary>
                alphanumeric,

                /// <summary>
                /// 十六进制
                /// </summary>
                hex
            }
        }
    }
}