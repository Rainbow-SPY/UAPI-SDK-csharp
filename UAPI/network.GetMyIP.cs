using System.Net.Http;
using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    /// <summary>
    /// 网络类请求
    /// </summary>
    public partial class network
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public const string _Request_Url = @"https://uapis.cn/api/v1/network/";

        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        /// <param name="commercial">是否指定为商业级的数据源</param>
        /// <returns><see cref="IPType"/> 对象</returns>
        public static async Task<IPType> GetMyIP(bool commercial = false)
        {
            var (result, statusCode) =
                await Interface.GetResult<IPType>($"{_Request_Url}myip?{(commercial ? "source=commercial" : "")}");
            if (!Interface.IsGetSuccessful(result, "", statusCode, new HttpRequestException("请求错误"), "IP"))
                LogLibraries.WriteLog.Error("请求错误, 请重试!");
            return result;
        }
    }
}