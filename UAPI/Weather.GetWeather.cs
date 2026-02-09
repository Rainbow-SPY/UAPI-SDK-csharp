using System.Threading.Tasks;
using Rox.Text;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace UAPI
{
    /// <summary>
    /// 天气查询, 但是新版本
    /// </summary>
    public partial class Weather
    {
        /// <summary>
        /// 获取天气信息
        /// </summary>
        /// <param name="city">城市名称</param>
        /// <param name="extended">是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）。</param>
        /// <param name="indices">是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）。</param>
        /// <param name="forecast">是否返回预报数据（当日最高/最低气温及未来3天天气预报）。</param>
        /// <returns><see cref="WeatherType"/> 类型的 <see cref="Json"/> 对象</returns>
        public static async Task<WeatherType> GetWeatherDataJson(string city, bool extended = false,
            bool indices = false, bool forecast = false) =>
            await SendMessageRequest(city, "city", extended, indices, forecast);

        /// <summary>
        /// 获取天气信息
        /// </summary>
        /// <param name="adcode">高德地图的6位数字城市编码</param>
        /// <param name="extended">是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）。</param>
        /// <param name="indices">是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）。</param>
        /// <param name="forecast">是否返回预报数据（当日最高/最低气温及未来3天天气预报）。</param>
        /// <returns><see cref="WeatherType"/> 类型的 <see cref="Json"/> 对象</returns>
        public static async Task<WeatherType> GetWeatherDataJson(int adcode, bool extended = false,
            bool indices = false, bool forecast = false) =>
            await SendMessageRequest(adcode.ToString(), "adcode", extended, indices, forecast);

        /// <summary>
        /// 获取天气信息
        /// </summary>
        /// <param name="city_Or_adcode">城市名称或<br/>高德地图的6位数字城市编码</param>
        /// <param name="param">方法</param>
        /// <param name="extended">是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）。</param>
        /// <param name="indices">是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）。</param>
        /// <param name="forecast">是否返回预报数据（当日最高/最低气温及未来3天天气预报）。</param>
        /// <returns><see cref="WeatherType"/> 类型的 <see cref="Json"/> 对象</returns>
        private static async Task<WeatherType> SendMessageRequest(string city_Or_adcode, string param,
            bool extended = false, bool indices = false, bool forecast = false)
        {
            var requestUrl = $"https://uapis.cn/api/v1/misc/weather?{param}={city_Or_adcode}" +
                             (extended ? "&extended=true" : "") +
                             (indices ? "&indices=true" : "") +
                             (forecast ? "&forecast=true" : "");
            var (result, statusCode) = await Interface.GetResult<WeatherType>(requestUrl);
            if (!Interface.IsGetSuccessful<WeatherType>(result, "city_or_adcode", statusCode,
                    new IException.Weather.WeatherServiceError(), "天气供应商", _Weather_Service_Error))
                WriteLog.Error(("请求失败, 请重试"));
            return result;
        }
    }
}