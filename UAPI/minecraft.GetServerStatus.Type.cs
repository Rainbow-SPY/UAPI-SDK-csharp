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
            /// 服务器图标的 Base64 Data URI
            /// </summary>
            public string favicon_url { get; set; }

            /// <summary>
            /// 服务器解析后的IP地址
            /// </summary>
            public string ip { get; set; }

            /// <summary>
            /// 服务器配置的最大玩家数量
            /// </summary>
            public int max_players { get; set; }

            /// <summary>
            /// 纯文本格式的服务器MOTD（每日消息），去除了所有颜色和格式代码。
            /// </summary>
            public string motd_clean { get; set; }

            /// <summary>
            /// HTML格式的服务器MOTD，保留了颜色和样式。
            /// </summary>
            public string motd_html { get; set; }

            /// <summary>
            /// 服务器是否在线
            /// </summary>
            public bool online { get; set; }

            /// <summary>
            /// 服务器当前的玩家数量
            /// </summary>
            public int players { get; set; }

            /// <summary>
            /// 服务器使用的端口号
            /// </summary>
            public int port { get; set; }

            /// <summary>
            /// 服务器报告的版本信息。
            /// </summary>
            public string version { get; set; }
        }
    }
}