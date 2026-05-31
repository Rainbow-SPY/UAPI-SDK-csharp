using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    public partial class Misc
    {
        /// <summary>
        /// 查询农历时间
        /// </summary>
        /// <param name="ts">Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。</param>
        /// <param name="timezone">时区名称。支持 IANA 时区(如 Asia/Shanghai)和别名(Shanghai、Beijing)。默认 Asia/Shanghai。</param>
        /// <param name="Authentication">API Token</param>
        /// <returns><see cref="LunarTimeType"/> 对象</returns>
        public static async Task<LunarTimeType> GetLunarTime(string ts = "", string timezone = "Asia/Shanghai",
            string Authentication = "")
        {
            var (result, statusCode) =
                await Interface.GetResult<LunarTimeType>(
                    $"{Interface._UAPI_Request_Url}misc/lunartime?ts={ts}&timezone={timezone}", Authentication);
            var list = Interface.IsGetSuccessful(result, "", statusCode, new General.UAPIUnknowException(),
                "GetLunarTime",
                Core._UAPI_Unknown_Exception);
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败,请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}