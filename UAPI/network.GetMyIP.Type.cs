namespace UAPI
{
    public partial class network
    {
        /// <summary>
        /// 请求本机的IP地址返回的Json属性列表
        /// </summary>
        public class IPType : Interface.TypeInterface
        {
            /// <summary>
            /// 你的公网IP地址
            /// </summary>
            public string ip { get; set; }

            /// <summary>
            /// IP段起始地址（标准查询）
            /// </summary>
            public string beginip { get; set; }

            /// <summary>
            /// IP段结束地址（标准查询）
            /// </summary>
            public string endip { get; set; }

            /// <summary>
            /// 地理位置，格式：国家 省份 城市
            /// </summary>
            public string region { get; set; }

            /// <summary>
            /// 运营商名称
            /// </summary>
            public string isp { get; set; }

            /// <summary>
            /// 自治系统编号
            /// </summary>
            public string asn { get; set; }

            /// <summary>
            /// 归属机构
            /// </summary>
            public string llc { get; set; }

            /// <summary>
            /// 纬度
            /// </summary>
            public int latitude { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            public int longitude { get; set; }

            /// <summary>
            /// 行政区 (仅限商业查询)
            /// </summary>
            public string district { get; set; }
        }
    }
}