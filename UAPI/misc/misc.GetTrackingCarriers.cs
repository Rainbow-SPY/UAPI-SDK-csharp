using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 获取支持的快递公司列表
        /// </summary>
        /// <returns><see cref="CarriersType"/> 对象</returns>
        public static async Task<CarriersType> GetTrackingCarriers(string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<CarriersType>($"{Interface._UAPI_Request_Url}misc/tracking/carriers",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "", statusCode, new General.UAPIUnknowException(),
                "GetTrackingCarriers", Core._UAPI_Unknown_Exception);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}