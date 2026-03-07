# 天气请求

## 请求示例

```csharp
var request = await UAPI.Weather.GetWeatherDataJson(string city, 
              bool extended = false,
              bool indices = false, 
              bool forecast = false);
    		= await UAPI.Weather.GetWeatherDataJson(int adcode,
              bool extended = false, 
              bool indices = false,
              bool forecast = false);
```

* 参数选项:
  * **city:** 指定要查询天气的城市
  * **adcode:** 指定要查询天气的城市的高德地图的6位数字城市编码
  * **extended:** 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 `false`
  * **indices:** 是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）, 默认为 `false`
  * **forecast:** 是否返回预报数据（当日最高/最低气温及未来3天天气预报）, 默认为 `false`
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
|`int` **Adcode**| 高德地图的6位数字城市编码 | |
|`string` **Weather**| 天气状况 | |
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
|`double` **Precipitation**| 降水量 | `extended=true` 时返回 |
|`double` **Cloud**| 云量 | `extended=true` 时返回 |
|`Life_Indices` **life_indices**| 生活指数 | |

___
#### `List<Forecast>` **forecast** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **date**| 预告日期 | | |
|`double` **MaxTemperature**| 一天中的最高温度 | | |
|`double` **MinTemperature**| 一天中的最低温度 | | |
|`string` **DayWeather**| 白天天气 | | |
|`string` **DayWindDirection**| 白天风向 | | |
|`string` **NightWindDirection**| 夜间风向 | | |
|`string` **DayWindPower**| 白天风力 | | |
|`string` **NightWindPower**| 夜间风力 | | |
|`string` **NightWeather**| 夜间天气 | | |
|`double` **Humidity**| 湿度 | | |
|`double` **Precipitation**| 降水量 | | |
|`double` **Visibility**| 能见度 | | |
|`double` **UV**| 紫外线指数 | | 0-11+ |
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

##### `IndicesLevel` 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **Level**| 等级 | | |
|`string` **Brief**| 简述 | | |
|`string` **Advice**| 建议 | | |