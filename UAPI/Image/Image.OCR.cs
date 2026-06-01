using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
}