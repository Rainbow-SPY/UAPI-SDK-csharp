using System;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class misc
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
}