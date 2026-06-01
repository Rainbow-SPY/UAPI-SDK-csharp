using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// Clipzy 剪贴板
    /// </summary>
    public class Clipzy
    {
        /// <summary>
        /// 获取 Clipzy 剪贴板中的加密数据<br/>
        /// 提供第一步获得的 ID，返回存储在服务器上的加密数据。需要在客户端中自行解密。<br/>
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

        /// <summary>
        /// 获取 Clipzy 剪贴板中的原始解密文本<br/>
        /// 提供 ID 和 Base64 编码的 AES 密钥，服务器直接解密并返回纯文本内容。<br/>
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
            var (result, statuscode) = await GetResult<BodyResult<string>>(
                $"{_UAPI_Request_Url}api/raw/{id}?key={key}",
                SendRequestType.GET, "", "text/plain", Authentication);
            var list = IsGetStringSuccessful(result, "id", statuscode,
                new General.UAPIUnknowException(), "Clipzy.GetClipzyRaw");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }

        /// <summary>
        /// 上传加密数据到 Clipzy 剪贴板<br/>
        /// 客户端需要先在本地准备好加密后的数据，上传成功后得到一个唯一 ID。<br/>
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

        /// <summary>
        /// Clipzy 上传响应
        /// </summary>
        public class ClipzyStoreResponse : TypeInterface
        {
            /// <summary>
            /// 用于构建分享链接的唯一 ID
            /// </summary>
            [JsonProperty("id")]
            public string ID { get; set; }
        }
    }
}
