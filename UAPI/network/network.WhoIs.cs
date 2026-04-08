using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    public partial class Network
    {
        /// <summary>
        /// 
        /// </summary>
        public class GetWhoIsInfo
        {
            /// <summary>
            /// 获取指定要查询的主机的WhoIs注册信息
            /// </summary>
            /// <param name="domain">指定要查询的主机</param>
            /// <param name="Authentication">API Token Key</param>
            /// <returns><see cref="WhoIsType"/> 对象</returns>
            /// <exception cref="General.UAPIUnknowException"></exception>
            public static async Task<string> AsText(string domain,
                string Authentication = "")
            {
                var b1 = "";

                #region PingTest

                var res = await Network_I.PingAsync("uapis.cn");
                var tempFile = Path.GetTempFileName();
                if (res.IsSuccess)
                    try
                    {
                        WriteLog.Info(LogKind.Downloader, "尝试下载 uapis.cn:443 界面资源...");
                        using (var webClient = new WebClient())
                            await webClient.DownloadFileTaskAsync(new Uri("https://uapis.cn:443"), tempFile);
                    }
                    catch (WebException)
                    {
                        WriteLog.Warning(LogKind.Downloader, "无法连接到 uapis.cn, 切换到备用站点使用");
                        b1 = "b1.";
                    }
                    finally
                    {
                        // 清理临时文件
                        if (File.Exists(tempFile))
                            try
                            {
                                File.Delete(tempFile);
                            }
                            catch (IOException ex)
                            {
                                WriteLog.Warning(LogKind.File,
                                    $"清理临时文件失败: {_Exception_With_xKind("File.Delete", ex)}");
                            }
                    }
                else
                {
                    WriteLog.Warning(LogKind.Downloader, "uapis.cn Ping 失败, 切换到备用站点使用");
                    b1 = "b1.";
                }

                #endregion

                var httpClient = Interface._httpClient.Value;
                WriteLog.Info(LogKind.Http, "新建 HttpClient 实例");
                if (!string.IsNullOrEmpty(Authentication))
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Authentication);
                    WriteLog.Info(LogKind.Http,
                        $"添加请求头: {Authentication.Substring(0, 6)}");
                }

                var requestUri = $"https://{b1}uapis.cn/api/v1/network/whois?domain={domain}&format=text";
                var response =
                    await httpClient.GetAsync(requestUri);
                WriteLog.Info(LogKind.Http, $"{_SEND_REQUEST}: GET {requestUri}");
                using (response)
                {
                    var _statuscode = (int)response.StatusCode;
                    WriteLog.Info(LogKind.Http, $"获取 Http 响应代码: {_statuscode}");
                    var responseData = await response.Content.ReadAsStringAsync();
                    WriteLog.Info(LogKind.Http, "异步读取响应内容");
                    if (!string.IsNullOrEmpty(responseData))
                        return responseData;
                    WriteLog.Error(LogKind.Http,
                        _void_value_null("GetResult<T>.HttpClient", "Content"));
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取指定要查询的主机的WhoIs注册信息
        /// </summary>
        /// <param name="domain">指定要查询的主机</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns><see cref="WhoIsType"/> 对象</returns>
        /// <exception cref="General.UAPIUnknowException"></exception>
        public static async Task<WhoIsType> AsJson(string domain, string Authentication = "")
        {
            var (result, statusCode) = await Interface.GetResult<WhoIsType>(
                $"{Interface._UAPI_Request_Url}network/whois?domain={domain}&format=json");
            var list = Interface.IsGetSuccessful(result, "domain", statusCode, new General.UAPIUnknowException(),
                "GetWhoIsInfo");
            if (!list.IsRequestSuccessfully)
                WriteLog.Error($"请求错误, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }

        /// <summary>
        /// 返回格式
        /// </summary>
        public enum Format
        {
            /// <summary>
            /// 返回文本格式的WhoIs信息
            /// </summary>
            Text,

            /// <summary>
            /// 返回Json格式的WhoIs信息
            /// </summary>
            Json
        }
    }
}