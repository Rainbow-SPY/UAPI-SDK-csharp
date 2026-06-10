using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary />
        public class MinecraftSearchMods : TypeInterface
        {
            /// <summary />
            public enum Source
            {
                /// <summary />
                all,

                /// <summary />
                modrinth,

                /// <summary />
                spigotmc
            }

            /// <summary />
            public class ResultsItem
            {
                /// <summary>
                /// 模组来源
                /// </summary>
                [JsonProperty("source")]
                public string source { get; set; }

                /// <summary>
                /// 模组ID
                /// </summary>
                [JsonProperty("id")]
                public string id { get; set; }

                [JsonProperty("slug")] public string Slug { get; set; }

                /// <summary>
                /// 模组名称
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }

                /// <summary>
                /// 模组描述
                /// </summary>
                [JsonProperty("description")]
                public string Description { get; set; }

                /// <summary>
                /// 模组作者
                /// </summary>
                [JsonProperty("author")]
                public string Author { get; set; }

                /// <summary>
                /// 项目分类
                /// </summary>
                [JsonProperty("project_type")]
                public string ProjectType { get; set; }

                /// <summary>
                /// 支持的模组加载器
                /// </summary>
                [JsonProperty("categories")]
                public List<string> categories { get; set; }

                /// <summary>
                /// 模组支持的游戏版本
                /// </summary>
                [JsonProperty("game_versions")]
                public List<string> game_versions { get; set; }

                /// <summary>
                /// 下载量
                /// </summary>
                [JsonProperty("downloads")]
                public long downloads { get; set; }

                /// <summary>
                /// 点赞量 / 粉丝量
                /// </summary>
                [JsonProperty("follows")]
                public int follows { get; set; }

                /// <summary>
                /// 图标 URL 地址
                /// </summary>
                [JsonProperty("icon_url")]
                public string icon_url { get; set; }

                /// <summary>
                /// 模组介绍页
                /// </summary>
                [JsonProperty("page_url")]
                public string page_url { get; set; }

                /// <summary>
                /// 直链下载链接
                /// </summary>
                [JsonProperty("download_url")]
                public string download_url { get; set; }
            }

            /// <summary>
            /// 指定搜索的名称
            /// </summary>
            [JsonProperty("query")]
            public string query { get; set; }

            /// <summary>
            /// 检索模组的来源
            /// </summary>
            [JsonProperty("source")]
            public string source { get; set; }

            /// <summary>
            /// 检索到的数量
            /// </summary>
            [JsonProperty("total")]
            public int Count { get; set; }

            /// <summary>
            /// 检索的结果
            /// </summary>
            [JsonProperty("results")]
            public List<ResultsItem> results { get; set; }

            /// <summary>
            /// 检索的来源
            /// </summary>
            [JsonProperty("sources")]
            public List<string> sources { get; set; }
        }
    }
}