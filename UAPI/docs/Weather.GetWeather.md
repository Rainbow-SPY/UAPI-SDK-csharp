# 天气请求

> [!WARNING]
>
> **此页面已过时**

## 请求示例

```csharp
var request = await UAPI.Weather.GetWeatherDataJson(string city,
                    bool extended = false, bool indices = false,
                    bool forecast = false, bool hourly = false,
                    bool minutely = false, string Authentication = "");
    		= await UAPI.Weather.GetWeatherDataJson(int adcode, 
                    bool extended = false, bool indices = false, 
                    bool forecast = false, bool hourly = false,
                    bool minutely = false, string Authentication = "");
```

* 参数选项:
  * **city:** 指定要查询天气的城市
  * **adcode:** 指定要查询天气的城市的高德地图的6位数字城市编码
  * **extended:** 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 `false`
  * **indices:** 是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）, 默认为 `false`
  * **forecast:** 是否返回预报数据（当日最高/最低气温及未来3天天气预报）, 默认为 `false`
  * **hourly**: 是否返回逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等
  * **minutely**:是否返回分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个
  * **Authentication**: API Token, 默认为空
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
|`string` **Province**| 省份名称 | 原始`Json`传入:`province` |
|`string` **City**| 城市名称 | 原始`Json`传入:`city` |
|`string` **District**| 区县名称 | 原始`Json`传入:`district` |
|`int` **Adcode**| 高德地图的6位数字城市编码 | 原始`Json`传入:`adcode` |
|`string` **Weather**| 天气状况 | 原始`Json`传入:`weather` |
|`string` **WeatherIcon**| 和风天气的Weather Icon, 用于前端显示 | 原始`Json`传入:`weather_icon` |
|`double` **Temperature**| 温度 | 原始`Json`传入:`temperature` |
|`string` **WindDirection**| 风向 | 原始`Json`传入:`wind_direction` |
|`string` **WindPower**| 风力等级 | 原始`Json`传入:`wind_power` |
|`double` **Humidity**| 湿度 | 原始`Json`传入:`humidity` |
|`string` **ReportTime**| 数据更新时间 | 原始`Json`传入:`report_time` |
|`double` **MaxTemperature**| 一天中的最高温度 | 原始`Json`传入:`temp_max` |
|`double` **MinTemperature**| 一天中的最低温度 | 原始`Json`传入:`temp_min` |
|`List<Forecast>` **forecast**| 未来三天的天气预报 |  |
|`double` **FeelsLikeTemperature**| 体感温度 | 原始`Json`传入:`feels_like`<br/>`extended=true` 时返回 |
|`double` **Visibility**| 能见度 | 原始`Json`传入:`visibility`<br/>extended=true` 时返回 |
|`double` **Pressure**| 气压 | 原始`Json`传入:`pressure`<br/>`extended=true 时返回` |
|`double` **UV**| 紫外线指数 | 原始`Json`传入:`uv`<br/>`extended=true` 时返回 |
|`double` **AQI**| 空气质量指数 | 原始`Json`传入:`aqi`<br/>`extended=true` 时返回 |
|`double` **AQILevel**| 空气质量指数等级 | 原始`Json`传入:`aqi_level`<br/>`extended=true` 时返回 |
|`string` **AQICategory**| AQI 等级描述 | 原始`Json`传入:`aqi_category`<br/>优/良/轻度污染/中度污染/重度污染/严重污染<br/> `extended=true` 时返回 |
|`string` **AQIPrimary**| 主要污染物 | 原始`Json`传入:`aqi_primary`<br/>`extended=true` 时返回 |
|`Air_pollutants` **AirPollutants**| 空气污染物分项数据 | 原始`Json`传入:`air_pollutants`<br/>`extended=true` 时返回 |
|`double` **Precipitation**| 降水量 | 原始`Json`传入:`precipitation`<br/>`extended=true` 时返回 |
|`double` **Cloud**| 云量 | 原始`Json`传入:`cloud`<br/>`extended=true` 时返回 |
|`minutely_Precipitation` **MinutelyPrecipitation** | 分钟级降水预报 | 原始`Json`传入:`minutely_precip`<br/>`minutely=true` 时返回 |
|`Life_Indices` **life_indices**| 生活指数 |  |
|`List<Hourly_forecastItem>` **HourlyForecast** | 每小时天气预报 |  |

___
#### `List<Forecast>` **forecast** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **Date**| 预告日期 | | 原始`Json`传入:`date` |
|`string` **Week**| 星期几 | | 原始`Json`传入:`week` |
|`double` **MaxTemperature**| 一天中的最高温度 | | 原始`Json`传入:`temp_max` |
|`double` **MinTemperature**| 一天中的最低温度 | | 原始`Json`传入:`temp_min` |
|`string` **DayWeather**| 白天天气 | | 原始`Json`传入:`weather_day` |
|`string` **DayWindDirection**| 白天风向 | | 原始`Json`传入:`wind_dir_day` |
|`string` **NightWindDirection**| 夜间风向 | | 原始`Json`传入:`wind_dir_night` |
|`string` **DayWindPower**| 白天风力 | | 原始`Json`传入:`wind_scale_day` |
|`string` **NightWindPower**| 夜间风力 | | 原始`Json`传入:`wind_scale_night` |
|`string` **NightWeather**| 夜间天气 | | 原始`Json`传入:`weather_night` |
|`double` **DayWindSpeed** | 白天风速 | | 原始`Json`传入:`wind_speed_day` |
|`double` **NightWindSpeed** | 夜间风速 | | 原始`Json`传入:`wind_speed_night` |
|`double` **Humidity**| 湿度 | | 原始`Json`传入:`humidity` |
|`double` **Precipitation**| 降水量 | | 原始`Json`传入:`precip` |
|`double` **Visibility**| 能见度 | | 原始`Json`传入:`visibility` |
|`double` **UV**| 紫外线指数 | | 原始`Json`传入:`uv_index`<br/>0-11+ |
|`string` **SunriseTime**| 日出时间 | | 原始`Json`传入:`sunrise`<br/>格式 HH:MM |
|`string` **SunsetTime**| 日落时间 | | 原始`Json`传入:`sunset`<br/>格式 HH:MM |
___

#### `Life_Indices` **life_indices** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`IndicesLevel` **Clothing**| 穿衣指数 | | 原始`Json`传入:`clothing` |
|`IndicesLevel` **UV**| 紫外线指数 | | 原始`Json`传入:`uv` |
|`IndicesLevel` **CarWash**| 洗车指数 | | 原始`Json`传入:`car_wash` |
|`IndicesLevel` **Drying**| 晾晒指数 | | 原始`Json`传入:`drying` |
|`IndicesLevel` **AirConditioner**| 空调指数 | | 原始`Json`传入:`air_conditioner` |
|`IndicesLevel` **ColdRisk**| 感冒指数 | | 原始`Json`传入:`cold_risk` |
|`IndicesLevel` **Exercise**| 运动指数 | | 原始`Json`传入:`exercise` |
|`IndicesLevel` **Comfort**| 舒适度指数 | | 原始`Json`传入:`comfort` |
|`IndicesLevel` **Travel**| 出行指数 | | 原始`Json`传入:`travel` |
|`IndicesLevel` **Fishing**| 钓鱼指数 | | 原始`Json`传入:`fishing` |
|`IndicesLevel` **Allergy**| 过敏指数 | | 原始`Json`传入:`allergy` |
|`IndicesLevel` **SunScreen**| 防晒指数 | | 原始`Json`传入:`sunscreen` |
|`IndicesLevel` **Mood**| 心情指数 | | 原始`Json`传入:`mood` |
|`IndicesLevel` **Beer**| 啤酒指数 | | 原始`Json`传入:`beer` |
|`IndicesLevel` **Umbrella**| 雨伞指数 | | 原始`Json`传入:`umbrella` |
|`IndicesLevel` **Traffic**| 交通指数 | | 原始`Json`传入:`traffic` |
|`IndicesLevel` **AirPurifier**| 空气净化器指数 | | 原始`Json`传入:`air_purifier` |
|`IndicesLevel` **Pollen**| 花粉扩散指数 | | 原始`Json`传入:`pollen` |

##### `IndicesLevel` 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **Level**| 等级 | | 原始`Json`传入:`level` |
|`string` **Brief**| 简述 | | 原始`Json`传入:`brief` |
|`string` **Advice**| 建议 | | 原始`Json`传入:`advice` |

#### `List<Hourly_forecastItem>` **HourlyForecast** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **Time**| 预报时间 | | 原始`Json`传入:`time`<br/>格式 ISO8601 或 YYYY-MM-DD HH:MM |
|`double` **Temperature**| 温度 | | 原始`Json`传入:`temperature` |
|`string` **Weather**| 天气状况 | | 原始`Json`传入:`weather` |
|`string` **WindDirection**| 风向 | | 原始`Json`传入:`wind_direction` |
|`double` **WindSpeed**| 风速 | | 原始`Json`传入:`wind_speed` |
|`string` **WindPower**| 风力等级 | | 原始`Json`传入:`wind_scale` |
|`double` **Pressure**| 湿度 | | 原始`Json`传入:`pressure` |
|`double` **Precipitation**| 降水量 | | 原始`Json`传入:`precip` |
|`double` **Cloud**| 云量 | | 原始`Json`传入:`cloud` |
|`double` **FeelsLikeTemperature**| 体感温度 | | 原始`Json`传入:`feels_like` |
|`double` **dew_point**| 露点温度 | | 原始`Json`传入:`dew_point` |
|`double` **Visibility**| 能见度 | | 原始`Json`传入:`visibility` |
|`double` **pop**| 降水概率 | | 原始`Json`传入:`pop` |
|`double` **UV**| 紫外线指数 | | 原始`Json`传入:`uv_index` |

#### `minutely_Precipitation` **MinutelyPrecipitation** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **summary** | 分钟级降水预报 | | 原始`Json`传入:`summary` |
| `string` **UpdateTime_ISO8601** | 更新时间 | | 原始`Json`传入:`UpdateTime_ISO8601` |
| `List<min_data>` **data**| 每5分钟一个数据点，共24个 | | 原始`Json`传入:`data` |

##### `List<min_data>` **data** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **time** | 预报时间 | | 原始`Json`传入:`time` |
| `double` **Precipitation** |降水量||原始`Json`传入: `precip`|
| `string` **Type** |降水类型||原始`Json`传入: `type`|

#### `List<min_data>` **data** 嵌套类

| 属性值            | 注释            | 示例 | 备注 |
| :---------------- | --------------- | :--- | ---- |
| `double` **pm25** | PM 2.5  μg/m³   |      |      |
| `double` **pm10** | PM10  μg/m³     |      |      |
| `double` **o3**   | 臭氧  μg/m³     |      |      |
| `double` **no2**  | 二氧化氮  μg/m³ |      |      |
| `double` **so2**  | 二氧化硫  μg/m³ |      |      |
| `double` **co**   | 一氧化碳  μg/m³ |      |      |