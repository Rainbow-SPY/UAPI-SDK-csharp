# 查询 bilibili 指定用户的投稿数据

## 请求示例

```csharp
var request = await UAPI.bilibili.GetArchives(string mid,
 ArchivesSearchType orderby = ArchivesSearchType.Pubdate,
 string keywords = "",
 int ps = 20, int pn = 1, string Authentication = "")
```

* 参数选项:
    * **mid:** 指定要查询的用户UID(mid)
    * **orderby:** 指定以何种查询方式, 默认为 `Pubdate`. 可供使用的枚举有:


|  枚举值   |        注释        |
| :-------: | :----------------: |
| `Pubdate` | 以最新发布顺序排列 |
|  `Views`  |    以播放量排列    |

- **keywords:** 指定一个关键字作为查找内容并返回与之相关的内容, 默认为空.
  * **ps:** 指定每页的稿件数量, 默认 `20`.
  * **pn:** 指定一个页码并返回指定页码的稿件信息, 默认为 `1`.
  * **Authentication**: API Token, 默认为空

* **返回类型:** `Task <UAPI.bilibili.ArchiveType>`
* **返回值:** `ArchiveType` 对象
* **异常:**

   - `IException.General.UAPIServerDown`: 请求源服务器发生错误

   - `UnauthorizedAccessException`: 未经授权的请求操作

   - `IException.bilibili.BilibiliServiceError`: bilibili API 上游服务异常, 这可能是他们的服务暂时中断.


## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------------------------------:|:--------:|:-----------------------------------:|
| `int` **total** | 投搞的视频总数量 | 所公开的全部视频数量 |
| `int` **page** | 页码数量 | 默认在个人资料显示的全部视频页数 |
| `int` **size** | 每页的数量 | 总数量 = 页码数量 x 每页的数量 |
| [`List<Videos>` **videos**](#listvideos-video-嵌套类) | 视频的综合数据 | 一个公共嵌套类, 使用<br/> `foreach/for` 循环读取 |

___
### `List<videos>` **Video** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------------|--------|:-----------------------|:----------------|
| `long` **aid** | 视频的AID | `AV55`<br/>2020年后的a<head/>v号将突破 `Int_MAX`<br/>例:`av116114575072948` | 经典老版的 A<head/>V 号 |
| `string` **bvid** | 视频的bv号 | `BV1xx411c7Ug` (同上转换得来) | 2020年3月23日 之后更新的 BV 号<br/>如 |
| `int` **title** | 视频的标题 | 【天哥版】最春哥 | |
| `int` **cover** | 视频的封面 ( Url ) | `http://i1.hdslb.com/bfs/archive/$MD5...jpg` | |
| `long` **duration** | 一个视频内所有选集的总时长(秒) | 98 | |
| `long` **play_count** | 播放量 | 1974600 | 整数型的 `long` 格式属性<br/>如果要使用以'万'为单位的<br/>请使用UAPI的接口函数 `UAPI.Interface.FormatPlayCount(int _Count)`<br/>返回以'万'为单位的字符串格式的播放量数据 |
| `long` **publish_time** | 视频发布的时间 (**时间戳**格式) | 1247496094 | |
| `string` **publish_time_str** | 视频发布的时间 (**字符串**格式) | 2009/7/13 22:41:34 | |
| `long` **create_time** | 视频创建的时间 (**时间戳**格式) | 1247496094 | |
| `string` **create_time_str** | 视频创建的时间 (**字符串**格式) | 2009/7/13 22:41:34 | |
| `int` **state** | 当前状态 | 0 ||
| `bool` **IsPayVideo** | 是否为充电视频 | `True`/`False` ||
| `string` **IsPayVideo_str** | 是否为充电视频 (**字符串**格式) | 免费/付费 |原始`Json`传入: `is_ugc_pay`|
| `bool` **IsInteractive** | 是否为共创视频 | `True`/`False` |原始`Json`传入: `is_interactive`|