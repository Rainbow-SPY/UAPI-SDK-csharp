using System;
using System.Globalization;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 识别int播放量/点赞量等并格式化，仅支持万(w)单位，返回字符串
        /// </summary>
        /// <param name="_Count">原始int播放量/点赞量等数据</param>
        /// <returns>格式化后的播放数字符串（如1234→"1234"，15000→"1.5万"）</returns>
        public static string FormatPlayCount(int _Count) =>
            _Count >= 10000 ? $"{(double)_Count / 10000:0.##}万" : _Count.ToString();

        /// <summary>
        /// 识别Unix时间戳并转换为字符串
        /// </summary>
        /// <param name="_time">时间戳</param>
        /// <returns>字符串格式的时间(YYYY-MM-DD)</returns>
        public static string FormatUnixTime(object _time) => DateTime.TryParse(_time.ToString(),
            CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
            out var dt)
            ? dt.ToString("yyyy-MM-dd")
            : string.Empty;
        /// <summary>
        /// 将ISO 8601格式（YYYY-MM-DDTHH:mm:ssZ）的UTC时间转换为本地时间，并格式化为指定格式
        /// </summary>
        /// <param name="iso8601Time">ISO 8601格式的时间字符串（带Z后缀）</param>
        /// <returns>格式化后的本地时间字符串，格式：yyyy-M-d dddd</returns>
        /// <exception cref="ArgumentException">输入时间字符串格式无效/为空时抛出</exception>
        public static string FormatISO8601TimeToLocal(string iso8601Time) => 
            string.IsNullOrWhiteSpace(iso8601Time) 
                ? throw new ArgumentException("输入的ISO 8601时间字符串不能为空", nameof(iso8601Time)) 
                : DateTime.TryParseExact(iso8601Time, "o", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var utcTime)
                    ? utcTime.ToLocalTime().ToString("yyyy-M-d dddd", CultureInfo.CurrentCulture)
                    : throw new ArgumentException($"无效的ISO 8601时间格式：{iso8601Time}，请确保格式为 YYYY-MM-DDTHH:mm:ssZ", nameof(iso8601Time));        /// <summary>
        /// 识别总长时间并转换为HH:MM:SS格式的字符串
        /// </summary>
        /// <param name="_time">时间 (秒)</param>
        /// <returns>HH:MM:SS 格式的时间字符串</returns>
        public static string FormatSecondsTime(int _time) => _time < 0
            ? "00:00:00"
            : $"{(_time / 3600 == 0 ? "00" : (_time / 3600).ToString())}";
    }
}