//  Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.
//
//  build on 2026-1-29 4:38
//  For .NET Framework 4.7.2, With the list of nuget packages:
//      - Newtonsoft.Json
//      - System.Net.Http
//      - Rox (on Github: https://github.com/Rainbow-SPY/Rox
//      - System.Buffers
//      - System.Diagnostics.DiagnosticSource
//  
//  This code for redirecting Bilibili API through a properties of third-party interface.
//  Now Play:       Ave Mujica - KiLLKiSS
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class bilibili
    {
        public class LiveRoomType
        {
            /// <summary>
            /// 详细信息
            /// </summary>
            public string details { get; set; }

            /// <summary>
            /// 错误代码
            /// </summary>
            public string error { get; set; }

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
            public List<string> hot_words { get; set; }

            [JsonProperty("new_pendants")] public Pendants new_pendants { get; set; }

            [Serializable]
            public class Pendants
            {
                [JsonProperty("frame")] // 显式映射JSON字段
                public Frame frame { get; set; }

                [JsonProperty("badge")] public Badge badge { get; set; }

                [Serializable]
                public class Frame
                {
                    [JsonProperty("name")] public string name { get; set; }
                    [JsonProperty("value")] public string value { get; set; }
                    [JsonProperty("desc")] public string desc { get; set; }
                }

                [Serializable]
                public class Badge
                {
                    [JsonProperty("name")] public string name { get; set; }
                    [JsonProperty("desc")] public string desc { get; set; }
                }
            }
        }
    }
}