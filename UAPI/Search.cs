using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Interface;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 搜索 - 聚合搜索引擎接口
    /// </summary>
    public partial class Search
    {
        /// <summary>
        /// 智能搜索 (POST)
        /// </summary>
        /// <param name="query">搜索查询关键词，支持中英文</param>
        /// <param name="site">限制搜索特定网站，不需要 `site:` 前缀</param>
        /// <param name="filetype">限制文件类型（如 pdf、doc、txt）</param>
        /// <param name="fetchFull">是否获取页面完整正文（会影响响应时间）</param>
        /// <param name="sort">排序方式</param>
        /// <param name="timeRange">时间范围过滤</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="SearchType"/> 对象</returns>
        public static async Task<SearchType> PostSearch(string query,
            string site = "", string filetype = "",
            bool fetchFull = false,
            SearchType.SearchSort sort = SearchType.SearchSort.relevance,
            SearchType.SearchTimeRange? timeRange = null,
            string Authentication = "")
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("query cannot be null or empty", nameof(query));

            var requestBody = new Dictionary<string, object>
            {
                ["query"] = query
            };

            if (!string.IsNullOrEmpty(site))
                requestBody["site"] = site;
            if (!string.IsNullOrEmpty(filetype))
                requestBody["filetype"] = filetype;
            if (fetchFull)
                requestBody["fetch_full"] = true;
            if (sort != SearchType.SearchSort.relevance)
                requestBody["sort"] = sort.ToString();
            if (timeRange.HasValue)
                requestBody["time_range"] = timeRange.Value.ToString();

            var json = JsonConvert.SerializeObject(requestBody);

            var (result, statuscode) = await GetResult<SearchType>(
                $"{_UAPI_Request_Url}search/aggregate",
                SendRequestType.POST, json, "application/json", Authentication);
            var list = IsGetSuccessful(result, "query", statuscode,
                new General.UAPIUnknowException(), "Search.PostSearch");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 搜索结果类型
        /// </summary>
        public class SearchType : TypeInterface
        {
            /// <summary>
            /// 执行的搜索查询
            /// </summary>
            [JsonProperty("query")]
            public string Query { get; set; }

            /// <summary>
            /// 返回的搜索结果总数
            /// </summary>
            [JsonProperty("total_results")]
            public int TotalResults { get; set; }

            /// <summary>
            /// 搜索结果列表
            /// </summary>
            [JsonProperty("results")]
            public List<SearchResultItem> Results { get; set; }

            /// <summary>
            /// 本次请求实际命中的搜索引擎信息
            /// </summary>
            [JsonProperty("sources")]
            public List<string> Sources { get; set; }

            /// <summary>
            /// 本次请求总耗时（毫秒）
            /// </summary>
            [JsonProperty("process_time_ms")]
            public int ProcessTimeMs { get; set; }

            /// <summary>
            /// 本次请求的处理元数据
            /// </summary>
            [JsonProperty("metadata")]
            public SearchMetadata Metadata { get; set; }

            /// <summary>
            /// 搜索排序方式
            /// </summary>
            public enum SearchSort
            {
                /// <summary>按相关性排序</summary>
                relevance,

                /// <summary>按时间排序</summary>
                date
            }

            /// <summary>
            /// 搜索时间范围
            /// </summary>
            public enum SearchTimeRange
            {
                /// <summary>过去一天</summary>
                day,

                /// <summary>过去一周</summary>
                week,

                /// <summary>过去一个月</summary>
                month,

                /// <summary>过去一年</summary>
                year
            }
        }

        /// <summary>
        /// 单个搜索结果
        /// </summary>
        public class SearchResultItem
        {
            /// <summary>
            /// 结果标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 结果链接
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// 结果摘要
            /// </summary>
            [JsonProperty("snippet")]
            public string Snippet { get; set; }

            /// <summary>
            /// 域名
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// 来源搜索引擎标识
            /// </summary>
            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// 结果位置
            /// </summary>
            [JsonProperty("position")]
            public int Position { get; set; }

            /// <summary>
            /// 相关性评分（0-1）
            /// </summary>
            [JsonProperty("score")]
            public double Score { get; set; }

            /// <summary>
            /// 发布时间（ISO 8601）
            /// </summary>
            [JsonProperty("publish_time")]
            public string PublishTime { get; set; }
        }

        /// <summary>
        /// 搜索处理元数据
        /// </summary>
        public class SearchMetadata
        {
            /// <summary>
            /// 服务端实际生效的请求参数回显
            /// </summary>
            [JsonProperty("request_params")]
            public Dictionary<string, object> RequestParams { get; set; }

            /// <summary>
            /// 去重后移除的结果数
            /// </summary>
            [JsonProperty("dedupe_removed")]
            public int DedupeRemoved { get; set; }

            /// <summary>
            /// 是否执行了排序重排
            /// </summary>
            [JsonProperty("rerank_applied")]
            public bool RerankApplied { get; set; }

            /// <summary>
            /// 额外抓取正文的结果数
            /// </summary>
            [JsonProperty("content_fetched")]
            public int ContentFetched { get; set; }
        }
    }
}
