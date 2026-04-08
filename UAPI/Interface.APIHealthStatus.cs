using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static Rox.Runtimes.LocalizedString;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 查询UAPI平台系统状态
        /// </summary>
        /// <returns></returns>
        public static async Task<HealthType> APIHealthStatus()
        {
            var b1 = "";

            #region PingTest

            var res = await Network_I.PingAsync("uapis.cn");
            var tempFile = Path.GetTempFileName();
            if (res.IsSuccess)
                try
                {
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Downloader, "尝试下载 uapis.cn:443 界面资源...");
                    using (var webClient = new WebClient())
                        await webClient.DownloadFileTaskAsync(new Uri("https://uapis.cn:443"), tempFile);
                }
                catch (WebException)
                {
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Downloader, "无法连接到 uapis.cn, 切换到备用站点使用");
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
                            LogLibraries.WriteLog.Warning(LogLibraries.LogKind.File,
                                $"清理临时文件失败: {_Exception_With_xKind("File.Delete", ex)}");
                        }
                }
            else
            {
                LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Downloader, "uapis.cn Ping 失败, 切换到备用站点使用");
                b1 = "b1.";
            }

            #endregion

            var (result, statusCode) = await GetResult<HealthType>($"https://{b1}uapis.cn/api/status/health");
            var list = IsGetSuccessful(result, "", statusCode, new General.UAPIServerDown(),
                "Health");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求错误,请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result;
        }
    }
}