# 转换 Unix 时间戳

## 请求示例

```csharp
var request = await UAPI.misc.CovertTimestamp(string ts);
```

* 参数选项:
  * **ts** : Unix 时间戳, 支持10位（秒）或13位（毫秒）。
* **返回类型:** `Task <UAPI.misc.TimestampType>`
* **返回值:** `TimestampType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常

___

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **input**| 输入的值 | |
|`string` **type**| 转换的类型 | |
|`long` **unix_timestamp**| Unix 时间戳 | |
|`string` **datetime_utc**| UTC+0:00 (世界协调时间) 格式的字符串 | |
|`string` **datetime_local**| 以IP地址推断的世界协调时间的本地时间 | 在中国一般指北京时间 UTC +8:00 |
