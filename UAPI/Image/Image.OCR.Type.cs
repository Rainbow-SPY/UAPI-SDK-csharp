using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 通用 OCR 文字识别结果
        /// </summary>
        public class OCRType : TypeInterface
        {
            /// <summary>
            /// 识别到的完整文本（含换行）
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// 识别的纯文本
            /// </summary>
            [JsonProperty("plain_text")]
            public string PlainText { get; set; }

            /// <summary>
            /// 识别到的所有文字结果列表
            /// </summary>
            [JsonProperty("words_result")]
            public List<WordResult> WordsResult { get; set; }

            /// <summary>
            /// 识别到的文字数量
            /// </summary>
            [JsonProperty("words_result_num")]
            public int WordsResultNum { get; set; }

            /// <summary>
            /// 是否返回了坐标信息
            /// </summary>
            [JsonProperty("need_location")]
            public bool NeedLocation { get; set; }
        }

        /// <summary>
        /// 单个文字识别结果
        /// </summary>
        public class WordResult
        {
            /// <summary>
            /// 识别到的文字
            /// </summary>
            [JsonProperty("words")]
            public string Words { get; set; }

            /// <summary>
            /// 置信度 (0-1)
            /// </summary>
            [JsonProperty("score")]
            public double Score { get; set; }

            /// <summary>
            /// 文字位置（矩形区域），当 need_location=false 时可能为 null
            /// </summary>
            [JsonProperty("location")]
            public WordLocation Location { get; set; }

            /// <summary>
            /// 文字四个顶点坐标，当 need_location=false 时可能为 null
            /// </summary>
            [JsonProperty("vertexes_location")]
            public List<VertexLocation> VertexesLocation { get; set; }
        }

        /// <summary>
        /// 矩形区域坐标
        /// </summary>
        public class WordLocation
        {
            /// <summary>
            /// 左上角 X 坐标
            /// </summary>
            [JsonProperty("left")]
            public int Left { get; set; }

            /// <summary>
            /// 左上角 Y 坐标
            /// </summary>
            [JsonProperty("top")]
            public int Top { get; set; }

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
        }

        /// <summary>
        /// 顶点坐标
        /// </summary>
        public class VertexLocation
        {
            /// <summary>
            /// X 坐标
            /// </summary>
            [JsonProperty("x")]
            public int X { get; set; }

            /// <summary>
            /// Y 坐标
            /// </summary>
            [JsonProperty("y")]
            public int Y { get; set; }
        }
    }
}