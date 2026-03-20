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
|`string` **InputValue**| 输入的值 | 原始`Json`传入:`input` |
|`string` **Type**| 转换的类型 | 原始`Json`传入:`type` |
|`long` **UnixTimestamp**| Unix 时间戳 | 原始`Json`传入:`unix_timestamp` |
|`string` **DateTime_UTC**| UTC+0:00 (世界协调时间) 格式的字符串 | 原始`Json`传入:`datetime_utc` |
|`string` **DateTime_Local**| 以IP地址推断的世界协调时间的本地时间 | 原始`Json`传入:`datetime_local`<br/>在中国一般指北京时间 UTC +8:00 |
