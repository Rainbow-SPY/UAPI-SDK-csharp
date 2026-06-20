using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using static UAPI.Type.VideoType;

namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public class VideoAttribute
        {
            /// <summary>
            /// 视频属性位
            /// </summary>
            [JsonProperty("attribute")]
            public int Attribute { get; set; }

            /// <summary>
            /// 视频属性
            /// </summary>
            [Flags]
            public enum VideoAttributeFlags
            {
                /// <summary>
                /// 默认 无
                /// </summary>
                None = 0,

                /// <summary>
                /// 禁止排行
                /// </summary>
                NoRank = 1 << 0,

                /// <summary>
                /// 动态禁止 / 禁止 APP 推送动态
                /// </summary>
                NoDynamic = 1 << 1,

                /// <summary>
                /// 禁止网页输出
                /// </summary>
                NoWebOutput = 1 << 2,

                /// <summary>
                /// 禁止客户端列表
                /// </summary>
                NoClientList = 1 << 3,

                /// <summary>
                /// 搜索禁止
                /// </summary>
                NoSearch = 1 << 4,

                /// <summary>
                /// 海外禁止
                /// </summary>
                NoOversea = 1 << 5,

                /// <summary>
                /// 禁止推荐 / 禁止被 APP 端天马列表推荐
                /// </summary>
                NoRecommend = 1 << 6,

                /// <summary>
                /// 显示“未经作者授权 禁止转载”标志
                /// </summary>
                NoReprint = 1 << 7,

                /// <summary>
                /// 是否高清，视频清晰度 >= 1080P
                /// </summary>
                IsHD = 1 << 8,

                /// <summary>
                /// 是否 PGC 稿件，番剧 & 影视
                /// </summary>
                IsPGC = 1 << 9,

                /// <summary>
                /// 允许承包
                /// </summary>
                AllowBp = 1 << 10,

                /// <summary>
                /// 是否番剧
                /// </summary>
                IsBangumi = 1 << 11,

                /// <summary>
                /// 是否私单 / 存在商业推广恰饭内容
                /// </summary>
                IsPrivateOrder = 1 << 12,

                /// <summary>
                /// 是否限制地区
                /// </summary>
                IsAreaLimit = 1 << 13,

                /// <summary>
                /// 禁止其他人添加 TAG
                /// </summary>
                NoAddTag = 1 << 14,

                /// <summary>
                /// 未知标志；大多数旧视频会有
                /// </summary>
                UnknownOldVideoFlag = 1 << 15,

                /// <summary>
                /// 跳转，番剧及影视 av/bv -> ep 跳转
                /// </summary>
                IsRedirect = 1 << 16,

                /// <summary>
                /// 是否影视
                /// </summary>
                IsMovie = 1 << 17,

                /// <summary>
                /// 是否付费
                /// </summary>
                IsPay = 1 << 18,

                /// <summary>
                /// 推送动态
                /// </summary>
                PushDynamic = 1 << 19,

                /// <summary>
                /// 家长模式
                /// </summary>
                ParentMode = 1 << 20,

                /// <summary>
                /// 是否限制游客和外链；该位语义比较特殊，不能仅凭该位区分具体是哪一种限制
                /// </summary>
                GuestOrRefererRestricted = 1 << 21,

                Unknown22 = 1 << 22,
                Unknown23 = 1 << 23,

                /// <summary>
                /// 是否为联合投稿
                /// </summary>
                IsCooperation = 1 << 24,

                Unknown25 = 1 << 25,
                Unknown26 = 1 << 26,
                Unknown27 = 1 << 27,
                Unknown28 = 1 << 28,

                /// <summary>
                /// 是否为互动视频
                /// </summary>
                IsSteinGate = 1 << 29
            }

            /// <summary>
            /// 合集属性位标志
            /// </summary>
            [JsonIgnore]
            public VideoAttributeFlags AttributeFlags
            {
                get => (VideoAttributeFlags)Attribute;
                set => Attribute = (int)value;
            }

            private bool HasAttribute(VideoAttributeFlags flag) => (AttributeFlags & flag) != 0;

            /// <summary>
            /// 是否禁止排行
            /// </summary>
            [JsonIgnore]
            public bool IsRankDisabled => HasAttribute(VideoAttributeFlags.NoRank);

            /// <summary>
            /// 是否禁止动态 / 禁止 APP 推送动态
            /// </summary>
            [JsonIgnore]
            public bool IsDynamicDisabled => HasAttribute(VideoAttributeFlags.NoDynamic);

            /// <summary>
            /// 是否禁止网页输出
            /// </summary>
            [JsonIgnore]
            public bool IsWebOutputDisabled => HasAttribute(VideoAttributeFlags.NoWebOutput);

            /// <summary>
            /// 是否禁止客户端列表
            /// </summary>
            [JsonIgnore]
            public bool IsClientListDisabled => HasAttribute(VideoAttributeFlags.NoClientList);

            /// <summary>
            /// 是否禁止搜索
            /// </summary>
            [JsonIgnore]
            public bool IsSearchDisabled => HasAttribute(VideoAttributeFlags.NoSearch);

            /// <summary>
            /// 是否海外禁止
            /// </summary>
            [JsonIgnore]
            public bool IsOverseaDisabled => HasAttribute(VideoAttributeFlags.NoOversea);

            /// <summary>
            /// 是否禁止推荐
            /// </summary>
            [JsonIgnore]
            public bool IsRecommendDisabled => HasAttribute(VideoAttributeFlags.NoRecommend);

            /// <summary>
            /// 是否显示“未经作者授权 禁止转载”标志
            /// </summary>
            [JsonIgnore]
            public bool IsNoReprint => HasAttribute(VideoAttributeFlags.NoReprint);

            /// <summary>
            /// 是否高清，视频清晰度 >= 1080P
            /// </summary>
            [JsonIgnore]
            public bool IsHD => HasAttribute(VideoAttributeFlags.IsHD);

            /// <summary>
            /// 是否 PGC 稿件
            /// </summary>
            [JsonIgnore]
            public bool IsPGC => HasAttribute(VideoAttributeFlags.IsPGC);

            /// <summary>
            /// 是否允许承包
            /// </summary>
            [JsonIgnore]
            public bool AllowBp => HasAttribute(VideoAttributeFlags.AllowBp);

            /// <summary>
            /// 是否番剧
            /// </summary>
            [JsonIgnore]
            public bool IsBangumi => HasAttribute(VideoAttributeFlags.IsBangumi);

            /// <summary>
            /// 是否私单 / 是否存在商业推广恰饭内容
            /// </summary>
            [JsonIgnore]
            public bool IsPrivateOrder => HasAttribute(VideoAttributeFlags.IsPrivateOrder);

            /// <summary>
            /// 是否限制地区
            /// </summary>
            [JsonIgnore]
            public bool IsAreaLimit => HasAttribute(VideoAttributeFlags.IsAreaLimit);

            /// <summary>
            /// 是否禁止其他人添加 TAG
            /// </summary>
            [JsonIgnore]
            public bool IsAddTagDisabled => HasAttribute(VideoAttributeFlags.NoAddTag);

            /// <summary>
            /// 未知旧视频标志；文档称大多数旧视频会有
            /// </summary>
            [JsonIgnore]
            public bool HasOldVideoUnknownFlag => HasAttribute(VideoAttributeFlags.UnknownOldVideoFlag);

            /// <summary>
            /// 是否跳转，番剧及影视 av/bv -> ep 跳转
            /// </summary>
            [JsonIgnore]
            public bool IsRedirect => HasAttribute(VideoAttributeFlags.IsRedirect);

            /// <summary>
            /// 是否影视
            /// </summary>
            [JsonIgnore]
            public bool IsMovie => HasAttribute(VideoAttributeFlags.IsMovie);

            /// <summary>
            /// 是否付费
            /// </summary>
            [JsonIgnore]
            public bool IsPay => HasAttribute(VideoAttributeFlags.IsPay);

            /// <summary>
            /// 是否推送动态
            /// </summary>
            [JsonIgnore]
            public bool IsPushDynamic => HasAttribute(VideoAttributeFlags.PushDynamic);

            /// <summary>
            /// 是否家长模式
            /// </summary>
            [JsonIgnore]
            public bool IsParentMode => HasAttribute(VideoAttributeFlags.ParentMode);

            /// <summary>
            /// 是否限制游客或外链；bit 21 语义较特殊，不能仅凭该字段判断具体限制类型
            /// </summary>
            [JsonIgnore]
            public bool IsGuestOrRefererRestricted =>
                HasAttribute(VideoAttributeFlags.GuestOrRefererRestricted);

            /// <summary>
            /// 是否为联合投稿
            /// </summary>
            [JsonIgnore]
            public bool IsCooperation => HasAttribute(VideoAttributeFlags.IsCooperation);

            /// <summary>
            /// 是否为互动视频
            /// </summary>
            [JsonIgnore]
            public bool IsSteinGate => HasAttribute(VideoAttributeFlags.IsSteinGate);
        }

        /// <summary />
        public abstract class VideoBase : TypeInterface
        {
            private int _copyright;

            /// <summary>
            /// 稿件的BV号
            /// </summary>
            [JsonProperty("bvid")]
            public string BVID { get; set; }

            /// <summary>
            /// 稿件的AV号
            /// </summary>
            [JsonProperty("aid")]
            public string AID { get; set; }

            /// <summary>
            /// 稿件分P总数如果是单P视频，则为1
            /// </summary>
            [JsonProperty("videos")]
            public int Videos { get; set; }

            /// <summary>
            /// 视频所属的子分区ID
            /// </summary>
            [JsonProperty("tid")]
            public int TID { get; set; }

            /// <summary>
            /// 视频所属的子分区名称
            /// </summary>
            [JsonProperty("tname")]
            public string TName { get; set; }

            /// <summary>
            /// 视频版权类型 原创/转载
            /// </summary>
            public string CopyrightType => _copyright switch
            {
                1 => "原创",
                2 => "转载",
                _ => "未知"
            };

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
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 稿件发布时间的Unix时间戳（秒)
            /// </summary>
            [JsonProperty("pubdate")]
            public long PubDate { get; set; }

            /// <summary>
            /// 稿件发布的字符串时间（秒）
            /// </summary>
            public string PubDate_str =>
                DateTime.TryParse(PubDate.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 用户投稿时间的Unix时间戳（秒）
            /// </summary>
            [JsonProperty("ctime")]
            public long CTime { get; set; }

            /// <summary>
            /// 用户投稿的字符串时间（秒）
            /// </summary>
            public string CTime_str =>
                DateTime.TryParse(CTime.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                    out var dt)
                    ? dt.ToString("yyyy-MM-dd")
                    : string.Empty;

            /// <summary>
            /// 视频简介, 可能会包含HTML换行符
            /// </summary>
            [JsonProperty("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// 详细的视频简介
            /// </summary>
            [JsonProperty("desc_v2")]
            public List<Desc_v2> DescV2List { get; set; }

            /// <summary>
            /// 视频当前状态码
            /// </summary>
            [JsonProperty("state")]
            public int StateCode { get; set; }

            /// <summary>
            /// 视频当前状态描述
            /// </summary>
            [JsonIgnore]
            public string State =>
                StateCode switch
                {
                    1 => "审核通过（非正常开放浏览/橙色通过）",
                    0 => "开放浏览",
                    -1 => "待审",
                    -2 => "被回退稿件",
                    -3 => "网警锁定",
                    -4 => "稿件撞车被锁定",
                    -5 => "管理员锁定了此稿件",
                    -6 => "修复待审",
                    -7 => "暂缓审核",
                    -8 => "补档待审",
                    -9 => "视频等待转码",
                    -10 => "延迟审核",
                    -11 => "视频源待修",
                    -12 => "转储失败",
                    -13 => "允许评论待审",
                    -14 => "临时回收站",
                    -15 => "分发中",
                    -16 => "转码失败",
                    -20 => "创建未提交",
                    -30 => "创建已提交",
                    -40 => "定时发布",
                    -50 => "仅UP主可见",
                    -100 => "用户删除",
                    _ => null
                };

            /// <summary>
            /// 稿件总时长（所有分P累加），单位为秒
            /// </summary>
            [JsonProperty("duration")]
            public int Duration { get; set; }

            /// <summary>
            /// 视频的各种权限开关（如是否允许转载）
            /// </summary>
            [JsonProperty("rights")]
            public Rights RightsInfo { get; set; }

            /// <summary>
            /// 视频UP主信息
            /// </summary>
            [JsonProperty("owner")]
            public Owner OwnerInfo { get; set; }

            /// <summary>
            /// 统计数据, 播放、点赞、硬币等数据
            /// </summary>
            [JsonProperty("stat")]
            public Stat StatInfo { get; set; }

            /// <summary>
            /// 动态的文字, 投稿时附带的动态描述
            /// </summary>
            [JsonProperty("dynamic")]
            public string DynamicText { get; set; }

            /// <summary>
            /// 弹幕 ID (CID), 视频资源（分P）的唯一 ID
            /// </summary>
            [JsonProperty("cid")]
            public long CID { get; set; }

            /// <summary>
            /// 分辨率信息, 视频宽高等
            /// </summary>
            [JsonProperty("dimension")]
            public Dimension DimensionInfo { get; set; }

            /// <summary>
            /// 不缓存, 一般为 false
            /// </summary>
            [JsonProperty("no_cache")]
            public bool IsNoCache { get; set; }

            /// <summary>
            /// 视频分P列表即使是单P视频，该数组也包含一个元素
            /// </summary>
            [JsonProperty("pages")]
            public List<Pages> PagesList { get; set; }

            /// <summary>
            /// 字幕
            /// </summary>
            [JsonProperty("subtitle")]
            public Subtitle SubtitleList { get; set; }

            /// <summary>
            /// 合作UP主, 联合投稿人列表 (非赞助商)
            /// </summary>
            [JsonProperty("staff")]
            public List<Staff> StaffList { get; set; }

            /// <summary/>
            public class Staff
            {
                /// <summary>
                /// 成员的UID
                /// </summary>
                [JsonProperty("mid")]
                public int UID { get; set; }

                /// <summary>
                /// 成员名称
                /// </summary>
                [JsonProperty("title")]
                public string Title { get; set; }

                /// <summary>
                /// 成员昵称
                /// </summary>
                [JsonProperty("name")]
                public string NickName { get; set; }

                /// <summary>
                /// 头像URL
                /// </summary>
                [JsonProperty("face")]
                public string CoverImageURL { get; set; }

                /// <summary>
                /// 大会员状态
                /// </summary>
                [JsonProperty("vip")]
                public Vip vip { get; set; }

                /// <summary>
                /// 认证信息
                /// </summary>
                [JsonProperty("official")]
                public Official official { get; set; }

                /// <summary>
                /// 粉丝数
                /// </summary>
                [JsonProperty("follower")]
                public int follower { get; set; }

                /// <summary>
                /// 标签样式
                /// </summary>
                [JsonProperty("label_style")]
                public int label_style { get; set; }

                /// <summary/>
                public class Vip
                {
                    private int _status;

                    /// <summary>
                    /// 大会员类型, 0=无, 1=月会员, 2=年会员
                    /// </summary>
                    [JsonProperty("type")]
                    public int type { get; set; }

                    /// <summary>
                    /// 是否有大会员
                    /// </summary>
                    [JsonProperty("status")]
                    public bool IsHasVIP
                    {
                        get => _status == 1;
                        set => _status = value ? 1 : 0;
                    }

                    /// <summary>
                    /// 到期时间 
                    /// </summary>
                    [JsonProperty("due_date")]
                    public int DueDate_Unix { get; set; }

                    /// <summary>
                    /// 未知 - 会员购买日期?
                    /// </summary>
                    [JsonProperty("vip_pay_date")]
                    public int VipPayDate { get; set; }

                    /// <summary>
                    /// 主题样式?
                    /// </summary>
                    [JsonProperty("theme_type")]
                    public int ThemeType { get; set; }

                    /// <summary>
                    /// 大会员标签
                    /// </summary>
                    [JsonProperty("label")]
                    public Label label { get; set; }

                    /// <summary/>
                    public class Label
                    {
                        [JsonProperty("path")] public string Path { get; set; }

                        /// <summary>
                        /// 描述
                        /// </summary>
                        [JsonProperty("text")]
                        public string Text { get; set; }

                        /// <summary>
                        /// 标签主题
                        /// </summary>
                        [JsonProperty("label_theme")]
                        public string LabelTheme { get; set; }

                        /// <summary>
                        /// 字体颜色
                        /// </summary>
                        [JsonProperty("text_color")]
                        public string TextColor { get; set; }

                        /// <summary>
                        /// 背景样式
                        /// </summary>
                        [JsonProperty("bg_style")]
                        public int BackgroundStyle { get; set; }

                        /// <summary>
                        /// 背景颜色
                        /// </summary>
                        [JsonProperty("bg_color")]
                        public string BackgroundColor { get; set; }

                        /// <summary>
                        /// 边框颜色
                        /// </summary>
                        [JsonProperty("border_color")]
                        public string BorderColor { get; set; }

                        /// <summary>
                        /// 是否使用图像标签
                        /// </summary>
                        [JsonProperty("use_img_label")]
                        public bool IsUseImgLabel { get; set; }

                        /// <summary>
                        /// 简体中文的标签动态图像URL
                        /// </summary>
                        [JsonProperty("img_label_uri_hans")]
                        public string DynamicImageLabelURL_zh_Hans { get; set; }

                        /// <summary>
                        /// 繁体中文的标签动态图像URL
                        /// </summary>
                        [JsonProperty("img_label_uri_hant")]
                        public string DynamicImageLabelURL_zh_Hant { get; set; }

                        /// <summary>
                        /// 简体中文的标签静态图像URL
                        /// </summary>
                        [JsonProperty("img_label_uri_hans_static")]
                        public string StaticImageLabelURL_zh_Hans { get; set; }

                        /// <summary>
                        /// 繁体中文的标签静态图像URL
                        /// </summary>
                        [JsonProperty("img_label_uri_hant_static")]
                        public string StaticImageLabelURL_zh_Hant { get; set; }
                    }
                }

                /// <summary/>
                public class Official
                {
                    private int _type;

                    /// <summary>
                    /// 成员认证码
                    /// </summary>
                    [JsonProperty("role")]
                    public int RoleCode { get; set; }

                    /// <summary>
                    /// 成员认证级别
                    /// </summary>
                    [JsonIgnore]
                    public string RoleType =>
                        RoleCode switch
                        {
                            1 => "个人认证 - 知名UP主",
                            2 => "个人认证 - 大V达人",
                            3 => "机构认证 - 企业",
                            4 => "机构认证 - 组织",
                            5 => "机构认证 - 媒体",
                            6 => "机构认证 - 政府",
                            7 => "个人认证 - 高能主播",
                            9 => "个人认证 - 社会知名人士",
                            _ => null
                        };

                    /// <summary>
                    /// 成员认证名
                    /// </summary>
                    [JsonProperty("title")]
                    public string Title { get; set; }

                    /// <summary>
                    /// 成员认证备注
                    /// </summary>
                    [JsonProperty("desc")]
                    public string Description { get; set; }

                    /// <summary>
                    /// 成员是否认证
                    /// </summary>
                    [JsonProperty("type")]
                    public bool IsRole
                    {
                        get => _type == 0;
                        set => _type = value ? 0 : -1;
                    }
                }
            }

            /// <summary>
            /// 合集信息	如果视频属于某个合集，这里会有数据
            /// </summary>
            public UGCSeason UgcSeason { get; set; }

            /// <summary>
            /// 是否为充电合集
            /// </summary>
            public bool IsChargeableSeason { get; set; }

            /// <summary>
            /// 是否为充电专属视频	
            /// </summary>
            [JsonProperty("is_upower_exclusive")]
            public bool IsUpowerExclusive { get; set; }

            /// <summary>
            /// 是否有权播放充电视频
            /// </summary>
            [JsonProperty("is_upower_play")]
            public bool IsUpowerPlay { get; set; }

            /// <summary>
            /// 充电专属视频是否支持试看
            /// </summary>
            [JsonProperty("is_upower_preview")]
            public bool IsUpowerPreview { get; set; }

            [JsonProperty("is_upower_exclusive_with_qa")]
            public bool is_upower_exclusive_with_qa { get; set; }

            [JsonProperty("pay_type")] public string pay_type { get; set; }

            /// <summary>
            /// 是否为动态视频
            /// </summary>
            [JsonProperty("is_story")]
            public bool IsStory { get; set; }

            /// <summary>
            /// 视频所得荣誉
            /// </summary>
            [JsonProperty("honor_reply")]
            public Honor_reply HonorReply { get; set; }
        }

        /// <summary>
        /// bilibili视频的返回属性列表
        /// </summary>
        public class VideoType : VideoBase
        {
            /// <summary/>
            public class UGCSeason : VideoAttribute
            {
                private int _enableVt;

                /// <summary>
                /// 视频合集id
                /// </summary>
                [JsonProperty("id")]
                public int ID { get; set; }

                /// <summary>
                /// 合集标题
                /// </summary>
                [JsonProperty("title")]
                public string Title { get; set; }

                /// <summary>
                /// 视频封面
                /// </summary>
                [JsonProperty("cover")]
                public string VideoImageCover { get; set; }

                /// <summary>
                /// 合集所有者的UID
                /// </summary>
                [JsonProperty("mid")]
                public long UID { get; set; }

                /// <summary>
                /// 视频合集介绍
                /// </summary>
                [JsonProperty("intro")]
                public string Introduction { get; set; }

                [JsonProperty("sign_state")] public int sign_state { get; set; }

                /// <summary/>
                /// <summary>
                /// 分部列表，名称可由up主自定义，默认为正片
                /// </summary>
                [JsonProperty("sections")]
                public List<SectionsItem> SectionsList { get; set; }

                /// <summary>
                /// 视频合集状态数
                /// </summary>
                [JsonProperty("stat")]
                public Stat Stat { get; set; }

                /// <summary>
                /// 视频合集中视频数量
                /// </summary>
                [JsonProperty("ep_count")]
                public int EpisodesCount { get; set; }

                [JsonProperty("season_type")] public int season_type { get; set; }

                /// <summary>
                /// 是否为付费合集
                /// </summary>
                [JsonProperty("is_pay_season")]
                public bool IsPaySeason { get; set; }

                /// <summary>
                /// 是否启用功能 [播放量 vv 改为播放总时长 vt]
                /// </summary>
                [JsonProperty("enable_vt")]
                public bool IsEnableVT
                {
                    get => _enableVt == 1;
                    set => _enableVt = value ? 1 : 0;
                }

                /// <summary/>
                public class SectionsItem
                {
                    /// <summary>
                    /// 视频合集中分部所属视频合集id
                    /// </summary>
                    [JsonProperty("season_id")]
                    public int SeasonID { get; set; }

                    [JsonProperty("id")] public int ID { get; set; }

                    /// <summary>
                    /// 视频合集中分部标题
                    /// </summary>
                    [JsonProperty("title")]
                    public string Title { get; set; }

                    [JsonProperty("type")] public int type { get; set; }

                    /// <summary>
                    /// 视频合集中分部的视频列表	
                    /// </summary>
                    [JsonProperty("episodes")]
                    public List<EpisodesItem> Episodes { get; set; }

                    /// <summary/>
                    public class EpisodesItem : VideoAttribute
                    {
                        /// <summary>
                        /// 分部中 视频所属视频的合集id
                        /// </summary>
                        [JsonProperty("season_id")]
                        public int SeasonID { get; set; }

                        /// <summary>
                        /// 分部中 视频所属视频的 合集分部id
                        /// </summary>
                        [JsonProperty("section_id")]
                        public int SectionID { get; set; }

                        /// <summary>
                        /// 视频合集分部中视频id
                        /// </summary>
                        [JsonProperty("id")]
                        public int ID { get; set; }

                        /// <summary>
                        /// AV号
                        /// </summary>
                        [JsonProperty("aid")]
                        public long AID { get; set; }

                        /// <summary>
                        /// 分P ID
                        /// </summary>
                        [JsonProperty("cid")]
                        public long CID { get; set; }

                        /// <summary>
                        /// 合集中视频的Fake标题
                        /// </summary>
                        [JsonProperty("title")]
                        public string FakeTitle { get; set; }

                        /// <summary>
                        /// 视频详细信息
                        /// </summary>
                        [JsonProperty("arc")]
                        public Arc Info { get; set; }

                        /// <summary>
                        /// 当前分P的数据
                        /// </summary>
                        [JsonProperty("page")]
                        public Pages PageData { get; set; }

                        /// <summary>
                        /// BV号
                        /// </summary>
                        [JsonProperty("bvid")]
                        public string BVID { get; set; }

                        /// <summary>
                        /// 分页数据
                        /// </summary>
                        [JsonProperty("pages")]
                        public List<Pages> pages { get; set; }

                        /// <summary>
                        /// 视频详细信息
                        /// </summary>
                        public class Arc : VideoBase
                        {
                            private int _enableVt;
                            [JsonProperty("is_blooper")] public bool is_blooper { get; set; }

                            /// <summary>
                            /// 功能 [播放量 vv 改为播放总时长 vt] 是否启用
                            /// </summary>
                            [JsonProperty("enable_vt")]
                            public bool IsEnableVT
                            {
                                get => _enableVt == 1;
                                set => _enableVt = value ? 1 : 0;
                            }

                            /// <summary>
                            /// 播放总时长
                            /// </summary>
                            [JsonProperty("vt_display")]
                            public string VTDisplay { get; set; }
                        }

                        public class Stat : VideoType.Stat
                        {
                            /// <summary>
                            /// 警告/争议提示信息
                            /// </summary>
                            [JsonProperty("argue_msg")]
                            public string ArgueMessage { get; set; }

                            /// <summary>
                            /// 播放量?
                            /// </summary>
                            [JsonProperty("vv")]
                            public int vv { get; set; }
                        }
                    }
                }
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
                    get => _type switch
                    {
                        1 => "提到了某人",
                        2 => "普通连接",
                        _ => "其他关联"
                    };
                    set => _type =
                        value switch
                        {
                            "提到了某人" => 1,
                            "普通连接" => 2,
                            _ => _type
                        };
                }

                /// <summary>
                /// 业务 ID, 被关联对象的 ID. 例如 type=1 时，这里是 mid (用户ID)
                /// </summary>
                [JsonProperty("biz_id")]
                public int BizId { get; set; }
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
                /// 是否PGC付费
                /// </summary>
                [JsonProperty("pay")]
                public bool IsPay
                {
                    get => _pay == 1;
                    set => _pay = value ? 1 : _pay;
                }

                /// <summary>
                /// 是否有高码率
                /// </summary>
                [JsonProperty("hd5")]
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
                    get => _noReprint == 0;
                    set => _noReprint = value ? 0 : _noReprint;
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

                public int no_background { get; set; }

                /// <summary>
                /// 是否为纯净模式
                /// </summary>
                [JsonProperty("clean_mode")]
                public bool IsCleanMode
                {
                    get => _cleanMode == 1;
                    set => _cleanMode = value ? 1 : _cleanMode;
                }

                /// <summary>
                /// 是否为互动视频
                /// </summary>
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
                [JsonProperty("aid")]
                public long AID { get; set; }

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
                /// </summary>\
                [Obsolete]
                [JsonProperty("dislike")]
                public int Dislike { get; set; }

                /// <summary>
                /// 评分/评估	通常为空，古早版本用于视频评分
                /// </summary>
                [Obsolete]
                [JsonProperty("evaluation")]
                public string Evaluation { get; set; }

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
                    get => _rotate switch
                    {
                        0 => "正常",
                        1 => "90度旋转",
                        _ => "未知"
                    };
                    set => _rotate =
                        value switch
                        {
                            "正常" => 0,
                            "90度旋转" => 1,
                            _ => _rotate
                        };
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
                [JsonProperty("cid")]
                public int CID { get; set; }

                /// <summary>
                /// 分P的序号，从1开始
                /// </summary>
                [JsonProperty("page")]
                public int Index { get; set; }

                /// <summary>
                /// 来源. 通常是 vupload (B站直传)，早期有 hunan 等
                /// </summary>
                [JsonProperty("from")]
                public string SourceWhere
                {
                    get => _from switch
                    {
                        "vupload" => "B站直传",
                        "hunan" => "芒果TV",
                        "qq" => "腾讯",
                        _ => _from
                    };
                    set => _from =
                        value switch
                        {
                            "vupload" => "B站直传",
                            "hunan" => "芒果TV",
                            "qq" => "腾讯",
                            _ => value
                        };
                }

                /// <summary>
                /// 分P的标题. 对于单P视频，通常是视频主标题
                /// </summary>
                [JsonProperty("part")]
                public string PartTitle { get; set; }

                /// <summary>
                /// 该分P的持续时间，单位为秒
                /// </summary>
                [JsonProperty("duration")]
                public long Duration { get; set; }

                /// <summary>
                /// 如果 <see cref="SourceWhere"/> 不是 "B站直传"，这里存外部视频源 ID，现大多为空
                /// </summary>
                /// <remarks>仅站外视频有效</remarks>
                [Obsolete]
                public string vid { get; set; }

                /// <summary>
                /// 外部链接	极少用到，跳转外部链接
                /// </summary>
                /// <remarks>仅站外视频有效</remarks>
                [JsonProperty("weblink")]
                [Obsolete]
                public string WebLink { get; set; }

                /// <summary>
                /// 分P视频的分辨率
                /// </summary>
                [JsonProperty("dimension")]
                public Dimension DimensionInfo { get; set; }
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
                /// <remarks>未登录为空</remarks>
                public List<Subtitles> List { get; set; }
            }

            /// <summary>
            /// 字幕
            /// </summary>
            public class Subtitles
            {
                /// <summary>
                /// 字幕ID
                /// </summary>
                public long ID { get; set; }

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

                /// <summary>
                /// 是否锁定
                /// </summary>
                [JsonProperty("is_lock")]
                public bool IsLock { get; set; }

                /// <summary>
                /// 字幕作者的UID
                /// </summary>
                [JsonProperty("author_mid")]
                public int AuthorMID { get; set; }

                /// <summary>
                /// Json 格式字幕文件 URL
                /// </summary>
                [JsonProperty("subtitle_url")]
                public string Subtitle_JsonFileURL { get; set; }

                /// <summary>
                /// 字幕作者信息
                /// </summary>
                [JsonProperty("author")]
                public SubtitleAuthor AuthorInfo { get; set; }

                /// <summary>
                /// 字幕作者
                /// </summary>
                public class SubtitleAuthor
                {
                    /// <summary>
                    /// 作者的UID
                    /// </summary>
                    [JsonProperty("mid")]
                    public int MID { get; set; }

                    /// <summary>
                    /// 作者昵称
                    /// </summary>
                    [JsonProperty("name")]
                    public string Name { get; set; }

                    /// <summary>
                    /// 作者头像链接
                    /// </summary>
                    [JsonProperty("face")]
                    public string AvatarImageUrl { get; set; }

                    /// <summary>
                    /// 性别, 返回 男,女,保密
                    /// </summary>
                    [JsonProperty("sex")]
                    [Obsolete]
                    public string Sex { get; set; }

                    /// <summary>
                    /// 字幕上传者签名
                    /// </summary>
                    [JsonProperty("sign")]
                    [Obsolete]
                    public string Sign { get; set; }

                    [JsonProperty("rank")] [Obsolete] public string rank { get; set; }

                    /// <summary>
                    /// 上传者的生日?
                    /// </summary>
                    [JsonProperty("birthday")]
                    [Obsolete]
                    public string birthday { get; set; }

                    [JsonProperty("is_fake_account")]
                    [Obsolete]
                    public string is_fake_account { get; set; }

                    [JsonProperty("is_deleted")]
                    [Obsolete]
                    public string is_deleted { get; set; }
                }
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
                public List<Honors> honor { get; set; }
            }

            /// <summary>
            /// 视频所得荣誉信息
            /// </summary>
            public class Honors
            {
                /// <summary>
                /// 当前稿件aid
                /// </summary>
                [JsonProperty("aid")]
                public int AID { get; set; }

                /// <summary>
                /// 荣誉名称
                /// </summary>
                [JsonProperty("desc")]
                public string Description { get; set; }

                /// <summary>
                /// 荣誉类型码
                /// </summary>
                [JsonProperty("type")]
                public int TypeCode { get; set; }

                /// <summary>
                /// 荣誉类型
                /// </summary>
                public string Type =>
                    TypeCode switch
                    {
                        1 => "入站必刷收录",
                        2 => "第?期每周必看",
                        3 => "全站排行榜最高第?名",
                        4 => "热门",
                        _ => null
                    };
            }

            #endregion
        }
    }
}