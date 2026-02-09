using Newtonsoft.Json;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 查询bilibili用户时返回的Json列表
        /// </summary>
        public class UserType : Interface.TypeInterface
        {
            /// <summary>
            /// bilibili 用户的 UID
            /// </summary>
            [JsonProperty("mid")]
            public string mid { get; set; }

            /// <summary>
            /// 昵称
            /// </summary>
            [JsonProperty("name")]
            public string name { get; set; }

            /// <summary>
            /// 性别
            /// </summary>
            [JsonProperty("sex")]
            public string sex { get; set; }

            /// <summary>
            /// 头像链接
            /// </summary>
            [JsonProperty("face")]
            public string face { get; set; }

            /// <summary>
            /// 签名
            /// </summary>
            [JsonProperty("sign")]
            public string sign { get; set; }

            /// <summary>
            /// 等级 (最大为6)
            /// </summary>
            [JsonProperty("level")]
            public int level { get; set; }

            /// <summary>
            /// 生日
            /// </summary>
            [JsonProperty("birthday")]
            public string birthday { get; set; }

            /// <summary>
            /// 大会员等级
            /// </summary>
            [JsonProperty("vip_type")]
            public int vip_type { get; set; }

            /// <summary>
            /// 大会员状态
            /// </summary>
            [JsonProperty("vip_status")]
            public int vip_status { get; set; }

            /// <summary>
            /// 关注数
            /// </summary>
            [JsonProperty("following")]
            public int following { get; set; }

            /// <summary>
            /// 粉丝数
            /// </summary>
            [JsonProperty("follower")]
            public int follower { get; set; }

            /// <summary>
            /// 稿件数量
            /// </summary>
            [JsonProperty("archive_count")]
            public int archive_count { get; set; }

            /// <summary>
            /// 文章数量
            /// </summary>
            [JsonProperty("article_count")]
            public int article_count { get; set; }
        }
    }
}