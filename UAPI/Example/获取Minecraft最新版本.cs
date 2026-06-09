using System.Linq;
using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI.Example
{
    public class GeneratedExample
    {
        public async Task Test()
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
    }
}