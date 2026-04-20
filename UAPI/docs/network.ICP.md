# 查询ICP备案信息

## 请求示例

```csharp
var request = await UAPI.Network.GetICPInfo(string domain, string Authentication = "")
```

* 参数选项:
  * **domain**: 指定要查询的主机
  * **Anthentication**: API Token Key
  
* **返回类型:** `Task <UAPI.Type.ICPType>`
* **返回值:** `ICPType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.General.UAPIUnknowException`:  未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **Code**| 返回的状态码 | |
|`string` **Domain**| 查询的主机 | |
|`string` **ServiceLicence**| ICP备案号 | |
|`string` **UnitName**| 主办单位名称 | |
|`string` **NatureName**| 主办单位的性质 (企业/个人) |  |
|`string` **msg**| 返回的消息                 | |
