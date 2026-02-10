using System.Collections.Generic;

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
                public int Mid { get; set; }

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
                public int Coin { get; set; }

                /// <summary>
                /// 弹幕量
                /// </summary>
                public int Danmaku { get; set; }

                /// <summary>
                /// 收藏量
                /// </summary>
                public int Favorite { get; set; }

                /// <summary>
                /// 点赞量
                /// </summary>
                public int Like { get; set; }

                /// <summary>
                /// 评论量
                /// </summary>
                public int Reply { get; set; }

                /// <summary>
                /// 分享量
                /// </summary>
                public int Share { get; set; }

                /// <summary>
                /// 观看量
                /// </summary>
                public int View { get; set; }
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
                public string duration => Interface.FormatSecondsTime(seconds);

                internal int seconds { get; set; }

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
                public string pubdate => Interface.FormatISO8601TimeToLocal(pubdate_ISO8601);

                internal string pubdate_ISO8601 { get; set; }

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