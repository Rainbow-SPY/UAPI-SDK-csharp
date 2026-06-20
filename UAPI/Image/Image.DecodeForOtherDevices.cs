using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type.DecodeForOtherDevicesType;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 解码并缩放图片 (POST)，通过图片二进制数据
        /// </summary>
        /// <param name="image">图片的二进制数据</param>
        /// <param name="format">输出格式 (默认 bmp)</param>
        /// <param name="colorMode">色彩模式 (默认 rgb888)，仅在 format=rgb565/rgb888 时生效</param>
        /// <param name="width">目标宽度 (像素)，不传则保持原图比例</param>
        /// <param name="height">目标高度 (像素)，不传则保持原图比例</param>
        /// <param name="maxWidth">最大宽度 (像素)</param>
        /// <param name="maxHeight">最大高度 (像素)</param>
        /// <param name="fit">缩放模式 (默认 contain)</param>
        /// <param name="background">填充背景色 (默认 black)，仅 fit=contain 时生效</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>解码后的图像二进制数据 (BMP 或原始像素流)</returns>
        public static async Task<byte[]> PostImageDecode(byte[] image,
            DecodeFormat format = DecodeFormat.bmp,
            ColorMode colorMode = ColorMode.rgb888,
            int? width = null, int? height = null,
            int? maxWidth = null, int? maxHeight = null,
            FitMode fit = FitMode.contain,
            string background = "black",
            string Authentication = "") =>
            await PostImageDecode(image, null, format, colorMode,
                width, height, maxWidth, maxHeight, fit, background, Authentication);

        /// <summary>
        /// 解码并缩放图片 (POST)，通过图片链接
        /// </summary>
        /// <param name="imageUrl">图片的公开访问链接</param>
        /// <param name="format">输出格式 (默认 bmp)</param>
        /// <param name="colorMode">色彩模式 (默认 rgb888)</param>
        /// <param name="width">目标宽度 (像素)</param>
        /// <param name="height">目标高度 (像素)</param>
        /// <param name="maxWidth">最大宽度 (像素)</param>
        /// <param name="maxHeight">最大高度 (像素)</param>
        /// <param name="fit">缩放模式 (默认 contain)</param>
        /// <param name="background">填充背景色 (默认 black)</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>解码后的图像二进制数据 (BMP 或原始像素流)</returns>
        public static async Task<byte[]> PostImageDecode(string imageUrl,
            DecodeFormat format = DecodeFormat.bmp,
            ColorMode colorMode = ColorMode.rgb888,
            int? width = null, int? height = null,
            int? maxWidth = null, int? maxHeight = null,
            FitMode fit = FitMode.contain,
            string background = "black",
            string Authentication = "") =>
            await PostImageDecode(null, imageUrl, format, colorMode,
                width, height, maxWidth, maxHeight, fit, background, Authentication);

        private static async Task<byte[]> PostImageDecode(byte[] image, string imageUrl,
            DecodeFormat format,
            ColorMode colorMode,
            int? width, int? height,
            int? maxWidth, int? maxHeight,
            FitMode fit,
            string background,
            string Authentication)
        {
            // 构建 URL 查询参数（仅添加非默认值）
            var queryParams = new List<string>();

            if (format != DecodeFormat.bmp)
                queryParams.Add($"format={format.ToString()}");
            if (colorMode != ColorMode.rgb888)
                queryParams.Add($"color_mode={colorMode.ToString()}");
            if (width.HasValue)
                queryParams.Add($"width={width.Value}");
            if (height.HasValue)
                queryParams.Add($"height={height.Value}");
            if (maxWidth.HasValue)
                queryParams.Add($"max_width={maxWidth.Value}");
            if (maxHeight.HasValue)
                queryParams.Add($"max_height={maxHeight.Value}");
            if (fit != FitMode.contain)
                queryParams.Add($"fit={fit.ToString()}");
            if (!string.IsNullOrEmpty(background) && background != "black")
                queryParams.Add($"background={Uri.EscapeDataString(background)}");

            var url = $"{_UAPI_Request_Url}image/decode";
            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            object postContent;
            string contentType;

            if (image != null)
            {
                // 从魔数推断图片类型
                contentType = "image/png";
                if (image.Length >= 2)
                    contentType = image[0] switch
                    {
                        0xFF when image[1] == 0xD8 => "image/jpeg",
                        0x89 when image[1] == 0x50 => "image/png",
                        0x47 when image[1] == 0x49 => "image/gif",
                        0x52 when image[1] == 0x49 => "image/webp",
                        _ => contentType
                    };

                var fileContent = new ByteArrayContent(image);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var form = new MultipartFormDataContent();
                form.Add(fileContent, "file", $"image.{contentType.Split('/')[1]}");
                postContent = form;
            }
            else if (!string.IsNullOrEmpty(imageUrl))
            {
                var form = new MultipartFormDataContent();
                form.Add(new StringContent(imageUrl), "url");
                postContent = form;
                contentType = "multipart/form-data";
            }
            else
                throw new ArgumentException("image 和 imageUrl 都为空，至少需要提供图片数据或链接");

            var (result, statuscode) = await GetResult<Type.BodyResult<byte[]>>(
                url, SendRequestType.POST, postContent, contentType, Authentication);
            var list = IsGetBytesSuccessful(result, "image", statuscode,
                new General.UAPIUnknowException(), "Image.PostImageDecode");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 图像解码与缩放类型
        /// </summary>
        public class DecodeForOtherDevicesType : TypeInterface
        {
            /// <summary>
            /// 输出格式
            /// </summary>
            public enum DecodeFormat
            {
                /// <summary>BMP 位图</summary>
                bmp,

                /// <summary>RGB565 原始像素流</summary>
                rgb565,

                /// <summary>RGB888 原始像素流</summary>
                rgb888
            }

            /// <summary>
            /// 色彩模式
            /// </summary>
            public enum ColorMode
            {
                /// <summary>16位色彩 (5-6-5)</summary>
                rgb565,

                /// <summary>24位真彩色</summary>
                rgb888
            }

            /// <summary>
            /// 缩放模式
            /// </summary>
            public enum FitMode
            {
                /// <summary>等比缩放，居中显示，空白填充 background</summary>
                contain,

                /// <summary>等比缩放，裁剪超出部分</summary>
                cover,

                /// <summary>拉伸填充，可能导致变形</summary>
                fill
            }
        }
    }
}
