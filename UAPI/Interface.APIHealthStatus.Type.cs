using System.Collections.Generic;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// UAPI平台的系统状态
        /// </summary>
        public class HealthType
        {
            /// <summary>
            /// 当前所有服务状态
            /// </summary>
            public List<ServicesProperties> services { get; set; }

            /// <summary>
            /// 所有API状态
            /// </summary>
            public APIs apis { get; set; }

            /// <summary>
            /// 所有在线Worker状态
            /// </summary>
            public Workers workers { get; set; }

            /// <summary>
            /// API历史记录
            /// </summary>
            public List<HistoryItem> history { get; set; }

            /// <summary>
            /// 最后更新时间
            /// </summary>
            public string last_update { get; set; }

            /// <summary>
            /// 服务属性
            /// </summary>
            public class ServicesProperties
            {
                /// <summary>
                /// 服务名称
                /// </summary>
                public string name { get; set; }

                /// <summary>
                /// 服务状态
                /// </summary>
                public string status { get; set; }
            }

            /// <summary>
            /// API属性值
            /// </summary>
            public class APIProperties
            {
                /// <summary>
                /// API在UAPI中的ID
                /// </summary>
                public string id { get; set; }

                /// <summary>
                /// 分类
                /// </summary>
                public string category { get; set; }

                /// <summary>
                /// API名称
                /// </summary>
                public string name { get; set; }

                /// <summary>
                /// API状态
                /// </summary>
                public string status { get; set; }
            }

            /// <summary>
            /// API的详细状态
            /// </summary>
            public class APIs
            {
                /// <summary></summary>
                public List<APIProperties> AI服务 { get; set; }

                /// <summary></summary>
                public List<APIProperties> GitHub { get; set; }

                /// <summary></summary>
                public List<APIProperties> 其他 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 历史事件 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 名言诗词 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 图片处理 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 头像服务 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 实用工具 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 搜索服务 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 文本处理 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 每日服务 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 游戏相关 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 状态查询 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 社交平台 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 答案之书 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 网络工具 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 网页服务 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 网页解析 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 翻译服务 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 转换工具 { get; set; }

                /// <summary></summary>
                public List<APIProperties> 随机服务 { get; set; }
            }

            /// <summary>
            /// 历史记录
            /// </summary>
            public class HistoryItem
            {
                /// <summary>
                /// 历史日期
                /// </summary>
                public string date { get; set; }

                /// <summary>
                /// 百分比
                /// </summary>
                public decimal percentage { get; set; }

                /// <summary>
                /// 字符串格式的百分比
                /// </summary>
                public string percent_str => percentage.ToString("0.00") ?? "转换错误";
            }

            /// <summary>
            /// UAPI的在线Worker模块
            /// </summary>
            public class Workers
            {
                /// <summary>
                /// 在线模块是否已连接到平台
                /// </summary>
                public bool connected { get; set; }

                /// <summary>
                /// 全部节点数
                /// </summary>
                public int total_nodes { get; set; }

                /// <summary>
                /// 在线节点数
                /// </summary>
                public int online_nodes { get; set; }

                /// <summary>
                /// 节点详细信息
                /// </summary>
                public List<NodesItem> nodes { get; set; }
            }

            /// <summary>
            /// 计算节点
            /// </summary>
            public class NodesItem
            {
                /// <summary>
                /// 节点ID
                /// </summary>
                public string id { get; set; }

                /// <summary>
                /// 节点名称
                /// </summary>
                public string name { get; set; }

                /// <summary>
                /// 节点状态
                /// </summary>
                public string status { get; set; }
            }
        }
    }
}