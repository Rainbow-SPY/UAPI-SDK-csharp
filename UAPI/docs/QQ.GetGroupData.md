# 获取QQ群相关信息

## 请求示例

```csharp
var request = await UAPI.QQ.GetGroupData(string group_id);
```

* 参数选项:
  * **group_id:** 指定要查询的群ID
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
|`string` **ID**| 群ID | |
|`string` **Name**| 群名称 | |
|`string` **AvatarImageUrl**| 群头像链接地址 | |
|`string` **Description**| 群简介 | |
|`string` **Tag**| 群标签 | |
|`string` **JoinQRCodeUrl**| 群QR码地址 | |
|`string` **LastUpdatedTime**| 最后更新时间 (ISO 8601) | |
|`int` **MemberCount**| 当前成员数 | |
|`int` **MaxMemberCount**| 最大成员数量 | |
|`int` **ActiveMemberNum**| 活跃成员数(可选，部分群有此数据) | |
|`string` **OwnerUinID**| 群主QQ号(可选) | |
|`string` **OwnerUID**| 群主UID(可选) | |
|`string` **CreateTimeUnix**| 建群时间戳(Unix时间戳，可选) | |
|`string` **CreateTime**| 建群时间格式化字符串(可选) | |
|`int` **GroupLevel**| 群等级(可选) | |
|`string` **Introduction**| 群公告/简介(可选) | |
|`bool` **IsCert**| 是否认证 | |
|`string` **CertDescription**| 认证说明文本(可选) | |