using System.Collections.Generic;

namespace UAPI
{
    public partial class minecraft
    {
        /// <summary>
        /// 查询Minecraft玩家历史昵称的属性值列表
        /// </summary>
        public class HistoryType : Interface.TypeInterface
        {
            /// <summary>
            /// 历史昵称的属性值列表
            /// </summary>
            public class History
            {
                /// <summary>
                /// 历史上的昵称
                /// </summary>
                public string name { get; set; }

                /// <summary>
                /// 何时改的昵称
                /// </summary>
                public string changedToAt { get; set; }
            }

            /// <summary>
            /// 【name 查询时返回】匹配用户列表，包含当前用户名或曾用名匹配的所有玩家。
            /// </summary>
            public class ResultsItem
            {
                /// <summary>
                /// 玩家当前的用户名。
                /// </summary>
                public string id { get; set; }

                /// <summary>
                /// 玩家的UUID（带连字符格式）。
                /// </summary>
                public string uuid { get; set; }

                /// <summary>
                /// 历史名称的总数。
                /// </summary>
                public int name_num { get; set; }

                /// <summary>
                /// 历史用户名数组。
                /// </summary>
                public List<History> history { get; set; }
            }

            /// <summary>
            /// 【name 查询时返回】查询的用户名。
            /// </summary>
            public string query { get; set; }

            /// <summary>
            /// 【name 查询时返回】匹配到的用户数量，为 0 时表示未找到。
            /// </summary>
            public int count { get; set; }

            /// <summary>
            /// 【name 查询时返回】匹配用户列表，包含当前用户名或曾用名匹配的所有玩家。
            /// </summary>
            public List<ResultsItem> results { get; set; }

            /// <summary>
            /// 【uuid 查询时返回】玩家当前的用户名。
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// 【uuid 查询时返回】被查询玩家的UUID（带连字符格式）。
            /// </summary>
            public string uuid { get; set; }

            /// <summary>
            /// 【uuid 查询时返回】历史名称的总数（包含当前名称）。
            /// </summary>
            public int name_num { get; set; }

            /// <summary>
            /// 【uuid 查询时返回】包含所有历史用户名的数组，按时间倒序排列。
            /// </summary>
            public List<History> history { get; set; }
        }
    }
}