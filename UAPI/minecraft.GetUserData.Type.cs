using Newtonsoft.Json;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// <see cref="GetUserData"/> 返回的属性列表
        /// </summary>
        public class UserType : Interface.TypeInterface
        {
            /// <summary>
            /// 用户名
            /// </summary>
            [JsonProperty("username")]
            public string UserName { get; set; }

            /// <summary>
            /// 玩家的32位无破折号UUID
            /// </summary>
            [JsonProperty("uuid")]
            public string UUID { get; set; }

            /// <summary>
            /// 玩家当前使用的皮肤图片URL
            /// </summary>
            [JsonProperty("skin_url")]
            public string SkinImageUrl { get; set; }
        }
    }
}