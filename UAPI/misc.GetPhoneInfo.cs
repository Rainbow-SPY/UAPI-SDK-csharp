using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 查询中国大陆手机号码的归属地
        /// </summary>
        /// <param name="phoneNumber">指定要查询的手机号码</param>
        /// <returns><see cref="PhoneInfoType"/> 对象</returns>
        public static async Task<PhoneInfoType> GetPhoneInfo(string phoneNumber)
        {
            var (result, statusCode) =
                await Interface.GetResult<PhoneInfoType>($"{_Request_Url}phoneinfo?phone={phoneNumber}");
            if (!Interface.IsGetSuccessful(result,"phone",statusCode,new IException.General.UAPIUnknowException(),"GetPhoneInfo"))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}