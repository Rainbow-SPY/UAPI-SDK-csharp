namespace UAPI
{
    public partial class Steam
    {
        /// <summary>
        /// Steam用户信息
        /// </summary>
        public class SteamType
        {
            /// <summary>
            /// 错误代码
            /// </summary>
            public string code { get; set; }

            /// <summary>
            /// 详细错误信息
            /// </summary>
            public string details { get; }

            /// <summary>
            /// 错误信息
            /// </summary>
            public string message { get; }

            /// <summary>
            /// SteamID64
            /// </summary>
            public string steamid { get; set; }

            /// <summary>
            /// Steam社区状态, 1 为隐藏 3为可见
            /// </summary>
            public int communityvisibilitystate { get; set; }

            /// <summary>
            /// 如果为 1 , 代表用户已经填写了个人资料
            /// </summary>
            public int profilestate { get; set; }

            /// <summary>
            /// Steam用户名
            /// </summary>
            public string personaname { get; set; }

            /// <summary>
            /// Steam个人主页
            /// </summary>
            public string profileurl { get; set; }


            /// <summary>
            /// Steam头像, 32*32图像
            /// </summary>
            public string avatar { get; set; }

            /// <summary>
            /// Steam头像, 64*64图像
            /// </summary>
            public string avatarmedium { get; set; }

            /// <summary>
            /// Steam头像, 184*184图像
            /// </summary>
            public string avatarfull { get; set; }

            /// <summary>
            /// 头像的哈希值
            /// </summary>
            public string avatarhash { get; set; }

            /// <summary>
            /// Steam在线状态, 0-离线/隐私, 1-在线, 2-忙碌, 3-离开, 4-打盹, 5-想交易, 6-想玩。
            /// </summary>
            public int personastate { get; set; }

            /// <summary>
            /// Steam真实姓名
            /// </summary>
            public string realname { get; set; }

            /// <summary>
            ///  主要社区组
            /// </summary>
            public string primaryclanid { get; set; }

            /// <summary>
            /// Steam账号创建日期的时间刻
            /// </summary>
            public int timecreated { get; set; }

            /// <summary>
            /// Steam账号创建日期的时间戳
            /// </summary>
            public string timecreated_str { get; set; }

            /// <summary>
            /// Steam账号绑定区域
            /// </summary>
            public string loccountrycode { get; set; }

            /// <summary>
            /// 好友代码 （SteamID32）
            /// </summary>
            public string friendcode => GetFriendCode(steamid);

            /// <summary>
            /// SteamID3
            /// </summary>
            public string steamID3 => SteamID.Converter.ToSteamID3(steamid);
        }
    }
}