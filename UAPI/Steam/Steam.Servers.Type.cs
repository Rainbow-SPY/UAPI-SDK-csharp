using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary />
        public class SteamServers : TypeInterface
        {
            public class ServersItem
            {
                /// <summary>
                /// 服务器名称
                /// </summary>
                [JsonProperty("name")]
                public string name { get; set; }

                /// <summary>
                /// 服务器IP
                /// </summary>
                [JsonProperty("ip")]
                public string ip { get; set; }

                /// <summary>
                /// 服务器端口
                /// </summary>
                [JsonProperty("port")]
                public int port { get; set; }

                /// <summary>
                /// 服务器当前在线人数
                /// </summary>
                [JsonProperty("players")]
                public int players { get; set; }

                /// <summary>
                /// 服务器最大人数容量
                /// </summary>
                [JsonProperty("max_players")]
                public int max_players { get; set; }

                /// <summary>
                /// 服务器地图名称
                /// </summary>
                [JsonProperty("map")]
                public string map { get; set; }

                /// <summary>
                /// 服务器当前是否在线
                /// </summary>
                [JsonProperty("online")]
                public bool online { get; set; }
            }

            /// <summary>
            /// 查询的 Steam AppID
            /// </summary>
            [JsonProperty("appid")]
            public int AppID { get; set; }

            /// <summary>
            /// 查询的字段
            /// </summary>
            [JsonProperty("query")]
            public string QueryText { get; set; }

            /// <summary>
            /// 返回的数量
            /// </summary>
            [JsonProperty("count")]
            public int Count { get; set; }

            /// <summary>
            /// 查询到的服务器列表
            /// </summary>
            [JsonProperty("servers")]
            public List<ServersItem> ServersList { get; set; }
        }
    }
}