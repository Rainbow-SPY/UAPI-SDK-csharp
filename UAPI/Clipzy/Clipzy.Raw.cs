using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// Clipzy 剪贴板 — 获取原始文本（方便自动化）
    /// </summary>
    public partial class Interface
    {
        /// <summary>
        /// 获取 Clipzy 剪贴板中的原始解密文本<br/>
        /// 提供 ID 和 Base64 编码的 AES 密钥，服务器直接解密并返回纯文本内容。<br/>
        /// GET /api/v1/api/raw/{id}
        /// </summary>
        /// <param name="id">片段的唯一 ID</param>
        /// <param name="key">用于解密的 Base64 编码的 AES 密钥</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>解密后的纯文本内容</returns>
        public static async Task<string> GetClipzyRaw(
            string id,
            string key,
            string Authentication = "")
        {
            var (result, statuscode) = await GetStringResult(
                $"{_UAPI_Request_Url}api/raw/{id}?key={key}",
                SendRequestType.GET, "", "text/plain", Authentication);
            var list = IsGetStringSuccessful(result, "id", statuscode,
                new General.UAPIUnknowException(), "Clipzy.GetClipzyRaw");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }
}
