# 获取全球指定时区的当地时间

## 请求示例

```csharp
var request = await UAPI.misc.GetWorldTime(string region);
```

* 参数选项:
  
  * **region:** 指定要查询天气的城市, 格式为 **七大洲之一/地区** 或 **直接输入地区**
  
    例: Asia/Shanghai, America/New_York, Tokyo
  
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
|`string` **query**| 查询的时区 | |
|`string` **timezone**| 时区 | |
|`string` **datetime**| 查询时区的当前时间 | |
|`string` **weekday**| 星期 | |
|`long` **timestamp_unix**| 查询时区的当前 Unix 时间 | |
|`int` **offset_seconds**| 时区秒数偏移量 | 计算公式: 3600 x \$UTC<br/>以北京时间 UTC+8为例: 3600 x 8 = 28800 |
|`string` **offset_string**| 查询时区的偏移字符串值 | 例: (UTC8) |
