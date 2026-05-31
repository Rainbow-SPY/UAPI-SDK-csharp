using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary/>
    public partial class Search
    {
        /// <summary>
        /// 获取搜索引擎配置 (GET)
        /// </summary>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="SearchConfigType"/> 对象</returns>
        public static async Task<SearchConfigType> GetConfig(string Authentication = "")
        {
            var (result, statuscode) = await GetResult<SearchConfigType>(
                $"{_UAPI_Request_Url}search/engines",
                SendRequestType.GET, "", "application/json", Authentication);
            var list = IsGetSuccessful(result, "", statuscode,
                new General.UAPIUnknowException(), "Search.GetConfig");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 搜索引擎配置类型
        /// </summary>
        public class SearchConfigType : TypeInterface
        {
            /// <summary>
            /// 搜索引擎的基本信息
            /// </summary>
            [JsonProperty("engine")]
            public SearchEngineInfo Engine { get; set; }

            /// <summary>
            /// 搜索结果数量限制
            /// </summary>
            [JsonProperty("limits")]
            public SearchLimits Limits { get; set; }

            /// <summary>
            /// 支持的所有参数说明列表
            /// </summary>
            [JsonProperty("supported_parameters")]
            public List<string> SupportedParameters { get; set; }
        }

        /// <summary>
        /// 搜索引擎基本信息
        /// </summary>
        public class SearchEngineInfo
        {
            /// <summary>
            /// 引擎标识名称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// 引擎显示名称
            /// </summary>
            [JsonProperty("display_name")]
            public string DisplayName { get; set; }

            /// <summary>
            /// 引擎描述
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// 引擎是否可用
            /// </summary>
            [JsonProperty("available")]
            public bool Available { get; set; }

            /// <summary>
            /// 配置版本标识
            /// </summary>
            [JsonProperty("version")]
            public string Version { get; set; }

            /// <summary>
            /// 支持的特性列表
            /// </summary>
            [JsonProperty("features")]
            public List<string> Features { get; set; }
        }

        /// <summary>
        /// 搜索结果数量限制
        /// </summary>
        public class SearchLimits
        {
            /// <summary>
            /// 默认返回结果数
            /// </summary>
            [JsonProperty("default")]
            public int Default { get; set; }

            /// <summary>
            /// 最大返回结果数
            /// </summary>
            [JsonProperty("max")]
            public int Max { get; set; }
        }
    }
}
