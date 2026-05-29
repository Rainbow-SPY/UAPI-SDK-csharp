using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    /// <summary/>
    public partial class Interface
    {
        /// <summary>
        /// 获取 API 使用统计
        /// </summary>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="Type.UsageResponse"/> 对象</returns>
        public static async Task<UsageResponse> GetUsage(string Authentication = "")
        {
            var (result, statuscode) = await GetResult<UsageResponse>(
                $"{_UAPI_Request_Url}status/usage",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "", statuscode,
                new General.UAPIUnknowException(), "Interface.GetUsage");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class UsageResponse : TypeInterface
        {
            /// <summary>
            /// 各端点调用次数
            /// </summary>
            [JsonProperty("endpoints")]
            public List<UsageEndpoint> Endpoints { get; set; }

            /// <summary>
            /// 未聚合的调用数据
            /// </summary>
            [JsonProperty("unaggregated")]
            public UsageUnaggregated Unaggregated { get; set; }
        }

        /// <summary>
        /// 单个端点的调用统计
        /// </summary>
        public class UsageEndpoint
        {
            /// <summary>
            /// 端点路径
            /// </summary>
            [JsonProperty("path")]
            public string Path { get; set; }

            /// <summary>
            /// 调用次数
            /// </summary>
            [JsonProperty("count")]
            public long Count { get; set; }
        }

        /// <summary>
        /// 未聚合调用数据
        /// </summary>
        public class UsageUnaggregated
        {
            /// <summary>
            /// 调用次数
            /// </summary>
            [JsonProperty("count")]
            public long Count { get; set; }

            /// <summary>
            /// 最早日志时间
            /// </summary>
            [JsonProperty("oldest_log")]
            public string OldestLog { get; set; }
        }
    }
}
