using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 查询bilibili稿件时返回的Json列表
        /// </summary>
        public class ArchiveType : TypeInterface
        {
            /// <summary>
            /// 投搞的视频总数量
            /// </summary>
            [JsonProperty("total")]
            public int Total { get; set; }

            /// <summary>
            /// 页码数量
            /// </summary>
            [JsonProperty("page")]
            public int PageCount { get; set; }

            /// <summary>
            /// 每页的数量
            /// </summary>
            [JsonProperty("size")]
            public int PageSize { get; set; }

            /// <summary>
            /// 视频的详细信息
            /// </summary>
            [JsonProperty("videos")]
            public List<Videos> VideosList { get; set; }

            /// <summary>
            /// 视频的综合数据
            /// </summary>
            public class Videos
            {
                private int _isPayVideo;

                /// <summary>
                /// 视频的AID
                /// </summary>
                [JsonProperty("aid")]
                public long AID { get; set; }

                /// <summary>
                /// 视频的bv号
                /// </summary>
                [JsonProperty("bvid")]
                public string BVID { get; set; }

                /// <summary>
                /// 视频的标题
                /// </summary>
                [JsonProperty("title")]
                public string Title { get; set; }

                /// <summary>
                /// 视频的封面
                /// </summary>
                [JsonProperty("cover")]
                public string CoverImageUrl { get; set; }

                /// <summary>
                /// 一个视频内所有选集的总时长(秒)
                /// </summary>
                [JsonProperty("duration")]
                public long Duration { get; set; }

                /// <summary>
                /// 播放量
                /// </summary>
                [JsonProperty("play_count")]
                public long PlayCount { get; set; }

                /// <summary>
                /// 视频发布的时间 (时间戳格式)
                /// </summary>
                [JsonProperty("publish_time")]
                public long PublishTime { get; set; }

                /// <summary>
                /// 视频发布的时间 (字符串格式)
                /// </summary>
                public string PublishTimeStr => TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))
                    .AddSeconds(PublishTime).ToString(CultureInfo.CurrentCulture); //当地时区

                /// <summary>
                /// 视频创建的时间 (时间戳格式)
                /// </summary>
                [JsonProperty("create_time")]
                public long CreateTime { get; set; }

                /// <summary>
                /// 视频创建的时间 (字符串格式)
                /// </summary>
                public string CreateTimeStr => TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))
                    .AddSeconds(CreateTime).ToString(CultureInfo.CurrentCulture); //当地时区

                /// <summary>
                /// 当前状态
                /// </summary>
                [JsonProperty("state")]
                public int State { get; set; }

                /// <summary>
                /// 是否为充电视频, 0=免费，1=付费
                /// </summary>
                [JsonProperty("is_ugc_pay")]
                public bool IsPayVideo
                {
                    get => _isPayVideo != 0;
                    set => _isPayVideo = value ? 1 : 0;
                }

                /// <summary>
                /// 是否为充电视频, 直接返回字符串 免费 or 付费
                /// </summary>
                public string IsPayVideo_str => IsPayVideo ? "付费" : "免费";

                /// <summary>
                /// 是否为共创视频
                /// </summary>
                [JsonProperty("is_interactive")]
                public bool IsInteractive { get; set; }
            }
        }
    }
}