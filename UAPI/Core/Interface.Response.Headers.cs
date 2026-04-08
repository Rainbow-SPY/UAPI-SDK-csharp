using Newtonsoft.Json;

namespace UAPI
{
    public partial class Interface
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
                private string _debitStatus;
                [JsonProperty("age")] public string Age { get; set; }
                [JsonProperty("cache-control")] public string CacheControl { get; set; }
                [JsonProperty("content-length")] public long? ContentLength { get; set; }
                [JsonProperty("content-type")] public string ContentType { get; set; }
                [JsonProperty("date")] public string Date { get; set; }
                [JsonProperty("eo-cache-status")] public string EOCacheStatus { get; set; }
                [JsonProperty("eo-log-uuid")] public string EOLogUUID { get; set; }
                [JsonProperty("nel")] public string NEL { get; set; }
                [JsonProperty("report-to")] public string ReportTo { get; set; }
                [JsonProperty("server")] public string Server { get; set; }

                [JsonProperty("strict-transport-security")]
                public string StrictTransportSecurity { get; set; }

                [JsonProperty("x-cache-status")] public string XCacheStatus { get; set; }

                /// <summary>
                /// 缓存是否命中
                /// </summary>
                public bool IsCacheHIT => XCacheStatus.ToLower() == "hit";

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
                /// 本次请求的扣费结果状态
                /// </summary>
                [JsonProperty("uapi-debit-status")]
                public Debit? DebitStatus
                {
                    get
                    {
                        switch (_debitStatus)
                        {
                            case "applied":
                                return Debit.Applied;
                            case "quota_exhausted":
                                return Debit.QuotaExhausted;
                            case "skipped_non_2xx":
                                return Debit.SkippedWhenFailed;
                            case "free_endpoint":
                                return Debit.FreeEndpoint;
                            case "exempt":
                                return Debit.Exempt;
                            case "failed":
                                return Debit.Failed;
                            default:
                                return Debit.Unknown;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case Debit.Applied: _debitStatus = "applied"; break;
                            case Debit.Exempt: _debitStatus = "exempt"; break;
                            case Debit.FreeEndpoint: _debitStatus = "exhausted"; break;
                            case Debit.SkippedWhenFailed: _debitStatus = "skipped_non_2xx"; break;
                            case Debit.QuotaExhausted: _debitStatus = "quota_exhausted"; break;
                            case Debit.Failed: _debitStatus = "failed"; break;
                            case Debit.Unknown: _debitStatus = "unknow"; break;
                            default: _debitStatus = value?.ToString(); break;
                        }
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
                public string RequestID { get; set; }

                /// <summary>
                /// 被限流，或者访客月额度耗尽时返回	客户端至少要等待多久再重试
                /// </summary>
                [JsonProperty("retry-after")]
                public string RetryAfter { get; set; }

                /// <summary>
                /// 命中 Billing、访客额度、QPS 限流相关逻辑时返回	当前生效的额度上限或速率上限
                /// </summary>
                [JsonProperty("ratelimit-policy")]
                public string RateLimitPolicyRaw { get; set; }

                /// <summary>
                /// 命中 Billing、访客额度、QPS 限流相关逻辑时返回	当前剩余额度、剩余余额、剩余请求数
                /// </summary>
                [JsonProperty("ratelimit")]
                public string RateLimitRaw { get; set; }

                /// <summary>
                /// 命中特殊计价时返回	当前扣费为何不是原价
                /// </summary>
                [JsonProperty("uapi-credits-pricing")]
                public string CreditsPricing { get; set; }
                
                /// <summary>
                /// Billing Key 当前生效的请求速率规则
                /// </summary>
                [JsonIgnore]
                public decimal BillingKeyRequestLimit => ParseRate("billing-key-rate");

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
                public decimal VisitorQuotaLimit => ParsePolicy("visitor-rate");


                /// <summary>
                /// 判断是否为访客请求
                /// 规则：VisitorQuotaLimit 和 VisitorQuotaRemaining 任意一个不为0 → 是访客
                /// <remarks>两个都为0 → API请求（不是访客）</remarks>
                /// <returns>是否为访客请求</returns>
                /// </summary>
                [JsonIgnore]
                public bool IsVisitor => !(VisitorQuotaLimit == 0 && VisitorQuotaRemaining == 0);

                /// <summary>
                /// 访客模式当前月度免费额度上限
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

                private static decimal Parse(string header, string name, string key)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(header)) return 0;
                        foreach (var item in header.Split(','))
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
                [JsonConverter(typeof(BooleanConverter))]
                public bool StopServiceWhenRemainingEmpty
                {
                    get => _stopOnEmpty == 1;
                    set => _stopOnEmpty = value ? 1 : 0;
                }

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