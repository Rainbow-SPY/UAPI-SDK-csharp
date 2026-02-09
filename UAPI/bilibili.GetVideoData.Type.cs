using System;
using System.Collections.Generic;
using System.Globalization;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// bilibili视频的返回属性列表
        /// </summary>
        public class VideoType
        {
            /// <summary>
            /// 详细错误信息
            /// </summary>
            public string details { get; set; }

            /// <summary>
            /// 错误信息
            /// </summary>
            public string error { get; set; }

            /// <summary>
            /// 稿件的BV号。
            /// </summary>
            public string bvid { get; set; }

            /// <summary>
            /// 稿件的AV号。
            /// </summary>
            public string aid { get; set; }

            /// <summary>
            /// 稿件分P总数。如果是单P视频，则为1
            /// </summary>
            public int videos { get; set; }

            /// <summary>
            /// 视频所属的子分区ID
            /// </summary>
            public int tid { get; set; }

            /// <summary>
            /// 视频所属的子分区名称。
            /// </summary>
            public string tname { get; set; }

            /// <summary>
            /// 视频类型 原创/转载。
            /// </summary>
            public string CopyRight => copyright == 1
                ? "原创"
                : (copyright == 2
                    ? "转载"
                    : "未知");

            private int copyright { get; set; }

            /// <summary>
            /// 稿件封面图片的URL。这是一个可以直接在网页上展示的链接。   
            /// </summary>
            public string pic { get; set; }

            /// <summary>
            /// 稿件的标题。
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// 稿件发布时间的Unix时间戳（秒）。
            /// </summary>
            public long pubdate { get; set; }

            /// <summary>
            /// 稿件发布的字符串时间（秒）。
            /// </summary>
            public string pubdate_str =>
                DateTime.TryParse(pubdate.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 用户投稿时间的Unix时间戳（秒）。
            /// </summary>
            public long ctime { get; set; }

            /// <summary>
            /// 用户投稿的字符串时间（秒）。
            /// </summary>
            public string ctime_str =>
                DateTime.TryParse(ctime.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 视频简介。可能会包含HTML换行符。
            /// </summary>
            public string desc { get; set; }

            /// <summary>
            /// 详细的视频简介
            /// </summary>
            public List<Desc_v2> desc_v2 { get; set; }

            /// <summary>
            /// 视频状态 1=正常，-6=被删除
            /// </summary>
            public int state { get; set; }

            /// <summary>
            /// 视频状态
            /// </summary>
            public string state_str => state == 1 ? "正常" : (state == -6 ? "被删除" : "未知");

            /// <summary>
            /// 稿件总时长（所有分P累加），单位为秒。
            /// </summary>
            public int duration { get; set; }

            /// <summary>
            /// 视频的各种权限开关（如是否允许转载）
            /// </summary>
            public Rights rights { get; set; }

            /// <summary>
            /// 视频UP主信息。
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
            /// 视频分P列表。即使是单P视频，该数组也包含一个元素。
            /// </summary>
            public List<Pages> pages { get; set; }

            /// <summary>
            /// 字幕
            /// </summary>
            public Subtitle subtitle { get; set; }

            /// <summary>
            /// 合作 UP 主	联合投稿人列表 (非赞助商)
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
        /// 视频的各种权限开关（如是否允许转载）
        /// </summary>
        public class Rights
        {
            /// <summary>
            /// 番剧付费 (Bangumi Pay)	是否可以承包/付费（老番剧字段）
            /// </summary>
            public bool BangumiPay => bp == 1;

            private int bp { get; set; }

            /// <summary>
            /// 是否允许充电
            /// </summary>
            public bool IsAllowElectronicPay => elec == 1;

            private int elec { get; set; }

            /// <summary>
            /// 是否允许缓存/下载
            /// </summary>
            public bool IsAllowDownload => download == 1;

            private int download { get; set; }

            /// <summary>
            /// 是否是电影
            /// </summary>
            public bool IsMovie => movie == 1;

            private int movie { get; set; }

            /// <summary>
            /// 是否需要付费观看
            /// </summary>
            public bool IsPay => pay == 1;

            private int pay { get; set; }

            /// <summary>
            /// (古早字段)是否有高码率
            /// </summary>
            public bool IsHighBitrate => hd5 == 1;

            private int hd5 { get; set; }

            /// <summary>
            /// 是否允许转载
            /// </summary>
            public bool IsAllowReprint => no_reprint != 1;

            private int no_reprint { get; set; }

            /// <summary>
            /// 是否允许自动播放
            /// </summary>
            public bool IsAllowAutoPlay => autoplay == 1;

            private int autoplay { get; set; }

            /// <summary>
            /// 是否为UGC 付费	也就是"B站课堂"之类的付费课程
            /// </summary>
            public bool IsUGCPay => ugc_pay == 1;

            private int ugc_pay { get; set; }

            /// <summary>
            /// 是否为合作视频
            /// </summary>
            public bool IsCooperation => is_cooperation == 1;

            private int is_cooperation { get; set; }

            /// <summary>
            /// 是否允许付费视频预览
            /// </summary>
            public bool IsAllowPayPreview => ugc_pay_preview == 1;

            private int ugc_pay_preview { get; set; }
            private int no_background { get; set; }

            /// <summary>
            /// 纯净模式
            /// </summary>
            public bool IsCleanMode => clean_mode == 1;

            private int clean_mode { get; set; }
            public bool IsSteinGate => is_stein_gate == 1;
            private int is_stein_gate { get; set; }

            /// <summary>
            /// 是否为360°全景视频
            /// </summary>
            public bool Is360PanoramicVideo => is_360 == 1;

            private int is_360 { get; set; }

            /// <summary>
            /// 是否允许分享
            /// </summary>
            public bool IsAllowShare => no_share != 1;

            private int no_share { get; set; }

            /// <summary>
            /// 是否为付费视频
            /// </summary>
            public bool IsArcPayVideo => arc_pay == 1;

            private int arc_pay { get; set; }

            /// <summary>
            /// 是否允许付费视频中的免费试看
            /// </summary>
            public bool IsAllowFreePreviewInPayVideo => free_watch == 1;

            private int free_watch { get; set; }
        }

        /// <summary>
        /// 详细的视频简介
        /// </summary>
        public class Desc_v2
        {
            /// <summary>
            /// 简介文本
            /// </summary>
            public string raw_text { get; set; }

            /// <summary>
            /// 节点类型	1=@某人, 2=普通链接 or= 其他关联
            /// </summary>
            public string Type => type == 1
                ? "提到了某人"
                : (type == 2
                    ? "普通连接"
                    : "其他关联");

            private int type { get; set; }

            /// <summary>
            /// 业务 ID	被关联对象的 ID。例如 type=1 时，这里是 mid (用户ID)
            /// </summary>
            public int biz_id { get; set; }
        }

        /// <summary>
        /// 视频所有者的信息
        /// </summary>
        public class Owner
        {
            /// <summary>
            /// UP主的UID。
            /// </summary>
            public int mid { get; set; }

            /// <summary>
            /// UP主昵称。
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// UP主头像的URL。
            /// </summary>
            public string face { get; set; }
        }

        /// <summary>
        /// 视频统计信息
        /// </summary>
        public class Stat
        {
            /// <summary>
            /// AV号
            /// </summary>
            public int aid { get; set; }

            /// <summary>
            /// 播放量
            /// </summary>
            public int view { get; set; }

            /// <summary>
            /// 弹幕量
            /// </summary>
            public int danmaku { get; set; }

            /// <summary>
            /// 评论量
            /// </summary>
            public int reply { get; set; }

            /// <summary>
            /// 收藏量
            /// </summary>
            public int favorite { get; set; }

            /// <summary>
            /// 投币量
            /// </summary>
            public int coin { get; set; }

            /// <summary>
            /// 分享量
            /// </summary>
            public int share { get; set; }

            /// <summary>
            /// 当前全站/分区排名
            /// </summary>
            public string NowRank => now_rank == 0
                ? "无排名"
                : now_rank.ToString();

            private int now_rank { get; set; }

            /// <summary>
            /// 历史排名
            /// </summary>
            public int his_rank { get; set; }

            /// <summary>
            /// 点赞量
            /// </summary>
            public int like { get; set; }

            /// <summary>
            /// 点踩量 (API 通常返回 0，前端不显示)
            /// </summary>
            internal int dislike { get; set; }

            /// <summary>
            /// 评分/评估	通常为空，古早版本用于视频评分
            /// </summary>
            internal string evaluation { get; set; }

            /// <summary>
            /// Video Type	(古早字段) 视频类型，通常为 0
            /// </summary>
            internal int vt { get; set; }
        }

        /// <summary>
        /// 视频分辨率
        /// </summary>
        public class Dimension
        {
            /// <summary>
            /// 宽度
            /// </summary>
            public int width { get; set; }

            /// <summary>
            /// 高度
            /// </summary>
            public int height { get; set; }

            /// <summary>
            /// 旋转角度	0=正常, 1=90度旋转 (通常手机拍摄上传会有此标记)
            /// </summary>
            public string Rotate => rotate == 0
                ? "正常"
                : (rotate == 1
                    ? "90度旋转"
                    : "未知");

            private int rotate { get; set; }
        }

        /// <summary>
        /// 分P信息
        /// </summary>
        public class Pages
        {
            /// <summary>
            /// 分P的唯一标识CID，用于获取弹幕等。
            /// </summary>
            public int cid { get; set; }

            /// <summary>
            /// 分P的序号，从1开始。  
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 来源	通常是 vupload (B站直传)，早期有 hunan 等
            /// </summary>
            public string SourceWhere => from == "vupload"
                ? "B站上传"
                : "其他";

            private string from { get; set; }

            /// <summary>
            /// 分P的标题。对于单P视频，通常是视频主标题。
            /// </summary>
            public string part { get; set; }

            /// <summary>
            /// 该分P的持续时间，单位为秒。
            /// </summary>
            public int duration { get; set; }

            /// <summary>
            /// 如果 <see cref="from"/> 不是 vupload，这里存外部视频源 ID，现大多为空
            /// </summary>
            public string vid { get; set; }

            /// <summary>
            /// 外部链接	极少用到，跳转外部链接
            /// </summary>
            public string weblink { get; set; }

            /// <summary>
            /// 分P视频的分辨率
            /// </summary>
            public Dimension dimension { get; set; }
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
            public string face { get; set; }
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
            public string lan { get; set; }

            /// <summary>
            /// 语言名称
            /// </summary>
            public string lan_doc { get; set; }

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
        /// 字幕
        /// </summary>
        public class Subtitle
        {
            /// <summary>
            /// 允许观众投稿 CC 字幕
            /// </summary>
            public bool allow_submit { get; set; }

            /// <summary>
            /// 字幕列表
            /// </summary>
            public List<Subtitles> list { get; set; }
        }

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
    }
}