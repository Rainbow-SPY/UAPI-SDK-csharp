using System;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// HTTP Response
        /// </summary>
        public class Response
        {
            /// <summary>
            /// HTTP Headers
            /// </summary>
            public class Headers
            {
                private int _stopOnEmpty;
                private string? _debitStatus;
                private string? _xCacheStatus;

                /// <summary />
                [JsonProperty("age")]
                public string Age { get; set; } = string.Empty;

                /// <summary>
                /// 缓存机制信息
                /// </summary>
                [JsonProperty("cache-control")]
                public string CacheControl { get; set; } = string.Empty;

                /// <summary />
                [JsonProperty("content-length")]
                public long ContentLength { get; set; }

                /// <summary>
                /// 请求中响应头的文档类型
                /// </summary>
                [JsonProperty("content-type")]
                public string ContentType { get; set; } = string.Empty;

                [JsonProperty("date")] public string Date { get; set; } = string.Empty;

                /// <summary>
                /// 是否命中腾讯云 EdgeOne 边缘加速平台CDN的资源缓存
                /// <br/>
                /// <remarks>此属性不属于 UAPI 平台缓存机制</remarks>
                /// </summary>
                [JsonProperty("eo-cache-status")]
                public string EdgeOneResourceCacheStatus { get; set; } = string.Empty;

                /// <summary>
                /// 在腾讯云 EdgeOne 边缘加速平台CDN的请求唯一标识符 (UUID)
                /// </summary>
                [JsonProperty("eo-log-uuid")]
                public string EdgeOneLogUUID { get; set; } = string.Empty;

                /// <summary>
                /// 在请求出错时可用, 用于记录网络请求日志
                /// </summary>
                [JsonProperty("nel")]
                public string NEL { get; set; }

                /// <summary>
                /// 在请求错误时有效, 用于记录浏览器信息
                /// </summary>
                [JsonProperty("report-to")]
                public string ReportTo { get; set; }

                /// <summary>
                /// 请求指向的服务器
                /// </summary>
                [JsonProperty("server")]
                public string Server { get; set; }

                [JsonProperty("strict-transport-security")]
                public string StrictTransportSecurity { get; set; }

                /// <summary>
                /// 缓存状态原始值，例如 HIT / MISS / BYPASS / STALE
                /// </summary>
                [JsonProperty("x-cache-status")]
                public string XCacheStatus
                {
                    get => _xCacheStatus ?? string.Empty;
                    set => _xCacheStatus = value;
                }

                /// <summary>
                /// 是否命中缓存
                /// </summary>
                [JsonIgnore]
                public bool IsHITCache
                {
                    get => string.Equals(_xCacheStatus, "HIT", StringComparison.OrdinalIgnoreCase);
                    set => _xCacheStatus = value ? "HIT" : "MISS";
                }

                [JsonProperty("x-powered-by")] public string XPoweredBy { get; set; }


                /// <summary>
                /// 本次应扣积分
                /// </summary>
                [JsonProperty("uapi-credits-requested")]
                public int RequestedCredits { get; set; }

                /// <summary>
                /// 本次实际扣除的积分
                /// </summary>
                [JsonProperty("uapi-credits-charged")]
                public int CreditsCharged { get; set; }

                /// <summary>
                /// Billing Key 剩余积分
                /// </summary>
                [JsonProperty("x-ratelimit-remaining")]
                public int CreditsRemaining { get; set; }

                /// <summary>
                /// 本次请求的扣费结果状态
                /// </summary>
                [JsonProperty("uapi-debit-status")]
                // ReSharper disable once ConvertToAutoPropertyWhenPossible
                private string? DebitJson
                {
                    get => _debitStatus;
                    set => _debitStatus = value;
                }

                /// <summary>
                /// 本次请求的扣费结果状态
                /// </summary>
                [JsonIgnore]
                public Debit? DebitStatus
                {
                    get
                    {
                        return _debitStatus switch
                        {
                            "applied" => Debit.Applied,
                            "quota_exhausted" => Debit.QuotaExhausted,
                            "skipped_non_2xx" => Debit.SkippedWhenFailed,
                            "free_endpoint" => Debit.FreeEndpoint,
                            "exempt" => Debit.Exempt,
                            "failed" => Debit.Failed,
                            _ => Debit.Unknown
                        };
                    }
                    set
                    {
                        _debitStatus = value switch
                        {
                            Debit.Applied => "applied",
                            Debit.Exempt => "exempt",
                            Debit.FreeEndpoint => "exhausted",
                            Debit.SkippedWhenFailed => "skipped_non_2xx",
                            Debit.QuotaExhausted => "quota_exhausted",
                            Debit.Failed => "failed",
                            Debit.Unknown => "unknow",
                            _ => value?.ToString()
                        };
                    }
                }

                /// <summary>
                /// 当前有效的资源包数量
                /// </summary>
                [JsonProperty("uapi-quota-active-buckets")]
                public int ActivatedResourcePackagesCount { get; set; }

                /// <summary>
                /// 请求唯一 ID，用来排查日志和问题
                /// </summary>
                [JsonProperty("x-request-id")]
                public string? RequestID { get; set; }

                /// <summary>
                /// 被限流，或者访客月额度耗尽时返回	客户端至少要等待多久再重试
                /// </summary>
                [JsonProperty("retry-after")]
                public string? RetryAfter { get; set; }

                /// <summary>
                /// 命中 Billing、访客额度、QPS 限流相关逻辑时返回	当前生效的额度上限或速率上限
                /// </summary>
                [JsonProperty("ratelimit-policy")]
                public string? RateLimitPolicyRaw { get; set; }

                /// <summary>
                /// 命中 Billing、访客额度、QPS 限流相关逻辑时返回	当前剩余额度、剩余余额、剩余请求数
                /// </summary>
                [JsonProperty("ratelimit")]
                public string? RateLimitRaw { get; set; }

                /// <summary>
                /// 命中特殊计价时返回	当前扣费为何不是原价
                /// </summary>
                [JsonProperty("uapi-credits-pricing")]
                public string? CreditsPricing { get; set; }

                /// <summary>
                /// Billing Key 当前生效的请求速率规则
                /// </summary>
                [JsonIgnore]
                public decimal? BillingKeyRequestLimit => ParseRate("billing-key-rate");

                /// <summary>
                /// Billing Key 下单 IP 的请求速率规则
                /// </summary>
                [JsonIgnore]
                public decimal BillingKeyRequestIPLimit => ParseRate("billing-ip-rate");

                /// <summary>
                /// 当前可用资源包额度总上限
                /// </summary>
                [JsonIgnore]
                public decimal BillingQuotaLimit => ParsePolicy("billing-quota");

                /// <summary>
                /// 当前可用余额上限，单位是分
                /// </summary>
                [JsonIgnore]
                public decimal ActivatedResourcePackagesRemainingTotal => ParsePolicy("billing-balance");

                /// <summary>
                /// 访客模式当前月度免费额度上限
                /// </summary>
                [JsonIgnore]
                public decimal VisitorRate => ParsePolicy("visitor-rate");


                /// <summary>
                /// 判断是否为访客请求
                /// 规则：VisitorQuotaLimit 和 VisitorQuotaRemaining 任意一个不为0 → 是访客
                /// <remarks>两个都为0 → API请求（不是访客）</remarks>
                /// <returns>是否为访客请求</returns>
                /// </summary>
                [JsonIgnore]
                public bool IsVisitor => !(VisitorRate == 0 && VisitorQuotaRemaining == 0);

                /// <summary>
                /// 访客模式当前月度剩余免费额度
                /// </summary>
                [JsonIgnore]
                public decimal VisitorQuotaRemaining => ParseRate("visitor-quota");

                /// <summary>
                /// 是否命中半价
                /// </summary>
                [JsonIgnore]
                public bool IsCacheHalfPrice => CreditsPricing == "cache-hit-half-price";

                private decimal ParsePolicy(string name) => Parse(RateLimitPolicyRaw, name, "q");

                private decimal ParseRate(string name) => Parse(RateLimitRaw, name, "r");

                private static decimal Parse(string? header, string name, string key)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(header))
                            return 0;
#pragma warning disable CS8602 // 解引用可能出现空引用。
                        foreach (var item in header.Split(','))
#pragma warning restore CS8602 // 解引用可能出现空引用。
                        {
                            var part = item.Trim();
                            if (!part.StartsWith($"\"{name}\"")) continue;
                            foreach (var k in part.Split(';'))
                            {
                                var t = k.Trim().Split('=');
                                if (t.Length == 2 && t[0] == key && decimal.TryParse(t[1].Replace("\"", ""), out var v))
                                    return v;
                            }
                        }
                    }
                    catch
                    {
                        // ignored
                    }

                    return 0;
                }


                /// <summary>
                /// 资源包用完后是否停止服务
                /// </summary>
                [JsonProperty("uapi-stop-on-empty")]
                [JsonConverter(typeof(Interface.BooleanConverter))]
                public bool StopServiceWhenRemainingEmpty
                {
                    get => _stopOnEmpty == 1;
                    set => _stopOnEmpty = value ? 1 : 0;
                }

                /// <summary>
                /// 获取请求响应头信息
                /// </summary>
                /// <param name="_Type">请求的响应对象</param>
                /// <typeparam name="T">响应对象的通用模型</typeparam>
                /// <returns></returns>
                public static string OutputRequestHeadersInfo<T>(T _Type) where T : TypeInterface
                {
                    const string hr = "=========================================================";

                    var headers = _Type.Headers;
                    var info = $"{hr}\n\t" +
                               $"本次请求的ID: {headers.RequestID}\n" +
                               $"应扣积分: {headers.RequestedCredits}, 实际扣除 {headers.CreditsCharged}, 因 {GetHeadersInfo(headers.DebitStatus)}\n" +
                               (headers.IsHITCache ? "命中缓存" : "") +
                               $"是否为访客请求: {headers.IsVisitor} {(headers.IsVisitor ? $"访客模式当前月免费额度上限: {headers.VisitorRate}, 剩余 {headers.VisitorQuotaRemaining}" : $"剩余积分: {headers.CreditsRemaining}")}\n" +
                               $"当前有效的资源包数量: {headers.ActivatedResourcePackagesCount}, 额度总上限: {headers.BillingQuotaLimit}\n" +
                               $"当前生效的请求速率规则: {headers.BillingKeyRequestLimit}, 下单IP速率规则: {headers.BillingKeyRequestIPLimit}\n" +
                               "";
                    return info;
                }

                /// <summary>
                /// 获取请求响应头的扣费机制信息
                /// </summary>
                /// <param name="h">请求的响应对象</param>
                /// <returns>详细的扣费信息</returns>
                public static string GetHeadersInfo(Debit? h) =>
                    h switch
                    {
                        Debit.Applied => "命中了缓存",
                        Debit.Exempt => "命中了豁免规则",
                        Debit.Failed => "扣费失败, 因余额不足或配额不足",
                        Debit.FreeEndpoint => "免费接口",
                        Debit.QuotaExhausted => "访客配额耗尽",
                        Debit.SkippedWhenFailed => "请求返回了非正常的 HttpStatusCode, 跳过扣费",
                        _ => "未知原因"
                    };

                /// <summary>
                /// 扣费状态
                /// </summary>
                public enum Debit
                {
                    /// <summary>
                    /// 正常扣费
                    /// </summary>
                    Applied,

                    /// <summary>
                    /// 命中了豁免规则
                    /// </summary>
                    Exempt,

                    /// <summary>
                    /// 访客配额耗尽
                    /// </summary>
                    QuotaExhausted,

                    /// <summary>
                    /// 请求返回非 2xx 状态码，跳过扣费
                    /// </summary>
                    SkippedWhenFailed,

                    /// <summary>
                    /// 免费接口
                    /// </summary>
                    FreeEndpoint,

                    /// <summary>
                    ///  扣费失败（配额不足、余额不足等）
                    /// </summary>
                    Failed,

                    /// <summary>
                    /// 未知
                    /// </summary>
                    Unknown
                }
            }
        }
    }
}