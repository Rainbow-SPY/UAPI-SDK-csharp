# 查询 bilibili 指定视频的数据

## 请求示例

```csharp
var request = await UAPI.bilibili.GetVideoData(string video_id, BiliVideoIDType IDType, string Authentication = "")
```

* 参数选项:
  * **mid:** 指定要查询的用户UID(mid)
  * **Authentication**: API Token, 默认为空
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
| `int` **IsCopyrightOwner** | 是否为版权拥有者 | 原始`Json`传入:`copyright` |
| `string` **CoverImageUrl** | 稿件封面图片的URL | 原始`Json`传入:`pic` |
| `string` **title** | 稿件的标题 | |
| `long` **pubdate** | 稿件发布时间的Unix时间戳（秒） | |
| `string` **pubdate_str** | 稿件发布的字符串时间（秒） | |
| `long` **ctime** | 用户投稿时间的Unix时间戳（秒） | |
| `string` **ctime_str** | 用户投稿的字符串时间（秒） | |
| `string` **desc** | 视频简介, 可能会包含HTML换行符 | |
| `List<Desc_v2>` **desc_v2** | 详细的视频简介 | |
| `bool` **IsDeleted** | 视频是否被删除 | 原始`Json`传入:`state` |
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
| `Honor_reply` **honor_reply** | 视频所得荣誉 | |


___

#### `List<Desc_v2>` **desc_v2** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `string` **Text** | 简介文本 | | 原始`Json`传入:`raw_text` |
| `string` **Type** | | | 原始`Json`传入:`type` |
| `int` **biz_id** | 业务 ID, 被关联对象的 ID | 当 type=1 时，这里是 mid (用户ID) | |

#### `Rights` **rights** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------------------------------ | ------------------------------ | :--- | ---- |
| `bool` **IsBangumiPay** | 是否可以承包/付费 (老番剧字段) | | 原始`Json`传入:`bp` |
| `bool` **IsAllowElectronicPay** | 是否允许付费充电 | | 原始`Json`传入:`elec` |
| `bool` **IsAllowDownload** | 是否允许缓存/下载 | | 原始`Json`传入:`download` |
| `bool` **IsMovie** | 是否是电影 | | 原始`Json`传入:`movie` |
| `bool` **IsPay** | 是否需要付费观看 | | 原始`Json`传入:`pay` |
| `bool` **IsHighBitrate** | (古早字段) 是否有高码率 | | 原始`Json`传入:`hd5` |
| `bool` **IsAllowReprint** | 是否允许转载 | | 原始`Json`传入:`no_reprint` |
| `bool` **IsAllowAutoPlay** | 是否允许自动播放 | | 原始`Json`传入:`autoplay` |
| `bool` **IsUGCPay** | 是否为UGC 付费 | | 原始`Json`传入:`ugc_pay`<br/>"B站课堂"之类的付费课程 |
| `bool` **IsCooperation** | 是否为合作视频 | | 原始`Json`传入:`is_cooperation` |
| `bool` **IsAllowPayPreview** | 是否允许付费视频预览 | | 原始`Json`传入:`ugc_pay_preview` |
| `int` **no_background** | ??? | ??? | ??? |
| `bool` **IsCleanMode** | 是否为纯净模式 | | 原始`Json`传入:`clean_mode` |
| `bool` **IsSteinGate** | ??? | | 原始`Json`传入:`s_stein_gate`<br/>??? |
| `bool` **Is360PanoramicVideo** | 是否为360°全景视频 | | 原始`Json`传入:`is_360` |
| `bool` **IsAllowShare** | 是否允许分享 | | 原始`Json`传入:`no_share` |
| `bool` **IsArcPayVideo** | 是否为付费视频 | | 原始`Json`传入:`arc_pay` |
| `bool` **IsAllowFreePreviewInPayVideo** | 是否允许付费视频中的免费试看 | | 原始`Json`传入:`free_watch` |

#### `Owner` **Owner** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `int` **mid** | UP主的UID | | |
| `string` **Name** | UP主昵称 | | 原始`Json`传入:`name` |
| `string` **AvatarImageUrl** | UP主头像的URL | | 原始`Json`传入:`face` |

