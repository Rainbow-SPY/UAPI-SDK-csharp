using Newtonsoft.Json;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// <see cref="GetUserData"/> 返回的属性列表
        /// </summary>
        public class UserType
        {
            /// <summary>
            /// 用户名
            /// </summary>
            public string username { get; }

            /// <summary>
            /// 玩家的32位无破折号UUID。
            /// </summary>
            public string uuid { get; }

            /// <summary>
            /// 玩家当前使用的皮肤图片URL。
            /// </summary>
            public string skin_url { get; }

            /// <summary>
            /// 详细错误信息
            /// </summary>
            [JsonProperty("details")]
            public string[] details { get; set; }

            /// <summary>
            ///  错误消息
            /// </summary>
            [JsonProperty("message")]
            public string message { get; set; }

            /// <summary>
            /// 错误消息
            /// </summary>
            [JsonProperty("error")]
            public string error { get; set; }
        }
    }
}