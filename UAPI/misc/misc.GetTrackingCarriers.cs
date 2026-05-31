using System.Collections.Generic;
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

    public partial class Type
    {
        /// <summary>
        /// 获取查询快递物流的快递公司列表返回的Json属性列表
        /// </summary>
        public class CarriersType : TypeInterface
        {
            /// <summary>
            /// 快递公司列表
            /// </summary>
            public class CarriersItem
            {
                /// <summary>
                /// 快递公司编码，用于API调用时的carrier_code参数
                /// </summary>
                [JsonProperty("code")]
                public string Code { get; set; }

                /// <summary>
                /// 快递公司中文名称，用于界面显示
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }
            }

            /// <summary>
            /// 快递公司列表
            /// </summary>
            [JsonProperty("carriers")]
            public List<CarriersItem> Carriers { get; set; }

            /// <summary>
            /// 支持的快递公司总数
            /// </summary>
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
}