#### `Stat` **stat** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `long` **aid** | AV号 | | |
| `int` **Views** | 播放量 | | 原始`Json`传入:`view` |
| `int` **Danmaku** | 弹幕量 | | 原始`Json`传入:`danmaku` |
| `int` **Like** | 点赞量 | | 原始`Json`传入:`like`          |
| `int` **reply** | 评论量 |  | 原始`Json`传入:`reply`         |
| `int` **Favorite** | 收藏量 | | 原始`Json`传入:`favorite`      |
| `int` **Coin** | 投币量 | | 原始`Json`传入:`coin`          |
| `int` **Share** | 分享量 | | 原始`Json`传入:`share` |
| `string` **NowRank** | 当前全站/分区排名 | 无排名<br/>/ `int.Parse(NowRank)` | 原始`Json`传入:`now_rank` |
| `int` **HistoryRank** | 历史排名 | 无排名<br/>/ `int.Parse(HistoryRank)` | 原始`Json`传入:`his_rank` |
| `int` **dislike** | (古早字段) 点踩量 | 0 | API 通常返回 0，前端不显示 |
| `int` **evaluation** | (古早字段) 评分/评估 | \<empty> | 通常为空，古早版本用于视频评分 |
| `int` **VideoType_old** | (古早字段) 视频类型 | 0 | 原始`Json`传入:`vt` |

#### `Dimension` **dimension** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `int` **Width** | 视频宽度 | | 原始`Json`传入:`width` |
| `int` **Height** | 视频高度 | | 原始`Json`传入:`height` |
| `string` **Rotate** | 旋转角度 | "正常" <br/>"90度旋转" (通常手机拍摄上传会有此标记) | 原始`Json`传入:`rotate` |
| `string` **VideoDimension** | 视频分辨率 | 1920x1080 | |

#### `Pages` **pages** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | :--- | :--- | ---- |
| `int` **cid** | 分P的唯一标识CID，用于获取弹幕等 | | |
| `int` **page** | 分P的序号， | | **从1开始 (非 0)** |
| `string` **SourceWhere** | 来源 | B站直传 | 原始`Json`传入:`from` |
| `string` **PartTitle** | 分P的标题 | | 原始`Json`传入:`part`<br/>对于单P视频, 通常是视频主标题 |
| `long` **duration** | 该分P的持续时间 | | 单位为秒 |
| `string` **vid** | 外部视频源 ID, 现大多为空 | \<empty> | 如果 `SourceWhere` 不是"B站直传", 则为外部视频源ID |
| `string` **weblink** | 跳转外部链接 | | 原始`Json`传入:`weblink`<br/>极少用到 |
| `Dimension` **dimension** | 分P视频的分辨率 | | |

#### `Subtitle` subtitle 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `bool` **IsAllowSubmitSubtitle** | 允许观众投稿 CC 字幕 | | 原始`Json`传入:`allow_submit` |
| `string` **Name** | UP主昵称 | | |
| `List<Subtitles>` **list** | 字幕列表 | | |

##### `List<Subtitles>` list 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `long` **id** | 字幕ID | | |
| `string` **LanguageCode** | 语言代码 | | 原始`Json`传入:`lan` |
| `string` **LanguageName** | 语言名称 | | 原始`Json`传入:`lan_doc` |
| `bool` **is_lock** | ??? | | ??? |
| `int` **author_mid** | 字幕作者的UID | | |
| `string` **subtitle_url** | ??? | ??? | ??? |
| `SubtitleAuthor` **author** | 字幕作者信息 | | |

###### `SubtitleAuthor` author 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `int` **mid** | 作者的UID | | |
| `string` **name** | 作者昵称 | | |
| `string` **AvatarImageUrl** | 作者头像链接 | | 原始`Json`传入:`face` |

#### `Honnor_reply` honor_reply 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `List<Honnors>` **honor** | 视频所得荣誉 | | |

##### `List<Honnors>` honor 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
| :------ | ---- | :--- | ---- |
| `string` **desc** | 荣誉名称 | | |
| `object` **type** | 荣誉类型 | | |