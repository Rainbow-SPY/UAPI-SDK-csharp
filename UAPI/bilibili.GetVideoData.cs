using System.Threading.Tasks;

namespace UAPI
{
    public partial class bilibili
    {
        public static async Task<VideoType> GetVideoData(string video_id, BiliVideoIDType IDType)
        {
            var (result, statusCode) = await Interface.GetResult<VideoType>(
                $"htts://uapis.cn/api/v1/social/bilibili/videoinfo?{(IDType.ToString().ToLower() == "bvid" ? "bvid" : "aid")}={video_id}");
            if ()
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