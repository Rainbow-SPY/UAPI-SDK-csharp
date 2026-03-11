using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class github
    {
        /// <summary>
        /// 查询github仓库时返回的Json列表
        /// </summary>
        public class ReposType : Interface.TypeInterface
        {
            private string _visibility = "private";

            /// <summary>
            /// 完整名称
            /// </summary>
            [JsonProperty("full_name")]
            public string FullName { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// 主页
            /// </summary>
            [JsonProperty("homepage")]
            public string HomePage { get; set; }

            /// <summary>
            /// 默认分支
            /// </summary>
            [JsonProperty("default_branch")]
            public string DefaultBranch { get; set; }

            /// <summary>
            /// 主要分支
            /// </summary>
            [JsonProperty("primary_branch")]
            public string PrimaryBranch { get; set; }

            /// <summary>
            /// 可见性
            /// </summary>
            [JsonProperty("visibility")]
            public string Visibility { get; set; }

            /// <summary>
            /// 仓库是否为公开
            /// </summary>
            public bool IsPublic => Visibility == "public";

            /// <summary>
            /// 是否归档
            /// </summary>
            [JsonProperty("archived")]
            public bool IsArchived { get; set; }

            /// <summary>
            /// 是否禁用
            /// </summary>
            [JsonProperty("disabled")]
            public bool IsDisabled { get; set; }

            /// <summary>
            /// 是否为 fork
            /// </summary>
            [JsonProperty("fork")]
            public bool IsForked { get; set; }

            /// <summary>
            /// 主要语言
            /// </summary>
            [JsonProperty("language")]
            public string MainLanguage { get; set; }

            /// <summary>
            /// 话题
            /// </summary>
            [JsonProperty("topics")]
            public List<string> Topics { get; set; }

            /// <summary>
            /// 许可证
            /// </summary>
            [JsonProperty("license")]
            public string License { get; set; }

            /// <summary>
            /// 星星数
            /// </summary>
            [JsonProperty("stargazers")]
            public int Stargazers { get; set; }

            /// <summary>
            /// Fork 数
            /// </summary>
            [JsonProperty("forks")]
            public int Forks { get; set; }

            /// <summary>
            /// 开放问题数
            /// </summary>
            [JsonProperty("open_issues")]
            public int OpenIssues { get; set; }

            /// <summary>
            /// 关注者数
            /// </summary>
            [JsonProperty("watchers")]
            public int Watchers { get; set; }

            /// <summary>
            /// 最后推送时间(ISO 8601 格式)
            /// </summary>
            [JsonProperty("pushed_at")]
            public string PushedTime_ISO8601 { get; set; }

            /// <summary>
            /// 创建时间(ISO 8601 格式)
            /// </summary>
            [JsonProperty("created_at")]
            public string CreatedTime_ISO8601 { get; set; }

            /// <summary>
            /// 更新时间(ISO 8601 格式)
            /// </summary>
            [JsonProperty("updated_at")]
            public string UpdatedTime_ISO8601 { get; set; }

            /// <summary>
            /// 语言统计
            /// </summary>
            [JsonProperty("languages")]
            public Dictionary<string, int> LanguagesStats { get; set; }

            /// <summary>
            /// 协作者
            /// </summary>
            [JsonProperty("collaborators")]
            public object Collaborators { get; set; }

            /// <summary>
            /// 维护者
            /// </summary>
            [JsonProperty("maintainers")]
            public Maintainer[] Maintainers { get; set; }

            /// <summary>
            /// 默认分支的 SHA 值
            /// </summary>
            [JsonProperty("default_branch_sha")]
            public string DefaultBranchSHAHash { get; set; }

            /// <summary>
            /// 最后推送时间 (字符串格式)
            /// </summary>
            public string PushedTime_String =>
                DateTime.TryParse(PushedTime_ISO8601, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 创建时间 (字符串格式)
            /// </summary>
            public string CreatedTime_String =>
                DateTime.TryParse(CreatedTime_ISO8601, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 更新时间 (字符串格式)
            /// </summary>
            public string UpdatedTime_Str =>
                DateTime.TryParse(UpdatedTime_ISO8601, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;
        }

        /// <summary>
        /// 维护者
        /// </summary>
        public class Maintainer
        {
            /// <summary>
            /// 登录名
            /// </summary>
            [JsonProperty("login")]
            public string login { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            [JsonProperty("name")]
            public string name { get; set; }

            /// <summary>
            /// 邮件
            /// </summary>
            [JsonProperty("email")]
            public string email { get; set; }

            /// <summary>
            /// URL
            /// </summary>
            [JsonProperty("url")]
            public string url { get; set; }
        }
    }
}