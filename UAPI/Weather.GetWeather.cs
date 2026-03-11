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
        /// <param name="extended">是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。</param>
        /// <param name="indices">是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。</param>
        /// <param name="forecast">是否返回预报数据(当日最高/最低气温及未来3天天气预报)。</param>
        /// <param name="hourly">逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等</param>
        /// <param name="minutely">分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个</param>
        /// <exception cref="IException.Weather.WeatherServiceError()">天气供应商的上游服务不可用, 这可能是他们的服务暂时中断</exception>
        /// <returns><see cref="WeatherType"/> 类型的 <see cref="Json"/> 对象</returns>
        public static async Task<WeatherType> GetWeatherDataJson(string city, bool extended = false,
            bool indices = false, bool forecast = false, bool hourly = false, bool minutely = false) =>
            await SendMessageRequest(city, "city", extended, indices, forecast, hourly, minutely);

        /// <summary>
        /// 获取天气信息
        /// </summary>
        /// <param name="adcode">高德地图的6位数字城市编码</param>
        /// <param name="extended">是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。</param>
        /// <param name="indices">是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。</param>
        /// <param name="forecast">是否返回预报数据(当日最高/最低气温及未来3天天气预报)。</param>
        /// <param name="hourly">逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等</param>
        /// <param name="minutely">分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个</param>
        /// <exception cref="IException.Weather.WeatherServiceError()">天气供应商的上游服务不可用, 这可能是他们的服务暂时中断</exception>
        /// <returns><see cref="WeatherType"/> 类型的 <see cref="Json"/> 对象</returns>
        public static async Task<WeatherType> GetWeatherDataJson(int adcode, bool extended = false,
            bool indices = false, bool forecast = false, bool hourly = false, bool minutely = false) =>
            await SendMessageRequest(adcode.ToString(), "adcode", extended, indices, forecast, hourly, minutely);

        /// <summary>
        /// 获取天气信息
        /// </summary>
        /// <param name="city_Or_adcode">城市名称或<br/>高德地图的6位数字城市编码</param>
        /// <param name="param">方法</param>
        /// <param name="extended">是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。</param>
        /// <param name="indices">是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。</param>
        /// <param name="forecast">是否返回预报数据(当日最高/最低气温及未来3天天气预报)。</param>
        /// <param name="hourly">逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等</param>
        /// <param name="minutely">分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个</param>
        /// <param name="AuthenticationAPITokenKey">API Token</param>
        /// <returns><see cref="WeatherType"/> 类型的 <see cref="Json"/> 对象</returns>
        private static async Task<WeatherType> SendMessageRequest(string city_Or_adcode, string param,
            bool extended = false, bool indices = false, bool forecast = false, bool hourly = false,
            bool minutely = false, string AuthenticationAPITokenKey = "")
        {
            var requestUrl = $"https://uapis.cn/api/v1/misc/weather?{param}={city_Or_adcode}" +
                             (extended ? "&extended=true" : "") +
                             (indices ? "&indices=true" : "") +
                             (forecast ? "&forecast=true" : "") +
                             (hourly ? "&hourly=true" : "") +
                             (minutely ? "&minutely=true" : "");
            var (result, statusCode) = await Interface.GetResult<WeatherType>(requestUrl, AuthenticationAPITokenKey);
            if (!Interface.IsGetSuccessful(result, "city_or_adcode", statusCode,
                    new IException.Weather.WeatherServiceError(), "天气供应商", _Weather_Service_Error))
                WriteLog.Error(("请求失败, 请重试"));
            return result;
        }
    }
}