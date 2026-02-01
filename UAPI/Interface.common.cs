using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;
using static Rox.Text.Json;

namespace UAPI
{
    /// <summary>
    /// UAPI常规方法接口
    /// </summary>
    public class Interface
    {
        /// <summary>
        /// 公共API 获取请求
        /// </summary>
        /// <param name="requestUrl">请求的API Url</param>
        /// <typeparam name="T">泛式类型</typeparam>
        /// <returns>泛式对象 <see cref="T"/></returns>
        internal static async Task<(T Result, int StatusCode)> GetResult<T>(string requestUrl) where T : class
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(requestUrl))
                    {
                        var statusCode = (int)response.StatusCode;
                        var responseData = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(responseData))
                        {
                            LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http,
                                _void_value_null("HttpClient", "Content"));
                            return (null, statusCode);
                        }

                        LogLibraries.WriteLog.Info(LogLibraries.LogKind.Json, "压缩 Json");
                        var compressedJson = CompressJson(responseData);
                        var result = JsonConvert.DeserializeObject<T>(compressedJson);
                        return (result, statusCode);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http, "HttpClient 请求失败, 请检查您的网络连接或反馈工单给工作人员");
                return (null, -1);
            }
            catch (Exception e)
            {
                LogLibraries.WriteLog.Error(_Exception_With_xKind("GetResult<T>()", e));
                return (null, -1);
            }
        }
    }
}