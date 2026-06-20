using System;
using System.Globalization;

namespace UAPI.Extensions
{
    /// <summary />
    public static class Time
    {
        /// <summary>
        /// 识别int播放量/点赞量等并格式化，仅支持万(w)单位，返回字符串
        /// </summary>
        /// <param name="value">原始int播放量/点赞量等数据</param>
        /// <returns>格式化后的播放数字符串(如1234→"1234"，15000→"1.5万")</returns>
        public static string FormatPlayCount(this int value) =>
            value >= 10000 ? $"{(double)value / 10000:0.##} 万" : value.ToString();

        /// <summary>
        /// 识别Unix时间戳并转换为字符串
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns>字符串格式的时间(YYYY-MM-DD)</returns>
        public static string? FormatUnixTime<T>(this T value) => DateTime.TryParse(value?.ToString(),
            CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt)
            ? dt.ToString("yyyy-MM-dd")
            : value?.ToString();

        /// <summary>
        /// 将ISO 8601格式(YYYY-MM-DDTHH:mm:ss[.fff]Z)的UTC时间转换为本地时间
        /// 兼容带毫秒(.fff)和不带毫秒的两种格式
        /// </summary>
        /// <param name="value">ISO 8601 格式的时间字符串(带Z后缀，可含毫秒)</param>
        /// <returns>格式化后的本地时间字符串，格式：yyyy-M-d dddd</returns>
        /// <exception cref="ArgumentException">输入时间字符串格式无效/为空时抛出</exception>
        public static string FormatISO8601TimeToLocal(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("输入的ISO 8601时间字符串不能为空", nameof(value));

            return DateTime.TryParseExact(
                value,
                new[] { "yyyy-MM-dd'T'HH:mm:ss.fffZ", "yyyy-MM-dd'T'HH:mm:ssZ" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal,
                out var utcTime)
                ? utcTime.ToLocalTime().ToString("yyyy-M-d dddd", CultureInfo.CurrentCulture)
                : throw new ArgumentException($"无效的ISO 8601时间格式：{value}，请确保格式为 YYYY-MM-DDTHH:mm:ss[.fff]Z",
                    nameof(value));
        }

        /// <summary>
        /// 识别总长时间并转换为HH:MM:SS格式的字符串
        /// </summary>
        /// <param name="value">时间 (秒)</param>
        /// <returns>HH:MM:SS 格式的时间字符串</returns>
        public static string FormatSecondsTime(this int value) =>
            value < 0 ? "00:00:00" : $"{(value / 3600 == 0 ? "00" : (value / 3600).ToString())}";
    }
}