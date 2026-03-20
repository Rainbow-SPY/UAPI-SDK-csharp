# 查询农历时间

## 请求示例

```csharp
var request = await UAPI.misc.GetLunarTime(string ts = "", string timezone = "Asia/Shanghai")
```

* 参数选项:

  * **ts: ** Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。
  * **timezone**: 时区名称。支持 IANA 时区（如 `Asia/Shanghai`）和别名（`Shanghai`、`Beijing`）。默认 `Asia/Shanghai`。
* **返回类型:** `Task <UAPI.misc.LunarTimeType>`
* **返回值:** `LunarTimeType` 对象
* **异常:**

   - `IException.General.UAPIServerDown`: 请求源服务器发生错误

   - `UnauthorizedAccessException`: 未经授权的请求操作

   - `IException.General.UAPIUnknowException`: 未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **InputTimestamp**| 原始传入的时间戳 | 原始`Json`传入:`query_timestamp` |
|`string` **InputTimezone**| 原始传入的`timezone`时区 | 原始`Json`传入:`query_timezone` |
|`string` **Timezone**| 解析后的时区 | 原始`Json`传入:`timezone` |
|`string` **DateTime**| 本地化时间 | 原始`Json`传入:`datetime`<br/>格式 YYYY-MM-DD HH:mm:ss |
|`string` **DateTime_RFC3339**| RFC3339 时间格式 | 原始`Json`传入:`datetime_rfc3339` |
|`decimal` **Timestamp_Unix**| 秒级 Unix 时间戳 | 原始`Json`传入:`timestamp_unix` |
|`string` **Weekday**| 星期英文 | 原始`Json`传入:`weekday` |
|`string` **Weekday_CN**| 星期中文 | 原始`Json`传入:`weekday_CN` |
|`int` **LunarYear**| 农历年份（数字） | 原始`Json`传入:`Lunar_year` |
|`int` **LunarMonth**| 农历月份（数字） | 原始`Json`传入:`Lunar_month` |
|`int` **LunarDay**| 农历日期（数字） | 原始`Json`传入:`Lunar_day` |
|`bool` **IsLeapMonth**| 是否闰月 | 原始`Json`传入:`is_leap_month` |
|`string` **LunarYear_CN**| 农历年份中文表示 | 原始`Json`传入:`cLunar_year_CNin` |
|`string` **LunarMonth_CN**| 农历月份中文表示 | 原始`Json`传入:`Lunar_month_CN` |
|`string` **LunarDay_CN**| 农历日期中文表示 | 原始`Json`传入:`Lunar_day_CN` |
|`string` **GanzhiYear**| 干支年 | 原始`Json`传入:`ganzhi_year` |
|`string` **GanzhiMonth**| 干支月 | 原始`Json`传入:`ganzhi_month` |
|`string` **GanzhiDay**| 干支日 | 原始`Json`传入:`ganzhi_day` |
|`string` **Zodiac**| 生肖 | 原始`Json`传入:`zodiac` |
|`string` **SolarTerm**| 节气，无则为空字符串 | 原始`Json`传入:`solar_term` |
|`List<string>` **LunarFestivals**| 农历节日数组 | 原始`Json`传入:`Lunar_festivals` |
|`List<string>` **SolarFestivals**| 公历节日数组 | 原始`Json`传入:`solar_festivals` |