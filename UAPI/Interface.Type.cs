using Newtonsoft.Json;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 自定义类的接口公共属性基类
        /// </summary>
        public class TypeInterface
        {
            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("code")]
            public string code { get; set; }
            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("error")]
            public string error { get; set; }

            /// <summary>
            /// 错误信息
            /// </summary>
            [JsonProperty("message")]
            public string message { get; set; }

            /// <summary>
            /// 详细错误信息
            /// </summary>
            [JsonProperty("details")]
            public string details { get; set; }
        }
    }
}