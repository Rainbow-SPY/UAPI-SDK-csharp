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
|`string` **query_timestamp**| 原始传入的时间戳 | |
|`string` **query_timezone**| 原始传入的`timezone`时区 | |
|`string` **timezone**| 解析后的时区 | |
|`string` **datetime**| 本地化时间 | 格式 YYYY-MM-DD HH:mm:ss |
|`string` **datetime_rfc3339**| RFC3339 时间格式 | |
|`decimal` **timestamp_unix**| 秒级 Unix 时间戳 | |
|`string` **weekday**| 星期英文 | |
|`string` **weekday_cn**| 星期中文 | |
|`int` **lunar_year**| 农历年份（数字） | |
|`int` **lunar_month**| 农历月份（数字） | |
|`int` **lunar_day**| 农历日期（数字） | |
|`bool` **is_leap_month**| 是否闰月 | |
|`string` **lunar_year_cn**| 农历年份中文表示 | |
|`string` **lunar_month_cn**| 农历月份中文表示 | |
|`string` **lunar_day_cn**| 农历日期中文表示 | |
|`string` **ganzhi_year**| 干支年 | |
|`string` **ganzhi_month**| 干支月 | |
|`string` **ganzhi_day**| 干支日 | |
|`string` **zodiac**| 生肖 | |
|`string` **solar_term**| 节气，无则为空字符串 | |
|`List<string>` **lunar_festivals**| 农历节日数组 | |
|`List<string>` **solar_festivals**| 公历节日数组 | |