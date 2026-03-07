# 天气请求

## 请求示例

```csharp
var request = await UAPI.Weather.GetWeatherDataJson(string city,
                    bool extended = false, bool indices = false,
                    bool forecast = false, bool hourly = false,
                    bool minutely = false);
    		= await UAPI.Weather.GetWeatherDataJson(int adcode, 
                    bool extended = false, bool indices = false, 
                    bool forecast = false, bool hourly = false,
                    bool minutely = false);
```

* 参数选项:
  * **city:** 指定要查询天气的城市
  * **adcode:** 指定要查询天气的城市的高德地图的6位数字城市编码
  * **extended:** 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 `false`
  * **indices:** 是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）, 默认为 `false`
  * **forecast:** 是否返回预报数据（当日最高/最低气温及未来3天天气预报）, 默认为 `false`
  * **hourly**: 是否返回逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等
  * **minutely**:是否返回分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个
* **返回类型:** `Task <UAPI.Weather.WeatherType>`
* **返回值:** `WeatherType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.Weather.WeatherServiceError()`:  天气供应商的上游服务不可用, 这可能是他们的服务暂时中断
  

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **Province**| 省份名称 | |
|`string` **City**| 城市名称 | |
|`string` **District**| 区县名称 | |
|`int` **Adcode**| 高德地图的6位数字城市编码 | |
|`string` **Weather**| 天气状况 | |
|`string` **WeatherIcon**| 和风天气的Weather Icon, 用于前端显示 | |
|`double` **Temperature**| 温度 | |
|`string` **WindDirection**| 风向 | |
|`string` **WindPower**| 风力等级 | |
|`double` **Humidity**| 湿度 | |
|`string` **ReportTime**| 数据更新时间 | |
|`double` **MaxTemperature**| 一天中的最高温度 | |
|`double` **MinTemperature**| 一天中的最低温度 | |
|`List<Forecast>` **forecast**| 未来三天的天气预报 | |
|`double` **FeelsLikeTemperature**| 体感温度 | `extended=true` 时返回 |
|`double` **Visibility**| 能见度 | `extended=true` 时返回 |
|`double` **Pressure**| 气压 | `extended=true 时返回`| |
|`double` **UV**| 紫外线指数 | `extended=true` 时返回 |
|`double` **AQI**| 空气质量指数 | `extended=true` 时返回 |
|`double` **AQILevel**| 空气质量指数等级 | `extended=true` 时返回 |
|`string` **AQICategory**| AQI 等级描述 | 优/良/轻度污染/中度污染/重度污染/严重污染<br/> `extended=true` 时返回 |
|`string` **AQIPrimary**| 主要污染物 | `extended=true` 时返回 |
|`string` **AirPollutants**| 空气污染物分项数据 | `extended=true` 时返回 |
|`double` **Precipitation**| 降水量 | `extended=true` 时返回 |
|`double` **Cloud**| 云量 | `extended=true` 时返回 |
|`minutely_Precipitation` **MinutelyPrecipitation** | 分钟级降水预报 | `minutely=true` 时返回 |
|`Life_Indices` **life_indices**| 生活指数 | |
|`List<Hourly_forecastItem>` **HourlyForecast** | 每小时天气预报 | |

___
#### `List<Forecast>` **forecast** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **date**| 预告日期 | | |
|`string` **week**| 星期几 | | |
|`double` **MaxTemperature**| 一天中的最高温度 | | |
|`double` **MinTemperature**| 一天中的最低温度 | | |
|`string` **DayWeather**| 白天天气 | | |
|`string` **DayWindDirection**| 白天风向 | | |
|`string` **NightWindDirection**| 夜间风向 | | |
|`string` **DayWindPower**| 白天风力 | | |
|`string` **NightWindPower**| 夜间风力 | | |
|`string` **NightWeather**| 夜间天气 | | |
|`double` **DayWindSpeed** | 白天风速 | | |
|`double` **NightWindSpeed** | 夜间风速 | | |
|`double` **Humidity**| 湿度 | | |
|`double` **Precipitation**| 降水量 | | |
|`double` **Visibility**| 能见度 | | |
|`double` **UV**| 紫外线指数 | | 0-11+ |
|`string` **SunriseTime**| 日出时间 | | 格式 HH:MM |
|`string` **SunsetTime**| 日落时间 | | 格式 HH:MM |
___

#### `Life_Indices` **life_indices** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`IndicesLevel` **Clothing**| 穿衣指数 | | |
|`IndicesLevel` **UV**| 紫外线指数 | | |
|`IndicesLevel` **CarWash**| 洗车指数 | | |
|`IndicesLevel` **Drying**| 晾晒指数 | | |
|`IndicesLevel` **AirConditioner**| 空调指数 | | |
|`IndicesLevel` **ColdRisk**| 感冒指数 | | |
|`IndicesLevel` **Exercise**| 运动指数 | | |
|`IndicesLevel` **Comfort**| 舒适度指数 | | |
|`IndicesLevel` **Travel**| 出行指数 | | |
|`IndicesLevel` **Fishing**| 钓鱼指数 | | |
|`IndicesLevel` **Allergy**| 过敏指数 | | |
|`IndicesLevel` **SunScreen**| 防晒指数 | | |
|`IndicesLevel` **Mood**| 心情指数 | | |
|`IndicesLevel` **Beer**| 啤酒指数 | | |
|`IndicesLevel` **Umbrella**| 雨伞指数 | | |
|`IndicesLevel` **Traffic**| 交通指数 | | |
|`IndicesLevel` **AirPurifier**| 空气净化器指数 | | |
|`IndicesLevel` **Pollen**| 花粉扩散指数 | | |

##### `IndicesLevel` 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **Level**| 等级 | | |
|`string` **Brief**| 简述 | | |
|`string` **Advice**| 建议 | | |

#### `List<Hourly_forecastItem>` **HourlyForecast** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **Time**| 预报时间 | | 格式 ISO8601 或 YYYY-MM-DD HH:MM |
|`double` **Temperature**| 温度 | | |
|`string` **Weather**| 天气状况 | | |
|`string` **WindDirection**| 风向 | | |
|`double` **WindSpeed**| 风速 | | |
|`string` **WindPower**| 风力等级 | | |
|`double` **Pressure**| 湿度 | | |
|`double` **Precipitation**| 降水量 | | |
|`double` **Cloud**| 云量 | | |
|`double` **FeelsLikeTemperature**| 体感温度 | | |
|`double` **dew_point**| 露点温度 | | |
|`double` **Visibility**| 能见度 | | |
|`double` **pop**| 降水概率 | | |
|`double` **UV**| 紫外线指数 | | |

#### `minutely_Precipitation` **MinutelyPrecipitation** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **summary** | 分钟级降水预报 | | |
| `string` **UpdateTime_ISO8601** | 更新时间 | | |
| `List<min_data>` **data**| 每5分钟一个数据点，共24个 | | |

##### `List<min_data>` **data** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **time** | 预报时间 | | |
| `double`