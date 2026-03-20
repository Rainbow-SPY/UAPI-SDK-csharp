using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 查询快递物流返回的Json属性列表
        /// </summary>
        public class TrackingInfoType : Interface.TypeInterface
        {
            /// <summary>
            /// 状态码
            /// </summary>
            [JsonProperty("code")]
            public string Code { get; set; }

            /// <summary>
            /// 消息
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// 返回的数据
            /// </summary>
            [JsonProperty("data")]
            public Data data { get; set; }
            
            /// <summary>
            /// 返回的数据
            /// </summary>
            public class Data
            {
                /// <summary>
                /// 快递公司编码
                /// </summary>
                [JsonProperty("tracking_number")]
                public string TrackingNumber { get; set; }

                /// <summary>
                /// 快递公司编码
                /// </summary>
                [JsonProperty("carrier_code")]
                public string CarrierCode { get; set; }

                /// <summary>
                /// 快递公司名称
                /// </summary>
                [JsonProperty("carrier_name")]
                public string CarrierName { get; set; }

                /// <summary>
                /// 物流轨迹数量
                /// </summary>
                [JsonProperty("track_count")]
                public int TrackCount { get; set; }

                /// <summary>
                /// 物流轨迹列表，按时间倒序排列
                /// </summary>
                [JsonProperty("tracks")]
                public List<TracksItem> Tracks { get; set; }
                
                /// <summary>
                /// 物流更新状态列表
                /// </summary>
                public class TracksItem
                {
                    /// <summary>
                    /// 物流更新时间
                    /// </summary>
                    [JsonProperty("time")]
                    public string Time { get; set; }

                    /// <summary>
                    /// 物流状态描述
                    /// </summary>
                    [JsonProperty("context")]
                    public string Context { get; set; }
                }
            }
        }
    }
}