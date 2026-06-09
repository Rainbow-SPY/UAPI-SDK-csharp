using System.Linq;
using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI.Example
{
    public class GeneratedExample
    {
        public async Task Test()
        {
            var result = await bilibili.GetArchives(mid: "2048173282", keywords: "",
                ps: 20, pn: 1, Authentication: "uapi-sk-********");
            var info = $"视频总数量: {result.Total}" +
                       $"\n\t页数: {result.PageCount}" +
                       $"\n\t每页数量: {result.PageSize}";

            var requestInfo = Type.Response.Headers.OutputRequestHeadersInfo(result);

            for (var index = 0; index < result.VideosList.Count; index++)
            {
                info = info + $"第 {index + 1} 个视频" +
                       $"\n\t视频的标题: {result.VideosList[index].Title}" +
                       $"\n\t视频的AVID: {result.VideosList[index].AID}" +
                       $"\n\t视频的BVID: {result.VideosList[index].BVID}" +
                       $"视频封面: {result.VideosList[index].CoverImageUrl}\n" +
                       $"视频持续时长: {(result.VideosList[index].Duration < 0 ? "00:00:00" : $"{(result.VideosList[index].Duration / 3600 == 0 ? "00" : (result.VideosList[index].Duration / 3600).ToString())}: {(result.VideosList[index].Duration % 3600 / 60 == 0 ? "00" : (result.VideosList[index].Duration % 3600 / 60).ToString())}:{result.VideosList[index].Duration % 60}")}\n" +
                       $"发布时间: {result.VideosList[index].PublishTimeStr}\n" +
                       $"播放量: {result.VideosList[index].PlayCount}" +
                       $"创建时间: {result.VideosList[index].CreateTimeStr}\n" +
                       $"视频状态: {result.VideosList[index].State}\n" +
                       $"是否为充电视频: {result.VideosList[index].IsPayVideo_str}\n" +
                       $"是否为共创视频: {result.VideosList[index].IsInteractive}\n";
            }

// 响应体详情
            LogLibraries.WriteLog.Info(info);
            LogLibraries.WriteLog.Info("\n\n");
// 响应头详情
            LogLibraries.WriteLog.Info(requestInfo);
        }
    }
}