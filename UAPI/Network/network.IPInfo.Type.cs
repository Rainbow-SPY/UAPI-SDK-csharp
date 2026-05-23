using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class IPInfoType : TypeInterface
        {
            /// <summary>
            /// 解析的IP地址
            /// </summary>
            [JsonProperty("ip")]
            public string IP { get; set; }

            /// <summary>
            /// 解析后的国家/地区
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
            public double Latitude { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            /// <summary>
            /// Region 解析的地区 Adcode 代码
            /// </summary>
            [JsonProperty("area_code")]
            public string AreaCode { get; set; }

            /// <summary>
            /// 邮政编码 (Zone Improvement Plan Code)
            /// </summary>
            [JsonProperty("zip_code")]
            public string ZIPCode { get; set; }

            /// <summary>
            /// 时区
            /// </summary>
            [JsonProperty("time_zone")]
            public string Timezone { get; set; }

            /// <summary>
            /// IP段起始地址（标准查询）
            /// </summary>
            [JsonProperty("beginip")]
            public string BeginIP { get; set; }

            /// <summary>
            /// IP段结束地址（标准查询）
            /// </summary>
            [JsonProperty("endip")]
            public string EndIP { get; set; }
        }
    }
}