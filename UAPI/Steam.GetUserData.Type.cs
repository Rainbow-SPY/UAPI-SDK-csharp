using Newtonsoft.Json;

namespace UAPI
{
    public partial class Steam
    {
        /// <summary>
        /// Steam用户信息
        /// </summary>
        public class SteamType : Interface.TypeInterface
        {
            private int _communityvisibilitystate;
            private int _profilestate;
            private int _personastate;
            private string _personastate_str;

            /// <summary>
            /// SteamID64
            /// </summary>
            [JsonProperty("steamid")]
            public string SteamID64 { get; set; }

            /// <summary>
            /// Steam社区状态是否可见
            /// </summary>
            [JsonProperty("communityvisibilitystate")]
            public bool IsCommunityVisibility
            {
                get => _communityvisibilitystate == 3;
                set => _communityvisibilitystate = value ? 3 : 1;
            }

            /// <summary>
            /// 是否已经填写了个人资料
            /// </summary>
            [JsonProperty("profilestate")]
            public bool IsInitialized
            {
                get => _profilestate == 1;
                set => _profilestate = value ? 1 : _profilestate;
            }

            /// <summary>
            /// Steam用户名
            /// </summary>
            [JsonProperty("personaname")]
            public string Name { get; set; }

            /// <summary>
            /// Steam个人主页
            /// </summary>
            [JsonProperty("profileurl")]
            public string ProfileUrl { get; set; }

            /// <summary>
            /// Steam头像, 32*32图像
            /// </summary>
            [JsonProperty("avatar")]
            public string Avatar_32x32 { get; set; }

            /// <summary>
            /// Steam头像, 64*64图像
            /// </summary>
            [JsonProperty("avatarmedium")]
            public string Avatar_64x64 { get; set; }

            /// <summary>
            /// Steam头像, 184*184图像
            /// </summary>
            [JsonProperty("avatarfull")]
            public string Avatar_184x184 { get; set; }

            /// <summary>
            /// 头像的哈希值
            /// </summary>
            [JsonProperty("avatarhash")]
            public string AvatarHash { get; set; }

            /// <summary>
            /// Steam在线状态
            /// </summary>
            [JsonProperty("personastate")]
            public string PersonaState
            {
                get
                {
                    switch (_personastate)
                    {
                        case 0:
                            return "离线或私密";
                        case 1:
                            return "在线";
                        case 2:
                            return "忙碌";
                        case 3:
                            return "离开";
                        case 4:
                            return "打盹";
                        case 5:
                            return "想交易";
                        case 6:
                            return "想玩";
                    }

                    return "未知状态";
                }
                set
                {
                    switch (value)
                    {
                        case "离线或私密":
                            _personastate = 0;
                            break;
                        case "在线":
                            _personastate = 1;
                            break;
                        case "忙碌":
                            _personastate = 2;
                            break;
                        case "离开":
                            _personastate = 3;
                            break;
                        case "打盹":
                            _personastate = 4;
                            break;
                        case "想交易":
                            _personastate = 5;
                            break;
                        case "想玩":
                            _personastate = 6;
                            break;
                        case "未知状态":
                            break;
                    }
                }
            }

            /// <summary>
            /// Steam真实姓名
            /// </summary>
            [JsonProperty("realname")]
            public string RealName { get; set; }

            /// <summary>
            ///  主要社区组
            /// </summary>
            [JsonProperty("primaryclanid")]
            public string PrimaryClanID { get; set; }

            /// <summary>
            /// Steam账号创建日期的时间戳
            /// </summary>
            [JsonProperty("timecreated")]
            public decimal RegisterTimeUnix { get; set; }

            /// <summary>
            /// Steam账号创建日期
            /// </summary>
            [JsonProperty("timecreated_str")]
            public string RegisterTime { get; set; }

            /// <summary>
            /// Steam账号绑定区域
            /// </summary>
            [JsonProperty("loccountrycode")]
            public string BindLocationRegionCode { get; set; }

            /// <summary>
            /// 好友代码 (SteamID32)
            /// </summary>
            [JsonProperty("friendcode")]
            public string FriendCode => GetFriendCode(SteamID64);

            /// <summary>
            /// SteamID3
            /// </summary>
            public string SteamID3 => SteamID.Converter.ToSteamID3(SteamID64);

            /// <summary>
            /// SteamID1
            /// </summary>
            public string SteamID1 => SteamID.Converter.ToSteamID(SteamID64);
        }
    }
}