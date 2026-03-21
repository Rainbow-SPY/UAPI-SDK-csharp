# 查询 bilibili 指定用户的公开数据

## 请求示例

```csharp
var request = await UAPI.bilibili.GetUserData(string mid, string Authentication = "");
```

* 参数选项:
  * **mid:** 指定要查询的用户UID(mid)
  * **Authentication**: API Token, 默认为空
* **返回类型:** `Task <UAPI.bilibili.UserType>`
* **返回值:** `UserType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.bilibili.BilibiliServiceError`:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **mid**| bilibili 用户的 UID | |
|`string` **Name**| 昵称 | 原始`Json`传入:`name` |
|`string` **Sex**| 性别 | 原始`Json`传入:`sex` |
|`string` **AvatarImageUrl**| 头像链接 | 原始`Json`传入:`face` |
|`string` **sign**| 签名 | |
|`int` **level**| 等级 | 最大为6 |
|`string` **birthday**| 生日 | |
|`int` **vip_type**| 大会员等级 | |
|`int` **vip_status**| 大会员状态 | |
|`int` **following**| 关注数 | |
|`int` **Fans**| 粉丝数 | 原始`Json`传入:`follower` |
|`int` **archive_count**| 稿件数量 | |
|`int` **article_count**| 文章数量 | |
