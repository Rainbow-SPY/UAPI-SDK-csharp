using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 获取查询快递物流的快递公司列表返回的Json属性列表
        /// </summary>
        public class CarriersType : Interface.TypeInterface
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
                public string code { get; set; }

                /// <summary>
                /// 快递公司中文名称，用于界面显示
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }
            }

            /// <summary>
            /// 快递公司列表
            /// </summary>
            [JsonProperty("carriers")]
            public List<CarriersItem> carriers { get; set; }

            /// <summary>
            /// 支持的快递公司总数
            /// </summary>
            [JsonProperty("total")]
            public int total { get; set; }
        }
    }
}