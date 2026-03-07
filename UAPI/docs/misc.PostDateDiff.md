# 计算两个日期之间的差值

## 请求示例

```csharp
var request = await UAPI.misc.PostDateDiff(string start_date, string end_date,string format = "YYYY-MM-DD");
```

- 参数列表
  -  **start_date**: 开始时间/日期
  -  **end_date**: 结束时间/日期
  -  **format**: 时间格式, 默认为 `YYYY-MM-DD`
- **返回类型:** `Task <UAPI.misc.DateDiffType>`
- **返回值:** `DateDiffType` 对象
- **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`long` **days**| 总天数 | |
|`long` **hours**| 总小时数 | |
|`long` **minutes**| 总分钟数 | |
|`long` **seconds**| 总秒数 | |
|`long` **weeks**| 总周数 | |
|`string` **human_readable**| 人性化显示格式 | |