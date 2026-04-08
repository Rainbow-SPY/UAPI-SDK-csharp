using Newtonsoft.Json;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 请求本机的IP地址返回的Json属性列表
        /// </summary>
        public class IPType : Interface.TypeInterface
        {
            /// <summary>
            /// 你的公网IP地址
            /// </summary>
            [JsonProperty("ip")]
            public string IP { get; set; }

            /// <summary>
            /// IP段起始地址(标准查询)
            /// </summary>
            [JsonProperty("beginip")]
            public string BeginAddress { get; set; }

            /// <summary>
            /// IP段结束地址(标准查询)
            /// </summary>
            [JsonProperty("endip")]
            public string EndAddress { get; set; }

            /// <summary>
            /// 地理位置，格式：国家 省份 城市
            /// </summary>
            [JsonProperty("region")]
            public string Region { get; set; }

            /// <summary>
            /// 运营商名称
            /// </summary>
            [JsonProperty("isp")]
            public string ISP { get; set; }

            /// <summary>
            /// 自治系统编号
            /// </summary>
            [JsonProperty("asn")]
            public string ASN { get; set; }

            /// <summary>
            /// 归属机构
            /// </summary>
            [JsonProperty("llc")]
            public string LLC { get; set; }

            /// <summary>
            /// 纬度
            /// </summary>
            [JsonProperty("latitude")]
            public decimal Latitude { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            [JsonProperty("longitude")]
            public decimal Longitude { get; set; }

            /// <summary>
            /// 行政区 (仅限商业查询)
            /// </summary>
            [JsonProperty("district")]
            public string District_Pro { get; set; }
        }
    }
}