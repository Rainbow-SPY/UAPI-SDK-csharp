using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UAPI;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace TestConsole
{
    internal class Program
    {
        internal static Stopwatch _stopwatch = new Stopwatch();

        public static void Main(string[] args)
        {
            TestbilibiliHotboard().Wait();
            TestNeteaseMusicHotboard().Wait();
            Thread.Sleep((2000));
            TestBiliVideoData().Wait();
            TestMinecraftServerStatus().Wait();
            TestMinecraftHistoryName().Wait();
            TestLiveRoomStatus().Wait();
            TestUAPIHealthStatus().Wait();
            TestBiliUserData().Wait();
            TestBiliArchiveData().Wait();
            TestQQUserData().Wait();
            TestQQGroupData().Wait();
            TestSteamUserData().Wait();
            TestWeatherData().Wait();
            TestEpic().Wait();
            TestGithubRepoData().Wait();
            _stopwatch.Reset();
        }

        private static void CatchAnyException(string _void, Exception e)
        {
            WriteLog.Error((_Exception_With_xKind(_void, e)));
            Thread.Sleep(2000);
        }

        public static async Task TestEpic()
        {
            var a = await EpicGames.GetDataJson();
        }

        public static void ASs()
        {
            const string text = "1f74bf9079b58865";
            WriteLog.Info($"token: {text}");
            WriteLog.Info("公钥: " + Interface.GetAssemblyPublicKeyToken("Rox.Runtimes.dll"));
            var en = Interface.Security.EncryptAPIKey(text);
            WriteLog.Info("加密后的token: " + en);
            WriteLog.Info("还原的token: " + Interface.Security.DecryptAPIKey(en));
        }

        public static async Task TestbilibiliHotboard()
        {
            WriteLog.Info("测试bilibili热榜");
            try
            {
                var a = await hotboard.GetBilibiliHotboard();
                var b = $"\n\n查询类型: {a.type}" +
                        $"\n更新时间: {a.update_time_str}" +
                        $"\n排行榜信息: ";
                foreach (var i in a.list)
                {
                    b += $"\n\t排名: {i.index}" +
                         $"\n\t视频标题: {i.title}" +
                         $"\n\t视频链接: {i.url}" +
                         $"\n\t视频短链接: {i.extra.short_link}" +
                         $"\n\t热度值: {Interface.FormatPlayCount(int.TryParse(i.hot_value.Replace("播放", ""), out var p) ? p : 0)}" +
                         $"\n\n视频详细信息:" +
                         $"\n\tAV号: {i.extra.aid}" +
                         $"\n\tBV号: {i.extra.bvid}" +
                         $"\n\t简介: {i.extra.desc}" +
                         $"\n\t总计时长: {i.extra.durations}" +
                         $"\n\t视频封面: {i.extra.CoverImageUrl}" +
                         $"\n\t发布时间: {i.extra.pubdate_str}" +
                         $"\n\t荣誉: {i.extra.rcmd_reason}" +
                         $"\n\t视频分区: {i.extra.tname}" +
                         $"\n\n视频统计信息:" +
                         $"\n\t播放量: {i.extra.stat.view_str}" +
                         $"\n\t点赞量: {i.extra.stat.Like_str}" +
                         $"\n\t投币量: {i.extra.stat.Coin_str}" +
                         $"\n\t收藏量: {i.extra.stat.Favorite_str}" +
                         $"\n\t分享量: {i.extra.stat.Share_str}" +
                         $"\n\t弹幕量: {i.extra.stat.Danmaku_str}" +
                         $"\n\t评论量: {i.extra.stat.Reply_str}" +
                         $"\n\n视频UP主信息:" +
                         $"\n\t昵称: {i.extra.owner.Name}" +
                         $"\n\tUID: {i.extra.owner.mid}" +
                         $"\n\t头像链接: {i.extra.owner.AvatarImageUrl}";
                }

                WriteLog.Info(b);
            }
            catch (Exception e)
            {
                CatchAnyException("bilibili Hotboard", e);
            }
        }

        public static async Task TestNeteaseMusicHotboard()
        {
            WriteLog.Info("测试网易云音乐");
            try
            {
                var a = await hotboard.GetNeteaseMusicHotboard();
                var b = $"\n\n查询类型: {a.type}" +
                        $"\n更新时间: {a.update_time_str}" +
                        $"\n排行榜信息: ";
                foreach (var i in a.list)
                {
                    b += $"\n\t排名: {i.index}" +
                         $"\n\t{i.extra.artist_names} - {i.title}, 时长: {i.extra.duration_text}, 热度值: {i.hot_value}" +
                         $"\n\tID: {i.extra.ID}" +
                         $"\n\t专辑名称: {i.extra.album}" +
                         $"\n\t专辑链接: {i.url}" +
                         $"\n\t专辑封面: {i.CoverImageUrl}" +
                         $"\n\t上次的热榜排名: {i.extra.last_rank}\n";
                }

                WriteLog.Info(b);
            }
            catch (Exception e)
            {
                CatchAnyException("Netease Music Hotboard", e);
            }
        }

        public static async Task TestUAPIHealthStatus()
        {
            WriteLog.Info("测试UAPI系统状态");
            try
            {
                var a = await Interface.APIHealthStatus();
                WriteLog.Info("服务名: ");
                foreach (var i in a.services)
                    WriteLog.Info($"\t{i.name}: {(i.status == "error" ? "接口故障" : "正常")}");
                WriteLog.Info("所有API:\n");
                foreach (var s in a.apis.GetType().GetProperties())
                {
                    if (!(s.GetValue(a.apis) is List<Interface.HealthType.APIProperties> k)) continue;
                    foreach (var j in k)
                    {
                        var o = $"API:  {j.name}\n\t状态: {(j.status == "error" ? "接口故障" : "正常")}" +
                                $"\n\t分类: {j.category}" +
                                $"\n\tID: {j.id}";
                        if (j.status != "error")
                            WriteLog.Info(o);
                        else
                            WriteLog.Error(o);
                    }
                }

                WriteLog.Info("Workers:\n" +
                              $"是否连接到了UAPI平台: {(a.workers.connected ? "已连接" : "未连接")}\n" +
                              $"全部计算节点: {a.workers.total_nodes}\n" +
                              $"在线计算节点: {a.workers.online_nodes}\n");
                foreach (var f in a.workers.nodes)
                    WriteLog.Info($"节点名称: {f.name}\n" +
                                  $"ID: {f.id}\n" +
                                  $"当前状态: {(f.status == "online" ? "在线" : "离线")}\n");
                WriteLog.Info("历史记录: ");
                foreach (var r in a.history)
                    WriteLog.Info($"{r.date} - 成功率: {r.percent_str}%");
            }
            catch (Exception e)
            {
                CatchAnyException("UAPI Health Status", e);
            }
        }

        public static async Task TestBiliVideoData()
        {
            WriteLog.Info("测试B站视频信息");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await bilibili.GetVideoData("BV1uT4y1P7CX", bilibili.BiliVideoIDType.BVID);
                var message = $"查询的BVID: {a.bvid}" +
                              $"\n查询的AID: {a.aid}";
                if (a.videos != 1)
                {
                    message += $"\n视频分集: {a.videos}P";
                    foreach (var i in a.pages)
                    {
                        message += $"\n\nP{i.page}: " +
                                   $"\n\t分P ID: {i.cid}" +
                                   $"\n\t从哪里上传: {i.SourceWhere}" +
                                   $"\n\t标题: {i.PartTitle}" +
                                   $"\n\t总计时长: {Interface.FormatSecondsTime((int)i.duration)}" +
                                   (string.IsNullOrEmpty(i.vid)
                                       ? ""
                                       : $"\n\t外部视频源: {i.vid}") +
                                   (string.IsNullOrEmpty(i.WebLink)
                                       ? ""
                                       : $"\n\t外部链接: {i.WebLink}") +
                                   $"\n\t分辨率: {i.dimension.Width}x{i.dimension.Height},{(i.dimension.Rotate == "正常" ? "" : $"旋转角度: {i.dimension.Rotate}")}";
                    }
                }

                message += $"\n视频所属子分区: {(string.IsNullOrEmpty(a.tname) ? "其他" : a.tname)}, ID: {a.tid}" +
                           $"\n视频版权: {a.CopyrightType}" +
                           $"\n视频封面链接: {a.CoverImageUrl}" +
                           $"\n视频标题: {a.title}" +
                           $"\n视频单P弹幕ID: {a.cid}" +
                           $"\n视频发布时间: {a.pubdate_str}" +
                           $"\nUP投稿时间: {a.ctime_str}" +
                           $"\n投稿附带的动态文字: {a.dynamic}" +
                           "\n视频简介:";
                foreach (var i in a.desc_v2)
                {
                    message += $"\n\t简介文字: {i.Text}" +
                               $"\n\t节点类型: {i.Type}" +
                               $"\n\t业务ID: {i.biz_id}";
                }

                message += $"\n视频状态: {a.state_str}" +
                           $"\n视频总长: {Interface.FormatSecondsTime((int)a.duration)}" +
                           "\n\n视频权限:" +
                           $"\n\t(过时)是否付费观看番剧: {a.rights.IsBangumiPay}" +
                           $"\n\t是否允许充电: {a.rights.IsAllowElectronicPay}" +
                           $"\n\t是否允许下载: {a.rights.IsAllowDownload}" +
                           $"\n\t视频类型是否为电影: {a.rights.IsMovie}" +
                           $"\n\t是否需要付费观看: {a.rights.IsPay}" +
                           $"\n\t(过时)是否有高码率: {a.rights.IsHighBitrate}" +
                           $"\n\t是否允许转载: {a.rights.IsAllowReprint}" +
                           $"\n\t是否允许自动播放: {a.rights.IsAllowAutoPlay}" +
                           $"\n\t是否为UGC 付费: {a.rights.IsUGCPay}" +
                           $"\n\t是否为合作视频: {a.rights.IsCooperation}" +
                           $"\n\t是否允许付费视频预览: {a.rights.IsAllowPayPreview}" +
                           // $"\n\t????: {a.rights.no_background}" +
                           $"\n\t是否为纯净模式: {a.rights.IsCleanMode}" +
                           $"\n\t????: {a.rights.IsSteinGate}" +
                           $"\n\t是否为全景视频: {a.rights.Is360PanoramicVideo}" +
                           $"\n\t是否允许分享: {a.rights.IsAllowShare}" +
                           $"\n\t是否为付费视频: {a.rights.IsArcPayVideo}" +
                           $"\n\t是否允许付费视频免费试看: {a.rights.IsAllowFreePreviewInPayVideo}" +
                           "\n\nUP主:" +
                           $"\n\tUID: {a.owner.mid}" +
                           $"\n\t昵称: {a.owner.Name}" +
                           $"\n\t头像链接: {a.owner.AvatarImageUrl}" +
                           "\n\n视频信息:" +
                           $"\n\t播放量: {Interface.FormatPlayCount(a.stat.Views)}" +
                           $"\n\t弹幕量: {Interface.FormatPlayCount(a.stat.Danmaku)}" +
                           $"\n\t评论量: {Interface.FormatPlayCount(a.stat.Reply)}" +
                           $"\n\t点赞量: {Interface.FormatPlayCount(a.stat.Like)}" +
                           $"\n\t收藏量: {Interface.FormatPlayCount(a.stat.Favorite)}" +
                           $"\n\t投币量: {Interface.FormatPlayCount(a.stat.Coin)}" +
                           $"\n\t分享量: {Interface.FormatPlayCount(a.stat.Share)}" +
                           $"\n\t当前全站排名: {a.stat.NowRank}" +
                           $"\n\t历史全站排名: {a.stat.HistoryRank}";
                if (a.staff != null)
                {
                    message += "\n\n共创信息: ";
                    foreach (var i in a.staff)
                    {
                        if (i == null) continue;
                        message += $"\n\t合作人: {i}";
                    }
                }

                if (a.subtitle.list != null)
                {
                    message += "\n\n字幕信息: " +
                               $"\n\t是否允许观众提交CC字幕: {a.subtitle.IsAllowSubmitSubtitle}" +
                               "\n\t字幕列表:";
                    foreach (var i in a.subtitle.list)
                    {
                        message += $"\n\n\t\t字幕ID: {i.id}" +
                                   $"\n\t\t语言: {i.LanguageCode} - {i.LanguageName}" +
                                   $"\n\t\t????: {i.is_lock}" +
                                   $"\n\t\t????: {i.subtitle_url}" +
                                   $"\n\t\t字幕作者UID: {i.author.mid}" +
                                   $"\n\t\t字幕作者昵称: {i.author.name}" +
                                   $"\n\t\t字幕作者头像链接: {i.author.AvatarImageUrl}";
                    }
                }

                if (a.honor_reply?.honor != null)
                {
                    message += "\n视频所得荣誉: ";
                    foreach (var i in a.honor_reply.honor)
                    {
                        message += $"\n\t荣誉名称: {i.desc}" +
                                   $"\n\t荣誉类型:{i.type}";
                    }
                }

                WriteLog.Info(message);
            }
            catch (Exception e)
            {
                CatchAnyException("GetBilibili Video Data", e);
            }
        }

        public static async Task TestLiveRoomStatus()
        {
            WriteLog.Info("测试 B站直播间信息获取......\n\n");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await bilibili.GetLiveroomStatus.AsLiveroomID("22637261");
                WriteLog.Info(
                    $"头像框名称: {(string.IsNullOrEmpty(a.new_pendants?.frame?.name) ? "没有" : a.new_pendants?.frame?.name)}");
                WriteLog.Info(
                    $"头像框简介: {(string.IsNullOrEmpty(a.new_pendants?.frame?.desc) ? "没有" : a.new_pendants?.frame?.desc)}");
                WriteLog.Info(
                    $"称号: {(string.IsNullOrEmpty(a.new_pendants?.badge?.desc) ? "没有" : a.new_pendants?.badge?.desc)}");
                WriteLog.Info($"主播UID: {a.uid}");
                WriteLog.Info($"主播直播间ID: {a.LiveroomID}");
                WriteLog.Info($"主播间的标题: {(string.IsNullOrEmpty(a.title) ? "未开播" : a.title)}");
                WriteLog.Info($"主播间的简介: {(string.IsNullOrEmpty(a.description) ? "未开播" : a.description)}");
                WriteLog.Info($"主播间的标签: {(string.IsNullOrEmpty(a.tags) ? "未开播" : a.tags)}");
                WriteLog.Info($"主播直播间的短号(靓号): {(a.short_id == 0 ? "未设置" : "")}");
                WriteLog.Info($"主播的粉丝: {a.Fans}");
                WriteLog.Info($"开始直播的时间: {(a.live_time == "0000-00-00 00:00:00" ? "未开播" : a.live_time)}");
                WriteLog.Info($"直播间的人气值:{(a.PopularValue == 0 ? "没开播" : a.PopularValue.ToString())}");
                WriteLog.Info($"在线状态: {(a.live_status == 0 ? "未开播" : (a.live_status == 1 ? "直播中" : "轮播中"))}");
                WriteLog.Info($"分区名称: {a.parent_area_name}:{a.area_name}, ID: {a.area_id}");
                WriteLog.Info($"热词: {string.Join("、", a.hot_words ?? new List<string>())}");
                _stopwatch.Stop();
                WriteLog.Info($"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒运行");
            }
            catch (Exception e)
            {
                CatchAnyException("捕获到LiveRoomStatus错误暂停", e);
            }
        }

        public static async Task TestSteamUserData()
        {
            WriteLog.Info("测试Steam用户");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await Steam.GetUserData("Rainbow-SPY");
                WriteLog.Info(LogKind.Network, $"SteamID64: {a.SteamID64}");
                WriteLog.Info(LogKind.Network,
                    $"个人资料可见性: {a.IsCommunityVisibility}");
                WriteLog.Info(LogKind.Network, $"Steam ID3: {a.SteamID3}");
                WriteLog.Info(LogKind.Network, $"Steam 用户名: {a.Name}");
                WriteLog.Info(LogKind.Network, $"个人资料主页链接: {a.ProfileUrl}");
                WriteLog.Info(LogKind.Network, $"是否填写了个人资料: {a.IsInitialized}");
                WriteLog.Info(LogKind.Network, $"头像地址: {a.Avatar_184x184}");
                WriteLog.Info(LogKind.Network, $"在线状态: {a.PersonaState}");
                WriteLog.Info(LogKind.Network, $"真实姓名: {a.RealName}");
                WriteLog.Info(LogKind.Network, $"主要社区组ID: {a.PrimaryClanID}");
                WriteLog.Info(LogKind.Network, $"账户创建时间戳: {a.RegisterTimeUnix}");
                WriteLog.Info(LogKind.Network, $"账户创建时间: {a.RegisterTime}");
                WriteLog.Info(LogKind.Network, $"账户所属国家或地区: {a.BindLocationRegionCode}");
                WriteLog.Info(LogKind.Network, $"好友代码: {a.FriendCode}");
                WriteLog.Info($"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒运行");
            }
            catch (Exception e)
            {
                CatchAnyException("捕获到SteamType错误", e);
            }
        }

        public static async Task TestWeatherData()
        {
            WriteLog.Info("测试天气......");
            try
            {
                var result = await Weather.GetWeatherDataJson(city: "连云港", true, true, true);
                WriteLog.Info("Weather",
                    $"请求位置: {result.Province} {result.City} Adcode: {result.Adcode}\n" +
                    $"今日天气: {result.Weather}, 气温:{result.Temperature} ℃, 最高气温: {result.MaxTemperature} ℃, 最低气温: {result.MinTemperature} ℃\n" +
                    $"风向: {result.WindDirection}, 风力 {result.WindPower}, 湿度 {result.Humidity}%\n" +
                    "\n");
                // 先校验 ForecastData 是否为 null，避免空引用
                if (result.forecast == null || result.forecast.Count == 0)
                    WriteLog.Warning("Weather", "未来三天天气预报数据为空，跳过遍历");
                else
                {
                    WriteLog.Info("Weather", $"未来三天的天气预报");
                    foreach (var _data in result.forecast)
                        WriteLog.Info("Weather Forecast",
                            $"{_data.date} 的天气预报:\n" + $"白天天气: {_data.DayWeather}, 夜间天气: {_data.NightWeather}\n" +
                            $"最高温度: {_data.MaxTemperature} ℃, 最低温度: {_data.MinTemperature} ℃\n" +
                            $"降水量: {_data.Precipitation} mm, 能见度: {_data.Visibility} km, 紫外线指数: {_data.UV}");
                }

                WriteLog.Info("Weather",
                    $"体感温度: {result.FeelsLikeTemperature} ℃, 能见度: {result.Visibility} km, 紫外线指数: {result.UV}\n" +
                    $"空气质量指数: {result.AQI}, 降水量: {result.Precipitation} mm, 云量: {result.Cloud} %, 气压: {result.Pressure} hPa");

                var b = result.life_indices;
                WriteLog.Info("Weather Indices",
                    $"穿衣指数: {b.Clothing.Level},简述: {b.Clothing.Brief},建议: {b.Clothing.Advice}\n" +
                    $"紫外线指数: {b.UV.Level},简述: {b.UV.Brief},建议: {b.UV.Advice}\n" +
                    $"洗车指数: {b.CarWash.Level},简述: {b.CarWash.Brief},建议: {b.CarWash.Advice}\n" +
                    $"晾晒指数: {b.Drying.Level},简述: {b.Drying.Brief},建议: {b.Drying.Advice}\n" +
                    $"空调指数: {b.AirConditioner.Level},简述: {b.AirConditioner.Brief},建议: {b.AirConditioner.Advice}\n" +
                    $"感冒指数: {b.ColdRisk.Level},简述: {b.ColdRisk.Brief},建议: {b.ColdRisk.Advice}\n" +
                    $"运动指数: {b.Exercise.Level},简述: {b.Exercise.Brief},建议: {b.Exercise.Advice}\n" +
                    $"舒适度指数: {b.Comfort.Level},简述: {b.Comfort.Brief},建议: {b.Comfort.Advice}\n" +
                    $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒运行");
            }
            catch (Exception e)
            {
                CatchAnyException("TestWeather", e);
            }
        }

        public static async Task TestBiliUserData()
        {
            WriteLog.Info("测试B站用户信息获取......");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await bilibili.GetUserData("1");
                WriteLog.Info($"UID: {a.mid}\n" +
                              $"昵称: {a.Name}\n" +
                              $"性别: {a.Sex}\n" +
                              $"头像链接: {a.AvatarImageUrl}\n" +
                              $"个性签名: {a.sign}\n" +
                              $"账户等级: {a.level}\n" +
                              $"生日: {a.birthday}\n" +
                              $"大会员等级: {a.vip_type}\n" +
                              $"大会员状态: {a.vip_status}\n" +
                              $"关注的人数: {a.following}\n" +
                              $"粉丝数: {a.Fans}\n" +
                              $"稿件数量: {a.archive_count}\n" +
                              $"文章数量: {a.article_count}\n\n" +
                              $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
            }
            catch (Exception e)
            {
                CatchAnyException("GetBilibili User Data", e);
            }
        }

        public static async Task TestBiliArchiveData()
        {
            WriteLog.Info("测试B站用户的投稿信息...");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await bilibili.GetArchives("1");
                WriteLog.Info($"总投稿数: {a.total}\n" +
                              $"页数: {a.page}\n" +
                              $"每页数量: {a.size}\n");
                for (var i = 0; i < a.videos?.Count; i++)
                {
                    var b = a.videos[i];
                    WriteLog.Info($"第{i + 1}个视频: \nAID:{b.aid}\n" +
                                  $"BVID: {b.bvid}\n" +
                                  $"标题: {b.title}\n" +
                                  $"视频封面: {b.cover}\n" +
                                  $"视频持续时长: {(b.duration < 0 ? "00:00:00" : $"{(b.duration / 3600 == 0 ? "00" : (b.duration / 3600).ToString())}: {(b.duration % 3600 / 60 == 0 ? "00" : (b.duration % 3600 / 60).ToString())}:{b.duration % 60}")}\n" +
                                  $"发布时间: {b.publish_time_str}\n" +
                                  $"播放量: {b.play_count}" +
                                  $"创建时间: {b.create_time_str}\n" +
                                  $"视频状态: {b.state}\n" +
                                  $"是否为充电视频: {b.IsPayVideo_str}\n" +
                                  $"是否为共创视频: {b.IsInteractive}\n" +
                                  $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
                }
            }
            catch (Exception e)
            {
                CatchAnyException("GetBilibili archives Data", e);
            }
        }

        public static async Task TestMinecraftServerStatus()
        {
            WriteLog.Info("测试获取Minecraft游戏服务器信息");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();

                var a = await minecraft.GetServerStatus("hypixel.net");
                WriteLog.Info($"是否在线: {(a.IsServerOnline ? "在线" : "离线")}");
                //      if (!a.online) return;
                WriteLog.Info($"解析的IP地址: {a.IP}\n" +
                              $"端口号: {a.Port}\n" +
                              $"当前玩家数量: {a.CurrentPlayers}\n" +
                              $"最大允许的玩家数量: {a.MaxPlayers}\n" +
                              $"客户端需求版本: {a.version}\n" +
                              $"描述: {a.motd_clean}\n" +
                              $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒");
            }
            catch (Exception e)
            {
                CatchAnyException("GetMinecraft Server Data", e);
            }
        }

        public static async Task TestMinecraftHistoryName()
        {
            WriteLog.Info("查找Minecraft玩家历史名称");
            try
            {
                var a = await minecraft.GetHistoryName("Dream", minecraft.SearchType.Name);
                WriteLog.Info($"查询的用户名: {a.NUserName}\n" +
                              $"匹配到的数量: {a.NCount}\n");
                foreach (var i in a.NResults)
                {
                    WriteLog.Info($"当前的用户名: {i.UserName}\n" +
                                  $"UUID: {i.UUID}\n" +
                                  $"历史名称的总数: {i.OldNameCount}");
                    foreach (var q in i.history)
                        WriteLog.Info($"{(q.changedToAt == "Initial" ? "创建账号时" : q.changedToAt)} 的用户名: {q.name}");
                }


                var b = await minecraft.GetHistoryName("ee9b4ed1-aac1-491e-b761-1471be374b80",
                    minecraft.SearchType.UUID);
                WriteLog.Info($"玩家当前的用户名: {b.U_UserName}\n" +
                              $"UUID: {b.U_UUID}\n" +
                              $"历史名称的总数(改过几次名): {b.U_OldNameCount}\n");
                foreach (var g in b.U_HistoryList)
                    WriteLog.Info($"{(g.changedToAt == "Initial" ? "创建账号时" : g.changedToAt)} 的用户名: {g.name}");
            }
            catch (Exception e)
            {
                CatchAnyException("GetMinecraftHistoryName", e);
            }
        }

        public static async Task TestQQUserData()
        {
            WriteLog.Info("测试获取QQ用户信息...");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await QQ.GetUserData("10001");
                WriteLog.Info($"QQ 号: {a.QQ}\n" +
                              $"昵称: {a.Name}\n" +
                              $"个性签名: {a.CustomSignText}\n" +
                              $"头像链接: {a.AvatarImageUrl}\n" +
                              $"年龄: {a.Age}\n" +
                              $"性别: {a.Sex}\n" +
                              $"个性域名: {a.QID}\n" +
                              $"QQ等级: {a.QQLevel}\n" +
                              $"地点: {a.Location}\n" +
                              $"电子邮箱: {a.Email}\n" +
                              $"是否为S/VIP: {a.IsVip}\n" +
                              $"vip等级: {a.VipLevel}\n" +
                              $"注册时间: {a.RegisterTime}\n" +
                              $"最后更新时间: {a.LastUpdatedTime}\n" +
                              $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
            }
            catch (Exception e)
            {
                CatchAnyException("GetQQ User Data", e);
            }
        }

        public static async Task TestQQGroupData()
        {
            WriteLog.Info("测试获取群聊信息...");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await QQ.GetGroupData("526357265");
                WriteLog.Info($"群ID: {a.ID}\n" +
                              $"群名称: {a.Name}\n" +
                              $"头像链接: {a.AvatarImageUrl}\n" +
                              $"描述: {a.Description}\n" +
                              $"标签: {a.Tag}\n" +
                              $"进群链接: {a.JoinQRCodeUrl}\n" +
                              $"最后更新时间: {a.LastUpdatedTime}\n" +
                              $"当前群人数: {a.MemberCount}\n" +
                              $"最大群人数: {a.MaxMemberCount}\n" +
                              $"活跃群人数: {a.ActiveMemberNum}\n" +
                              $"群主qq号: {a.OwnerUinID}\n" +
                              $"群主UID: {a.OwnerUID}\n" +
                              $"创建群聊的时间戳: {a.CreateTime}\n" +
                              $"群等级: {a.GroupLevel}\n" +
                              $"群公告: {a.Introduction}\n" +
                              $"认证类型: {a.IsCert}\n" +
                              $"认证说明: {a.CertDescription}\n" +
                              $"测试完毕, 共用 {_stopwatch.Elapsed.TotalSeconds} 秒");
            }
            catch (Exception e)
            {
                CatchAnyException("GetQQ Group Data", e);
            }
        }

        public static async Task TestGithubRepoData()
        {
            WriteLog.Info("测试github仓库");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await github.GetReposData("torvalds/linux");
                var _topics = "";
                for (var i = 0; i < a.Topics?.Count; i++)
                    _topics += $"{(i == 0 ? "" : ",")}{a.Topics?[i]}";
                var _languages = a.LanguagesStats.Aggregate("",
                    (current, v) =>
                        current + $"{(v.Equals(a.LanguagesStats.First()) ? "\n" : "")}\t{v.Key}: {v.Value} 行代码\n");

                WriteLog.Info($"完整名称: {a.FullName}\n" +
                              $"描述: {a.Description}\n" +
                              $"主页: {a.HomePage}\n" +
                              $"默认分支: {a.DefaultBranch}\n" +
                              $"默认分支SHA值: {a.DefaultBranchSHAHash}\n" +
                              $"主要分支: {a.PrimaryBranch}\n" +
                              $"可见性: {a?.Visibility}\n" +
                              $"仓库是否为公开: {a.IsPublic}\n" +
                              $"是否为存档: {a.IsArchived}\n" +
                              $"是否禁用: {a.IsDisabled}\n" +
                              $"是否为Fork的仓库: {a.IsForked}\n" +
                              $"主要代码语言: {a.MainLanguage}\n" +
                              $"话题: {_topics}\n" +
                              $"许可证: {a.License}\n" +
                              $"Star 数量: {a.Stargazers}\n" +
                              $"Fork 的数量: {a.Forks}\n" +
                              $"打开的Issue: {a.OpenIssues}\n" +
                              $"关注人数: {a.Watchers}\n" +
                              $"推送时间: {a.PushedTime_String}\n" +
                              $"创建仓库时间: {a.CreatedTime_String}\n" +
                              $"更新时间: {a.UpdatedTime_Str}\n" +
                              $"代码语言: {_languages}\n" +
                              $"仓库协作者: {a.Collaborators}\n");
                foreach (var t in a.Maintainers)
                {
                    WriteLog.Info($"协作者: {t.login}\n" +
                                  $"名称: {t.name}\n" +
                                  $"邮箱: {t.email}\n" +
                                  $"个人主页: {t.url}\n\n");
                }

                WriteLog.Info($"测试完毕, 共用时 {_stopwatch.Elapsed.TotalSeconds} 秒");
            }
            catch (Exception e)
            {
                //CatchAnyException("GetGithubRepos Data", e);
                throw;
            }
        }
    }
}