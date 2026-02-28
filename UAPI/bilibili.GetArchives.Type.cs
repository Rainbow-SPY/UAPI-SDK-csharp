using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 查询bilibili稿件时返回的Json列表
        /// </summary>
        public class ArchiveType : Interface.TypeInterface
        {
            /// <summary>
            /// 投搞的视频总数量
            /// </summary>
            public int total { get; set; }

            /// <summary>
            /// 页码数量
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 每页的数量
            /// </summary>
            public int size { get; set; }

            /// <summary>
            /// 视频的详细信息
            /// </summary>
            public List<Videos> videos { get; set; }

            /// <summary>
            /// 视频的综合数据
            /// </summary>
            public class Videos
            {
                private int _isPayVideo;

                /// <summary>
                /// 视频的AID
                /// </summary>
                public long aid { get; set; }

                /// <summary>
                /// 视频的bv号
                /// </summary>
                public string bvid { get; set; }

                /// <summary>
                /// 视频的标题
                /// </summary>
                public string title { get; set; }

                /// <summary>
                /// 视频的封面
                /// </summary>
                public string cover { get; set; }

                /// <summary>
                /// 一个视频内所有选集的总时长(秒)
                /// </summary>
                public long duration { get; set; }

                /// <summary>
                /// 播放量
                /// </summary>
                public long play_count { get; set; }

                /// <summary>
                /// 视频发布的时间 (时间戳格式)
                /// </summary>
                public long publish_time { get; set; }

                /// <summary>
                /// 视频发布的时间 (字符串格式)
                /// </summary>
                public string publish_time_str => TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))
                    .AddSeconds(publish_time).ToString(CultureInfo.CurrentCulture); //当地时区

                /// <summary>
                /// 视频创建的时间 (时间戳格式)
                /// </summary>
                public long create_time { get; set; }

                /// <summary>
                /// 视频创建的时间 (字符串格式)
                /// </summary>
                public string create_time_str => TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))
                    .AddSeconds(create_time).ToString(CultureInfo.CurrentCulture); //当地时区

                /// <summary>
                /// 当前状态
                /// </summary>
                public int state { get; set; }

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
                public string IsPayVideo_str => IsPayVideo ? "免费" : "付费";

                /// <summary>
                /// 是否为共创视频
                /// </summary>
                [JsonProperty("is_interactive")]
                public bool IsInteractive { get; set; }
            }
        }
    }
}