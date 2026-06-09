using System;
using System.Linq;
using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI.Example
{
    public class GeneratedExample
    {
        public async Task Test()
        {
            try
            {
                var result = await Minecraft.GetLatestVersion.FromUAPI();
                var requestInfo = Type.Response.Headers.OutputRequestHeadersInfo(result);
                var info = $"最新快照: {result.Snapshot}\n最新正式版: {result.Release}";


// 响应体详情
                LogLibraries.WriteLog.Info(info);
                LogLibraries.WriteLog.Info("\n\n");
// 响应头详情
                LogLibraries.WriteLog.Info(requestInfo);
            }
            catch (minecraft.MojangAPIServiceError e)
            {
                LogLibraries.WriteLog.Error(Core.ReportText("与Mojang 通信错误", "Test", e));
            }
            catch (General.UAPIServerDown e)
            {
                LogLibraries.WriteLog.Error(Core.ReportText("UAPI服务异常", "Test", e));
            }
            catch (General.UAPIServiceUnavailable e)
            {
                LogLibraries.WriteLog.Error(Core.ReportText("指定的服务暂时不可用", "Test", e));
            }
            catch (Exception e)
            {
                LogLibraries.WriteLog.Error(Core.ReportText("未知的异常", "Test", e));
            }
        }
    }
}