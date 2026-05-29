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
    /// Clipzy 剪贴板 — 上传加密数据
    /// </summary>
    public partial class Interface
    {
        /// <summary>
        /// 上传加密数据到 Clipzy 剪贴板<br/>
        /// 客户端需要先在本地准备好加密后的数据，上传成功后得到一个唯一 ID。<br/>
        /// POST /api/v1/api/store
        /// </summary>
        /// <param name="compressedData">经过加密和 LZString 压缩后的 Base64 字符串</param>
        /// <param name="ttl">片段的留存时间（秒）。正数表示秒数（最大约 30 天），-1 表示永久存储。默认为 3600。</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.ClipzyStoreResponse"/> 对象，包含生成的唯一 ID</returns>
        public static async Task<ClipzyStoreResponse> PostClipzyStore(
            string compressedData,
            int ttl = 3600,
            string Authentication = "")
        {
            var body = new
            {
                compressedData,
                ttl
            };

            var (result, statuscode) = await GetResult<ClipzyStoreResponse>(
                $"{_UAPI_Request_Url}api/store",
                SendRequestType.POST, body, "application/json", Authentication);
            var list = IsGetSuccessful(result, "compressedData", statuscode,
                new General.UAPIUnknowException(), "Clipzy.PostClipzyStore");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    /// <summary/>
    public partial class Type
    {
        /// <summary>
        /// Clipzy 上传响应
        /// </summary>
        public class ClipzyStoreResponse : TypeInterface
        {
            /// <summary>
            /// 用于构建分享链接的唯一 ID
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}
