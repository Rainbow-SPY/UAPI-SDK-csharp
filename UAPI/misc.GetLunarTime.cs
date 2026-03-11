using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
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
                    $"https://uapis.cn/api/v1/misc/lunartime?ts={ts}&timezone={timezone}", Authentication);
            if (!Interface.IsGetSuccessful(result, "", statusCode, new General.UAPIUnknowException(), "GetLunarTime",
                    IException.General._UAPI_Unknown_Exception))
                LogLibraries.WriteLog.Error("请求失败,请重试");
            return result;
        }
    }
}