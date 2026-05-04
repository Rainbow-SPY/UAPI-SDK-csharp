using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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


        private static async Task<NSFWType> CheckImageNSFW(byte[] image, string url, string Authentication = "")
        {
            var contentType = "image/jpeg";

            if (image == null || image.Length < 8)
                contentType = string.IsNullOrEmpty(url)
                    ? "application/octet-stream"
                    : "application/json";
            else
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

            var postContent = image ??
                              (object)(url ??
                                       throw new ArgumentException("image and url are null"));

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

    public partial class Type
    {
        /// <summary/>
        public class NSFWType : TypeInterface
        {
            /// <summary>
            /// 违规内容置信度，0-1 之间，越高表示越可能违规
            /// </summary>
            [JsonProperty("nsfw_score")]
            public double NSFWScore { get; set; }

            /// <summary>
            /// 正常内容置信度，0-1 之间，与 nsfw_score 互补
            /// </summary>
            [JsonProperty("normal_score")]
            public double NormalScore { get; set; }

            /// <summary>
            /// 是否判定为违规内容
            /// </summary>
            [JsonProperty("is_nsfw")]
            public bool IsNSFWContent { get; set; }

            /// <summary>
            /// 内容标签
            /// </summary>
            [JsonProperty("label")]
            public string Label { get; set; }

            /// <summary>
            /// 处理建议
            /// </summary>
            [JsonProperty("suggestion")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Actions Suggestion { get; set; }

            /// <summary>
            /// 处理建议
            /// </summary>
            public enum Actions
            {
                /// <summary>
                /// 可直接放行
                /// </summary>
                Pass,

                /// <summary>
                /// 存在风险, 需要人工复查
                /// </summary>
                Review,

                /// <summary>
                /// 高风险内容, 建议直接拦截
                /// </summary>
                Block
            }

            /// <summary>
            /// 风险等级
            /// </summary>
            public enum Level
            {
                /// <summary>
                /// 低风险
                /// </summary>
                Low,

                /// <summary>
                /// 中风险
                /// </summary>
                Medium,

                /// <summary>
                /// 高风险
                /// </summary>
                High
            }

            /// <summary>
            /// 风险等级
            /// </summary>
            [JsonProperty("risk_level")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Level RiskLevel { get; set; }

            /// <summary>
            /// 模型对当前判断的整体置信度
            /// </summary>
            [JsonProperty("confidence")]
            public double confidence { get; set; }

            /// <summary>
            /// 模型推理耗时，单位毫秒
            /// </summary>
            [JsonProperty("inference_time_ms")]
            public double SeekTime { get; set; }
        }
    }
}