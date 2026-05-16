using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UAPI;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;
using static UAPI.Type;

namespace TestConsole
{
    internal class Program
    {
        internal static readonly Stopwatch _stopwatch = new Stopwatch();

        public static void Main(string[] args)
        {
            TestBytes();
            Console.ReadLine();
            TestNSFW();
            AnalyzeWords();
            ToHTML();
            TestbilibiliHotboard().Wait();
            TestNeteaseMusicHotboard().Wait();
            Thread.Sleep(2000);
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


        private static async void TestBytes()
        {
            try
            {
                var result = await Image.QRCode.GetBytes("123");
                var md5 = await Text.CreateMD5(result.ToString());
                var data = MD5.Create().ComputeHash(result);
                var builder = new StringBuilder();
                foreach (var t in data) 
                    builder.Append(t.ToString("x2"));
                WriteLog.Info($"请求成功: 获取到的图像MD5为: {md5.MD5}, 本地计算的MD5为: {builder}");
            }
            catch (Exception e)
            {
                CatchAnyException("TestBytes", e);
            }
        }

        private static async void TestNSFW()
        {
            try
            {
                WriteLog.Info("测试图片敏感度");
                // var result =
                //     await Image.CheckImageNSFW(File.ReadAllBytes(@"C:\Windows\System32\SecurityAndMaintenance.png"));
                // WriteLog.Info($"违规值: {result.NSFWScore}");
                var score = await Image.CheckImageNSFW(
                    "https://th.bing.com/th/id/OSK.yYOTs4P7yz5q7hLpAHkXz_tl-Tgx5BR0FdlDRaU4WqE?o=7rm=3&rs=1&pid=ImgDetMain&o=7&rm=3");
                WriteLog.Info($"违规值: {score.NSFWScore}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                CatchAnyException("TestNSFW", e);
            }
        }

        private static async void AnalyzeWords()
        {
            try
            {
                WriteLog.Info("审查敏感词");
                foreach (var i in (await Text.SensitiveWords.Analyze(new[] { "你妈死了", "操你妈" })).Results)
                    WriteLog.Info($"风险分类: {i.Level}\n" +
                                  $"文本字段是否安全: {i.IsSafe}\n" +
                                  $"置信度: {i.Confidence}\n");
            }
            catch (Exception e)
            {
                CatchAnyException("AnalyzeWords", e);
            }
        }

        private static async void ToHTML()
        {
            try
            {
                WriteLog.Info("Markdown 转换 HTML");
                var result = await Text.Markdown.ToHTML.ReturnedHTMLCode("### 123");
                WriteLog.Info(result.Split('\n').First());
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "123.html"), result);

                WriteLog.Info("Markdown 转换 PDF");
                var result1 = await Text.Markdown.ToPDF("### 123");
                File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, "123.pdf"), result1);
                WriteLog.Info("生成完毕");
            }
            catch (Exception e)
            {
                CatchAnyException("ToHtml", e);
            }
        }

        private static void CatchAnyException(string _void, Exception e)
        {
            WriteLog.Error(_Exception_With_xKind(_void, e));
            Thread.Sleep(2000);
        }

        public static async Task TestEpic() => await EpicGames.GetDataJson();

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
                var b = $"\n\t查询类型: {a.Type}" +
                        $"\n\t更新时间: {a.UpdateTime_Str}" +
                        "\n\t排行榜信息";
                b = a.list.Aggregate(b,
                    (current, i) => current + $"\n\t排名: {i.Index}" + $"\n\t视频标题: {i.Title}" + $"\n\t视频链接: {i.Url}" +
                                    $"\n\t视频短链接: {i.extra.short_link}" +
                                    $"\n\t热度值: {Interface.FormatPlayCount(int.TryParse(i.HotValue.Replace("播放", ""), out var p) ? p : 0)}" +
                                    "\n\n\t视频详细信息:" + $"\n\tAV号: {i.extra.aid}" +
                                    $"\n\tBV号: {i.extra.bvid}" + $"\n\t简介: {i.extra.desc}" +
                                    $"\n\t总计时长: {i.extra.durations}" + $"\n\t视频封面: {i.extra.CoverImageUrl}" +
                                    $"\n\t发布时间: {i.extra.pubdate_str}" + $"\n\t荣誉: {i.extra.rcmd_reason}" +
                                    $"\n\t视频分区: {i.extra.tname}" + "\n\n\t视频统计信息:" +
                                    $"\n\t播放量: {i.extra.stat.view_str}" +
                                    $"\n\t点赞量: {i.extra.stat.Like_str}" +
                                    $"\n\t投币量: {i.extra.stat.Coin_str}" +
                                    $"\n\t收藏量: {i.extra.stat.Favorite_str}" +
                                    $"\n\t分享量: {i.extra.stat.Share_str}" +
                                    $"\n\t弹幕量: {i.extra.stat.Danmaku_str}" +
                                    $"\n\t评论量: {i.extra.stat.Reply_str}" + "\n\n\t视频UP主信息:" +
                                    $"\n\t昵称: {i.extra.owner.Name}" + $"\n\tUID: {i.extra.owner.mid}" +
                                    $"\n\t头像链接: {i.extra.owner.AvatarImageUrl}");

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
                var b = $"\n\n查询类型: {a.Type}" +
                        $"\n更新时间: {a.UpdateTime_Str}" +
                        "\n排行榜信息: ";
                b = a.Lists.Aggregate(b,
                    (current, i) => current + $"\n\t排名: {i.Index}" +
                                    $"\n\t{i.ExtraInfo.ArtistNames} - {i.Title}, 时长: {i.ExtraInfo.DurationText}, 热度值: {i.HotValue}" +
                                    $"\n\tID: {i.ExtraInfo.ID}" + $"\n\t专辑名称: {i.ExtraInfo.Album}" +
                                    $"\n\t专辑链接: {i.Url}" + $"\n\t专辑封面: {i.CoverImageUrl}" +
                                    $"\n\t上次的热榜排名: {i.ExtraInfo.LastRank}\n");

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
                var a = await Interface.APIHealthPlatformStatus();
                WriteLog.Info("服务名: ");
                foreach (var i in a.services)
                    WriteLog.Info($"\t{i.name}: {(i.status == "error" ? "接口故障" : "正常")}");
                WriteLog.Info("所有API:\n");
                foreach (var s in a.apis.GetType().GetProperties())
                {
                    if (!(s.GetValue(a.apis) is List<HealthType.APIProperties> k)) continue;
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
                var message = $"查询的BVID: {a.BVID}" +
                              $"\n查询的AID: {a.AID}";
                if (a.Videos != 1)
                {
                    message += $"\n视频分集: {a.Videos}P";
                    message = a.PagesList.Aggregate(message, (current, i)
                        => current + $"\n\nP{i.Index}: " +
                           $"\n\t分P ID: {i.CID}" +
                           $"\n\t从哪里上传: {i.SourceWhere}" +
                           $"\n\t标题: {i.PartTitle}" +
                           $"\n\t总计时长: {Interface.FormatSecondsTime((int)i.Duration)}" +
                           (string.IsNullOrEmpty(i.vid)
                               ? ""
                               : $"\n\t外部视频源: {i.vid}") +
                           (string.IsNullOrEmpty(i.WebLink)
                               ? ""
                               : $"\n\t外部链接: {i.WebLink}") +
                           $"\n\t分辨率: {i.DimensionInfo.Width}x{i.DimensionInfo.Height},{(i.DimensionInfo.Rotate == "正常" ? "" : $"旋转角度: {i.DimensionInfo.Rotate}")}");
                }

                message += $"\n视频所属子分区: {(string.IsNullOrEmpty(a.TName) ? "其他" : a.TName)}, ID: {a.TID}" +
                           $"\n视频版权: {a.CopyrightType}" +
                           $"\n视频封面链接: {a.CoverImageUrl}" +
                           $"\n视频标题: {a.Title}" +
                           $"\n视频单P弹幕ID: {a.CID}" +
                           $"\n视频发布时间: {a.PubDate_str}" +
                           $"\nUP投稿时间: {a.CTime_str}" +
                           $"\n投稿附带的动态文字: {a.DynamicText}" +
                           "\n视频简介:";
                message = a.DescV2List.Aggregate(message,
                    (current, i) =>
                        current + $"\n\t简介文字: {i.Text}" + $"\n\t节点类型: {i.Type}" + $"\n\t业务ID: {i.BizId}");


                message += $"\n视频状态: {a.State}" +
                           $"\n视频总长: {Interface.FormatSecondsTime(a.Duration)}" +
                           "\n\n视频权限:" +
                           $"\n\t(过时)是否付费观看番剧: {a.RightsInfo.IsBangumiPay}" +
                           $"\n\t是否允许充电: {a.RightsInfo.IsAllowElectronicPay}" +
                           $"\n\t是否允许下载: {a.RightsInfo.IsAllowDownload}" +
                           $"\n\t视频类型是否为电影: {a.RightsInfo.IsMovie}" +
                           $"\n\t是否需要付费观看: {a.RightsInfo.IsPay}" +
                           $"\n\t(过时)是否有高码率: {a.RightsInfo.IsHighBitrate}" +
                           $"\n\t是否允许转载: {a.RightsInfo.IsAllowReprint}" +
                           $"\n\t是否允许自动播放: {a.RightsInfo.IsAllowAutoPlay}" +
                           $"\n\t是否为UGC 付费: {a.RightsInfo.IsUGCPay}" +
                           $"\n\t是否为合作视频: {a.RightsInfo.IsCooperation}" +
                           $"\n\t是否允许付费视频预览: {a.RightsInfo.IsAllowPayPreview}" +
                           // $"\n\t????: {a.rights.no_background}" +
                           $"\n\t是否为纯净模式: {a.RightsInfo.IsCleanMode}" +
                           $"\n\t????: {a.RightsInfo.IsSteinGate}" +
                           $"\n\t是否为全景视频: {a.RightsInfo.Is360PanoramicVideo}" +
                           $"\n\t是否允许分享: {a.RightsInfo.IsAllowShare}" +
                           $"\n\t是否为付费视频: {a.RightsInfo.IsArcPayVideo}" +
                           $"\n\t是否允许付费视频免费试看: {a.RightsInfo.IsAllowFreePreviewInPayVideo}" +
                           "\n\nUP主:" +
                           $"\n\tUID: {a.OwnerInfo.mid}" +
                           $"\n\t昵称: {a.OwnerInfo.Name}" +
                           $"\n\t头像链接: {a.OwnerInfo.AvatarImageUrl}" +
                           "\n\n视频信息:" +
                           $"\n\t播放量: {Interface.FormatPlayCount(a.StatInfo.Views)}" +
                           $"\n\t弹幕量: {Interface.FormatPlayCount(a.StatInfo.Danmaku)}" +
                           $"\n\t评论量: {Interface.FormatPlayCount(a.StatInfo.Reply)}" +
                           $"\n\t点赞量: {Interface.FormatPlayCount(a.StatInfo.Like)}" +
                           $"\n\t收藏量: {Interface.FormatPlayCount(a.StatInfo.Favorite)}" +
                           $"\n\t投币量: {Interface.FormatPlayCount(a.StatInfo.Coin)}" +
                           $"\n\t分享量: {Interface.FormatPlayCount(a.StatInfo.Share)}" +
                           $"\n\t当前全站排名: {a.StatInfo.NowRank}" +
                           $"\n\t历史全站排名: {a.StatInfo.HistoryRank}";
                if (a.StaffList != null)
                {
                    message += "\n\n共创信息: ";
                    message = a.StaffList.Where(i => i != null)
                        .Aggregate(message, (current, i) => current + $"\n\t合作人: {i}");
                }

                if (a.SubtitleList.List != null)
                {
                    message += "\n\n字幕信息: " +
                               $"\n\t是否允许观众提交CC字幕: {a.SubtitleList.IsAllowSubmitSubtitle}" +
                               "\n\t字幕列表:";
                    message = a.SubtitleList.List.Aggregate(message,
                        (current, i) => current + $"\n\n\t\t字幕ID: {i.ID}" +
                                        $"\n\t\t语言: {i.LanguageCode} - {i.LanguageName}" +
                                        $"\n\t\t????: {i.IsLock}" + $"\n\t\t????: {i.Subtitle_JsonFileURL}" +
                                        $"\n\t\t字幕作者UID: {i.AuthorInfo.MID}" + $"\n\t\t字幕作者昵称: {i.AuthorInfo.Name}" +
                                        $"\n\t\t字幕作者头像链接: {i.AuthorInfo.AvatarImageUrl}");
                }

                if (a.HonorReply?.honor != null)
                {
                    message += "\n视频所得荣誉: ";
                    message = a.HonorReply.honor.Aggregate(message,
                        (current, i) => current + $"\n\t荣誉名称: {i.Description}" + $"\n\t荣誉类型:{i.Type}");
                }

                var Headers = a.Headers;
                var messa1ge = $"\n\t本次请求的扣费结果状态: {Headers.DebitStatus?.ToString()}" +
                               $"\n\t本次应扣积分: {Headers.RequestedCredits}" +
                               $"\n\t实际扣除积分: {Headers.CreditsCharged}" +
                               $"\n\t当前有效的资源包数量: {Headers.ActivatedResourcePackagesCount}";
                WriteLog.Info("ResponseHeader", messa1ge);


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
                    $"头像框名称: {(string.IsNullOrEmpty(a.NewPendants?.Frame?.Name) ? "没有" : a.NewPendants?.Frame?.Name)}");
                WriteLog.Info(
                    $"头像框简介: {(string.IsNullOrEmpty(a.NewPendants?.Frame?.Desc) ? "没有" : a.NewPendants?.Frame?.Desc)}");
                WriteLog.Info(
                    $"称号: {(string.IsNullOrEmpty(a.NewPendants?.Badge?.Desc) ? "没有" : a.NewPendants?.Badge?.Desc)}");
                WriteLog.Info($"主播UID: {a.UID}");
                WriteLog.Info($"主播直播间ID: {a.LiveroomID}");
                WriteLog.Info($"主播间的标题: {(string.IsNullOrEmpty(a.Title) ? "未开播" : a.Title)}");
                WriteLog.Info($"主播间的简介: {(string.IsNullOrEmpty(a.Description) ? "未开播" : a.Description)}");
                WriteLog.Info($"主播间的标签: {(string.IsNullOrEmpty(a.Tags) ? "未开播" : a.Tags)}");
                WriteLog.Info($"主播直播间的短号(靓号): {(a.ShortId == 0 ? "未设置" : "")}");
                WriteLog.Info($"主播的粉丝: {a.Fans}");
                WriteLog.Info($"开始直播的时间: {(a.LiveTime == "0000-00-00 00:00:00" ? "未开播" : a.LiveTime)}");
                WriteLog.Info($"直播间的人气值:{(a.PopularValue == 0 ? "没开播" : a.PopularValue.ToString())}");
                WriteLog.Info($"在线状态: {(a.LiveStatus == 0 ? "未开播" : a.LiveStatus == 1 ? "直播中" : "轮播中")}");
                WriteLog.Info($"分区名称: {a.ParentAreaName}:{a.AreaName}, ID: {a.AreaID}");
                WriteLog.Info($"热词: {string.Join("、", a.HotWordsList ?? new List<string>())}");
                _stopwatch.Stop();
                var Headers = a.Headers;
                var message = $"\n\t本次请求的扣费结果状态: {Headers.DebitStatus?.ToString()}" +
                              $"\n\t本次应扣积分: {Headers.RequestedCredits}" +
                              $"\n\t实际扣除积分: {Headers.CreditsCharged}" +
                              $"\n\t当前有效的资源包数量: {Headers.ActivatedResourcePackagesCount}";
                WriteLog.Info("ResponseHeader", message);

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
                var Headers = a.Headers;
                var message = $"\n\t本次请求的扣费结果状态: {Headers.DebitStatus?.ToString()}" +
                              $"\n\t本次应扣积分: {Headers.RequestedCredits}" +
                              $"\n\t实际扣除积分: {Headers.CreditsCharged}" +
                              $"\n\t当前有效的资源包数量: {Headers.ActivatedResourcePackagesCount}";
                WriteLog.Info("ResponseHeader", message);
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
                    WriteLog.Info("Weather", "未来三天的天气预报");
                    foreach (var _data in result.forecast)
                        WriteLog.Info("Weather Forecast",
                            $"{_data.Date} 的天气预报:\n" + $"白天天气: {_data.DayWeather}, 夜间天气: {_data.NightWeather}\n" +
                            $"最高温度: {_data.MaxTemperature} ℃, 最低温度: {_data.MinTemperature} ℃\n" +
                            $"降水量: {_data.Precipitation} mm, 能见度: {_data.Visibility} km, 紫外线指数: {_data.UV}");
                }

                WriteLog.Info("Weather",
                    $"体感温度: {result.FeelsLikeTemperature} ℃, 能见度: {result.Visibility} km, 紫外线指数: {result.UV}\n" +
                    $"空气质量指数: {result.AQI}, 降水量: {result.Precipitation} mm, 云量: {result.Cloud} %, 气压: {result.Pressure} hPa");

                var b = result.life_indices;
                var Headers = result.Headers;
                var message = $"\n\t本次请求的扣费结果状态: {Headers.DebitStatus?.ToString()}" +
                              $"\n\t本次应扣积分: {Headers.RequestedCredits}" +
                              $"\n\t实际扣除积分: {Headers.CreditsCharged}" +
                              $"\n\t当前有效的资源包数量: {Headers.ActivatedResourcePackagesCount}";
                WriteLog.Info("ResponseHeader", message);


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
                WriteLog.Info($"UID: {a.MID}\n" +
                              $"昵称: {a.Name}\n" +
                              $"性别: {a.Sex}\n" +
                              $"头像链接: {a.AvatarImageUrl}\n" +
                              $"个性签名: {a.Sign}\n" +
                              $"账户等级: {a.Level}\n" +
                              $"生日: {a.Birthday}\n" +
                              $"大会员等级: {a.VipType}\n" +
                              $"大会员状态: {a.VipStatus}\n" +
                              $"关注的人数: {a.Following}\n" +
                              $"粉丝数: {a.Fans}\n" +
                              $"稿件数量: {a.ArchiveCount}\n" +
                              $"文章数量: {a.ArticleCount}\n\n" +
                              $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
                var Headers = a.Headers ?? throw new ArgumentNullException();
                var message = $"\n\t本次请求的扣费结果状态: {Headers.DebitStatus?.ToString()}" +
                              $"\n\t本次应扣积分: {Headers.RequestedCredits}" +
                              $"\n\t实际扣除积分: {Headers.CreditsCharged}" +
                              $"\n\t当前有效的资源包数量: {Headers.ActivatedResourcePackagesCount}";
                WriteLog.Info("ResponseHeader", message);
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
                WriteLog.Info($"总投稿数: {a.Total}\n" +
                              $"页数: {a.PageCount}\n" +
                              $"每页数量: {a.PageSize}\n");
                for (var i = 0; i < a.VideosList?.Count; i++)
                {
                    var b = a.VideosList[i];
                    WriteLog.Info($"第{i + 1}个视频: \nAID:{b.AID}\n" +
                                  $"BVID: {b.BVID}\n" +
                                  $"标题: {b.Title}\n" +
                                  $"视频封面: {b.CoverImageUrl}\n" +
                                  $"视频持续时长: {(b.Duration < 0 ? "00:00:00" : $"{(b.Duration / 3600 == 0 ? "00" : (b.Duration / 3600).ToString())}: {(b.Duration % 3600 / 60 == 0 ? "00" : (b.Duration % 3600 / 60).ToString())}:{b.Duration % 60}")}\n" +
                                  $"发布时间: {b.PublishTimeStr}\n" +
                                  $"播放量: {b.PlayCount}" +
                                  $"创建时间: {b.CreateTimeStr}\n" +
                                  $"视频状态: {b.State}\n" +
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
                          $"可见性: {a.Visibility}\n" +
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
                WriteLog.Info($"协作者: {t.Login}\n" +
                              $"名称: {t.Name}\n" +
                              $"邮箱: {t.Email}\n" +
                              $"个人主页: {t.Url}\n\n");
            }

            WriteLog.Info($"测试完毕, 共用时 {_stopwatch.Elapsed.TotalSeconds} 秒");
        }
    }
}