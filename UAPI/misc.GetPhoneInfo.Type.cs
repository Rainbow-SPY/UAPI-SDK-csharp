using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 中国大陆的电话号码归属地
        /// </summary>
        public class PhoneInfoType : Interface.TypeInterface
        {
            /// <summary>
            /// 省份归属地
            /// </summary>
            [JsonProperty("province")]
            public string province { get; set; }

            /// <summary>
            /// 城市/地区归属地
            /// </summary>
            [JsonProperty("city")]
            public string city { get; set; }

            /// <summary>
            /// 运营商名称
            /// </summary>
            [JsonProperty("sp")]
            public string sp { get; set; }
        }
    }
}