using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 查询bilibili直播间时返回的Json列表
        /// </summary>
        public class LiveRoomType
        {
            /// <summary>
            /// 头像框
            /// </summary>
            public class Frame
            {
                /// <summary>
                /// 头像框名称
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }

                /// <summary>
                /// 头像框的值?
                /// </summary>
                [JsonProperty("value")]
                public string value { get; set; }

                /// <summary>
                /// 头像框的描述
                /// </summary>
                [JsonProperty("desc")]
                public string desc { get; set; }
            }

            /// <summary>
            /// 称号
            /// </summary>
            public class Badge
            {
                /// <summary>
                /// 称号的名称
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }

                /// <summary>
                /// 称号的简介
                /// </summary>
                [JsonProperty("desc")]
                public string desc { get; set; }
            }

            /// <summary>
            /// 主播佩戴的头像框、大航海等级等信息
            /// </summary>
            public class Pendants
            {
                /// <summary>
                /// 头像框
                /// </summary>
                [JsonProperty("frame")]
                public Frame frame { get; set; }

                /// <summary>
                /// 称号
                /// </summary>
                [JsonProperty("badge")]
                public Badge badge { get; set; }
            }

            /// <summary>
            /// 详细错误信息
            /// </summary>
            [JsonProperty("details")]
            public string details { get; set; }

            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("error")]
            public string error { get; set; }

            /// <summary>
            /// 主播的用户ID (mid)。
            /// </summary>
            [JsonProperty("uid")]
            public long uid { get; set; }

            /// <summary>
            /// 直播间的真实房间号（长号）。
            /// </summary>
            [JsonProperty("room_id")]
            public long room_id { get; set; }

            /// <summary>
            /// 直播间的短号（靓号）。如果没有设置，则为0。
            /// </summary>
            [JsonProperty("short_id")]
            public long short_id { get; set; }

            /// <summary>
            /// 主播的粉丝数（关注数量）。
            /// </summary>
            [JsonProperty("attention")]
            public long attention { get; set; }

            /// <summary>
            /// 直播间当前的人气值。注意这不是真实在线人数
            /// </summary>
            [JsonProperty("online")]
            public long online { get; set; }

            /// <summary>
            /// 直播状态。0:未开播, 1:直播中, 2:轮播中。
            /// </summary>
            [JsonProperty("live_status")]
            public int live_status { get; set; }

            /// <summary>
            /// 分区ID。
            /// </summary>
            [JsonProperty("area_id")]
            public int area_id { get; set; }

            /// <summary>
            /// 父分区名称。
            /// </summary>
            [JsonProperty("parent_area_name")]
            public string parent_area_name { get; set; }

            /// <summary>
            /// 子分区名称。
            /// </summary>
            [JsonProperty("area_name")]
            public string area_name { get; set; }

            /// <summary>
            /// 直播间背景图的URL。
            /// </summary>
            [JsonProperty("background")]
            public string background { get; set; }

            /// <summary>
            /// 当前直播间的标题。
            /// </summary>
            [JsonProperty("title")]
            public string title { get; set; }

            /// <summary>
            /// 用户设置的直播间封面URL。
            /// </summary>
            [JsonProperty("user_cover")]
            public string user_cover { get; set; }

            /// <summary>
            /// 直播间公告或描述，支持换行符。
            /// </summary>
            [JsonProperty("description")]
            public string description { get; set; }

            /// <summary>
            /// 本次直播开始的时间，格式为 `YYYY-MM-DD HH:mm:ss`。如果未开播，则为空字符串。
            /// </summary>
            [JsonProperty("live_time")]
            public string live_time { get; set; }

            /// <summary>
            /// 直播间设置的标签，以逗号分隔。
            /// </summary>
            [JsonProperty("tags")]
            public string tags { get; set; }

            /// <summary>
            /// 直播间热词列表，通常用于弹幕互动。
            /// </summary>
            [JsonProperty("hot_words")]
            public List<string> hot_words { get; set; }

            /// <summary>
            /// 主播佩戴的头像框、大航海等级等信息
            /// </summary>
            [JsonProperty("new_pendants")]
            public Pendants new_pendants { get; set; }
        }
    }
}