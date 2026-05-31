namespace UAPI
{
    public partial class Type
    {
        /// <summary/>
        public enum RandomImage
        {
            /// <summary>
            /// 二次元动漫，源自UapiPro服务器
            /// </summary>
            acg,

            /// <summary>
            /// 风景图，外部图床
            /// </summary>
            landscape,

            /// <summary>
            /// 混合动漫
            /// </summary>
            anime,

            /// <summary>
            /// 电脑壁纸，外部图床
            /// </summary>
            mobile_wallpaper,

            /// <summary>
            /// 手机壁纸，外部图床
            /// </summary>
            pc_wallpaper,

            /// <summary>
            /// 动漫图，外部图床
            /// </summary>
            general_anime,

            /// <summary>
            /// AI绘画，外部图床
            /// </summary>
            ai_drawing,

            /// <summary>
            /// 表情包/趣图，UapiPro服务器
            /// </summary>
            bq,

            /// <summary>
            /// 福瑞，UapiPro服务器
            /// </summary>
            furry,

            /// <summary>
            /// 不选择
            /// </summary>
            None
        }

        /// <summary>
        /// 壁纸类型枚举
        /// </summary>
        public enum WallpaperType
        {
            /// <summary>
            /// 电脑壁纸
            /// </summary>
            pc,

            /// <summary>
            /// 手机壁纸
            /// </summary>
            mb,

            /// <summary>
            /// 二次元壁纸
            /// </summary>
            eciyuan,

            /// <summary>
            /// iKun专属壁纸
            /// </summary>
            ikun,

            /// <summary>
            /// 4K壁纸
            /// </summary>
            _4k,

            /// <summary>
            /// 横屏4K壁纸
            /// </summary>
            s4k,

            /// <summary>
            /// 竖屏4K壁纸
            /// </summary>
            z4k,

            /// <summary>
            /// 竖屏8K壁纸
            /// </summary>
            szs8k,

            /// <summary>
            /// 熊猫壁纸
            /// </summary>
            xiongmao,

            /// <summary>
            /// 猫咪壁纸
            /// </summary>
            maomao,

            /// <summary>
            /// 外国人壁纸
            /// </summary>
            waiguoren,

            /// <summary>
            /// 不选择
            /// </summary>
            None
        }
    }
}