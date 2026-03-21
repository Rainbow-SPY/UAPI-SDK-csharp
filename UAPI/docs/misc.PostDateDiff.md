# 计算两个日期之间的差值

## 请求示例

```csharp
var request = await UAPI.misc.PostDateDiff(string start_date, string end_date,string format = "YYYY-MM-DD", string Authentication = "");
```

- 参数列表
  -  **start_date**: 开始时间/日期
  -  **end_date**: 结束时间/日期
  -  **format**: 时间格式, 默认为 `YYYY-MM-DD`
  -  **Authentication**: API Token, 默认为空
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
|`long` **Days**| 总天数 | 原始`Json`传入:`days` |
|`long` **Hours**| 总小时数 | 原始`Json`传入:`hours` |
|`long` **Minutes**| 总分钟数 | 原始`Json`传入:`minutes` |
|`long` **Seconds**| 总秒数 | 原始`Json`传入:`seconds` |
|`long` **Weeks**| 总周数 | 原始`Json`传入:`weeks` |
|`string` **HumanReadable**| 人性化显示格式 | 原始`Json`传入:`human_readable` |