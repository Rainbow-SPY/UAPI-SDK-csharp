using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Misc
    {
        /// <summary>
        /// 将Unix时间戳转换为人类可读日期时间的旧版接口。
        /// </summary>
        /// <param name="ts">Unix 时间戳</param>
        /// <param name="Authentication">API Token</param>
        /// <returns><see cref="TimestampType"/> 对象</returns>
        [Obsolete("这个接口已被新的 /convert/unixtime 取代。新接口功能更强大，支持双向转换。我们建议你迁移到新接口")]
        public static async Task<TimestampType> CovertTimestamp(string ts, string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<TimestampType>($"{Interface._UAPI_Request_Url}misc/timestamp?ts={ts}",
                    Authentication);
            var list = Interface.IsGetSuccessful(result, "ts", statusCode, new General.UAPIUnknowException(),
                "ConvertTimestamp", Core.INTERNAL_SERVER_ERROR);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败,请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }

    public partial class Type
    {
        /// <summary>
        /// 转换时间戳返回的Json属性列表
        /// </summary>
        public class TimestampType : TypeInterface
        {
            /// <summary>
            /// 输入的值
            /// </summary>
            [JsonProperty("input")]
            public string InputValue { get; set; }

            /// <summary>
            /// 转换的类型
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Unix 时间戳
            /// </summary>
            [JsonProperty("unix_timestamp")]
            public long UnixTimestamp { get; set; }

            /// <summary>
            /// UTC+0:00 (世界协调时间) 格式的字符串
            /// </summary>
            [JsonProperty("datetime_utc")]
            public string DateTime_UTC { get; set; }

            /// <summary>
            /// 以IP地址推断的世界协调时间的本地时间, 在中国一般指北京时间 UTC +8:00.
            /// </summary>
            [JsonProperty("datetime_local")]
            public string DateTime_Local { get; set; }
        }
    }
}