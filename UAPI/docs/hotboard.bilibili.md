# 查询 bilibili 热榜排名详细数据

## 请求示例

```csharp
var request = await UAPI.hotboard.GetBilibiliHotboard();
```

* **返回类型:** `Task <UAPI.hotboard.bilibiliType>`
* **返回值:** `bilibiliType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `Hotboard.HotboardUpstreamServiceError()`: 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`List<lists>` **list**| bilibili热榜排行榜列表 | |

___
#### `List<lists>` **lists** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `Extra` extra | 视频的额外信息 |  |  |

___

##### `Extra` extra 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `long` **aid** | av号 |  |  |
| `string` **bvid** | BV号 |  |  |
| `string` **desc** | 简介文本 |  |  |
| `string` **durations** | 总计时长  |  | 格式化为分钟+秒 |
| `int` **seconds** | 总计时长 |  | 原始`Json`传入:`duration`<br/>以秒为单位 |
| `Owner` **owner** | UP主信息 |  |  |
| `string` **CoverImageUrl** | 视频封面链接 |      | 原始`Json`传入:`pic` |
| `string` **pubdate_str** | 发布时间 | YYYY-MM-DD HH:mm:ss | 格式化后 |
| `string` **pubdate** | 发布时间 | YYYY-MM-DDT HH:mm:ssZ | ISO 8601格式 |
| `string` **rcmd_reason** | 视频荣誉 |  |  |
| `string` **short_link** | 视频短链接 |  |  |
| `Stat` **stat** | 视频统计信息 |  |  |
| `string` **tname** | 视频分区名称 |  |  |

###### `Owner` owner 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **AvatarImageUrl** | 头像链接 |  | 原始`Json`传入: `face` |
| `long` **Mid** | UID |  |  |
| `string` **Name** | 昵称 |  |  |

###### `Stat` stat嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **Coin_str** | 投币量 |  | 以**万**为单位的形式                     |
| `int` **Coin_int** | 投币量 |  | 原始`Json`传入:`coin`<br/>纯数字形式 |
| `string` **Danmaku_str** | 弹幕量 |  | 以**万**为单位的形式 |
| `int` **Danmaku_int** | 弹幕量 |  | 原始`Json`传入:`danmaku`<br/>纯数字形式 |
| `string` **Favorite_str** | 收藏量 |  | 以**万**为单位的形式 |
| `int` **Favorite_int** | 收藏量 |  | 原始`Json`传入:`favorite`<br/>纯数字形式 |
| `string` **Like_str** | 点赞量 |  | 以**万**为单位的形式 |
| `int` **Like_int** | 点赞量 |  | 原始`Json`传入:`like`<br/>纯数字形式 |
| `string` **Reply_str** | 评论量 |  | 以**万**为单位的形式 |
| `int` **Reply_int** | 评论量 |  | 原始`Json`传入:`reply`<br/>纯数字形式 |
| `string` **Share_str** | 分享量 |  | 以**万**为单位的形式 |
| `int` **Share_int** | 分享量 |  | 原始`Json`传入:`share`<br/>纯数字形式 |
| `string` **view_str** | 观看量 |  | 以**万**为单位的形式 |
| `int` **View_int** | 观看量 |  | 原始`Json`传入:`view`<br/>纯数字形式 |
