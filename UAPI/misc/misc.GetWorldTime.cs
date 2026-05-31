using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 杂项类请求, 通常没有特定的分类
    /// </summary>
    public partial class Misc
    {
        internal const string _Request_Url = "uapis.cn/api/v1/misc/";

        /// <summary>
        /// 请求获取全球时区的时间
        /// </summary>
        /// <param name="region">指定要查询的地区时间, 格式为 七大洲之一/地区或直接输入地区 例: Asia/Shanghai, America/Newyork, Tokyo</param>
        /// <param name="Authentication">API Token</param>
        /// <exception cref="UAPI.IException.General.UAPIUnknowException">未知的异常</exception>
        /// <exception cref="UAPI.IException.General.UAPIServerDown">请求源服务器错误</exception>
        /// <returns><see cref="WorldTimeType"/> 对象</returns>
        public static async Task<WorldTimeType> GetWorldTime(string region, string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<WorldTimeType>($"{_Request_Url}misc/worldtime?city={region}", Authentication);
            var list = Interface.IsGetSuccessful(result, "region", statusCode, new General.UAPIUnknowException(),
                "GetWorldTime");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 世界时间的Json返回属性列表
        /// </summary>
        public class WorldTimeType : TypeInterface
        {
            /// <summary>
            /// 查询的时区
            /// </summary>
            [JsonProperty("query")]
            public string InputValue { get; set; }

            /// <summary>
            /// 时区
            /// </summary>
            [JsonProperty("timezone")]
            public string Timezone { get; set; }

            /// <summary>
            /// 查询时区的当前时间
            /// </summary>
            [JsonProperty("datetime")]
            public string DateTime { get; set; }

            /// <summary>
            /// 星期
            /// </summary>
            [JsonProperty("weekday")]
            public string Weekday { get; set; }

            /// <summary>
            /// 查询时区的当前 Unix 时间
            /// </summary>
            [JsonProperty("timestamp_unix")]
            public long Timestamp_Unix { get; set; }

            /// <summary>
            /// 时区秒数偏移量, 3600 x $UTC, 以北京时间 UTC+8为例: 3600 x 8 = 28800
            /// </summary>
            [JsonProperty("offset_seconds")]
            public int Timezone_OffsetsSeconds { get; set; }

            /// <summary>
            /// 查询时区的偏移字符串值, 例: (UTC8)
            /// </summary>
            [JsonProperty("offset_string")]
            public string Timezone_Offsets_str { get; set; }
        }
    }
}