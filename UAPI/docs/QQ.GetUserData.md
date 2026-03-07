# 获取QQ用户相关信息

## 请求示例

```csharp
var request = await UAPI.QQ.GetUserData(string qq);
```

* 参数选项:
  * **qq:** 指定要查询的用户QQ号
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
|`string` **QQ**| QQ号 | |
|`string` **Name**| 昵称 | |
|`string` **CustomSignText**| 个性签名 | |
|`string` **AvatarImageUrl**| 头像链接 | |
|`int` **Age**| 年龄 | |
|`string` **Sex**| 性别 | |
|`string` **QID**| QQ个性域名 | |
|`int` **QQLevel**| QQ等级 | |
|`string` **Location**| 地理位置 | |
|`string` **Email**| 电子邮箱 | |
|`bool` **IsVip**| 是否开通了SVIP | |
|`int` **VipLevel**| 会员等级 | |
|`string` **RegisterTime_ISO8601**| 注册时间 | ISO 8601 格式 |
|`string` **RegisterTime**| 注册时间 | 字符串格式 |
|`string` **LastUpdatedTime_ISO8601**| 最后更新时间 | ISO 8601 格式 |
|`string` **LastUpdatedTime**| 最后更新时间 | 字符串格式 |