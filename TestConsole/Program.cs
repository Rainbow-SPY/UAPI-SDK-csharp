using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UAPI;
using static Rox.Runtimes.LogLibraries;
using static Rox.Runtimes.LocalizedString;

namespace TestConsole
{
    internal class Program
    {
        internal static Stopwatch _stopwatch = new Stopwatch();

        public static void Main(string[] args)
        {
            Test().Wait();
        }

        public static async Task Test()
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
                WriteLog.Info(_Exception_With_xKind("捕获到错误暂停", e));
                Console.ReadLine();
            }
        }
    }
}