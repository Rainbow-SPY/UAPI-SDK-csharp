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
    /// Clipzy 剪贴板 — 获取加密数据（最高安全等级）
    /// </summary>
    public partial class Interface
    {
        /// <summary>
        /// 获取 Clipzy 剪贴板中的加密数据<br/>
        /// 提供第一步获得的 ID，返回存储在服务器上的加密数据。需要在客户端中自行解密。<br/>
        /// GET /api/v1/api/get
        /// </summary>
        /// <param name="id">片段的唯一 ID</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.ClipzyGetResponse"/> 对象，包含加密后的 compressedData</returns>
        public static async Task<ClipzyGetResponse> GetClipzyData(
            string id,
            string Authentication = "")
        {
            var (result, statuscode) = await GetResult<ClipzyGetResponse>(
                $"{_UAPI_Request_Url}api/get?id={id}",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "id", statuscode,
                new General.UAPIUnknowException(), "Clipzy.GetClipzyData");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    /// <summary/>
    public partial class Type
    {
        /// <summary>
        /// Clipzy 获取加密数据响应
        /// </summary>
        public class ClipzyGetResponse : TypeInterface
        {
            /// <summary>
            /// 加密并使用 LZString 压缩后的 Base64 数据
            /// </summary>
            [JsonProperty("compressedData")]
            public string CompressedData { get; set; }
        }
    }
}
