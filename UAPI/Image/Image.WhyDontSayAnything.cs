using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 生成"你们怎么不说话了"表情包 (POST)
        /// <br/>上方描述某个行为，下方通常以「们」开头表示劝阻，形成戏谑的对比效果。
        /// </summary>
        /// <param name="topText">表情包上方的文字内容，例如 "玩Uapi"</param>
        /// <param name="bottomText">表情包下方的文字内容，例如 "们不要玩Uapi了"</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>表情包图片二进制 (PNG)</returns>
        public static async Task<byte[]> PostWhyDontSayAnything(string topText, string bottomText = "",
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(topText) && string.IsNullOrWhiteSpace(bottomText))
                throw new ArgumentException("至少需要提供 topText 或 bottomText 之一");

            var requestBody = new
            {
                top_text = string.IsNullOrWhiteSpace(topText) ? null : topText,
                bottom_text = string.IsNullOrWhiteSpace(bottomText) ? null : bottomText
            };

            var json = JsonConvert.SerializeObject(requestBody,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var (result, statuscode) = await GetBytesResult(
                $"{_UAPI_Request_Url}image/speechless",
                SendRequestType.POST, json, "application/json", Authentication);
            var list = IsGetBytesSuccessful(result, "topText/bottomText", statuscode,
                new General.UAPIUnknowException(), "Image.PostWhyDontSayAnything");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }
}
