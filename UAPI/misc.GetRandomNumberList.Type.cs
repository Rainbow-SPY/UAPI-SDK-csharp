using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 随机数字返回的Json属性列表
        /// </summary>
        public class RandomNumberType : Interface.TypeInterface
        {
            /// <summary>
            /// 生成的随机数组
            /// </summary>
            [JsonProperty("numbers")]
            public List<decimal> numbers { get; set; }
        }
    }
}