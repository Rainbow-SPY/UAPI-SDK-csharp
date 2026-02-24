using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 识别快递公司
        ///
        /// 不确定手里的快递单号属于哪家快递公司？这个接口专门做识别，不查物流。
        /// </summary>
        /// <param name="tracking_number">快递单号</param>
        /// <returns><see cref="DetectedCarrierType"/> 对象</returns>
        public static async Task<DetectedCarrierType> DetectTrackingCarrier(string tracking_number)
        {
            var (result, statusCode) = await Interface.GetResult<DetectedCarrierType>(
                $"https://uapis.cn/api/v1/misc/tracking/detect?tracking_number={tracking_number}");
            if (!Interface.IsGetSuccessful(result, "tracking_number", statusCode, new General.UAPIUnknowException(),
                    "DetectTrackingCarrier", General._UAPI_Unknown_Exception))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}