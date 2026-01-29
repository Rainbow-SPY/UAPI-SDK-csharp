using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class bilibili
    {
        public class LiveRoomType
        {
            public class Frame
            {
                [JsonProperty("name")] public string name { get; set; }
                [JsonProperty("value")] public string value { get; set; }
                [JsonProperty("desc")] public string desc { get; set; }
            }

            public class Badge
            {
                [JsonProperty("name")] public string name { get; set; }
                [JsonProperty("desc")] public string desc { get; set; }
            }

            public class Pendants
            {
                [JsonProperty("frame")] public Frame frame { get; set; }
                [JsonProperty("badge")] public Badge badge { get; set; }
            }

            [JsonProperty("details")] public string details { get; set; }
            [JsonProperty("error")] public string error { get; set; }
            [JsonProperty("uid")] public long uid { get; set; }
            [JsonProperty("room_id")] public long room_id { get; set; }
            [JsonProperty("short_id")] public long short_id { get; set; }
            [JsonProperty("attention")] public long attention { get; set; }
            [JsonProperty("online")] public long online { get; set; }
            [JsonProperty("live_status")] public int live_status { get; set; }
            [JsonProperty("area_id")] public int area_id { get; set; }
            [JsonProperty("parent_area_name")] public string parent_area_name { get; set; }
            [JsonProperty("area_name")] public string area_name { get; set; }
            [JsonProperty("background")] public string background { get; set; }
            [JsonProperty("title")] public string title { get; set; }
            [JsonProperty("user_cover")] public string user_cover { get; set; }
            [JsonProperty("description")] public string description { get; set; }
            [JsonProperty("live_time")] public string live_time { get; set; }
            [JsonProperty("tags")] public string tags { get; set; }
            [JsonProperty("hot_words")] public List<string> hot_words { get; set; }
            public Pendants new_pendants { get; set; }
        }
    }
}