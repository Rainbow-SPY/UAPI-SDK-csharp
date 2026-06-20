using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UAPI.Extensions;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 请求bilibili评论列表返回的Json属性列表
        /// </summary>
        public class RepliesListType : TypeInterface
        {
            /// <summary>
            /// 分页信息
            /// </summary>
            [JsonProperty("page")]
            public Page PageInfo { get; set; }

            [JsonProperty("config")] public object config { get; set; }

            /// <summary>
            /// 当前页的评论列表
            /// </summary>
            [JsonProperty("replies")]
            public List<RepliesItem> RepliesList { get; set; }

            /// <summary>
            /// 热门评论列表结构与 `replies` 中的对象一致如果当前页是第一页，且有热门评论，则此数组非空
            /// </summary>
            [JsonProperty("hots")]
            public List<object> hots { get; set; }

            [JsonProperty("upper")] public object upper { get; set; }
            [JsonProperty("top")] public object top { get; set; }
            [JsonProperty("notice")] public object notice { get; set; }
            [JsonProperty("vote")] public int vote { get; set; }
            [JsonProperty("folder")] public object folder { get; set; }
            [JsonProperty("control")] public object control { get; set; }
            [JsonProperty("cursor")] public object cursor { get; set; }


            /// <summary>
            /// 分页信息概览
            /// </summary>
            public class Page
            {
                /// <summary>
                /// 当前的页码
                /// </summary>
                [JsonProperty("num")]
                public int Num { get; set; }

                /// <summary>
                /// 每页的评论个数
                /// </summary>
                [JsonProperty("size")]
                public int Size { get; set; }

                /// <summary>
                /// 根评论(即直接评论视频的评论)的总数
                /// </summary>
                [JsonProperty("count")]
                public int Count { get; set; }

                /// <summary>
                /// 评论区总评论数，包含了所有的楼中楼回复
                /// </summary>
                [JsonProperty("acount")]
                public int Acount { get; set; }
            }

            /// <summary>
            /// 用户的B站等级
            /// </summary>
            public class Level_info
            {
                /// <summary>
                /// 用户的B站等级
                /// </summary>
                [JsonProperty("current_level")]
                public int CurrentLevel { get; set; }
            }

            /// <summary/>
            public class Official_verify
            {
                [JsonProperty("type")] public int type { get; set; }
                [JsonProperty("desc")] public string desc { get; set; }
            }

            /// <summary/>
            public class Vip
            {
                [JsonProperty("vipType")] public int vipType { get; set; }
                [JsonProperty("vipStatus")] public int vipStatus { get; set; }
                [JsonProperty("vipDueDate")] public int vipDueDate { get; set; }
            }

            /// <summary/>
            public class Member
            {
                /// <summary>
                /// 用户的 UID
                /// </summary>
                [JsonProperty("mid")]
                public string MID { get; set; }

                /// <summary>
                /// 用户昵称
                /// </summary>
                [JsonProperty("uname")]
                public string Name { get; set; }

                /// <summary>
                /// 用户性别
                /// </summary>
                [JsonProperty("sex")]
                public string Sex { get; set; }

                [JsonProperty("sign")] public string sign { get; set; }

                /// <summary>
                /// 用户头像的URL
                /// </summary>
                [JsonProperty("avatar")]
                public string AvatarUrl { get; set; }

                [JsonProperty("rank")] public string rank { get; set; }

                /// <summary>
                /// 用户的B站等级
                /// </summary>
                [JsonProperty("level_info")]
                public Level_info LevelInfo { get; set; }

                [JsonProperty("official_verify")] public Official_verify official_verify { get; set; }
                [JsonProperty("vip")] public Vip vip { get; set; }
            }

            /// <summary/>
            public class Content
            {
                /// <summary>
                /// 评论的文本内容
                /// </summary>
                [JsonProperty("message")]
                public string Text { get; set; }

                [JsonProperty("emote")] public object emote { get; set; }
                [JsonProperty("members")] public object members { get; set; }
                [JsonProperty("jump_url")] public object jump_url { get; set; }
            }

            /// <summary/>
            public class Reply_control
            {
                [JsonProperty("time_desc")] public string time_desc { get; set; }
                [JsonProperty("location")] public string location { get; set; }
            }

            internal static string GetReplyLocaleType(object type)
            {
                switch (type)
                {
                    case 1: return "视频稿件";
                    case 2: return "话题";
                    case 4: return "活动";
                    case 5: return "小视频";
                    case 6: return "小黑屋封禁信息";
                    case 7: return "公告信息";
                    case 8: return "直播活动";
                    case 9: return "活动稿件";
                    case 10: return "直播公告";
                    case 11: return "相簿(图片动态)";
                    case 12: return "专栏";
                    case 13: return "票务";
                    case 14: return "音频";
                    case 15: return "风纪委员会";
                    case 16: return "点评";
                    case 17: return "动态(纯文字动态&分享)";
                    case 18: return "播单";
                    case 19: return "音乐播单";
                    case 20:
                    case 21:
                    case 22: // 20/21/22 均为漫画，合并case简化代码
                        return "漫画";
                    case 33: return "课程";
                }

                return null;
            }

            /// <summary/>
            public class RepliesItem
            {
                private int _fansgrade;
                private int _isHidden;

                /// <summary>
                /// 评论的唯一ID (Reply ID)
                /// </summary>
                [JsonProperty("rpid")]
                public long ReplyID { get; set; }

                /// <summary>
                /// 评论区对象ID，即视频的aid
                /// </summary>
                [JsonProperty("oid")]
                public long OID { get; set; }

                /// <summary>
                /// 以字符串格式返回评论区父级分类
                /// </summary>
                public string ReplyLocaleType => GetReplyLocaleType(Type);

                /// <summary>
                /// 评论区父级分类
                /// </summary>
                [JsonProperty("type")]
                public int Type { get; set; }

                /// <summary>
                /// 发表评论的用户的mid
                /// </summary>
                [JsonProperty("mid")]
                public int MID { get; set; }

                /// <summary>
                /// 根评论的rpid如果为0，表示这条评论是根评论
                /// </summary>
                [JsonProperty("root")]
                public long Root { get; set; }

                /// <summary>
                /// 该评论是否为根评论
                /// </summary>
                public bool IsRootReply => Root == 0 && Parent == 0;

                /// <summary>
                /// 回复的父级评论的rpid如果为0，表示是根评论
                /// </summary>
                [JsonProperty("parent")]
                public long Parent { get; set; }

                /// <summary>
                /// 回复对方 rpid
                /// </summary>
                [JsonProperty("dialog")]
                public int Dialog { get; set; }

                /// <summary>
                /// 这条评论下的回复(楼中楼)数量
                /// </summary>
                [JsonProperty("count")]
                public int Count { get; set; }

                /// <summary>
                /// 回复评论条数
                /// </summary>
                [JsonProperty("rcount")]
                public int Rcount { get; set; }

                /// <summary>
                /// 是否被系统隐藏
                /// </summary>
                [JsonProperty("state")]
                // public int state { get; set; }
                //评论状态, 0: 正常 17: 被阿瓦隆系统隐藏 (无法被别人看到, 只能自己看到)
                public bool IsHidden
                {
                    get => _isHidden == 17;
                    set => _isHidden = value ? 17 : 0;
                }

                /// <summary>
                /// 是否具有粉丝标签
                /// </summary>
                [JsonProperty("fansgrade")]
                public bool IsHadFanTag
                {
                    get => _fansgrade == 1;
                    set => _fansgrade = value ? 1 : 0;
                }

                [JsonProperty("attr")] public int attr { get; set; }

                /// <summary>
                /// 评论发送时间的Unix时间戳(秒)
                /// </summary>
                [JsonProperty("ctime")]
                public int SendTime_Unix { get; set; }

                /// <summary>
                /// 该评论获得的点赞数
                /// </summary>
                [JsonProperty("like")]
                public int Like { get; set; }

                /// <summary>
                /// 该评论获得的点赞数, 返回以"万"为单位的字符串
                /// </summary>
                public string Like_str => Like.FormatPlayCount();

                [JsonProperty("action")] public int action { get; set; }

                /// <summary>
                /// 发表评论的用户信息
                /// </summary>
                [JsonProperty("member")]
                public Member MemberInfo { get; set; }

                /// <summary>
                /// 评论内容
                /// </summary>
                [JsonProperty("content")]
                public Content ContentInfo { get; set; }

                /// <summary>
                /// 楼中楼回复列表结构与顶层评论对象一致，但通常此数组为空，需要单独请求
                /// </summary>
                [JsonProperty("replies")]
                [Obsolete]
                public List<RepliesItem> RepliesList { get; set; }

                [JsonProperty("reply_control")] public Reply_control reply_control { get; set; }
            }
        }
    }
}