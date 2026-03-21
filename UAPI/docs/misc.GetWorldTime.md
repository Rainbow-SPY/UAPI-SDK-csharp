# 获取全球指定时区的当地时间

## 请求示例

```csharp
var request = await UAPI.misc.GetWorldTime(string region, string Authentication = "");
```

* 参数选项:
  
  * **region:** 指定要查询天气的城市, 格式为 **七大洲之一/地区** 或 **直接输入地区**
  
    例: Asia/Shanghai, America/New_York, Tokyo
    
  * **Authentication**: API Token, 默认为空
  
* **返回类型:** `Task <UAPI.misc.WorldTimeType>`

* **返回值:** `WorldTimeType` 对象

* **异常:**

  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常

> 因为这个接口没有什么所谓的上游, 因此也不会报出其他异常.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **InputValue**| 查询的时区 | 原始`Json`传入:`query` |
|`string` **Timezone**| 时区 | 原始`Json`传入:`timezone` |
|`string` **DateTime**| 查询时区的当前时间 | 原始`Json`传入:`datetime` |
|`string` **Weekday**| 星期 | 原始`Json`传入:`weekday` |
|`long` **Timestamp_Unix**| 查询时区的当前 Unix 时间 | 原始`Json`传入:`timestamp_unix` |
|`int` **Timezone_OffsetsSeconds**| 时区秒数偏移量 | 原始`Json`传入:`offset_seconds`<br/>计算公式: 3600 x \$UTC<br/>以北京时间 UTC+8为例: 3600 x 8 = 28800 |
|`string` **Timezone_Offsets_str**| 查询时区的偏移字符串值 | 原始`Json`传入:`offset_string`<br/>例: (UTC8) |
