# 获取QQ群相关信息

## 请求示例

```csharp
var request = await UAPI.QQ.GetGroupData(string group_id, string Authentication = "");
```

* 参数选项:
  * **group_id:** 指定要查询的群ID
  * **Authentication**: API Token, 默认为空
* **返回类型:** `Task <UAPI.QQ.GroupType>`
* **返回值:** `GroupType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.QQ.QQServiceError()`:  QQ 上游服务异常, 这可能是他们的服务暂时中断.


## 属性列表

### 根属性

> [!WARNING]
> 标记为 `(可选)` 的项可为 `null` 或 `string.Empty` 空字符串,这代表您在处理接受的 `Json` 对象时要注意 `null` 判定

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **ID**| 群ID | 原始`Json`传入:`group_id` |
|`string` **Name**| 群名称 | 原始`Json`传入:`group_name` |
|`string` **AvatarImageUrl**| 群头像链接地址 | 原始`Json`传入:`avatar_url` |
|`string` **Description**| 群简介 | 原始`Json`传入:`description` |
|`string` **Tag**| 群标签 | 原始`Json`传入:`tag` |
|`string` **JoinQRCodeUrl**| 群QR码地址 | 原始`Json`传入:`join_url` |
|`string` **LastUpdatedTime**| 最后更新时间 (ISO 8601) | 原始`Json`传入:`last_updated` |
|`int` **MemberCount**| 当前成员数 | 原始`Json`传入:`member_count` |
|`int` **MaxMemberCount**| 最大成员数量 | 原始`Json`传入:`max_member_count` |
|`int` **ActiveMemberNum**| 活跃成员数(可选，部分群有此数据) | 原始`Json`传入:`ActiveMemberNum` |
|`string` **OwnerUinID**| 群主QQ号(可选) | 原始`Json`传入:`owner_uin` |
|`string` **OwnerUID**| 群主UID(可选) | 原始`Json`传入:`owner_uid` |
|`string` **CreateTimeUnix**| 建群时间戳(Unix时间戳，可选) | 原始`Json`传入:`create_time` |
|`string` **CreateTime**| 建群时间格式化字符串(可选) | 原始`Json`传入:`create_time_str` |
|`int` **GroupLevel**| 群等级(可选) | 原始`Json`传入:`group_grade` |
|`string` **Introduction**| 群公告/简介(可选) | 原始`Json`传入:`group_memo` |
|`bool` **IsCert**| 是否认证 | 原始`Json`传入:`cert_type` |
|`string` **CertDescription**| 认证说明文本(可选) | 原始`Json`传入:`cert_text` |