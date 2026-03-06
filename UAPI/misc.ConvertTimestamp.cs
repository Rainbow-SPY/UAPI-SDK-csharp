using System;
using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 将Unix时间戳转换为人类可读日期时间的旧版接口。
        /// </summary>
        /// <param name="ts">Unix 时间戳</param>
        /// <returns><see cref="TimestampType"/> 对象</returns>
        [Obsolete("这个接口已被新的 /convert/unixtime 取代。新接口功能更强大，支持双向转换。我们建议你迁移到新接口")]
        public static async Task<TimestampType> CovertTimestamp(string ts)
        {
            var (result, statusCode) =
                await Interface.GetResult<TimestampType>($"https://uapis.cn/api/v1/misc/timestamp?ts={ts}");
            if (!Interface.IsGetSuccessful(result,"ts",statusCode,new IException.General.UAPIUnknowException(),"ConvertTimestamp",IException.General._UAPI_Server_Down))
                LogLibraries.WriteLog.Error("请求失败,请重试");
            return result;
        }
    }
}