using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 获取摸摸头表情包处理后的图像 (GET)
        /// </summary>
        /// <param name="backgroundColor">指定图片生成的背景颜色</param>
        /// <param name="Authentication">API Token Key</param>
        /// <param name="qq">要摸头的QQ</param>
        /// <returns>图像二进制 byte[]</returns>
        public static async Task<byte[]> GetMotouImage(string qq,
            MotouType.BackgroundColor backgroundColor, string Authentication = "")
        {
            var (result, statuscode) = await GetResult<BodyResult<byte[]>>(
                $"{_UAPI_Request_Url}image/motou" +
                $"?qq={qq}&bg_color={backgroundColor.ToString()}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetBytesSuccessful(result, "qq", statuscode,
                new General.UAPIUnknowException(), "Image.GetMotouImage");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }

        /// <summary>
        /// 上传图片生成摸摸头表情包 (POST)，通过图片URL
        /// </summary>
        /// <param name="imageUrl">图片URL地址</param>
        /// <param name="backgroundColor">指定图片生成的背景颜色</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>图像二进制 byte[]</returns>
        public static async Task<byte[]> PostMotouImage(string imageUrl,
            MotouType.BackgroundColor backgroundColor, string Authentication = "")
        {
            var postContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["image_url"] = imageUrl,
                ["bg_color"] = backgroundColor.ToString()
            });

            var (result, statuscode) = await GetResult<BodyResult<byte[]>>(
                $"{_UAPI_Request_Url}image/motou",
                SendRequestType.POST, postContent, "application/x-www-form-urlencoded", Authentication);
            var list = IsGetBytesSuccessful(result, "imageUrl", statuscode,
                new General.UAPIUnknowException(), "Image.PostMotouImage");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }

        /// <summary>
        /// 上传图片生成摸摸头表情包 (POST)，通过图片二进制数据
        /// </summary>
        /// <param name="image">图片的二进制数据</param>
        /// <param name="backgroundColor">指定图片生成的背景颜色</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>图像二进制 byte[]</returns>
        public static async Task<byte[]> PostMotouImage(byte[] image,
            MotouType.BackgroundColor backgroundColor, string Authentication = "")
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("image cannot be null or empty", nameof(image));

            var contentType = "image/gif";
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

            var fileContent = new ByteArrayContent(image);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            var form = new MultipartFormDataContent();
            form.Add(fileContent, "file", $"image.{contentType.Split('/')[1]}");
            form.Add(new StringContent(backgroundColor.ToString()), "bg_color");

            var (result, statuscode) = await GetResult<BodyResult<byte[]>>(
                $"{_UAPI_Request_Url}image/motou",
                SendRequestType.POST, form, contentType, Authentication);
            var list = IsGetBytesSuccessful(result, "image byte[]", statuscode,
                new General.UAPIUnknowException(), "Image.PostMotouImage");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 摸摸头表情包类型
        /// </summary>
        public class MotouType : TypeInterface
        {
            /// <summary>
            /// 摸摸头表情包处理模式
            /// </summary>
            public enum BackgroundColor
            {
                /// <summary>
                /// 透明
                /// </summary>
                transparent,

                /// <summary>
                /// 白
                /// </summary>
                white,

                /// <summary>
                /// 黑
                /// </summary>
                black
            }
        }
    }
}