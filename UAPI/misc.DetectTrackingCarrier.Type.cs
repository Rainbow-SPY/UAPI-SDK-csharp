using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 识别到的快递公司返回的Json属性列表
        /// </summary>
        public class DetectedCarrierType : Interface.TypeInterface
        {
            /// <summary>
            /// 其他可能的快递公司列表（如果存在)
            /// </summary>
            public class AlternativesItem
            {
                /// <summary>
                /// 快递公司编码
                /// </summary>
                [JsonProperty("code")]
                public string Code { get; set; }

                /// <summary>
                /// 快递公司名称
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }
            }

            /// <summary>
            /// 返回的数据
            /// </summary>
            public class Data
            {
                /// <summary>
                /// 查询的快递单号
                /// </summary>
                [JsonProperty("tracking_number")]
                public string TrackingNumber { get; set; }

                /// <summary>
                /// 最可能的快递公司编码
                /// </summary>
                [JsonProperty("carrier_code")]
                public string CarrierCode { get; set; }

                /// <summary>
                /// 最可能的快递公司名称
                /// </summary>
                [JsonProperty("carrier_name")]
                public string CarrierName { get; set; }

                /// <summary>
                /// 其他可能的快递公司列表（如果存在）
                /// </summary>
                [JsonProperty("alternatives")]
                public List<AlternativesItem> alternatives { get; set; }
            }

            /// <summary>
            /// 返回值
            /// </summary>
            [JsonProperty("code")]
            public new string Code { get; set; }

            /// <summary>
            /// 返回消息
            /// </summary>
            [JsonProperty("message")]
            public new string Message { get; set; }

            /// <summary>
            /// 返回的数据
            /// </summary>
            [JsonProperty("data")]
            public Data data { get; set; }
        }
    }
}