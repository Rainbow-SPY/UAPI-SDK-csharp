using System.Collections.Generic;

namespace UAPI
{
    public partial class hotboard
    {
        /// <summary>
        /// 网易云音乐获取到的Json对象列表
        /// </summary>
        public class NeteaseType :Interface.Hotboard.HotboardInterface
        {
            /// <summary>
            /// 主要的歌曲热榜列表信息
            /// </summary>
            public new List<MainLists> list { get; set; }
            
        }
        /// <summary>
        /// 主要的歌曲热榜列表信息
        /// </summary>
        public class MainLists : Interface.Hotboard.MainLists
        {
            /// <summary>
            /// 歌曲专辑封面
            /// </summary>
            public string cover { get; set; }
            /// <summary>
            /// 歌曲额外元数据
            /// </summary>
            public Extra extra { get; set; }
        }
        /// <summary>
        /// 歌曲额外信息
        /// </summary>
        public class Extra
        {
            /// <summary>
            /// 专辑名称
            /// </summary>
            public string album { get; set; }
            /// <summary>
            /// 歌手名称
            /// </summary>
            public string artist_names { get; set; }
            /// <summary>
            /// 歌曲时长
            /// </summary>
            public string duration_text { get; set; }
            /// <summary>
            /// 歌曲在网易云音乐的唯一ID
            /// </summary>
            public long id { get; set; }
            /// <summary>
            /// 上次的热榜排名
            /// </summary>
            public int last_rank { get; set; }
            /// <summary>
            /// 受欢迎程度 (暂时没有具体用法)
            /// </summary>
            internal int Popularity { get; set; }
        }
    }
}