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
            if (string.IsNullOrEmpty(city_Or_adcode))
            {
                WriteLog.Error(LogKind.Network,
                    $"{_value_Not_Is_NullOrEmpty("city_Or_adcode")}, 错误代码: {_String_NullOrEmpty}");
                MessageBox_I.Error($"{_value_Not_Is_NullOrEmpty("city_Or_adcode")}, 错误代码: {_String_NullOrEmpty}",
                    _ERROR);
                return null;
            }

            var requestUrl = $"https://uapis.cn/api/v1/misc/weather?{param}={city_Or_adcode}" +
                             (extended ? "&extended=true" : "") +
                             (indices ? "&indices=true" : "") +
                             (forecast ? "&forecast=true" : "");
            var (result, statusCode) = await Interface.GetResult<WeatherType>(requestUrl);
            if (!IsGetSuccessful(result, statusCode))
                WriteLog.Error(("请求失败, 请重试"));
            return result;
        }

        internal static bool IsGetSuccessful(WeatherType Type, int StatusCode)
        {
            if (Type == null) return false;
            switch (StatusCode) // 修改为通过实例访问 code 属性
            {
                case 400:
                    WriteLog.Error(LogKind.Network,
                        $"{_value_Not_Is_NullOrEmpty("city_Or_adcode")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.message}");
                    MessageBox_I.Error(
                        $"{_value_Not_Is_NullOrEmpty("city_Or_adcode")}, 错误代码: {_String_NullOrEmpty}, 错误信息: {Type.code} - {Type.message}",
                        _ERROR);
                    break;
                case 404:
                case 410:
                    WriteLog.Error(LogKind.Network,
                        $"请求的城市不存在或未找到, 错误代码: {_Weather_City_Not_Found}, 错误信息: {Type.code} - {Type.message}");
                    MessageBox_I.Error(
                        $"请求的城市不存在或未找到, 错误代码: {_Weather_City_Not_Found}, 错误信息: {Type.code} - {Type.message}",
                        _ERROR);
                    break;
                case 502:
                    WriteLog.Error(LogKind.Network,
                        $"上游服务错误, 天气供应商API暂时不可用或返回了错误, 错误代码: {_Weather_Service_Error}, 错误信息: {Type.code} - {Type.message}");
                    MessageBox_I.Error(
                        $"上游服务错误, 天气供应商API暂时不可用或返回了错误, 错误代码: {_Weather_Service_Error}, 错误信息: {Type.code} - {Type.message}",
                        _ERROR);
                    throw new IException.Weather.WeatherServiceError();
                case 500:
                    WriteLog.Error(LogKind.Network,
                        $"服务器内部错误。在处理天气数据时发生了未知问题, 错误代码: {_Weather_Unknow_Exception}, 错误信息: {Type.code} - {Type.message}");
                    MessageBox_I.Error(
                        $"服务器内部错误。在处理天气数据时发生了未知问题, 错误代码: {_Weather_Unknow_Exception}, 错误信息: {Type.code} - {Type.message}",
                        _ERROR);
                    throw new IException.Weather.WeatherAPIServerError();
                case -1:
                    WriteLog.Error(LogKind.Network, "请求失败, 请查找错误并提交日志给工作人员");
                    MessageBox_I.Error("请求失败, 请查找错误并提交日志给工作人员", _ERROR);
                    break;

                case 200:
                    WriteLog.Info(LogKind.Network, $"请求成功");
                    break;
                default:
                    WriteLog.Error(LogKind.Network, $"未知异常, 请联系管理员, 错误代码: {_UNKNOW_ERROR}");
                    throw new IException.General.UAPIUnknowException();
            }

            return false;
        }
    }
}