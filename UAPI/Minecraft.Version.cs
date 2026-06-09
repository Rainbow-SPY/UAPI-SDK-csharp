using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class Minecraft
    {
        /// <summary>
        /// 获取Minecraft Java 最新快照和正式版
        /// </summary>
        public class GetLatestVersion
        {
            /// <summary>
            /// 通过 Mojang API 获取Minecraft Java 最新快照和正式版
            /// </summary>
            /// <returns><see cref="Type.MinecraftVerFromMojang"/> 对象</returns>
            /// <exception cref="minecraft.MojangAPIServiceError"></exception>
            public static async Task<Type.MinecraftVerFromMojang> FromMojang()
            {
                var (result, statuscode) =
                    await Interface.GetResult<Type.MinecraftVerFromMojang>(
                        $"https://launchermeta.mojang.com/mc/game/version_manifest_v2.json",
                        Interface.SendRequestType.GET,
                        "", "application/json", "");
                var list = Interface.IsGetSuccessful(result, "", statuscode, new minecraft.MojangAPIServiceError(),
                    "GetMinecraftVersion.FromMojang");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }

            /// <summary>
            /// 通过 Mojang API 获取Minecraft Java 最新快照和正式版
            /// </summary>
            /// <returns><see cref="Type.MinecraftVerFromMojang"/> 对象</returns>
            /// <exception cref="minecraft.MojangAPIServiceError"></exception>
            public static async Task<Type.MinecraftVerFromUAPI> FromUAPI(string Authentication = "")
            {
                var (result, statuscode) = await Interface.GetResult<Type.MinecraftVerFromUAPI>(
                    $"{Interface._UAPI_Request_Url}game/minecraft/version", Interface.SendRequestType.GET, "",
                    "application/json", Authentication);
                var list = Interface.IsGetSuccessful(result, "", statuscode, new minecraft.MojangAPIServiceError(),
                    "GetMinecraftVersion.FromUAPI");
                if (!list.IsRequestSuccessfully)
                    LogLibraries.WriteLog.Error($"请求失败, 请重试!\n\t返回值: {list.StatusCode}\n\t错误信息: {list.FailedReason}");
                return list.FailedException != null ? throw list.FailedException : result;
            }
        }
    }

    public partial class Type
    {
        /// <summary />
        public class MinecraftVerFromMojang : TypeInterface
        {
            /// <summary>
            /// 最新版本
            /// </summary>
            public class latest
            {
                /// 最新正式版
                [JsonProperty("release")]
                public string release { get; set; }

                /// 最新快照
                public string snapshot { get; set; }
            }

            /// <summary>
            /// 最新正式版
            /// </summary>
            [JsonProperty("latest")]
            public latest Latest { get; set; }

            /// 所有版本列表集合
            public List<subV> versions { get; set; }

            /// 所有版本列表集合
            public class subV
            {
                /// 版本字符串
                public string id { get; set; }

                /// "snapshot" or "release" 区分正式版和快照
                public string type { get; set; }

                /// 所选版本的配置, 包含依赖项, JVM配置, 下载链接
                public string url { get; set; }

                /// 构建/新建文件夹 时间
                public string time { get; set; }

                /// 发行快照/正式版时间
                public string releaseTime { get; set; }

                ///版本json 的SHA1哈希值 (已实际验证)
                public string sha1 { get; set; }

                /// 安全等级: 0 => 不具备玩家安全/聊天举报等合规功能 ; 1 => 包含玩家安全功能（聊天举报、玩家报告、封禁系统等）
                public int complianceLevel { get; set; }
            }
        }

        /// <summary />
        public class MinecraftVerFromUAPI : TypeInterface
        {
            /// 最新正式版
            [JsonProperty("release")]
            public string Release { get; set; }

            /// 最新快照
            [JsonProperty("snapshot")]
            public string Snapshot { get; set; }

            /// 发行正式版时间
            [JsonProperty("release_time")]
            public string ReleaseTime { get; set; }

            /// 发行快照时间
            [JsonProperty("snapshot_time")]
            public string SnapshotTime { get; set; }
        }
    }
}