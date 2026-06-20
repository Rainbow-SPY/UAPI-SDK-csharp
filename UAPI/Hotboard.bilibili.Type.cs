using System.Collections.Generic;
using Newtonsoft.Json;
using UAPI.Extensions;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// bilibili热榜请求的返回Json属性列表
        /// </summary>
        public class bilibiliType : Hotboard.HotboardInterface
        {
            /// <summary>
            /// bilibili热榜排行榜列表
            /// </summary>
            public List<lists> list { get; set; }

            /// <summary>
            /// bilibili热榜排行榜列表
            /// </summary>
            public class lists : Hotboard.MainLists
            {
                /// <summary>
                /// 视频的额外信息
                /// </summary>
                public Extra extra { get; set; }
            }

            /// <summary>
            /// 视频UP主信息
            /// </summary>
            public class Owner
            {
                /// <summary>
                /// 头像链接
                /// </summary>
                [JsonProperty("face")]
                public string AvatarImageUrl { get; set; }

                /// <summary>
                /// UID
                /// </summary>
                public long mid { get; set; }

                /// <summary>
                /// 昵称
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }
            }

            /// <summary>
            /// 视频统计信息
            /// </summary>
            public class Stat
            {
                /// <summary>
                /// 格式化单位为'万'的投币量
                /// </summary>
                public string Coin_str => Coin_int.FormatPlayCount();

                /// <summary>
                /// 投币量
                /// </summary>
                [JsonProperty("coin")]
                public int Coin_int { get; set; }

                /// <summary>
                /// 格式化单位为'万'弹幕量
                /// </summary>
                public string Danmaku_str => Danmaku_int.FormatPlayCount();

                /// <summary>
                /// 弹幕量
                /// </summary>
                [JsonProperty("danmaku")]
                public int Danmaku_int { get; set; }

                /// <summary>
                /// 格式化单位为'万'收藏量
                /// </summary>
                public string Favorite_str => Favorite_int.FormatPlayCount();

                /// <summary>
                /// 收藏量
                /// </summary>
                [JsonProperty("favorite")]
                public int Favorite_int { get; set; }

                /// <summary>
                /// 格式化单位为'万'点赞量
                /// </summary>
                public string Like_str => Like_int.FormatPlayCount();

                /// <summary>
                /// 点赞量
                /// </summary>
                [JsonProperty("like")]
                public int Like_int { get; set; }

                /// <summary>
                /// 格式化单位为'万'评论量
                /// </summary>
                public string Reply_str => Reply_int.FormatPlayCount();
                /// <summary>
                /// 评论量
                /// </summary>
                [JsonProperty("reply")]
                public int Reply_int { get; set; }

                /// <summary>
                /// 格式化单位为'万'分享量
                /// </summary>
                public string Share_str =>Share_int.FormatPlayCount();

                /// <summary>
                /// 分享量
                /// </summary>
                [JsonProperty("share")]
                public int Share_int { get; set; }

                /// <summary>
                /// 格式化单位为'万'观看量
                /// </summary>
                public string view_str => View_int.FormatPlayCount();

                /// <summary>
                /// 观看量
                /// </summary>
                [JsonProperty("view")]
                public int View_int { get; set; }
            }

            /// <summary>
            /// 视频详细信息
            /// </summary>
            public class Extra
            {
                /// <summary>
                /// AV号
                /// </summary>
                public long aid { get; set; }

                /// <summary>
                /// BV号
                /// </summary>
                public string bvid { get; set; }

                /// <summary>
                /// 简介
                /// </summary>
                public string desc { get; set; }

                /// <summary>
                /// 总计时长
                /// </summary>
                public string durations => seconds.FormatSecondsTime();

                /// <summary>
                /// 总计时长
                /// </summary>

                [JsonProperty("duration")]
                public int seconds { get; set; }

                /// <summary>
                /// UP主信息
                /// </summary>
                public Owner owner { get; set; }

                /// <summary>
                /// 视频封面链接
                /// </summary>
                [JsonProperty("pic")]
                public string CoverImageUrl { get; set; }

                /// <summary>
                /// 发布时间
                /// </summary>
                public string pubdate_str => pubdate.Contains("T")
                    ? pubdate.FormatISO8601TimeToLocal()
                    : pubdate;

                /// <summary>
                /// 发布时间
                /// </summary>
                public string pubdate { get; set; }

                /// <summary>
                /// 视频荣誉
                /// </summary>
                public string rcmd_reason { get; set; }

                /// <summary>
                /// 视频短链接
                /// </summary>
                public string short_link { get; set; }

                /// <summary>
                /// 视频统计信息
                /// </summary>
                public Stat stat { get; set; }

                /// <summary>
                /// 视频分区名称
                /// </summary>
                public string tname { get; set; }
            }
        }
    }
}