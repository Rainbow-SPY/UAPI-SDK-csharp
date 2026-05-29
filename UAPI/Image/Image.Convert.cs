using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type.SVGConvertType;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 将 SVG 矢量图转换为位图或矢量图 (POST)
        /// </summary>
        /// <param name="svg">SVG 文件的二进制数据</param>
        /// <param name="format">输出图片格式 (默认 png)</param>
        /// <param name="width">输出宽度 (像素)，不传则保持 SVG 原始宽高比</param>
        /// <param name="height">输出高度 (像素)，不传则保持 SVG 原始宽高比</param>
        /// <param name="quality">输出质量 (1-100，默认 90)，仅 JPEG 格式有效</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>转换后的图片二进制数据</returns>
        public static async Task<byte[]> PostSVGConvertToBitImage(byte[] svg,
            SVGFormat format = SVGFormat.png,
            int? width = null, int? height = null,
            int quality = 90,
            string Authentication = "")
        {
            if (svg == null || svg.Length == 0)
                throw new ArgumentException("svg cannot be null or empty", nameof(svg));

            if (quality < 1 || quality > 100)
                throw new ArgumentOutOfRangeException(nameof(quality), quality,
                    "quality must be between 1 and 100");

            // 构建 URL 查询参数（仅添加非默认值）
            var queryParams = new List<string>();

            if (format != SVGFormat.png)
                queryParams.Add($"format={format.ToString()}");
            if (width.HasValue)
                queryParams.Add($"width={width.Value}");
            if (height.HasValue)
                queryParams.Add($"height={height.Value}");
            if (quality != 90)
                queryParams.Add($"quality={quality}");

            var url = $"{_UAPI_Request_Url}image/svg";
            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            var fileContent = new ByteArrayContent(svg);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/svg+xml");

            var form = new MultipartFormDataContent();
            form.Add(fileContent, "file", "image.svg");

            var (result, statuscode) = await GetBytesResult(
                url, SendRequestType.POST, form, "image/svg+xml", Authentication);
            var list = IsGetBytesSuccessful(result, "svg", statuscode,
                new General.UAPIUnknowException(), "Image.PostImageSVG");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// SVG 转图片类型
        /// </summary>
        public class SVGConvertType : TypeInterface
        {
            /// <summary>
            /// 输出图片格式
            /// </summary>
            public enum SVGFormat
            {
                /// <summary>PNG 格式</summary>
                png,

                /// <summary>JPEG 格式</summary>
                jpeg,

                /// <summary>JPG 格式（同 JPEG）</summary>
                jpg,

                /// <summary>GIF 格式</summary>
                gif,

                /// <summary>TIFF 格式</summary>
                tiff,

                /// <summary>BMP 格式</summary>
                bmp
            }
        }
    }
}
