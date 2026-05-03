using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 查询bilibili用户时返回的Json列表
        /// </summary>
        public class bilibiliUserType : TypeInterface
        {
            /// <summary>
            /// bilibili 用户的 UID
            /// </summary>
            [JsonProperty("mid")]
            public string MID { get; set; }

            /// <summary>
            /// 昵称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// 性别
            /// </summary>
            [JsonProperty("sex")]
            public string Sex { get; set; }

            /// <summary>
            /// 头像链接
            /// </summary>
            [JsonProperty("face")]
            public string AvatarImageUrl { get; set; }

            /// <summary>
            /// 签名
            /// </summary>
            [JsonProperty("sign")]
            public string Sign { get; set; }

            /// <summary>
            /// 等级 (最大为6)
            /// </summary>
            [JsonProperty("level")]
            public int Level { get; set; }

            /// <summary>
            /// 生日
            /// </summary>
            [JsonProperty("birthday")]
            public string Birthday { get; set; }

            /// <summary>
            /// 大会员等级
            /// </summary>
            [JsonProperty("vip_type")]
            public int VipType { get; set; }

            /// <summary>
            /// 大会员状态
            /// </summary>
            [JsonProperty("vip_status")]
            public int VipStatus { get; set; }

            /// <summary>
            /// 关注数
            /// </summary>
            [JsonProperty("following")]
            public int Following { get; set; }

            /// <summary>
            /// 粉丝数
            /// </summary>
            [JsonProperty("follower")]
            public int Fans { get; set; }

            /// <summary>
            /// 稿件数量
            /// </summary>
            [JsonProperty("archive_count")]
            public int ArchiveCount { get; set; }

            /// <summary>
            /// 文章数量
            /// </summary>
            [JsonProperty("article_count")]
            public int ArticleCount { get; set; }
        }
    }
}