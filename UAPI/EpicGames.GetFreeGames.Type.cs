using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// Epic Games API
        /// </summary>
        public class EpicType : TypeInterface
        {
            /// <summary>
            /// 免费游戏列表(数组)
            /// </summary>
            public List<GameData> DataList { get; set; }

            /// <summary>
            /// 免费游戏列表数组
            /// </summary>
            public class GameData
            {
                /// <summary>
                /// 游戏的唯一标识ID
                /// </summary>
                [JsonProperty("id")]
                public string ID { get; set; }

                /// <summary>
                /// 游戏的完整标题名称
                /// </summary>
                [JsonProperty("title")]
                public string Title { get; set; }

                /// <summary>
                /// 游戏封面图片的URL地址
                /// </summary>
                [JsonProperty("cover")]
                public string CoverImageUrl { get; set; }

                /// <summary>
                /// 游戏的原价，单位为人民币元
                /// </summary>
                [JsonProperty("original_price")]
                public int OriginalPrice { get; set; }

                /// <summary>
                /// 格式化后的原价描述字符串
                /// </summary>
                [JsonProperty("original_price_desc")]
                public string OriginalPriceDesc { get; set; }

                /// <summary>
                /// 游戏的简介描述
                /// </summary>
                [JsonProperty("description")]
                public string Description { get; set; }

                /// <summary>
                /// 发行商
                /// </summary>
                [JsonProperty("seller")]
                public string Seller { get; set; }

                /// <summary>
                /// 当前是否处于免费状态
                /// </summary>
                [JsonProperty("is_free_now")]
                public bool IsFreeNow { get; set; }

                /// <summary>
                /// 免费开始时间的可读字符串格式
                /// </summary>
                [JsonProperty("free_start")]
                public string FreeStartTime { get; set; }

                /// <summary>
                /// 免费开始时间的13位毫秒时间戳
                /// </summary>
                [JsonProperty("free_start_at")]
                public long FreeStartTimeUnix { get; set; }

                /// <summary>
                /// 免费结束时间的可读字符串格式
                /// </summary>
                [JsonProperty("free_end")]
                public string EndFreeTime { get; set; }

                /// <summary>
                /// 免费结束时间的13位毫秒时间戳
                /// </summary>
                [JsonProperty("free_end_at")]
                public long EndFreeTimeUnix { get; set; }

                /// <summary>
                /// 游戏在Epic Games商店的详情页链接
                /// </summary>
                [JsonProperty("link")]           public string Link { get; set; }
            }
        }
    }
}