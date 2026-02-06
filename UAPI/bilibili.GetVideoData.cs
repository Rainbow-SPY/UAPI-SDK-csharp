using System.Threading.Tasks;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;

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
            if (!IsGetSuccessful(result,statusCode)) LogLibraries.WriteLog.Error("请求失败,请重试!");
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

        internal static bool IsGetSuccessful(VideoType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode)
            {
                case 400:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("aid_or_bvid")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.error} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("aid_or_bvid")}, {_ERROR_CODE}: {_String_NullOrEmpty}, 错误信息: {Type.error} - {Type.details}",
                        _ERROR);
                    break;
                case 500:
                    LogLibraries.WriteLog.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}, 错误信息: {Type.error} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"UAPI 服务器内部错误, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {IException.General._UAPI_Server_Down}, 错误信息: {Type.error} - {Type.details}",
                        _ERROR);
                    throw new IException.General.UAPIServerDown();

                case 502:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network,
                        $"bilibili 上游 API请求错误, {_ERROR_CODE}: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.error} - {Type.details}");
                    LogLibraries.MessageBox_I.Error(
                        $"Github 上游 API请求错误, {_ERROR_CODE}: {IException.bilibili._Bilibili_Service_Error}, 错误信息: {Type.error} - {Type.details}",
                        _ERROR);
                    throw new IException.bilibili.BilibiliServiceError();
                case 200:
                    LogLibraries.WriteLog.Info(LogLibraries.LogKind.Network, "请求成功");
                    return true;
                case 403:
                    LogLibraries.WriteLog.Warning(LogLibraries.LogKind.Network, "您已被限制请求, 因 请求量过大.");
                    LogLibraries.MessageBox_I.Warning("您已被限制请求, 因 请求量过大.", _ERROR);
                    break;
                case 404:
                    LogLibraries.WriteLog.Warning("未找到用户");
                    LogLibraries.MessageBox_I.Warning("未找到用户", _ERROR);
                    break;
                case -1:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    LogLibraries.MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    break;
                default:
                    LogLibraries.WriteLog.Error(LogLibraries.LogKind.Http, "未知错误");
                    LogLibraries.MessageBox_I.Error("发生了未知错误", _ERROR);
                    break;
            }

            return false;
        }
    }
}