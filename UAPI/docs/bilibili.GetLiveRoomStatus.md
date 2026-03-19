# 查询 bilibili 指定用户的直播间数据

>[!IMPORTANT]
> 此页面需要补充

## 请求示例

```csharp
var request = await UAPI.bilibili.GetLiveRoomStatus.AsID(string mid);
 = await UAPI.bilibili.GetLiveRoomStatus.AsLiveroomID(string room_id);
```

* 参数选项:
 * **mid:** 指定要查询的用户UID(mid)
 * **room_id:** 指定要查询的直播间ID, 和上述参数 `mid` 选其一即可.
* **返回类型:** `Task <UAPI.bilibili.LiveRoomType>`
* **返回值:** `LiveRoomType` 对象
* **异常:**
 - `IException.General.UAPIServerDown`: 请求源服务器发生错误
 - `UnauthorizedAccessException`: 未经授权的请求操作
 - `IException.bilibili.BilibiliServiceError`: bilibili API 上游服务异常, 这可能是他们的服务暂时中断.


## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
| `long` **uid** | 主播的用户ID (mid) | |
| `long` **LiveroomID** | 直播间的真实房间号（长号） | 原始`Json`传入:`LiveroomID` |
| `long` **short_id** | 直播间的短号（靓号）如果没有设置，则为0 | |
| `long` **Fans** | 主播的粉丝数（关注数量） | 原始`Json`传入:`attention` |
| `long` **PopularValue** | 直播间当前的人气值, 注意! 这不是真实在线人数 | 原始`Json`传入:`online` |
| `bool` **is_portrait** | ??? | ??? |
| `int` **live_status** | 直播状态0:未开播, 1:直播中, 2:轮播中 | |
| `bool` **IsLiveNow** | 当前是否正在直播? (包括直播和轮播) | |
| `string` **parent_area_name** | 父分区名称 | |
| `int` **parent_area_id** | 父分区ID | |
| `int` **area_name** | 子分区名称 | |
| `int` **area_id** | 子分区ID | |
| `string` **BackgroundImageUrl** | 直播间背景图的URL | 原始`Json`传入:`background` |
| `string` **title** | 当前直播间的标题 | |
| `string` **CoverImageUrl** | 用户设置的直播间封面URL | 原始`Json`传入:`user_cover` |
| `string` **description** | 直播间公告或描述，支持换行符 | |
| `string` **live_time** | 本次直播开始的时间，格式为 `YYYY-MM-DD HH:mm:ss`, 如果未开播，则为空字符串 | |
| `string` **keyframe** | ??? | ??? |
| `string` **tags** | 直播间设置的标签，以逗号分隔 | |
| `List<string>` **hot_words** | 直播间热词列表，通常用于弹幕互动 | |
| [`Pendants` **new_pendants**](#pendants-new_pendants-嵌套类) | 主播佩戴的头像框、大航海等级等信息 | |

___
### `Pendants` **new_pendants** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|:-----|
| [`Frame` **frame**](#frame-frame-嵌套类) | 头像框 | | 
| [`Badge` **badge**](#badge-badge-嵌套类) | 称号 | |

### `Frame` **frame** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|:-----|
| `string` **name** | 头像框 | | 
| `string` **value** | ??? | ??? |
| `string` **desc** | 称号 | |

### `Badge` **badge** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|:-----|
| `string` **name** | 头像框 | | 
| `string` **desc** | 称号 | |
