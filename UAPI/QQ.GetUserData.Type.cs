using System;
using System.Globalization;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class QQ
    {
        /// <summary>
        /// 查询QQ用户时返回的Json列表
        /// </summary>
        public class UserType : Interface.TypeInterface
        {
            /// <summary>
            /// QQ号
            /// </summary>
            [JsonProperty("qq")]
            public string qq { get; set; }

            /// <summary>
            /// 昵称
            /// </summary>
            [JsonProperty("nickname")]
            public string nickname { get; set; }

            /// <summary>
            /// 个性签名
            /// </summary>
            [JsonProperty("long_nick")]
            public string long_nick { get; set; }

            /// <summary>
            /// 头像链接
            /// </summary>
            [JsonProperty("avatar_url")]
            public string avatar_url { get; set; }

            /// <summary>
            /// 年龄
            /// </summary>
            [JsonProperty("age")]
            public int age { get; set; }

            /// <summary>
            /// 性别
            /// </summary>
            [JsonProperty("sex")]
            public string sex { get; set; }

            /// <summary>
            /// QQ个性域名
            /// </summary>
            [JsonProperty("qid")]
            public string qid { get; set; }

            /// <summary>
            /// QQ等级
            /// </summary>
            [JsonProperty("qq_level")]
            public int qq_level { get; set; }

            /// <summary>
            /// 地理位置
            /// </summary>
            [JsonProperty("location")]
            public string location { get; set; }

            /// <summary>
            /// 电子邮箱
            /// </summary>
            [JsonProperty("email")]
            public string email { get; set; }

            /// <summary>
            /// 是否开了SVIP
            /// </summary>
            [JsonProperty("is_vip")]
            public bool is_vip { get; set; }

            /// <summary>
            /// 会员等级
            /// </summary>
            [JsonProperty("vip_level")]
            public int vip_level { get; set; }

            /// <summary>
            /// 注册时间（ISO 8601 格式）
            /// </summary>
            [JsonProperty("reg_time")]
            public string reg_time { get; set; }

            /// <summary>
            /// 注册时间 (字符串格式)
            /// </summary>
            public string reg_time_str =>
                DateTime.TryParse(reg_time, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 最后更新时间（ISO 8601 格式）
            /// </summary>
            [JsonProperty("last_updated")]
            public string last_updated { get; set; }

            /// <summary>
            /// 最后更新时间 (字符串格式)
            /// </summary>
            public string last_updated_str =>
                DateTime.TryParse(last_updated, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;
        }
    }
}