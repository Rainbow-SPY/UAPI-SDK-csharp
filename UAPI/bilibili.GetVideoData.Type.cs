using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// bilibili视频的返回属性列表
        /// </summary>
        public class VideoType : Interface.TypeInterface
        {
            private int _copyright;
            private int _state;

            /// <summary>
            /// 稿件的BV号
            /// </summary>
            public string bvid { get; set; }

            /// <summary>
            /// 稿件的AV号
            /// </summary>
            public string aid { get; set; }

            /// <summary>
            /// 稿件分P总数如果是单P视频，则为1
            /// </summary>
            public int videos { get; set; }

            /// <summary>
            /// 视频所属的子分区ID
            /// </summary>
            public int tid { get; set; }

            /// <summary>
            /// 视频所属的子分区名称
            /// </summary>
            public string tname { get; set; }

            /// <summary>
            /// 视频版权类型 原创/转载
            /// </summary>
            public string Copyright => _copyright == 1
                ? "原创"
                : (_copyright == 2
                    ? "转载"
                    : "未知");

            /// <summary>
            /// 是否为版权拥有者
            /// </summary>
            [JsonProperty("copyright")]
            public bool IsCopyrightOwner
            {
                get => _copyright == 1;
                set => _copyright = value ? _copyright = 1 : _copyright = 2;
            }

            /// <summary>
            /// 稿件封面图片的URL
            /// </summary>
            [JsonProperty("pic")]
            public string CoverImageUrl { get; set; }

            /// <summary>
            /// 稿件的标题
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// 稿件发布时间的Unix时间戳（秒)
            /// </summary>
            public long pubdate { get; set; }

            /// <summary>
            /// 稿件发布的字符串时间（秒）
            /// </summary>
            public string pubdate_str =>
                DateTime.TryParse(pubdate.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 用户投稿时间的Unix时间戳（秒）
            /// </summary>
            public long ctime { get; set; }

            /// <summary>
            /// 用户投稿的字符串时间（秒）
            /// </summary>
            public string ctime_str =>
                DateTime.TryParse(ctime.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 视频简介, 可能会包含HTML换行符
            /// </summary>
            public string desc { get; set; }

            /// <summary>
            /// 详细的视频简介
            /// </summary>
            public List<Desc_v2> desc_v2 { get; set; }

            /// <summary>
            /// 视频是否被删除
            /// </summary>
            [JsonProperty("state")]
            public bool IsDeleted
            {
                get => _state == -6;
                set => _state = value ? -6 : 1;
            }

            /// <summary>
            /// 视频状态
            /// </summary>
            public string state_str => _state == 1 ? "正常" : (_state == -6 ? "被删除" : "未知");

            /// <summary>
            /// 稿件总时长（所有分P累加），单位为秒
            /// </summary>
            public long duration { get; set; }

            /// <summary>
            /// 视频的各种权限开关（如是否允许转载）
            /// </summary>
            public Rights rights { get; set; }

            /// <summary>
            /// 视频UP主信息
            /// </summary>
            public Owner owner { get; set; }

            /// <summary>
            /// 统计数据, 播放、点赞、硬币等数据
            /// </summary>
            public Stat stat { get; set; }

            /// <summary>
            /// 动态的文字, 投稿时附带的动态描述
            /// </summary>
            public string dynamic { get; set; }

            /// <summary>
            /// 弹幕 ID (CID), 视频资源（分P）的唯一 ID
            /// </summary>
            public long cid { get; set; }

            /// <summary>
            /// 分辨率信息, 视频宽高等
            /// </summary>
            public Dimension dimension { get; set; }

            /// <summary>
            /// 不缓存, 一般为 false
            /// </summary>
            public bool no_cache { get; set; }

            /// <summary>
            /// 视频分P列表即使是单P视频，该数组也包含一个元素
            /// </summary>
            public List<Pages> pages { get; set; }

            /// <summary>
            /// 字幕
            /// </summary>
            public Subtitle subtitle { get; set; }

            /// <summary>
            /// 合作UP主, 联合投稿人列表 (非赞助商)
            /// </summary>
            public List<string> staff { get; set; }

            /// <summary>
            /// 合集信息	如果视频属于某个合集，这里会有数据
            /// </summary>
            public object ugc_season { get; set; }

            public bool is_chargeable_season { get; set; }
            public bool is_story { get; set; }

            /// <summary>
            /// 视频所得荣誉
            /// </summary>
            public Honor_reply honor_reply { get; set; }
        }

        /// <summary>
        /// 详细的视频简介
        /// </summary>
        public class Desc_v2
        {
            private int _type;

            /// <summary>
            /// 简介文本
            /// </summary>
            [JsonProperty("raw_text")]
            public string Text { get; set; }

            /// <summary>
            /// 节点类型	1=@某人, 2=普通链接 or= 其他关联
            /// </summary>
            [JsonProperty("type")]
            public string Type
            {
                get => _type == 1
                    ? "提到了某人"
                    : (_type == 2
                        ? "普通连接"
                        : "其他关联");
                set => _type =
                    value == "提到了某人"
                        ? 1
                        : (value == "普通连接" ? 2 : _type);
            }

            /// <summary>
            /// 业务 ID, 被关联对象的 ID. 例如 type=1 时，这里是 mid (用户ID)
            /// </summary>
            public int biz_id { get; set; }
        }

        /// <summary>
        /// 视频的各种权限开关（如是否允许转载）
        /// </summary>
        public class Rights
        {
            private int _bp;
            private int _elec;
            private int _download;
            private int _movie;
            private int _pay;
            private int _hd5;
            private int _noReprint;
            private int _autoplay;
            private int _isCooperation;
            private int _ugcPayPreview;
            private int _ugcPay;
            private int _noShare;
            private int _is360;
            private int _isSteinGate;
            private int _cleanMode;
            private int _arcPay;
            private int _freeWatch;

            /// <summary>
            /// 番剧付费 (Bangumi Pay)	是否可以承包/付费（老番剧字段）
            /// </summary>
            [JsonProperty("bp")]
            [Obsolete]
            public bool IsBangumiPay
            {
                get => _bp == 1;
                set => _bp = value ? 1 : _bp;
            }

            /// <summary>
            /// 是否允许充电
            /// </summary>
            [JsonProperty("elec")]
            public bool IsAllowElectronicPay
            {
                get => _elec == 1;
                set => _elec = value ? 1 : _elec;
            }

            /// <summary>
            /// 是否允许缓存/下载
            /// </summary>
            [JsonProperty("download")]
            public bool IsAllowDownload
            {
                get => _download == 1;
                set => _download = value ? 1 : _download;
            }

            /// <summary>
            /// 是否是电影
            /// </summary>
            [JsonProperty("movie")]
            public bool IsMovie
            {
                get => _movie == 1;
                set => _movie = value ? 1 : _movie;
            }

            /// <summary>
            /// 是否需要付费观看
            /// </summary>
            [JsonProperty("pay")]
            public bool IsPay
            {
                get => _pay == 1;
                set => _pay = value ? 1 : _pay;
            }

            /// <summary>
            /// (古早字段)是否有高码率
            /// </summary>
            [JsonProperty("hd5")]
            [Obsolete]
            public bool IsHighBitrate
            {
                get => _hd5 == 1;
                set => _hd5 = value ? 1 : _hd5;
            }

            /// <summary>
            /// 是否允许转载
            /// </summary>
            [JsonProperty("no_reprint")]
            public bool IsAllowReprint
            {
                get => _noReprint == 1;
                set => _noReprint = value ? 1 : _noReprint;
            }

            /// <summary>
            /// 是否允许自动播放
            /// </summary>
            [JsonProperty("autoplay")]
            public bool IsAllowAutoPlay
            {
                get => _autoplay == 1;
                set => _autoplay = value ? 1 : _autoplay;
            }

            /// <summary>
            /// 是否为UGC 付费	也就是"B站课堂"之类的付费课程
            /// </summary>
            [JsonProperty("ugc_pay")]
            public bool IsUGCPay
            {
                get => _ugcPay == 1;
                set => _ugcPay = value ? 1 : _ugcPay;
            }

            /// <summary>
            /// 是否为合作视频
            /// </summary>
            [JsonProperty("is_cooperation")]
            public bool IsCooperation
            {
                get => _isCooperation == 1;
                set => _isCooperation = value ? 1 : _isCooperation;
            }

            /// <summary>
            /// 是否允许付费视频预览
            /// </summary>
            [JsonProperty("ugc_pay_preview")]
            public bool IsAllowPayPreview
            {
                get => _ugcPayPreview == 1;
                set => _ugcPayPreview = value ? 1 : _ugcPayPreview;
            }

            private int no_background { get; set; }

            /// <summary>
            /// 是否为纯净模式
            /// </summary>
            [JsonProperty("clean_mode")]
            public bool IsCleanMode
            {
                get => _cleanMode == 1;
                set => _cleanMode = value ? 1 : _cleanMode;
            }

            [JsonProperty("is_stein_gate")]
            public bool IsSteinGate
            {
                get => _isSteinGate == 1;
                set => _isSteinGate = value ? 1 : _isSteinGate;
            }

            /// <summary>
            /// 是否为360°全景视频
            /// </summary>
            [JsonProperty("is_360")]
            public bool Is360PanoramicVideo
            {
                get => _is360 == 1;
                set => _is360 = value ? 1 : _is360;
            }

            /// <summary>
            /// 是否允许分享
            /// </summary>
            [JsonProperty("no_share")]
            public bool IsAllowShare
            {
                get => _noShare != 1;
                set => _noShare = value ? _noReprint : 1;
            }

            /// <summary>
            /// 是否为付费视频
            /// </summary>
            [JsonProperty("arc_pay")]
            public bool IsArcPayVideo
            {
                get => _arcPay == 1;
                set => _arcPay = value ? 1 : _arcPay;
            }

            /// <summary>
            /// 是否允许付费视频中的免费试看
            /// </summary>
            [JsonProperty("free_watch")]
            public bool IsAllowFreePreviewInPayVideo
            {
                get => _freeWatch == 1;
                set => _freeWatch = value ? 1 : _freeWatch;
            }
        }
        
        /// <summary>
        /// 视频所有者的信息
        /// </summary>
        public class Owner
        {
            /// <summary>
            /// UP主的UID
            /// </summary>
            public int mid { get; set; }

            /// <summary>
            /// UP主昵称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// UP主头像的URL
            /// </summary>
            [JsonProperty("face")]
            public string AvatarImageUrl { get; set; }
        }

        /// <summary>
        /// 视频统计信息
        /// </summary>
        public class Stat
        {
            private int _nowRank;
            private int _historyRank;

            /// <summary>
            /// AV号
            /// </summary>
            public long aid { get; set; }

            /// <summary>
            /// 播放量
            /// </summary>
            [JsonProperty("view")]
            public int Views { get; set; }

            /// <summary>
            /// 弹幕量
            /// </summary>
            [JsonProperty("danmaku")]
            public int Danmaku { get; set; }

            /// <summary>
            /// 评论量
            /// </summary>
            [JsonProperty("reply")]
            public int Reply { get; set; }

            /// <summary>
            /// 收藏量
            /// </summary>
            [JsonProperty("favorite")]
            public int Favorite { get; set; }

            /// <summary>
            /// 投币量
            /// </summary>
            [JsonProperty("coin")]
            public int Coin { get; set; }

            /// <summary>
            /// 分享量
            /// </summary>
            [JsonProperty("share")]
            public int Share { get; set; }

            /// <summary>
            /// 当前全站/分区排名
            /// </summary>
            [JsonProperty("now_rank")]
            public string NowRank
            {
                get => _nowRank == 0
                    ? "无排名"
                    : _nowRank.ToString();

                set => _nowRank =
                    value == "无排名"
                        ? 0
                        : int.Parse(value);
            }

            /// <summary>
            /// 历史排名
            /// </summary>
            [JsonProperty("his_rank")]
            public string HistoryRank
            {
                get => _historyRank == 0
                    ? "无排名"
                    : _historyRank.ToString();

                set => _historyRank =
                    value == "无排名"
                        ? 0
                        : int.Parse(value);
            }

            /// <summary>
            /// 点赞量
            /// </summary>
            [JsonProperty("like")]
            public int Like { get; set; }

            /// <summary>
            /// 点踩量 (API 通常返回 0，前端不显示)
            /// </summary>
            public int dislike { get; set; }

            /// <summary>
            /// 评分/评估	通常为空，古早版本用于视频评分
            /// </summary>
            public string evaluation { get; set; }

            /// <summary>
            /// Video Type	(古早字段) 视频类型，通常为 0
            /// </summary>
            [JsonProperty("vt")]
            [Obsolete]
            public int VideoType_old { get; set; }
        }

        /// <summary>
        /// 视频分辨率
        /// </summary>
        public class Dimension
        {
            private int _rotate;

            /// <summary>
            /// 宽度
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// 高度
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// 旋转角度	0=正常, 1=90度旋转 (通常手机拍摄上传会有此标记)
            /// </summary>
            [JsonProperty("rotate")]
            public string Rotate
            {
                get => _rotate == 0
                    ? "正常"
                    : (_rotate == 1
                        ? "90度旋转"
                        : "未知");
                set => _rotate =
                    value == "正常"
                        ? 0
                        : value == "90度旋转"
                            ? 1
                            : _rotate;
            }

            /// <summary>
            /// 视频分辨率 ($Width x $Height), 例: 1920x1080
            /// </summary>
            public string VideoDimension => $"{Width}x{Height}";
        }

        /// <summary>
        /// 分P信息
        /// </summary>
        public class Pages
        {
            private string _from;

            /// <summary>
            /// 分P的唯一标识CID，用于获取弹幕等
            /// </summary>
            public int cid { get; set; }

            /// <summary>
            /// 分P的序号，从1开始
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 来源. 通常是 vupload (B站直传)，早期有 hunan 等
            /// </summary>
            [JsonProperty("from")]
            public string SourceWhere
            {
                get => _from == "vupload"
                    ? "B站直传"
                    : _from;
                set => _from =
                    value == "vupload"
                        ? "B站直传"
                        : value;
            }

            /// <summary>
            /// 分P的标题. 对于单P视频，通常是视频主标题
            /// </summary>
            [JsonProperty("part")]
            public string PartTitle { get; set; }

            /// <summary>
            /// 该分P的持续时间，单位为秒
            /// </summary>
            public long duration { get; set; }

            /// <summary>
            /// 如果 <see cref="SourceWhere"/> 不是 "B站直传"，这里存外部视频源 ID，现大多为空
            /// </summary>
            [Obsolete]
            public string vid { get; set; }

            /// <summary>
            /// 外部链接	极少用到，跳转外部链接
            /// </summary>
            [JsonProperty("weblink")]
            [Obsolete]
            public string WebLink { get; set; }

            /// <summary>
            /// 分P视频的分辨率
            /// </summary>
            public Dimension dimension { get; set; }
        }

        #region Subtitle

        /// <summary>
        /// 字幕
        /// </summary>
        public class Subtitle
        {
            /// <summary>
            /// 允许观众投稿 CC 字幕
            /// </summary>
            [JsonProperty("allow_submit")]
            public bool IsAllowSubmitSubtitle { get; set; }

            /// <summary>
            /// 字幕列表
            /// </summary>
            public List<Subtitles> list { get; set; }
        }

        /// <summary>
        /// 字幕
        /// </summary>
        public class Subtitles
        {
            /// <summary>
            /// 字幕ID
            /// </summary>
            public long id { get; set; }

            /// <summary>
            /// 语言代码
            /// </summary>
            [JsonProperty("lan")]
            public string LanguageCode { get; set; }

            /// <summary>
            /// 语言名称
            /// </summary>
            [JsonProperty("lan_doc")]
            public string LanguageName { get; set; }

            public bool is_lock { get; set; }

            /// <summary>
            /// 字幕作者的UID
            /// </summary>
            public int author_mid { get; set; }

            public string subtitle_url { get; set; }

            /// <summary>
            /// 字幕作者信息
            /// </summary>
            public SubtitleAuthor author { get; set; }
        }

        /// <summary>
        /// 字幕作者
        /// </summary>
        public class SubtitleAuthor
        {
            /// <summary>
            /// 作者的UID
            /// </summary>
            public int mid { get; set; }

            /// <summary>
            /// 作者昵称
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 作者头像链接
            /// </summary>
            [JsonProperty("face")]
            public string AvatorImageUrl { get; set; }
        }

        #endregion

        #region Honors

        /// <summary>
        /// 荣誉
        /// </summary>
        public class Honor_reply
        {
            /// <summary>
            /// 视频所得荣誉
            /// </summary>
            public List<Honnors> honor { get; set; }
        }

        /// <summary>
        /// 视频所得荣誉信息
        /// </summary>
        public class Honnors
        {
            /// <summary>
            /// 荣誉名称
            /// </summary>
            public string desc { get; set; }

            /// <summary>
            /// 荣誉类型
            /// </summary>
            public object type { get; set; }
        }

        #endregion
    }
}