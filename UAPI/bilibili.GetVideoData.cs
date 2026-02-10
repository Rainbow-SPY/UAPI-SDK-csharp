using System.Threading.Tasks;
using Rox.Runtimes;

namespace UAPI
{
    public partial class bilibili
    {
        /// <summary>
        /// 获取哔哩哔哩视频的详细信息
        /// </summary>
        /// <param name="video_id">视频AID/BVID</param>
        /// <param name="IDType">视频ID的类型</param>
        /// <returns><see cref="VideoType"/> 对象</returns>
        public static async Task<VideoType> GetVideoData(string video_id, BiliVideoIDType IDType)
        {
            var (result, statusCode) = await Interface.GetResult<VideoType>(
                $"https://uapis.cn/api/v1/social/bilibili/videoinfo?{(IDType.ToString().ToLower() == "bvid" ? "bvid" : "aid")}={video_id}");
            if (!Interface.IsGetSuccessful(result, "aid_or_bvid", statusCode,
                    new IException.bilibili.BilibiliServiceError(), "bilibili",
                    IException.bilibili._Bilibili_Service_Error)) LogLibraries.WriteLog.Error("请求失败,请重试!");
            return result;
        }

        /// <summary>
        /// 哔哩哔哩视频ID类型
        /// </summary>
        public enum BiliVideoIDType
        {
            /// <summary>
            /// 视频的AV号 (aid)
            /// </summary>
            AID,

            /// <summary>
            /// 视频的BV号 (bvid)
            /// </summary>
            BVID,
        }
    }
}