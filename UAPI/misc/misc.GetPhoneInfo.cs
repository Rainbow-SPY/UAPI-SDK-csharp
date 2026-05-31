using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Misc
    {
        /// <summary>
        /// 查询中国大陆手机号码的归属地
        /// </summary>
        /// <param name="phoneNumber">指定要查询的手机号码</param>
        /// <param name="Authentication">API Token</param>
        /// <returns><see cref="PhoneInfoType"/> 对象</returns>
        public static async Task<PhoneInfoType> GetPhoneInfo(string phoneNumber, string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<PhoneInfoType>($"{_Request_Url}misc/phoneinfo?phone={phoneNumber}",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "phone", statusCode, new General.UAPIUnknowException(),
                "GetPhoneInfo");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
    
    public partial class Type
    {
        /// <summary>
        /// 中国大陆的电话号码归属地
        /// </summary>
        public class PhoneInfoType : TypeInterface
        {
            /// <summary>
            /// 省份归属地
            /// </summary>
            [JsonProperty("province")]
            public string Province { get; set; }

            /// <summary>
            /// 城市/地区归属地
            /// </summary>
            [JsonProperty("city")]
            public string City { get; set; }

            /// <summary>
            /// 运营商名称
            /// </summary>
            [JsonProperty("sp")]
            public string LSP { get; set; }
        }
    }

}