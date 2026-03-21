# 获取QQ用户相关信息

## 请求示例

```csharp
var request = await UAPI.QQ.GetUserData(string qq, string Authentication = "");
```

* 参数选项:
  * **qq:** 指定要查询的用户QQ号
  * **Authentication**: API Token, 默认为空
* **返回类型:** `Task <UAPI.QQ.UserType>`
* **返回值:** `UserType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.QQ.QQServiceError()`:  QQ 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **QQ**| QQ号 | 原始`Json`传入:`qq` |
|`string` **Name**| 昵称 | 原始`Json`传入:`nickname` |
|`string` **CustomSignText**| 个性签名 | 原始`Json`传入:`long_nick` |
|`string` **AvatarImageUrl**| 头像链接 | 原始`Json`传入:`avatar_url` |
|`int` **Age**| 年龄 | 原始`Json`传入:`age` |
|`string` **Sex**| 性别 | 原始`Json`传入:`sex` |
|`string` **QID**| QQ个性域名 | 原始`Json`传入:`qid` |
|`int` **QQLevel**| QQ等级 | 原始`Json`传入:`qq_level` |
|`string` **Location**| 地理位置 | 原始`Json`传入:`location` |
|`string` **Email**| 电子邮箱 | 原始`Json`传入:`email` |
|`bool` **IsVip**| 是否开通了SVIP | 原始`Json`传入:`is_vip` |
|`int` **VipLevel**| 会员等级 | 原始`Json`传入:`vip_level` |
|`string` **RegisterTime_ISO8601**| 注册时间 | 原始`Json`传入:`reg_time`<br/>ISO 8601 格式 |
|`string` **RegisterTime**| 注册时间 | 字符串格式 |
|`string` **LastUpdatedTime_ISO8601**| 最后更新时间 | 原始`Json`传入:`last_updated`<br/>ISO 8601 格式 |
|`string` **LastUpdatedTime**| 最后更新时间 | 字符串格式 |