using System.Collections.Generic;

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
            /// 视频类型。1代表原创，2代表转载。
            /// </summary>
            public int copyright { get; set; }

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
            /// 用户投稿时间的Unix时间戳（秒）。
            /// </summary>
            public long ctime { get; set; }

            /// <summary>
            /// 视频简介。可能会包含HTML换行符。
            /// </summary>
            public string desc { get; set; }

            public Desc_v2 desc_v2 { get; set; }
            public int state { get; set; }

            /// <summary>
            /// 稿件总时长（所有分P累加），单位为秒。
            /// </summary>
            public long duration { get; set; }

            public Rights rights { get; set; }

            /// <summary>
            /// 视频UP主信息。
            /// </summary>
            public Owner owner { get; set; }

            public Stat stat { get; set; }
            public string dynamic { get; set; }
            public int cid { get; set; }
            public Dimension dimension { get; set; }
            public bool no_cache { get; set; }

            /// <summary>
            /// 视频分P列表。即使是单P视频，该数组也包含一个元素。
            /// </summary>
            public List<Pages> pages { get; set; }

            public Subtitle subtitle { get; set; }
            public string staff { get; set; }
            public object ugc_season { get; set; }
            public bool is_chargeable_season { get; set; }
            public bool is_story { get; set; }
            public Honor_reply honor_reply { get; set; }
        }

        public class Rights
        {
            public int bp { get; set; }
            public int elec { get; set; }
            public int download { get; set; }
            public int movie { get; set; }
            public int pay { get; set; }
            public int hd5 { get; set; }
            public int no_reprint { get; set; }
            public int autoplay { get; set; }
            public int ugc_pay { get; set; }
            public int is_cooperation { get; set; }
            public int ugc_pay_preview { get; set; }
            public int no_background { get; set; }
            public int clean_mode { get; set; }
            public int is_stein_gate { get; set; }
            public int is_360 { get; set; }
            public int no_share { get; set; }
            public int arc_pay { get; set; }
            public int free_watch { get; set; }
        }

        public class Desc_v2
        {
            public string raw_text { get; set; }
            public int type { get; set; }
            public int biz_id { get; set; }
        }

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

        public class Stat
        {
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

            public int now_rank { get; set; }
            public int his_rank { get; set; }

            /// <summary>
            /// 点赞量
            /// </summary>
            public int like { get; set; }

            /// <summary>
            /// 点踩量
            /// </summary>
            public int dislike { get; set; }

            public string evaluation { get; set; }
            public int vt { get; set; }
        }

        public class Dimension
        {
            public int width { get; set; }
            public int height { get; set; }
            public int rotate { get; set; }
        }

        public class Pages
        {
            /// <summary>
            /// // 分P的唯一标识CID，用于获取弹幕等。
            /// </summary>
            public int cid { get; set; }

            /// <summary>
            /// 分P的序号，从1开始。  
            /// </summary>
            public int page { get; set; }

            public string from { get; set; }

            /// <summary>
            /// 分P的标题。对于单P视频，通常是视频主标题。
            /// </summary>
            public string part { get; set; }

            /// <summary>
            /// 该分P的持续时间，单位为秒。
            /// </summary>
            public int duration { get; set; }

            public string vid { get; set; }
            public string weblink { get; set; }
            public Dimension dimension { get; set; }
        }

        public class Subtitle
        {
            public bool allow_submit { get; set; }
            public List<object> list { get; set; }
        }

        public class Honor_reply
        {
            public object honor { get; set; }
        }
    }
}