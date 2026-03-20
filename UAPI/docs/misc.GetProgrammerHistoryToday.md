# 获取程序员历史上的今天的事件 

## 请求示例

```csharp
var request = await UAPI.misc.GetProgrammerHistoryToday();
```

* **返回类型:** `Task <UAPI.misc.HistoryTodayType>`
* **返回值:** `HistoryTodayType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常
  

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **Date**| 今日日期 | 原始`Json`传入:`date` |
|`List<EventItem>` **Events**| 事件列表 | 原始`Json`传入:`events` |

___
#### `List<EventItem>` **events** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`int` **Year**| 年 | |原始`Json`传入:`year`|
|`int` **Month**| 月 | |原始`Json`传入:`month`|
|`int` **Day**| 日 | |原始`Json`传入:`day`|
|`string` **Title**| 标题 | |原始`Json`传入:`title`|
|`string` **Description**| 描述 | |原始`Json`传入:`description`|
|`string` **Category**| 类型 | |原始`Json`传入:`category`|
|`List<string>` **Tags**| 标签 | |原始`Json`传入:`tags`|
|`int` **ImportanceLevel**| 重要等级 | |原始`Json`传入:`importance`|
|`string` **Source**| 数据源 | |原始`Json`传入:`source`|
