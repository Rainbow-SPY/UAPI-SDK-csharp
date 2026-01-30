using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            TestLiveRoomStatus().Wait();
            TestBiliUser().Wait();
            TestBiliArchive().Wait();
            TestQQUser().Wait();
            TestQQGroup().Wait();

            TestGithubRepos().Wait();
            _stopwatch.Reset();
        }

        public static async Task TestLiveRoomStatus()
        {
            WriteLog.Info("测试 B站直播间信息获取......\n\n");
            try
            {
                _stopwatch.Start();
                var a = await bilibili.GetLiveRoomStatus.AsLiveroomID("22637261");
                WriteLog.Info(
                    $"头像框名称: {(string.IsNullOrEmpty(a.new_pendants.frame?.name) ? "没有" : a.new_pendants.frame.name)}");
                WriteLog.Info(
                    $"头像框简介: {(string.IsNullOrEmpty(a.new_pendants.frame?.desc) ? "没有" : a.new_pendants.frame.desc)}");
                WriteLog.Info(
                    $"称号: {(string.IsNullOrEmpty(a.new_pendants.badge?.desc) ? "没有" : a.new_pendants.badge.desc)}");
                WriteLog.Info($"主播UID: {a.uid}");
                WriteLog.Info($"主播直播间ID: {a.room_id}");
                WriteLog.Info($"主播间的标题: {(string.IsNullOrEmpty(a.title) ? "未开播" : a.title)}");
                WriteLog.Info($"主播间的简介: {(string.IsNullOrEmpty(a.description) ? "未开播" : a.description)}");
                WriteLog.Info($"主播间的标签: {(string.IsNullOrEmpty(a.tags) ? "未开播" : a.tags)}");
                WriteLog.Info($"主播直播间的短号（靓号): {(a.short_id == 0 ? "未设置" : "")}");
                WriteLog.Info($"主播的粉丝: {a.attention}");
                WriteLog.Info($"开始直播的时间: {(a.live_time == "0000-00-00 00:00:00" ? "未开播" : a.live_time)}");
                WriteLog.Info($"直播间的人气值:{(a.online == 0 ? "没开播" : a.online.ToString())}");
                WriteLog.Info($"在线状态: {(a.live_status == 0 ? "未开播" : (a.live_status == 1 ? "直播中" : "轮播中"))}");
                WriteLog.Info($"分区名称: {a.parent_area_name}:{a.area_name}, ID: {a.area_id}");
                WriteLog.Info($"热词: {string.Join("、", a.hot_words ?? new List<string>())}");
                _stopwatch.Stop();
                WriteLog.Info($"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒运行");
            }
            catch (Exception e)
            {
                WriteLog.Info(_Exception_With_xKind("捕获到LiveRoomStatus错误暂停", e));
                Console.ReadLine();
            }
        }

        public static async Task TestBiliUser()
        {
            WriteLog.Info("测试B站用户信息获取......");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await bilibili.GetUserData("1");
                WriteLog.Info($"UID: {a.mid}\n" +
                              $"昵称: {a.name}\n" +
                              $"性别: {a.sex}\n" +
                              $"头像链接: {a.face}\n" +
                              $"个性签名: {a.sign}\n" +
                              $"账户等级: {a.level}\n" +
                              $"生日: {a.birthday}\n" +
                              $"大会员等级: {a.vip_type}\n" +
                              $"大会员状态: {a.vip_status}\n" +
                              $"关注的人数: {a.following}\n" +
                              $"粉丝数: {a.follower}\n" +
                              $"稿件数量: {a.archive_count}\n" +
                              $"文章数量: {a.article_count}\n\n" +
                              $"共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task TestBiliArchive()
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
                for (var i = 0; i < a.videos.Count; i++)
                {
                    var b = a.videos[i];
                    WriteLog.Info($"第{i + 1}个视频: \nAID:{b.aid}\n" +
                                  $"BVID: {b.bvid}\n" +
                                  $"标题: {b.title}\n" +
                                  $"视频封面: {b.cover}\n" +
                                  $"视频持续时长: {(b.duration < 0 ? "00:00:00" : $"{(b.duration / 3600 == 0 ? "00" : (b.duration / 3600).ToString())}: {(b.duration % 3600 / 60 == 0 ? "00" : (b.duration % 3600 / 60).ToString())}:{b.duration % 60}")}\n" +
                                  $"发布时间: {b.publish_time_str}\n" +
                                  $"创建时间: {b.create_time_str}\n" +
                                  $"视频状态: {b.state}\n" +
                                  $"是否为充电视频: {b.is_ugc_pay_str}\n" +
                                  $"是否为共创视频: {b.is_interactive}\n共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task TestQQUser()
        {
            WriteLog.Info("测试获取QQ用户信息...");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await QQ.GetUserData("10001");
                WriteLog.Info($"QQ 号: {a.qq}\n" +
                              $"昵称: {a.nickname}\n" +
                              $"个性签名: {a.long_nick}\n" +
                              $"头像链接: {a.avatar_url}\n" +
                              $"年龄: {a.age}\n" +
                              $"性别: {a.sex}\n" +
                              $"个性域名: {a.qid}\n" +
                              $"QQ等级: {a.qq_level}\n" +
                              $"地点: {a.location}\n" +
                              $"电子邮箱: {a.email}\n" +
                              $"是否为S/VIP: {a.is_vip}\n" +
                              $"vip等级: {a.vip_level}\n" +
                              $"注册时间: {a.reg_time_str}\n" +
                              $"最后更新时间: {a.last_updated_str}\n共用了 {_stopwatch.Elapsed.TotalSeconds} 秒\n测试完毕");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task TestQQGroup()
        {
            WriteLog.Info("测试获取群聊信息...");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await QQ.GetGroupData("526357265");
                WriteLog.Info($"群ID: {a.group_id}\n" +
                              $"群名称: {a.group_name}\n" +
                              $"头像链接: {a.avatar_url}\n" +
                              $"描述: {a.description}\n" +
                              $"标签: {a.tag}\n" +
                              $"进群链接: {a.join_url}\n" +
                              $"最后更新时间: {a.last_updated}\n" +
                              $"当前群人数: {a.member_count}\n" +
                              $"最大群人数: {a.max_member_count}\n" +
                              $"活跃群人数: {a.active_member_num}\n" +
                              $"群主qq号: {a.owner_uin}\n" +
                              $"群主UID: {a.owner_uid}\n" +
                              $"创建群聊的时间戳: {a.create_time_str}\n" +
                              $"群等级: {a.group_grade}\n" +
                              $"群公告: {a.group_memo}\n" +
                              $"认证类型: {a.cert_type_str}\n" +
                              $"认证说明: {a.cert_text}\n测试完毕, 共用 {_stopwatch.Elapsed.TotalSeconds} 秒");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task TestGithubRepos()
        {
            WriteLog.Info("测试github仓库");
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var a = await github.GetReposData("torvalds/linux");
                WriteLog.Info($"完整名称: {a.full_name}\n" +
                              $"描述: {a.description}\n" +
                              $"主页: {a.homepage}\n" +
                              $"默认分支: {a.default_branch}\n" +
                              $"默认分支SHA值: {a.default_branch_sha}\n" +
                              $"主要分支: {a.primary_branch}\n" +
                              $"可见性: {a.visibility}\n" +
                              $"是否为存档: {a.archived}\n" +
                              $"是否禁用: {a.disabled}\n" +
                              $"是否为Fork的仓库: {a.fork}\n" +
                              $"主要代码语言: {a.language}\n" +
                              $"话题: {a.topics}\n" +
                              $"许可证: {a.license}\n" +
                              $"Star 数量: {a.stargazers}\n" +
                              $"Fork 的数量: {a.forks}\n" +
                              $"打开的Issue: {a.open_issues}\n" +
                              $"关注人数: {a.watchers}\n" +
                              $"推送时间: {a.pushed_at_str}\n" +
                              $"创建仓库时间: {a.created_at_str}\n" +
                              $"更新时间: {a.updated_at_str}\n" +
                              $"代码语言: {a.languages}\n" +
                              $"仓库协作者: {a.collaborators}\n");
                foreach (var t in a.maintainers)
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}