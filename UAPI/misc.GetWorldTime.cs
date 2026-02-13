using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    /// <summary>
    /// 杂项类请求, 通常没有特定的分类
    /// </summary>
    public partial class misc
    {
        internal const string _Request_Url = @"uapis.cn/api/v1/misc/";
        /// <summary>
        /// 请求获取全球时区的时间
        /// </summary>
        /// <param name="region">指定要查询的地区时间, 格式为 七大洲之一/地区或直接输入地区 例: Asia/Shanghai, America/Newyork, Tokyo</param>
        /// <exception cref="UAPI.IException.General.UAPIUnknowException">未知的异常</exception>
        /// <exception cref="UAPI.IException.General.UAPIServerDown">请求源服务器错误</exception>
        /// <returns><see cref="WorldTimeType"/> 对象</returns>

        public static async Task<WorldTimeType> GetWorldTime(string region)
        {
            var (result, statusCode) =
                await Interface.GetResult<WorldTimeType>($"{_Request_Url}worldtime?city={region}");
            if (!Interface.IsGetSuccessful(result,"region",statusCode,new IException.General.UAPIUnknowException(),"GetWorldTime"))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}