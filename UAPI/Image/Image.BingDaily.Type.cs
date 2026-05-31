using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 必应壁纸历史列表响应
        /// </summary>
        public class BingDailyHistoryType : TypeInterface
        {
            /// <summary>
            /// 分辨率
            /// </summary>
            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            /// <summary>
            /// 历史壁纸列表
            /// </summary>
            [JsonProperty("items")]
            public System.Collections.Generic.List<BingDailyType> Items { get; set; }

            /// <summary>
            /// 分页信息
            /// </summary>
            [JsonProperty("pagination")]
            public BingDailyPaginationType Pagination { get; set; }

            /// <summary>
            /// 必应壁纸历史分页信息
            /// </summary>
            public class BingDailyPaginationType
            {
                /// <summary>
                /// 当前页码
                /// </summary>
                [JsonProperty("page")]
                public int Page { get; set; }

                /// <summary>
                /// 每页数量
                /// </summary>
                [JsonProperty("page_size")]
                public int PageSize { get; set; }

                /// <summary>
                /// 总记录数
                /// </summary>
                [JsonProperty("total")]
                public int Total { get; set; }
            }
        }

        /// <summary/>
        public class BingDailyType : TypeInterface
        {
            /// <summary>
            /// 必应每日壁纸小知识问答
            /// </summary>
            public class BingTriviaType
            {
                /// <summary>
                /// 问题
                /// </summary>
                [JsonProperty("question")]
                public string Question { get; set; }

                /// <summary>
                /// 选项列表
                /// </summary>
                [JsonProperty("options")]
                public System.Collections.Generic.List<BingTriviaOptionType> Options { get; set; }
            }

            /// <summary>
            /// 必应每日壁纸小知识问答选项
            /// </summary>
            public class BingTriviaOptionType
            {
                /// <summary>
                /// 选项标识（A、B、C）
                /// </summary>
                [JsonProperty("bullet")]
                public string Bullet { get; set; }

                /// <summary>
                /// 选项文本
                /// </summary>
                [JsonProperty("text")]
                public string Text { get; set; }

                /// <summary>
                /// 选项链接
                /// </summary>
                [JsonProperty("url")]
                public string Url { get; set; }
            }


            /// <summary/>
            public enum Format
            {
                /// <summary>
                /// 返回图片二进制
                /// </summary>
                image,

                /// <summary>
                /// 302重定向到图像二进制 (返回仍然是 <see langword="byte[]"/> )
                /// </summary>
                redirect
            }

            /// <summary/>
            public enum Resolutions
            {
                /// <summary/>
                _4K,

                /// <summary/>
                _1080P
            }

            /// <summary>
            /// 图像的日期
            /// </summary>
            [JsonProperty("date")]
            public string Date { get; set; }

            /// <summary>
            /// 区域
            /// </summary>
            [JsonProperty("market")]
            public string MarketLanguage { get; set; }

            /// <summary>
            /// 图片标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 子标题
            /// </summary>
            [JsonProperty("subtitle")]
            public string Subtitle { get; set; }

            /// <summary>
            /// 子标题
            /// </summary>
            [JsonProperty("headline")]
            public string Headline { get; set; }

            /// <summary>
            /// 图像描述
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// 版权所有者
            /// </summary>
            [JsonProperty("copyright")]
            public string Copyright { get; set; }

            /// <summary>
            /// 版权详情链接
            /// </summary>
            [JsonProperty("copyright_link")]
            public string CopyrightLink { get; set; }

            /// <summary/>
            [JsonProperty("quiz_id")]
            public string quiz_id { get; set; }

            /// <summary>
            /// 分辨率
            /// </summary>
            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            /// <summary>
            /// 图像的原始URL
            /// </summary>
            [JsonProperty("image_url")]
            public string Link { get; set; }

            /// <summary>
            /// 图像的4K分辨率地址URL
            /// </summary>
            [JsonProperty("image_url_4k")]
            public string Link_4K { get; set; }

            /// <summary>
            /// 图像的1080P分辨率地址URL
            /// </summary>
            [JsonProperty("image_url_1080")]
            public string Link_1080P { get; set; }

            /// <summary>
            /// 拉取时间
            /// </summary>
            [JsonProperty("fetched_at")]
            public string FetchTime_ISO8601 { get; set; }

            /// <summary>
            /// 最后的更新时间
            /// </summary>
            [JsonProperty("updated_at")]
            public string LastUpdateTime_ISO8601 { get; set; }

            /// <summary>
            /// 小知识问答（仅历史列表返回）
            /// </summary>
            [JsonProperty("trivia")]
            public BingTriviaType Trivia { get; set; }
        }
    }
}