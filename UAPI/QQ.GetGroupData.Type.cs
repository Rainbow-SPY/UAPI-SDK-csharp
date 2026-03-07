using Newtonsoft.Json;

namespace UAPI
{
    public partial class QQ
    {
        /// <summary>
        /// 查询QQ群组返回的Json列表
        /// </summary>
        public class GroupType : Interface.TypeInterface
        {
            private int _certType;

            /// <summary>
            /// 群ID
            /// </summary>
            [JsonProperty("group_id")]
            public string ID { get; set; }

            /// <summary>
            /// 群名称
            /// </summary>
            [JsonProperty("group_name")]
            public string Name { get; set; }

            /// <summary>
            /// 群头像链接地址
            /// </summary>
            [JsonProperty("avatar_url")]
            public string AvatarImageUrl { get; set; }

            /// <summary>
            /// 群简介
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// 群标签
            /// </summary>
            [JsonProperty("tag")]
            public string Tag { get; set; }

            /// <summary>
            /// 群QR码地址
            /// </summary>
            [JsonProperty("join_url")]
            public string JoinQRCodeUrl { get; set; }

            /// <summary>
            /// 最后更新时间 (ISO 8601)
            /// </summary>
            [JsonProperty("last_updated")]
            public string LastUpdatedTime { get; set; }

            /// <summary>
            /// 当前成员数
            /// </summary>
            [JsonProperty("member_count")]
            public int MemberCount { get; set; }

            /// <summary>
            /// 最大成员数量
            /// </summary>
            [JsonProperty("max_member_count")]
            public int MaxMemberCount { get; set; }

            /// <summary>
            /// 活跃成员数(可选，部分群有此数据)
            /// </summary>
            [JsonProperty("active_member_num")]
            public int ActiveMemberNum { get; set; }

            /// <summary>
            /// 群主QQ号(可选)
            /// </summary>
            [JsonProperty("owner_uin")]
            public string OwnerUinID { get; set; }

            /// <summary>
            /// 群主UID(可选)
            /// </summary>
            [JsonProperty("owner_uid")]
            public string OwnerUID { get; set; }

            /// <summary>
            /// 建群时间戳(Unix时间戳，可选)
            /// </summary>
            [JsonProperty("create_time")]
            public string CreateTimeUnix { get; set; }

            /// <summary>
            /// 建群时间格式化字符串(可选)
            /// </summary>
            [JsonProperty("create_time_str")]
            public string CreateTime { get; set; }

            /// <summary>
            /// 群等级(可选)
            /// </summary>
            [JsonProperty("group_grade")]
            public int GroupLevel { get; set; }

            /// <summary>
            /// 群公告/简介(可选)
            /// </summary>
            [JsonProperty("group_memo")]
            public string Introduction { get; set; }

            /// <summary>
            /// 是否认证
            /// </summary>
            [JsonProperty("cert_type")]
            public bool IsCert
            {
                get => _certType != 0;
                set => _certType = value ? _certType : 0;
            }

            /// <summary>
            /// 认证说明文本(可选)
            /// </summary>
            [JsonProperty("cert_text")]
            public string CertDescription { get; set; }
        }
    }
}