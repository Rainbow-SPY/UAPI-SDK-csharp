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
                private int _creditsExempt;
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
                /// 访客月剩余额度
                /// </summary>
                /// <remarks>Nullable: <see langword="null"/></remarks>
                [JsonProperty("x-ratelimit-remaining")]
                public double? RateLimitRemaining { get; set; }

                /// <summary>
                /// 免费额度重置日期, 只在访客可用
                /// </summary>
                /// <remarks>Nullable: <see langword="null"/></remarks>
                [JsonProperty("x-ratelimit-reset")]
                public string RateLimitResetDateTime { get; set; }

                /// <summary>
                /// 每月额度
                /// </summary>
                [JsonProperty("x-ratelimit-limit")]
                public double RateLimit { get; set; }

                /// <summary>
                /// 额度类型
                /// </summary>
                [JsonProperty("x-ratelimit-type")]
                public string RateType { get; set; }

                /// <summary>
                /// 账户余额
                /// </summary>
                [JsonProperty("x-uapi-balance-remaining")]
                public int BalanceRemaining { get; set; }

                /// <summary>
                /// 以何种方式请求
                /// </summary>
                /// <returns>Web / API / visitor</returns>
                [JsonProperty("x-uapi-billing-source")]
                public string SourceWhere { get; set; }

                /// <summary>
                /// 本次请求是否被豁免扣费
                /// </summary>
                /// <returns> 0 / 1 => <see langword="true"/> / <see langword="false"/></returns>
                [JsonProperty("x-uapi-credits-exempt")]
                public bool CreditsExempt
                {
                    get => _creditsExempt == 0;
                    set => _creditsExempt = value ? 1 : 0;
                }

                /// <summary>
                /// 本次应扣积分
                /// </summary>
                [JsonProperty("x-uapi-credits-requested")]
                public int RequestedCredits { get; set; }

                /// <summary>
                /// 本次实际扣除的积分
                /// </summary>
                [JsonProperty("x-uapi-credits-charged")]
                public int CreditsCharged { get; set; }

                /// <summary>
                /// 本次请求的扣费结果状态
                /// </summary>
                [JsonProperty("x-uapi-debit-status")]
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
                [JsonProperty("x-uapi-quota-active-buckets")]
                public int ActivatedResourcePackagesCount { get; set; }

                /// <summary>
                /// 所有有效资源包剩余额度总和
                /// </summary>
                [JsonProperty("x-uapi-quota-remaining")]
                public int ActivatedResourcePackagesRemainingTotal { get; set; }

                /// <summary>
                /// 资源包用完后是否停止服务
                /// </summary>
                [JsonProperty("x-uapi-stop-on-empty")]
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