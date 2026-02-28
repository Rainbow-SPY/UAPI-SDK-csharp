# 查询 bilibili 指定用户的投稿数据

>[!IMPORTANT]
> 此页面需要补充

## 请求示例

```csharp
var request = await UAPI.bilibili.GetRepliesList(string oid, string sort = "0", int ps = 20, int pn = 1)
```

* 参数选项:
    * **oid:** 指定要查询的目标评论区的ID对于视频，这通常就是它的 `aid`/`bvid`.
    * **sort:** 指定查询视频的排序方式支持 `0/time（按时间）`、`1/like（按点赞）`、`2/reply（按回复数）`、`3/hot/hottest/最热（按最热）`默认为`0/time`
    * **ps:** 每页获取的评论数量，范围是`1`到`20`默认为 `20`
    * **pn:** 要获取的页码，从`1`开始默认为 `1`
* **返回类型:** `Task <UAPI.bilibili.RepliesListType>`
* **返回值:** `RepliesListType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.bilibili.BilibiliServiceError`:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`Page` **page**| 分页信息 | |
|`object` **config**| ??? | ??? |
|`List<RepliesItem>` **replies**| 当前页的评论列表 | |
|`List<object>` **hots**| 热门评论列表结构与 `replies` 中的对象一致如果当前页是第一页，且有热门评论，则此数组非空 | |
|`object` **upper**| ??? | ??? |
|`object` **top**| ??? | ??? |
|`object` **notice**| ??? | ??? |
|`int` **vote**| ??? | ??? |
|`object` **folder**| ??? | ??? |
|`object` **control**| ??? | ??? |
|`object` **cursor**| ??? | ??? |

___
### `Page` **page** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`int` **num**| 当前的页码 | | |
|`int` **size**| 每页的评论个数 | | |
|`int` **count**| 根评论（即直接评论视频的评论）的总数 | | |
|`int` **acount**| 评论区总评论数，包含了所有的楼中楼回复 | | |


### `List<RepliesItem>` **replies** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`long` **ReplyID**| 评论的唯一ID (Reply ID) | | |
|`long` **oid**| 评论区对象ID，即视频的aid | | |
|`string` **ReplyLocaleType**| 以字符串格式返回评论区父级分类, 参见 [评论区父级分类](#评论区父级分类) | | |
|`int` **type**| 评论区父级分类代码, 参见 [评论区父级分类](#评论区父级分类) | | |
|`int` **mid**| 发表评论的用户的mid | | |
|`long` **root**| 根评论的rpid如果为0，表示这条评论是根评论 | | |
|`bool` **IsRootReply**| 该评论是否为根评论 | | |
|`long` **parent**| 回复的父级评论的rpid如果为0，表示是根评论 | | |
|`int` **dialog**| 回复对方 rpid | | |
|`int` **count**| 这条评论下的回复（楼中楼）数量 | | |
|`int` **rcount**| 回复评论条数 | | |
|`bool` **IsHidden**| 是否被系统隐藏 | | |
|`bool` **IsHadFanTag**| 是否具有粉丝标签 | | |
|`int` **attr**| ??? | ??? | ??? |
|`int` **ctime**| 评论发送时间的Unix时间戳（秒） | | |
|`int` **like**| 该评论获得的点赞数 | | |
|`string` **Like_str**| 该评论获得的点赞数, 返回以"万"为单位的字符串 | | |
|`int` **action**| ??? | ??? | ??? |
|`Member` **member**| 发表评论的用户信息 | | |
|`Content` **content**| 评论内容 | | |
|`List<RepliesItem>` **replies**| 楼中楼回复列表结构与顶层评论对象一致，但通常此数组为空，需要单独请求 | 通常为空 | |
|`Reply_control` **reply_control**| ??? | ??? | ??? |

### `Member` **member** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **mid**| 用户的 UID | | |
|`string` **Name**| 用户昵称 | | |
|`string` **Sex**| 用户性别 | | |
|`string` **sign**| ??? | ??? | ??? |
|`string` **AvatarUrl**|  | | |
|`string` **rank**| ??? | ??? | ??? |
|`Level_info` **level_info**|  用户的B站等级 | | |
|`Official_verify` **official_verify**| ??? | ??? | ??? |
|`Vip` **vip**| ??? | ??? | ??? |

### 评论区父级分类

| 数值 | 描述 |
|-----|------|
| 1 | 视频稿件 |
| 2 | 话题 |
| 4 | 活动 |
| 5 | 小视频 |
| 6 | 小黑屋封禁信息 |
| 7 | 公告信息 |
| 8 | 直播活动 |
| 9 | 活动稿件 |
| 10 | 直播公告 |
| 11 | 相簿（图片动态） |
| 12 | 专栏 |
| 13 | 票务 |
| 14 | 音频 |
| 15 | 风纪委员会 |
| 16 | 点评 |
| 17 | 动态（纯文字动态&分享） |
| 18 | 播单 |
| 19 | 音乐播单 |
| 20/21/22 | 漫画 |
| 33 | 课程 |