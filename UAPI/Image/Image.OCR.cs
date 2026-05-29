using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 通用 OCR 文字识别 (POST)，通过图片二进制数据
        /// </summary>
        /// <param name="image">图片的二进制数据</param>
        /// <param name="needLocation">是否返回坐标信息（默认 true）</param>
        /// <param name="enableCls">是否启用方向预校正（默认 false，适用于手机拍摄的旋转/倾斜图片）</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.OCRType"/> 对象</returns>
        public static async Task<Type.OCRType> PostImageOCR(byte[] image,
            bool needLocation = true, bool enableCls = false,
            string Authentication = "")
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("image cannot be null or empty", nameof(image));

            // 从魔数推断图片类型
            var contentType = "image/png";
            if (image.Length >= 2)
            {
                switch (image[0])
                {
                    case 0xFF when image[1] == 0xD8:
                        contentType = "image/jpeg";
                        break;
                    case 0x89 when image[1] == 0x50:
                        contentType = "image/png";
                        break;
                    case 0x47 when image[1] == 0x49:
                        contentType = "image/gif";
                        break;
                    case 0x52 when image[1] == 0x49:
                        contentType = "image/webp";
                        break;
                }
            }

            var fileContent = new ByteArrayContent(image);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            var form = new MultipartFormDataContent();
            form.Add(fileContent, "file", $"image.{contentType.Split('/')[1]}");
            form.Add(new StringContent(needLocation ? "true" : "false"), "need_location");

            if (enableCls)
                form.Add(new StringContent("true"), "enable_cls");

            var (result, statuscode) = await Interface.GetResult<Type.OCRType>(
                $"{Interface._UAPI_Request_Url}image/ocr",
                Interface.SendRequestType.POST, form, contentType, Authentication);
            var list = Interface.IsGetSuccessful(result, "image", statuscode,
                new General.UAPIUnknowException(), "Image.PostImageOCR");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 通用 OCR 文字识别 (POST)，通过图片 URL
        /// </summary>
        /// <param name="imageUrl">图片的 URL 地址</param>
        /// <param name="needLocation">是否返回坐标信息（默认 true）</param>
        /// <param name="enableCls">是否启用方向预校正（默认 false，适用于手机拍摄的旋转/倾斜图片）</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.OCRType"/> 对象</returns>
        public static async Task<Type.OCRType> PostImageOCR(string imageUrl,
            bool needLocation = true, bool enableCls = false,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                throw new ArgumentException("imageUrl cannot be null or empty", nameof(imageUrl));

            var postData = new Dictionary<string, string>
            {
                ["url"] = imageUrl,
                ["need_location"] = needLocation ? "true" : "false"
            };

            if (enableCls)
                postData["enable_cls"] = "true";

            var postContent = new FormUrlEncodedContent(postData);

            var (result, statuscode) = await Interface.GetResult<Type.OCRType>(
                $"{Interface._UAPI_Request_Url}image/ocr",
                Interface.SendRequestType.POST, postContent,
                "application/x-www-form-urlencoded", Authentication);
            var list = Interface.IsGetSuccessful(result, "imageUrl", statuscode,
                new General.UAPIUnknowException(), "Image.PostImageOCR");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

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
