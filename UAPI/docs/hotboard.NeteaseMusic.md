# 查询网易云音乐热榜详细数据

## 请求示例

```csharp
var request = await UAPI.hotboard.GetNeteaseMusicHotboard();
```

* **返回类型:** `Task <UAPI.hotboard.NeteaseType>`
* **返回值:** `NeteaseType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `Hotboard.HotboardUpstreamServiceError`:  上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`List<MainLists>` **list**| 主要的歌曲热榜列表信息 | |

___
#### `List<MainLists>` **MainLists** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **CoverImageUrl**| 歌曲专辑封面链接 | ||
|`Extra` **extra**| 歌曲额外元数据 | ||

___
#### `Extra` **extra** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **album**| 专辑名称 | ||
|`string` **artist_names**| 歌手名称 | ||
|`string` **duration_text**| 歌曲时长 | ||
|`long` **id**| 歌曲在网易云音乐的唯一ID | ||
|`int` **last_rank**| 上次的热榜排名 | ||
|`int` **Popularity**| 受欢迎程度 | |暂时没有具体用法|
