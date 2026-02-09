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
            public string username { get; set;  }

            /// <summary>
            /// 玩家的32位无破折号UUID。
            /// </summary>
            public string uuid { get;  set; }

            /// <summary>
            /// 玩家当前使用的皮肤图片URL。
            /// </summary>
            public string skin_url { get;  set; }
        }
    }
}