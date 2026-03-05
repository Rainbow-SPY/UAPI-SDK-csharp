# 查询 Epic Games 当前免费游戏的数据

## 请求示例

```csharp
var request = await UAPI.EpicGames.GetDataJson();
```

* **返回类型:** `Task <UAPI.EpicGames.EpicType>`
* **返回值:** `EpicType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.EpicGames.EpicGamesServerError`:  Epic Games 上游 API 服务异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`List<GameData>` **data**| 免费游戏列表（数组） | |

#### `List<GameData>` data 嵌套类


| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **id**| 游戏的唯一标识ID | |
|`string` **title**| 游戏的完整标题名称 | |
|`string` **CoverImageUrl**| 游戏封面图片的URL地址 | |
|`int` **original_price**| 游戏的原价 | 单位: 人民币 |
|`string` **original_price_desc**| 格式化后的原价描述字符串 | |
|`string` **description**| 游戏的简介描述 | |
|`string` **seller**| 发行商 | |
|`bool` **IsFreeNow**| 当前是否处于免费状态 | |
|`string` **FreeStartTime**| 免费开始时间, 可读字符串格式 | |
|`long` **FreeStartTimeUnix**| 免费开始时间, 13位毫秒时间戳 | |
|`string` **FreeEndTime**| 免费结束时间的可读字符串格式 | |
|`long` **FreeEndTimeUnix**| 免费结束时间的13位毫秒时间戳 | |
|`string` **link**| 游戏在Epic Games商店的详情页链接 | |