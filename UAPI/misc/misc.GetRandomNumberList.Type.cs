using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 随机数字返回的Json属性列表
        /// </summary>
        public class RandomNumberType : TypeInterface
        {
            /// <summary>
            /// 生成的随机数组
            /// </summary>
            [JsonProperty("numbers")]
            public List<decimal> Numbers { get; set; }
        }
    }
}