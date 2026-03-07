using System.Collections.Generic;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Weather
    {
        /// <summary>
        /// 获取指定城市的数据更新时间信息属性
        /// </summary>
        public class WeatherType : Interface.TypeInterface
        {
            /// <summary>
            /// 省份名称
            /// </summary>
            [JsonProperty("province")]
            public string Province { get; set; }

            /// <summary>
            /// 城市名称
            /// </summary>
            [JsonProperty("city")]
            public string City { get; set; }

            /// <summary>
            /// 区县名称
            /// </summary>
            [JsonProperty("district")]
            public string District { get; set; }

            /// <summary>
            /// <see langword="int"/>高德地图的6位数字城市编码
            /// </summary>
            [JsonProperty("adcode")]
            public string Adcode { get; set; }

            /// <summary>
            /// 天气状况
            /// </summary>
            [JsonProperty("weather")]
            public string Weather { get; set; }

            /// <summary>
            /// 和风天气的Weather Icon, 用于前端显示
            /// </summary>
            [JsonProperty("weather_icon")]
            public string WeatherIcon { get; set; }

            /// <summary>   
            /// <see langword="double"/> 温度
            /// </summary>
            [JsonProperty("temperature")]
            public double Temperature { get; set; }

            /// <summary>
            /// 风向
            /// </summary>
            [JsonProperty("wind_direction")]
            public string WindDirection { get; set; }

            /// <summary>
            /// 风力等级
            /// </summary>
            [JsonProperty("wind_power")]
            public string WindPower { get; set; }

            /// <summary>
            /// 湿度
            /// </summary>
            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            /// <summary>
            /// 数据更新时间	
            /// </summary>
            [JsonProperty("report_time")]
            public string ReportTime { get; set; }

            /// <summary>
            /// <see langword="double"/> 一天中的最高温度
            /// </summary>
            [JsonProperty("temp_max")]
            public double MaxTemperature { get; set; }

            /// <summary>
            /// <see langword="double"/> 一天中的最低温度
            /// </summary>
            [JsonProperty("temp_min")]
            public double MinTemperature { get; set; }

            /// <summary>
            /// <see cref="List{Forcast}"/> 未来三天的天气预报
            /// </summary>
            public List<Forecast> forecast { get; set; }

            /// <summary>
            /// 体感温度 °C(extended=true 时返回)
            /// </summary>
            [JsonProperty("feels_like")]
            public double FeelsLikeTemperature { get; set; }

            /// <summary>
            /// 能见度 km(extended=true 时返回)
            /// </summary>
            [JsonProperty("visibility")]
            public double Visibility { get; set; }

            /// <summary>
            /// 气压 hPa(extended=true 时返回)
            /// </summary>
            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            /// <summary>
            /// 紫外线指数 0-11+(extended=true 时返回)
            /// </summary>
            [JsonProperty("uv")]
            public double UV { get; set; }

            /// <summary>
            /// 空气质量指数 0-500(extended=true 时返回)
            /// </summary>
            [JsonProperty("aqi")]
            public double AQI { get; set; }

            /// <summary>
            /// 空气质量指数等级 1-6 (extended=true 时返回)
            /// </summary>
            [JsonProperty("aqi_level")]
            public double AQILevel { get; set; }

            /// <summary>
            /// AQI 等级描述 优/良/轻度污染/中度污染/重度污染/严重污染
            /// </summary>
            [JsonProperty("aqi_category")]
            public string AQICategory { get; set; }

            /// <summary>
            /// 主要污染物 (如 PM2.5、PM10、O3 等)
            /// </summary>
            [JsonProperty("aqi_primary")]
            public string AQIPrimary { get; set; }

            /// <summary>
            /// 空气污染物分项数据
            /// </summary>
            [JsonProperty("air_pollutants")]
            public Air_pollutants AirPollutants { get; set; }

            /// <summary>
            /// 降水量 mm(extended=true 时返回)
            /// </summary>
            [JsonProperty("precipitation")]
            public double Precipitation { get; set; }

            /// <summary>
            /// 云量 %(extended=true 时返回)
            /// </summary>
            [JsonProperty("cloud")]
            public double Cloud { get; set; }

            /// <summary>
            /// 分钟级降水预报
            /// </summary>
            [JsonProperty("minutely_precip")]
            public minutely_Precipitation MinutelyPrecipitation { get; set; }

            /// <summary>
            /// 生活指数
            /// </summary>
            public Life_Indices life_indices { get; set; }

            /// <summary>
            /// 每小时天气预报
            /// </summary>
            [JsonProperty("hourly_forecast")]
            public List<Hourly_forecastItem> HourlyForecast { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public class Hourly_forecastItem
            {
                /// <summary>
                /// 预报时间 ISO8601 或 YYYY-MM-DD HH:MM
                /// </summary>
                [JsonProperty("time")]
                public string Time { get; set; }

                /// <summary>
                /// 温度 °C
                /// </summary>
                [JsonProperty("temperature")]
                public double Temperature { get; set; }

                /// <summary>
                /// 天气状况
                /// </summary>
                [JsonProperty("weather")]
                public string Weather { get; set; }

                /// <summary>
                /// 风向
                /// </summary>
                [JsonProperty("wind_direction")]
                public string WindDirection { get; set; }

                /// <summary>
                /// 风速 km/h
                /// </summary>
                [JsonProperty("wind_speed")]
                public double WindSpeed { get; set; }

                /// <summary>
                /// 风力等级
                /// </summary>
                [JsonProperty("wind_scale")]
                public string WindPower { get; set; }

                /// <summary>
                /// 湿度 %
                /// </summary>
                [JsonProperty("pressure")]
                public double Pressure { get; set; }

                /// <summary>
                /// 降水量
                /// </summary>
                [JsonProperty("precip")]
                public double Precipitation { get; set; }

                /// <summary>
                /// 云量
                /// </summary>
                [JsonProperty("cloud")]
                public double Cloud { get; set; }

                /// <summary>
                /// 体感温度 °C
                /// </summary>
                [JsonProperty("feels_like")]
                public double FeelsLikeTemperature { get; set; }

                /// <summary>
                /// 露点温度 °C
                /// </summary>
                [JsonProperty("dew_point")]
                public double dew_point { get; set; }

                /// <summary>
                /// 能见度 km
                /// </summary>
                [JsonProperty("visibility")]
                public double Visibility { get; set; }

                /// <summary>
                /// 降水概率 %
                /// </summary>
                [JsonProperty("pop")]
                public double pop { get; set; }

                /// <summary>
                /// 紫外线指数
                /// </summary>
                [JsonProperty("uv_index")]
                public double UV { get; set; }
            }

            /// <summary>
            /// 
            /// </summary>
            public class minutely_Precipitation
            {
                /// <summary>
                /// 分钟级降水预报
                /// </summary>
                public string summary { get; set; }

                /// <summary>
                /// 更新时间
                /// </summary>
                [JsonProperty("update_time")]
                public string UpdateTime_ISO8601 { get; set; }

                /// <summary>
                /// 每5分钟一个数据点，共24个
                /// </summary>
                public List<min_data> data { get; set; }
            }

            /// <summary>
            /// 
            /// </summary>
            public class min_data
            {
                /// <summary>
                /// 预报时间
                /// </summary>
                public string time { get; set; }

                /// <summary>
                /// 降水量
                /// </summary>
                [JsonProperty("precip")]
                public double Precipitation { get; set; }

                /// <summary>
                /// 降水类型
                /// </summary>
                [JsonProperty("type")]
                public string Type { get; set; }
            }

            /// <summary>
            /// 空气污染分项数据
            /// </summary>
            public class Air_pollutants
            {
                /// <summary>
                /// PM 2.5  μg/m³
                /// </summary>
                [JsonProperty("pm25")]
                public double pm25 { get; set; }

                /// <summary>
                /// PM10  μg/m³
                /// </summary>
                [JsonProperty("pm10")]
                public double pm10 { get; set; }

                /// <summary>
                /// 臭氧  μg/m³
                /// </summary>
                [JsonProperty("o3")]
                public double o3 { get; set; }

                /// <summary>
                /// 二氧化氮  μg/m³
                /// </summary>
                [JsonProperty("no2")]
                public double no2 { get; set; }

                /// <summary>
                /// 二氧化硫  μg/m³
                /// </summary>
                [JsonProperty("so2")]
                public double so2 { get; set; }

                /// <summary>
                /// 一氧化碳  μg/m³
                /// </summary>
                [JsonProperty("co")]
                public double co { get; set; }
            }

            /// <summary>
            /// 
            /// </summary>
            public class IndicesLevel
            {
                /// <summary>
                /// 等级
                /// </summary>
                [JsonProperty("level")]
                public string Level { get; set; }

                /// <summary>
                /// 简述
                /// </summary>
                [JsonProperty("brief")]
                public string Brief { get; set; }

                /// <summary>
                /// 建议
                /// </summary>
                [JsonProperty("advice")]
                public string Advice { get; set; }
            }

            /// <summary>
            /// 生活指数(indices=true 时返回)
            /// </summary>
            public class Life_Indices
            {
                /// <summary>
                /// 穿衣指数
                /// </summary>
                [JsonProperty("clothing")]
                public IndicesLevel Clothing { get; set; }

                /// <summary>
                /// 紫外线指数
                /// </summary>
                [JsonProperty("uv")]
                public IndicesLevel UV { get; set; }

                /// <summary>
                /// 洗车指数
                /// </summary>
                [JsonProperty("car_wash")]
                public IndicesLevel CarWash { get; set; }

                /// <summary>
                /// 晾晒指数
                /// </summary>
                [JsonProperty("drying")]
                public IndicesLevel Drying { get; set; }

                /// <summary>
                /// 空调指数
                /// </summary>
                [JsonProperty("air_conditioner")]
                public IndicesLevel AirConditioner { get; set; }

                /// <summary>
                /// 感冒指数
                /// </summary>
                [JsonProperty("cold_risk")]
                public IndicesLevel ColdRisk { get; set; }

                /// <summary>
                /// 运动指数
                /// </summary>
                [JsonProperty("exercise")]
                public IndicesLevel Exercise { get; set; }

                /// <summary>
                /// 舒适度指数
                /// </summary>
                [JsonProperty("comfort")]
                public IndicesLevel Comfort { get; set; }

                /// <summary>
                /// 出行指数
                /// </summary>
                [JsonProperty("travel")]
                public IndicesLevel Travel { get; set; }

                /// <summary>
                /// 钓鱼指数
                /// </summary>
                [JsonProperty("fishing")]
                public IndicesLevel Fishing { get; set; }

                /// <summary>
                /// 过敏指数
                /// </summary>
                [JsonProperty("allergy")]
                public IndicesLevel Allergy { get; set; }

                /// <summary>
                /// 防晒指数
                /// </summary>
                [JsonProperty("sunscreen")]
                public IndicesLevel SunScreen { get; set; }

                /// <summary>
                /// 心情指数
                /// </summary>
                [JsonProperty("mood")]
                public IndicesLevel Mood { get; set; }

                /// <summary>
                /// 啤酒指数
                /// </summary>
                [JsonProperty("beer")]
                public IndicesLevel Beer { get; set; }

                /// <summary>
                /// 雨伞指数
                /// </summary>
                [JsonProperty("umbrella")]
                public IndicesLevel Umbrella { get; set; }

                /// <summary>
                /// 交通指数
                /// </summary>
                [JsonProperty("traffic")]
                public IndicesLevel Traffic { get; set; }

                /// <summary>
                /// 空气净化器指数
                /// </summary>
                [JsonProperty("air_purifier")]
                public IndicesLevel AirPurifier { get; set; }

                /// <summary>
                /// 花粉扩散指数
                /// </summary>
                [JsonProperty("pollen")]
                public IndicesLevel Pollen { get; set; }
            }

            /// <summary>
            /// 未来3天天气预报(forecast=true 时返回)
            /// </summary>
            public class Forecast
            {
                /// <summary>
                /// 预告日期
                /// </summary>
                public string date { get; set; }

                /// <summary>
                /// 星期几
                /// </summary>
                [JsonProperty("week")]
                public string week { get; set; }

                /// <summary>
                /// <see langword="double"/> 一天中的最高温度
                /// </summary>
                [JsonProperty("temp_max")]
                public double MaxTemperature { get; set; }

                /// <summary>
                /// <see langword="double"/> 一天中的最低温度
                /// </summary>
                [JsonProperty("temp_min")]
                public double MinTemperature { get; set; }

                /// <summary>
                /// 白天天气
                /// </summary>
                [JsonProperty("weather_day")]
                public string DayWeather { get; set; }

                /// <summary>
                /// 白天风向
                /// </summary>
                [JsonProperty("wind_dir_day")]
                public string DayWindDirection { get; set; }

                /// <summary>
                /// 夜间风向
                /// </summary>
                [JsonProperty("wind_dir_night")]
                public string NightWindDirection { get; set; }

                /// <summary>
                /// 白天风力
                /// </summary>
                [JsonProperty("wind_scale_day")]
                public string DayWindPower { get; set; }

                /// <summary>
                /// 夜间风力
                /// </summary>
                [JsonProperty("wind_scale_night")]
                public string NightWindPower { get; set; }

                /// <summary>
                /// 夜间天气
                /// </summary>
                [JsonProperty("weather_night")]
                public string NightWeather { get; set; }

                /// <summary>
                /// 白天风速
                /// </summary>
                [JsonProperty("wind_speed_day")]
                public double DayWindSpeed { get; set; }

                /// <summary>
                /// 夜间风速
                /// </summary>
                [JsonProperty("wind_speed_night")]
                public double NightWindSpeed { get; set; }

                /// <summary>
                /// <see langword="int"/> 湿度
                /// </summary>
                [JsonProperty("humidity")]
                public double Humidity { get; set; }

                /// <summary>
                /// 降水量 mm
                /// </summary>
                [JsonProperty("precip")]
                public double Precipitation { get; set; }

                /// <summary>
                /// 能见度 km
                /// </summary>
                [JsonProperty("visibility")]
                public double Visibility { get; set; }

                /// <summary>
                /// 紫外线指数 0-11+
                /// </summary>
                [JsonProperty("uv_index")]
                public double UV { get; set; }

                /// <summary>
                /// 日出时间 (HH:MM)
                /// </summary>
                [JsonProperty("sunrise")]
                public string SunriseTime { get; set; }

                /// <summary>
                /// 日落时间 (HH:MM)
                /// </summary>
                [JsonProperty("sunset")]
                public string SunsetTime { get; set; }
            }
        }
    }
}