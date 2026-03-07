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
|`string` **date**| 今日日期 | |
|`List<EventItem>` **events**| 事件列表 | |

___
#### `List<EventItem>` **events** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`int` **year**| 年 | ||
|`int` **month**| 月 | ||
|`int` **day**| 日 | ||
|`string` **Title**| 标题 | ||
|`string` **Description**| 描述 | ||
|`string` **category**| 类型 | ||
|`List<string>` **Tags**| 标签 | ||
|`int` **ImportanceLevel**| 重要等级 | ||
|`string` **source**| 数据源 | ||
