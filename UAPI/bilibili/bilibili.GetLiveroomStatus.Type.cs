using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 查询bilibili直播间时返回的Json列表
        /// </summary>
        public class LiveroomType : TypeInterface
        {
            /// <summary>
            /// 头像框
            /// </summary>
            public class Frame : Badge
            {
                /// <summary>
                /// 头像框的值?
                /// </summary>
                [JsonProperty("value")]
                public string? Value { get; set; }
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
                public string? Name { get; set; }

                /// <summary>
                /// 称号的简介
                /// </summary>
                [JsonProperty("desc")]
                public string? Desc { get; set; }
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
                public Frame? Frame { get; set; }

                /// <summary>
                /// 称号
                /// </summary>
                [JsonProperty("badge")]
                public Badge? Badge { get; set; }
            }

            /// <summary>
            /// 主播的用户ID (mid)
            /// </summary>
            [JsonProperty("uid")]
            public long UID { get; set; }

            /// <summary>
            /// 直播间的真实房间号(长号)
            /// </summary>
            [JsonProperty("room_id")]
            public long LiveroomID { get; set; }

            /// <summary>
            /// 直播间的短号(靓号)如果没有设置，则为0
            /// </summary>
            [JsonProperty("short_id")]
            public long ShortId { get; set; }

            /// <summary>
            /// 主播的粉丝数(关注数量)
            /// </summary>
            [JsonProperty("attention")]
            public long Fans { get; set; }

            /// <summary>
            /// 直播间当前的人气值, 注意! 这不是真实在线人数
            /// </summary>
            [JsonProperty("online")]
            public long PopularValue { get; set; }

            [JsonProperty("is_portrait")] public bool is_portrait { get; set; }

            /// <summary>
            /// 直播状态0:未开播, 1:直播中, 2:轮播中
            /// </summary>
            [JsonProperty("live_status")]
            public int LiveStatus { get; set; }

            /// <summary>
            /// 当前是否正在直播? (包括直播和轮播)
            /// </summary>
            public bool IsLiveNow => LiveStatus != 0;

            /// <summary>
            /// 父分区名称
            /// </summary>
            [JsonProperty("parent_area_name")]
            public string? ParentAreaName { get; set; }

            /// <summary>
            /// 父分区ID
            /// </summary>
            [JsonProperty("parent_area_id")]
            public int ParentAreaID { get; set; }

            /// <summary>
            /// 子分区名称
            /// </summary>
            [JsonProperty("area_name")]
            public string? AreaName { get; set; }

            /// <summary>
            /// 子分区ID
            /// </summary>
            [JsonProperty("area_id")]
            public int AreaID { get; set; }

            /// <summary>
            /// 直播间背景图的URL
            /// </summary>
            [JsonProperty("background")]
            public string BackgroundImageUrl { get; set; } = string.Empty;

            /// <summary>
            /// 当前直播间的标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; } = string.Empty;

            /// <summary>
            /// 用户设置的直播间封面URL
            /// </summary>
            [JsonProperty("user_cover")]
            public string CoverImageUrl { get; set; } = string.Empty;

            /// <summary>
            /// 直播间 公告或描述，支持换行符
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; } = string.Empty;

            /// <summary>
            /// 本次直播开始的时间，格式为 `YYYY-MM-DD HH:mm:ss`如果未开播，则为空字符串
            /// </summary>
            [JsonProperty("live_time")]
            public string LiveTime { get; set; } = string.Empty;

            [JsonProperty("keyframe")] public string? keyframe { get; set; }

            /// <summary>
            /// 直播间设置的标签，以逗号分隔
            /// </summary>
            [JsonProperty("tags")]
            public string? Tags { get; set; }

            /// <summary>
            /// 直播间热词列表，通常用于弹幕互动
            /// </summary>
            [JsonProperty("hot_words")]
            public List<string>? HotWordsList { get; set; }

            /// <summary>
            /// 主播佩戴的头像框、大航海等级等信息
            /// </summary>
            [JsonProperty("new_pendants")]
            public Pendants? NewPendants { get; set; }
        }
    }
}