# 获取手机号码的归属地信息

## 请求示例

```csharp
var request = await UAPI.misc.GetPhoneInfo(string phoneNumber);
```

- 参数选项:
  - **phoneNumber:** 指定要查询的中国大陆 11 位手机号码
- **返回类型:** `Task <UAPI.misc.PhoneInfoType>`
- **返回值:** `PhoneInfoType` 对象
- **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`: 未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **province**| 省份归属地 | |
|`string` **city**| 城市或地区归属地 | |
|`string` **sp**| 运营商名称 | |
