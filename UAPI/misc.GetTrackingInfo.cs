using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 查询快递物流信息
        /// </summary>
        /// <param name="tracking_number">快递单号，通常是一串10-20位的数字或字母数字组合。</param>
        /// <param name="carrier_code">快递公司编码(可选)。不填写时系统会自动识别，填写后可加快查询速度。</param>
        /// <param name="phone">收件人手机尾号，4位数字(可选)。部分快递公司需要验证手机尾号才能查询详细物流信息。</param>
        /// <param name="Authentication">API Token</param>
        /// <returns><see cref="TrackingInfoType"/> 对象</returns>
        public static async Task<TrackingInfoType> GetTrackingInfo(string tracking_number, string carrier_code = "",
            string phone = "", string Authentication = "")
        {
            var (result, statusCode) = await Interface.GetResult<TrackingInfoType>(
                $"{Interface._UAPI_Request_Url}misc/tracking/query?tracking_number={tracking_number}" +
                carrier_code ?? $"&carrier_code={carrier_code}" +
                phone ?? $"&phone={phone}", Authentication);
            if (!Interface.IsGetSuccessful(result, $"tracking_number", statusCode,
                    new IException.General.UAPIUnknowException(), "GetTrackingInfo",
                    IException.General._UAPI_Unknown_Exception))
                LogLibraries.WriteLog.Error("请求失败,请重试");
            return result;
        }
    }
}