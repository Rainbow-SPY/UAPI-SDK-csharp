using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 图像敏感度检查
        /// </summary>
        /// <param name="image">图像的二进制文件</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="NSFWType"/>对象</returns>
        public static async Task<NSFWType> CheckImageNSFW(byte[] image, string Authentication = "") =>
            await CheckImageNSFW(image, null, Authentication);

        /// <summary>
        /// 图像敏感度检查
        /// </summary>
        /// <param name="url">图像的URL地址</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="NSFWType"/>对象</returns>
        public static async Task<NSFWType> CheckImageNSFW(string url, string Authentication = "") =>
            await CheckImageNSFW(null, url, Authentication);


        private static async Task<NSFWType> CheckImageNSFW(byte[] image, string _url, string Authentication = "")
        {
            object postContent;
            string contentType;

            if (image != null)
            {
                contentType = "image/jpeg";
                switch (image[0])
                {
                    // 魔数判断（最准）
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
                form.Add(fileContent, "file", "image.png");
                postContent = form;
            }
            else if (!string.IsNullOrEmpty(_url))
            {
                postContent = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["url"] = _url
                });

                contentType = "application/x-www-form-urlencoded";
            }
            else
                throw new ArgumentException("image and url are null");

            var (result, statuscode) = await Interface.GetResult<NSFWType>($"{Interface._UAPI_Request_Url}image/nsfw",
                Interface.SendRequestType.POST, postContent, contentType, Authentication);
            var list = Interface.IsGetSuccessful(result, "byte[] image or string url", statuscode,
                new General.UAPIUnknowException(),
                "Image.CheckImageNSFW");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}