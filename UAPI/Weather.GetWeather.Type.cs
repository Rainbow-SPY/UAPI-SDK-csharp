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
            /// <see langword="int"/>高德地图的6位数字城市编码
            /// </summary>
            [JsonProperty("adcode")]
            public int Adcode { get; set; }

            /// <summary>
            /// 天气状况
            /// </summary>
            [JsonProperty("weather")]
            public string Weather { get; set; }

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
            /// 未来3天天气预报(forecast=true 时返回)
            /// </summary>
            public class Forecast
            {
                /// <summary>
                /// 预告日期
                /// </summary>
                public string date { get; set; }

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
            }

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
            /// 生活指数
            /// </summary>
            public Life_Indices life_indices { get; set; }

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
            }
        }
    }
}