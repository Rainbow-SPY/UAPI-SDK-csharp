using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type;

namespace UAPI
{
    /// <summary>
    /// 随机类接口
    /// </summary>
    public partial class Random
    {
        /// <summary>
        /// 获取随机图片, 302重定向到图像
        /// </summary>
        /// <param name="_category">指定图像的主类别</param>
        /// <param name="_type">指定图像的子类别, 仅 Uapi-Pro 服务器图床支持</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>二进制 image/jpeg 数据</returns>
        public static async Task<byte[]> GetImage(RandomImage _category = RandomImage.None,
            WallpaperType _type = WallpaperType.None, string Authentication = "")
        {
            var (result, statusCode) = await Interface.GetResult<BodyResult<byte[]>>(
                $"https://uapis.cn/api/v1/random/image{(_category == RandomImage.None && _type == WallpaperType.None ? "" : "?")}{(_type == WallpaperType.None ? "" : $"type={_type.ToString()}")}{(_type != WallpaperType.None ? "&" : "")}{(_category == RandomImage.None ? "" : $"category={_category.ToString()}")}",
                Authentication);
            var list = Interface.IsGetBytesSuccessful(result, null, statusCode, new General.UAPIUnknowException(),
                "random.GetImage");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }
}