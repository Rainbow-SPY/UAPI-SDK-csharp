using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class hotboard
    {
        /// <summary>
        /// bilibili热榜请求的返回Json属性列表
        /// </summary>
        public class bilibiliType : Interface.Hotboard.HotboardInterface
        {
            /// <summary>
            /// bilibili热榜排行榜列表
            /// </summary>
            public new List<lists> list { get; set; }

            /// <summary>
            /// bilibili热榜排行榜列表
            /// </summary>
            public class lists : Interface.Hotboard.MainLists
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
                public string Face { get; set; }

                /// <summary>
                /// UID
                /// </summary>
                public long Mid { get; set; }

                /// <summary>
                /// 昵称
                /// </summary>
                public string Name { get; set; }
            }

            /// <summary>
            /// 视频统计信息
            /// </summary>
            public class Stat
            {
                /// <summary>
                /// 投币量
                /// </summary>
                public string Coin_str => Interface.FormatPlayCount(Coin_int);

                /// <summary>
                /// 投币量
                /// </summary>
                [JsonProperty("coin")]
                public int Coin_int { get; set; }

                /// <summary>
                /// 弹幕量
                /// </summary>
                public string Danmaku_str => Interface.FormatPlayCount(Danmaku_int);

                /// <summary>
                /// 弹幕量
                /// </summary>
                [JsonProperty("danmaku")]
                public int Danmaku_int { get; set; }

                /// <summary>
                /// 收藏量
                /// </summary>
                public string Favorite_str => Interface.FormatPlayCount(Favorite_int);

                /// <summary>
                /// 收藏量
                /// </summary>
                [JsonProperty("favorite")]
                public int Favorite_int { get; set; }

                /// <summary>
                /// 点赞量
                /// </summary>
                public string Like_str => Interface.FormatPlayCount(Like_int);

                /// <summary>
                /// 点赞量
                /// </summary>
                [JsonProperty("like")]
                public int Like_int { get; set; }

                /// <summary>
                /// 评论量
                /// </summary>
                public string Reply_str => Interface.FormatPlayCount(Reply_int);

                /// <summary>
                /// 评论量
                /// </summary>
                [JsonProperty("reply")]
                public int Reply_int { get; set; }

                /// <summary>
                /// 分享量
                /// </summary>
                public string Share_str => Interface.FormatPlayCount(Share_int);

                /// <summary>
                /// 分享量
                /// </summary>
                [JsonProperty("share")]
                public int Share_int { get; set; }

                /// <summary>
                /// 观看量
                /// </summary>
                public string view_str => Interface.FormatPlayCount(View_int);

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
                public string durations => Interface.FormatSecondsTime(seconds);

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
                public string pic { get; set; }

                /// <summary>
                /// 发布时间
                /// </summary>
                public string pubdate_str => pubdate.Contains("T")
                    ? Interface.FormatISO8601TimeToLocal(pubdate)
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