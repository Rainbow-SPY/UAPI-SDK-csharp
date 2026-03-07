using System;
using static UAPI.Steam.SteamID.Converter;

namespace UAPI
{
    /// <summary>
    /// Steam 游戏平台相关扩展功能库
    /// </summary>
    public partial class Steam
    {
        /// <summary>
        /// 从任意 <see cref="UAPI.Steam.SteamID.SteamIDType"/> 格式获取好友代码(<see cref="UAPI.Steam.SteamID.SteamIDType.SteamID32"/>), 此方法重定向到 <see cref="ToSteamID32(string)"/> 方法。
        /// </summary>
        /// <param name="AnySteamID"> 任意格式的 <see cref="SteamID"/></param>
        /// <returns> 好友代码(<see cref="UAPI.Steam.SteamID.SteamIDType.SteamID32"/>)</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string GetFriendCode(string AnySteamID) => ToSteamID32(AnySteamID);

        /// <summary>
        /// 获取 Steam 用户的在线状态, 此方法仅限于 <see cref="SteamType"/> 的 <see cref="SteamType.PersonaState"/> 属性。
        /// </summary>
        /// <param name="steamType"> <see cref="SteamType"/> 对象, 其中包含了 Steam 用户的在线状态信息</param>
        /// <returns> Steam 用户的在线状态字符串</returns>
        public static string GetPersonalState(SteamType steamType) =>
            GetPersonalState(int.Parse(steamType.PersonaState));

        /// <summary>
        /// 获取 Steam 用户的在线状态, 此方法仅限于 <see cref="SteamType"/> 的 <see cref="SteamType.PersonaState"/> 属性。
        /// </summary>
        /// <param name="PersonaState"><see cref="SteamType.PersonaState"/>属性值</param>
        /// <returns> Steam 用户的在线状态字符串</returns>
        public static string GetPersonalState(int PersonaState)
        {
            switch (PersonaState)
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

        /// <summary>
        /// 获取 Steam 用户的社区可见性状态, 此方法仅限于 <see cref="SteamType"/> 的 <see cref="SteamType.IsCommunityVisibility"/> 属性。
        /// </summary>
        /// <param name="steamType"><see cref="SteamType"/> 对象</param>
        /// <returns> Steam 用户的社区可见性状态字符串</returns>
        public static string GetCommunityVisibilityState(SteamType steamType) => steamType.IsCommunityVisibility
            ? "公开"
            : "私密";

        /// <summary>
        /// 获取 Steam 用户的个人资料状态, 此方法仅限于 <see cref="SteamType"/> 的 <see cref="SteamType.IsInitialized"/> 属性。
        /// </summary>
        /// <param name="steamType"> <see cref="SteamType"/> 对象, 其中包含了 Steam 用户的个人资料状态信息</param>
        /// <returns> Steam 用户的个人资料状态字符串</returns>
        public static string GetProfileState(SteamType steamType) =>
            steamType.IsInitialized ? "已填写个人资料" : "未填写个人资料";
    }
}