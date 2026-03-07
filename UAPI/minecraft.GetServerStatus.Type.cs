using Newtonsoft.Json;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// 查询Minecraft游戏服务器返回的属性列表
        /// </summary>
        public class ServerType : Interface.TypeInterface
        {
            /// <summary>
            /// 服务器图标的 Base64 Data Url
            /// </summary>
            [JsonProperty("favicon_url")]
            public string FaviconUrlWithBase64 { get; set; }

            /// <summary>
            /// 服务器解析后的IP地址
            /// </summary>
            [JsonProperty("ip")]
            public string IP { get; set; }

            /// <summary>
            /// 服务器配置的最大玩家数量
            /// </summary>
            [JsonProperty("max_players")]
            public int MaxPlayers { get; set; }

            /// <summary>
            /// 纯文本格式的服务器MOTD(每日消息)，去除了所有颜色和格式代码
            /// </summary>
            public string motd_clean { get; set; }

            /// <summary>
            /// HTML格式的服务器MOTD，保留了颜色和样式
            /// </summary>
            public string motd_html { get; set; }

            /// <summary>
            /// 服务器是否在线
            /// </summary>
            [JsonProperty("online")]
            public bool IsServerOnline { get; set; }

            /// <summary>
            /// 服务器当前的玩家数量
            /// </summary>
            [JsonProperty("players")]
            public int CurrentPlayers { get; set; }

            /// <summary>
            /// 服务器使用的端口号
            /// </summary>
            [JsonProperty("port")]
            public int Port { get; set; }

            /// <summary>
            /// 服务器报告的版本信息
            /// </summary>
            public string version { get; set; }
        }
    }
}