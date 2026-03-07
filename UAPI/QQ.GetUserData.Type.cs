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
            public string QQ { get; set; }

            /// <summary>
            /// 昵称
            /// </summary>
            [JsonProperty("nickname")]
            public string Name { get; set; }

            /// <summary>
            /// 个性签名
            /// </summary>
            [JsonProperty("long_nick")]
            public string CustomSignText { get; set; }

            /// <summary>
            /// 头像链接
            /// </summary>
            [JsonProperty("avatar_url")]
            public string AvatarImageUrl { get; set; }

            /// <summary>
            /// 年龄
            /// </summary>
            [JsonProperty("age")]
            public int Age { get; set; }

            /// <summary>
            /// 性别
            /// </summary>
            [JsonProperty("sex")]
            public string Sex { get; set; }

            /// <summary>
            /// QQ个性域名
            /// </summary>
            [JsonProperty("qid")]
            public string QID { get; set; }

            /// <summary>
            /// QQ等级
            /// </summary>
            [JsonProperty("qq_level")]
            public int QQLevel { get; set; }

            /// <summary>
            /// 地理位置
            /// </summary>
            [JsonProperty("location")]
            public string Location { get; set; }

            /// <summary>
            /// 电子邮箱
            /// </summary>
            [JsonProperty("email")]
            public string Email { get; set; }

            /// <summary>
            /// 是否开通了SVIP
            /// </summary>
            [JsonProperty("is_vip")]
            public bool IsVip { get; set; }

            /// <summary>
            /// 会员等级
            /// </summary>
            [JsonProperty("vip_level")]
            public int VipLevel { get; set; }

            /// <summary>
            /// 注册时间(ISO 8601 格式)
            /// </summary>
            [JsonProperty("reg_time")]
            public string RegisterTime_ISO8601 { get; set; }

            /// <summary>
            /// 注册时间 (字符串格式)
            /// </summary>
            public string RegisterTime =>
                DateTime.TryParse(RegisterTime_ISO8601, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 最后更新时间(ISO 8601 格式)
            /// </summary>
            [JsonProperty("last_updated")]
            public string LastUpdatedTime_ISO8601 { get; set; }

            /// <summary>
            /// 最后更新时间 (字符串格式)
            /// </summary>
            public string LastUpdatedTime =>
                DateTime.TryParse(LastUpdatedTime_ISO8601, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;
        }
    }
}