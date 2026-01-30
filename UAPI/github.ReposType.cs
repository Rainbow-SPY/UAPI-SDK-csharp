using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class github
    {
        public class ReposType
        {
            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("code")]
            public string code { get; set; }

            /// <summary>
            /// 详细错误信息
            /// </summary>
            [JsonProperty("details")]
            public string details { get; set; }

            /// <summary>
            /// 错误信息
            /// </summary>
            [JsonProperty("message")]
            public string message { get; set; }

            /// <summary>
            /// 完整名称
            /// </summary>
            [JsonProperty("full_name")]
            public string full_name { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            [JsonProperty("description")]
            public string description { get; set; }

            /// <summary>
            /// 主页
            /// </summary>
            [JsonProperty("homepage")]
            public string homepage { get; set; }

            /// <summary>
            /// 默认分支
            /// </summary>
            [JsonProperty("default_branch")]
            public string default_branch { get; set; }

            /// <summary>
            /// 主要分支
            /// </summary>
            [JsonProperty("primary_branch")]
            public string primary_branch { get; set; }

            /// <summary>
            /// 可见性
            /// </summary>
            [JsonProperty("visibility")]
            public string visibility { get; set; }

            /// <summary>
            /// 是否归档
            /// </summary>
            [JsonProperty("archived")]
            public bool archived { get; set; }

            /// <summary>
            /// 是否禁用
            /// </summary>
            [JsonProperty("disabled")]
            public bool disabled { get; set; }

            /// <summary>
            /// 是否为 fork
            /// </summary>
            [JsonProperty("fork")]
            public bool fork { get; set; }

            /// <summary>
            /// 主要语言
            /// </summary>
            [JsonProperty("language")]
            public string language { get; set; }

            /// <summary>
            /// 话题
            /// </summary>
            [JsonProperty("topics")]
            public List<string> topics { get; set; }

            /// <summary>
            /// 许可证
            /// </summary>
            [JsonProperty("license")]
            public string license { get; set; }

            /// <summary>
            /// 星星数
            /// </summary>
            [JsonProperty("stargazers")]
            public int stargazers { get; set; }

            /// <summary>
            /// Fork 数
            /// </summary>
            [JsonProperty("forks")]
            public int forks { get; set; }

            /// <summary>
            /// 开放问题数
            /// </summary>
            [JsonProperty("open_issues")]
            public int open_issues { get; set; }

            /// <summary>
            /// 观看者数
            /// </summary>
            [JsonProperty("watchers")]
            public int watchers { get; set; }

            /// <summary>
            /// 最后推送时间（ISO 8601 格式）
            /// </summary>
            [JsonProperty("pushed_at")]
            public string pushed_at { get; set; }

            /// <summary>
            /// 创建时间（ISO 8601 格式）
            /// </summary>
            [JsonProperty("created_at")]
            public string created_at { get; set; }

            /// <summary>
            /// 更新时间（ISO 8601 格式）
            /// </summary>
            [JsonProperty("updated_at")]
            public string updated_at { get; set; }

            /// <summary>
            /// 语言统计
            /// </summary>
            [JsonProperty("languages")]
            public Dictionary<string, int> languages { get; set; }

            /// <summary>
            /// 协作者
            /// </summary>
            [JsonProperty("collaborators")]
            public object collaborators { get; set; }

            /// <summary>
            /// 维护者
            /// </summary>
            [JsonProperty("maintainers")]
            public Maintainer[] maintainers { get; set; }

            /// <summary>
            /// 默认分支的 SHA 值
            /// </summary>
            [JsonProperty("default_branch_sha")]
            public string default_branch_sha { get; set; }

            /// <summary>
            /// 最后推送时间 (字符串格式)
            /// </summary>
            public string pushed_at_str =>
                DateTime.TryParse(pushed_at, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 创建时间 (字符串格式)
            /// </summary>
            public string created_at_str =>
                DateTime.TryParse(created_at, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 更新时间 (字符串格式)
            /// </summary>
            public string updated_at_str =>
                DateTime.TryParse(updated_at, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;
        }

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