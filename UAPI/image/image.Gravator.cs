using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;
using static UAPI.Type.GravatorType;

namespace UAPI
{
    public partial class Image
    {
        /// <summary>
        /// 获取Gravatar头像
        /// </summary>
        /// <param name="email">用户的 Email 地址。如果未提供 hash 参数，则此参数为必需</param>
        /// <param name="hash">用户 Email 地址的小写 MD5 哈希值。如果提供此参数，将忽略 email 参数</param>
        /// <param name="s">头像的尺寸，单位为像素, 有效范围是 1 到 2048</param>
        /// <param name="d">当用户没有自己的 Gravatar 头像时，显示的默认头像类型</param>
        /// <param name="r">头像分级</param>
        /// <param name="Authentication">API Token Key</param>
        /// <returns>图像二进制</returns>
        public static async Task<byte[]> GetGravatorImage(string email, string hash, int s, dType d = dType.None,
            rType r = rType.None,
            string Authentication = "")
        {
            var (result, statuscode) = await Interface.GetResult<Type.BodyResult<byte[]>>(
                $"{Interface._UAPI_Request_Url}avatar/gravatar?s={(s > 2048 ? 2048 : s < 1 ? 1 : s)}{(string.IsNullOrEmpty(email) ? "" : $"&email={email}")}{(string.IsNullOrEmpty(hash.ToLower()) ? "" : $"&hash={hash.ToLower()}")}&{(r == rType.None ? "" : $"&r={r.ToString()}")}{(d == dType.None ? "" : $"&d={d.ToString()}")}",
                Interface.SendRequestType.GET, "", "application/json", Authentication);
            var list = Interface.IsGetBytesSuccessful(result, "", statuscode,new General.UAPIUnknowException(),"GetGravatorImage");
            if (!list.IsRequestSuccessfully)
                LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
            return list.FailedException != null ? throw list.FailedException : result.Result;
        }
    }

    public partial class Type
    {
        /// <summary/>
        public class GravatorType
        {
            /// <summary/>
            public enum dType
            {
                /// <summary/>
                mp,

                /// <summary/>
                identicon,

                /// <summary/>
                monsterid,

                /// <summary/>
                wavatar,

                /// <summary/>
                retro,

                /// <summary/>
                robohash,

                /// <summary/>
                blank,

                /// <summary/>
                _404,

                /// <summary/>
                None
            }

            /// <summary/>
            public enum rType
            {
                /// <summary/>
                g,

                /// <summary/>
                rg,

                /// <summary/>
                r,

                /// <summary/>
                x,

                /// <summary/>
                None
            }
        }
    }
}