using Newtonsoft.Json;

namespace UAPI
{
    public partial class QQ
    {
        public class GroupType
        {
            /// <summary>
            /// 群ID
            /// </summary>
            [JsonProperty("group_id")]
            public string group_id { get; set; }

            /// <summary>
            /// 群名称
            /// </summary>
            [JsonProperty("group_name")]
            public string group_name { get; set; }

            /// <summary>
            /// 群头像链接地址
            /// </summary>
            [JsonProperty("avatar_url")]
            public string avatar_url { get; set; }

            /// <summary>
            /// 群简介
            /// </summary>
            [JsonProperty("description")]
            public string description { get; set; }

            /// <summary>
            /// 群标签
            /// </summary>
            [JsonProperty("tag")]
            public string tag { get; set; }

            /// <summary>
            /// 群QR码地址
            /// </summary>
            [JsonProperty("join_url")]
            public string join_url { get; set; }

            /// <summary>
            /// 最后更新时间 (ISO 8601)
            /// </summary>
            [JsonProperty("last_updated")]
            public string last_updated { get; set; }

            /// <summary>
            /// 当前成员数
            /// </summary>
            [JsonProperty("member_count")]
            public int member_count { get; set; }

            /// <summary>
            /// 最大成员数量
            /// </summary>
            [JsonProperty("max_member_count")]
            public int max_member_count { get; set; }

            /// <summary>
            /// 活跃成员数（可选，部分群有此数据）
            /// </summary>
            [JsonProperty("active_member_num")]
            public int active_member_num { get; set; }

            /// <summary>
            /// 群主QQ号（可选）
            /// </summary>
            [JsonProperty("owner_uin")]
            public string owner_uin { get; set; }

            /// <summary>
            /// 群主UID（可选）
            /// </summary>
            [JsonProperty("owner_uid")]
            public string owner_uid { get; set; }

            /// <summary>
            /// 建群时间戳（Unix时间戳，可选）
            /// </summary>
            [JsonProperty("create_time")]
            public string create_time { get; set; }

            /// <summary>
            /// 建群时间格式化字符串（可选）
            /// </summary>
            [JsonProperty("create_time_str")]
            public string create_time_str { get; set; }

            /// <summary>
            /// 群等级（可选）
            /// </summary>
            [JsonProperty("group_grade")]
            public int group_grade { get; set; }

            /// <summary>
            /// 群公告/简介（可选）
            /// </summary>
            [JsonProperty("group_memo")]
            public string group_memo { get; set; }

            /// <summary>
            /// 认证类型（0=未认证，可选）
            /// </summary>
            [JsonProperty("cert_type")]
            public int cert_type { get; set; }

            /// <summary>
            /// 认证类型
            /// </summary>
            public string cert_type_str => cert_type == 0 ? "未认证" : "已认证";

            /// <summary>
            /// 认证说明文本（可选）
            /// </summary>
            [JsonProperty("cert_text")]
            public string cert_text { get; set; }

            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("code")]
            public string code { get; set; }

            /// <summary>
            /// ???
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