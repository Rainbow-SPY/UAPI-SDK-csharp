using System.Collections.Generic;

namespace UAPI
{
    public partial class bilibili
    {
        public class LiveRoomType
        {
            /// <summary>
            /// 主播的用户ID (mid)
            /// </summary>
            public long uid { get; set; }

            /// <summary>
            /// 直播间的真实房间号（长号）
            /// </summary>
            public long room_id { get; set; }

            /// <summary>
            /// 直播间的短号（靓号）。如果没有设置，则为0
            /// </summary>
            public long short_id { get; set; }

            /// <summary>
            /// 主播的粉丝数（关注数量）
            /// </summary>
            public long attention { get; set; }

            /// <summary>
            /// 直播间当前的人气值。注意这不是真实在线人数。
            /// </summary>
            public long online { get; set; }

            /// <summary>
            /// 直播状态。0:未开播, 1:直播中, 2:轮播中。
            /// </summary>
            public int live_status { get; set; }

            /// <summary>
            /// 分区ID。
            /// </summary>
            public int area_id { get; set; }

            /// <summary>
            /// 父分区名称。
            /// </summary>
            public string parent_area_name { get; set; }

            /// <summary>
            /// 子分区名称。
            /// </summary>
            public string area_name { get; set; }

            /// <summary>
            /// 直播间背景图的URL。
            /// </summary>
            public string background { get; set; }

            /// <summary>
            /// 当前直播间的标题。
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// 用户设置的直播间封面URL。
            /// </summary>
            public string user_cover { get; set; }

            /// <summary>
            /// 直播间公告或描述，支持换行符。
            /// </summary>
            public string description { get; set; }

            /// <summary>
            /// 本次直播开始的时间，格式为 `YYYY-MM-DD HH:mm:ss`。如果未开播，则为空字符串。
            /// </summary>
            public string live_time { get; set; }

            /// <summary>
            /// 直播间设置的标签，以逗号分隔。
            /// </summary>
            public string tags { get; set; }

            /// <summary>
            /// 直播间热词列表，通常用于弹幕互动。
            /// </summary>
            public string[] hot_words { get; set; }

            public List<Pendants> new_pendants { get; set; }

            public abstract class Pendants
            {
                public List<Frame> frame { get; set; }
                public List<Badge> badge { get; set; }

                public abstract class Frame
                {
                    public string name { get; set; }
                    public string value { get; set; }
                    public string desc { get; set; }
                }

                public abstract class Badge
                {
                    public string name { get; set; }
                    public string desc { get; set; }
                }
            }

            public class CommonProperties
            {
                public string name { get; set; }
                public string description { get; set; }
                public string value { get; set; }
            }
        }
    }
}