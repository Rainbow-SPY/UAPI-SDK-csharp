using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 获取支持的快递公司列表
        /// </summary>
        /// <returns><see cref="CarriersType"/> 对象</returns>
        public static async Task<CarriersType> GetTrackingCarriers()
        {
            var (result, statusCode) =
                await Interface.GetResult<CarriersType>("https://uapis.cn/api/v1/misc/tracking/carriers");
            if (!Interface.IsGetSuccessful(result, "", statusCode, new General.UAPIUnknowException(),
                    "GetTrackingCarriers", General._UAPI_Unknown_Exception))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}