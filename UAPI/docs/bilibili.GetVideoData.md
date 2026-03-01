# 查询 bilibili 指定用户的投稿数据

## 请求示例

```csharp
var request = await UAPI.bilibili.GetVideoData(string video_id, BiliVideoIDType IDType)
```

* 参数选项:

 * **mid:** 指定要查询的用户UID(mid)

 * **IDType:** 指定查询视频的ID格式, 可供使用的枚举如下:

 | 枚举值 | 注释 |
 | :----: | :---------------: |
 | AID | 视频的AV号 (aid) |
 | BVID | 视频的BV号 (bvid) |

* **返回类型:** `Task <UAPI.bilibili.VideoType>`

* **返回值:** `VideoType` 对象

* **异常:**

 - `IException.General.UAPIServerDown`: 请求源服务器发生错误
 - `UnauthorizedAccessException`: 未经授权的请求操作
 - `IException.bilibili.BilibiliServiceError`: bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
| :---------------- | :--- | :--- |
| `string` **bvid** | 稿件的BV号 | |
| `string` **aid** | 稿件的AV号 | |
| `int` **videos** | 稿件分P总数。如果是单P视频，则为1 | |
| `int` **tid** | 视频所属的子分区ID | |
| `string` **tname** | 视频所属的子分区名称 | |
| `string` **Copyright** | 视频版权类型 | 返回 "原创"/"转载" |
| `int` **IsCopyrightOwner** | 是否为版权拥有者 | |
| `string` **CoverImageUrl** | 稿件封面图片的URL | |
| `string` **title** | 稿件的标题 | |
| `long` **pubdate** | 稿件发布时间的Unix时间戳（秒） | |
| `string` **pubdate_str** | 稿件发布的字符串时间（秒） | |
| `long` **ctime** | 用户投稿时间的Unix时间戳（秒） | |
| `string` **ctime_str** | 用户投稿的字符串时间（秒） | |
| `string` **desc** | 视频简介, 可能会包含HTML换行符 | |
| `List<Desc_v2>` **desc_v2** | 详细的视频简介 | |
| `bool` **IsDeleted** | 视频是否被删除 | |
| `string` **state_str** | 视频状态 | |
| `long` **duration** | 稿件总时长（所有分P累加），单位为秒 | |
| `Rights` **rights** | 视频的各种权限开关（如是否允许转载） | |
| `Owner` **owner** | 视频UP主信息 | |
| `Stat` **stat** | 统计数据, 播放、点赞、硬币等数据 | |
| `string` **dynamic** | 动态的文字, 投稿时附带的动态描述 | |
| `long` **cid** | 弹幕 ID (CID), 视频资源（分P）的唯一 ID | |
| `Dimension` **dimension** | 分辨率信息, 视频宽高等 | |
| `bool` **no_cache** | 不缓存, 一般为 false | |
| `List<Pages>` **stat** | 视频分P列表。即使是单P视频，该数组也包含一个元素。 | |
| `Subtitle` **subtitle** | 字幕 | |
| `List<string>` **staff** | 合作UP主, 联合投稿人列表 (非赞助商) | |
| `object` **ugc_season** | 合集信息	如果视频属于某个合集，这里会有数据 | |
| `bool` **is_chargeable_season** | ??? | ??? |
| `bool` **is_story** | ??? | ??? |
| `Honor_reply` **honor_reply** | ??? | ??? |


___

#### `List<Desc_v2>` **Video** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `string` **Text** | 简介文本 | | |
| `string` **Type** | | | |
| `int` **biz_id** | 业务 ID, 被关联对象的 ID | 当 type=1 时，这里是 mid (用户ID) |  |

#### `Rights` **rights** 嵌套类

| 属性值                          | 注释                           | 示例 | 备注 |
| :------------------------------ | ------------------------------ | :--- | ---- |
| `bool` **IsBangumiPay**         | 是否可以承包/付费 (老番剧字段) |      |      |
| `bool` **IsAllowElectronicPay** | 是否允许付费充电               |      |      |
| `` ****                         |                                |      |      |
| `` ****                         |                                |      |      |

#### `Owner` **Owner** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `int` **mid** | UP主的UID | | |
| `string` **Name** | UP主昵称 | | |
| `string` **AvatarImageUrl** | UP主头像的URL | | |

#### `Stat` **stat** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `long` **aid** | AV号 | | |
| `int` **Views** | 播放量 | | |
| `int` **Danmaku** | 弹幕量 | | |
| `int` **Like** | 点赞量 | | |
| `int` **reply** | 评论量 | | |
| `int` **Favorite** | 收藏量 | | |
| `int` **Coin** | 投币量 | | |
| `int` **Share** | 分享量 | | |
| `string` **NowRank** | 当前全站/分区排名 | 无排名<br/>/ `int.Parse(NowRank)` | |
| `int` **HistoryRank** | 历史排名 | 无排名<br/>/ `int.Parse(HistoryRank)` | |
| `int` **dislike** | 点踩量 | 0 | API 通常返回 0，前端不显示 |
| `int` **evaluation** | 评分/评估 | \<empty> | 通常为空，古早版本用于视频评分 |
| `int` **VideoType_old** | (古早字段) 视频类型 | 0 | |

#### `Dimension` **dimension** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `int` **Width** | 视频宽度 | | |
| `int` **Height** | 视频高度 | | |
| `string` **Rotate** | 旋转角度 | "正常" <br/>"90度旋转" (通常手机拍摄上传会有此标记) | |
| `string` **VideoDimension** | 视频分辨率 | 1920x1080 | |

#### `Pages` **pages** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | :--- | :--- | ---- |
| `int` **cid** | 分P的唯一标识CID，用于获取弹幕等 | | |
| `int` **page** | 分P的序号， | | **从1开始 (非 0)** |
| `string` **SourceWhere** | 来源 | B站直传 | |
| `string` **PartTitle** | 分P的标题 | | 对于单P视频, 通常是视频主标题 |
| `long` **duration** | 该分P的持续时间                  | | 单位为秒 |
| `string` **vid** | 外部视频源 ID, 现大多为空 | \<empty> | 如果 `SourceWhere` 不是"B站直传", 则为外部视频源ID |
| `string` **** | 跳转外部链接 | | 极少用到 |
| `Dimension` **dimension** | 分P视频的分辨率 | | |