using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 图片无损压缩 (POST)，通过图片二进制数据
        /// </summary>
        /// <param name="image">图片的二进制数据</param>
        /// <param name="level">
        /// 压缩等级 (1-5)，数字越小压缩率越高
        /// <br/>1: 极限压缩（推荐，体积最小，画质优异）
        /// <br/>2: 高效压缩
        /// <br/>3: 智能均衡（默认）
        /// <br/>4: 画质优先
        /// <br/>5: 专业保真
        /// </param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>压缩后的图像二进制 byte[]</returns>
        /// <exception cref="ArgumentNullException">image 为空时抛出</exception>
        /// <exception cref="ArgumentOutOfRangeException">level 超出 1-5 范围时抛出</exception>
        public static async Task<byte[]> PostImageCompress(byte[] image, int level = 3,
            string Authentication = "")
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("image cannot be null or empty", nameof(image));

            if (level < 1 || level > 5)
                throw new ArgumentOutOfRangeException(nameof(level), level,
                    "level must be between 1 and 5");

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
            form.Add(new StringContent(level.ToString()), "level");

            var (result, statuscode) = await GetResult<Type.BodyResult<byte[]>>(
                $"{_UAPI_Request_Url}image/compress",
                SendRequestType.POST, form, contentType, Authentication);
            var list = IsGetBytesSuccessful(result, "image", statuscode,
                new General.UAPIUnknowException(), "Image.PostImageCompress");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }
}