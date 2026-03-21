# 获取本机的公网IP地址

## 请求示例

```csharp
var request = await UAPI.Network.GetMyIP(bool commercial = false, string Authentication = "");
```

* 参数选项:
  * **commercial:** 指定是否使用商业级的数据源, 默认为 `false`
  * **Authentication**: API Token, 默认为空
* **返回类型:** `Task <UAPI.Network.IPType>`
* **返回值:** `IPType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `HttpRequestException`:  引发的异常的基类 `HttpClient` 和 `HttpMessageHandler` 类 , 使用此异常通常是这个接口没有上游服务, 多数异常来源于服务器和连接过程.
## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **IP**| 你的公网IP地址 | 原始`Json`传入:`ip` |
|`string` **BeginAddress**| IP段起始地址 | 原始`Json`传入:`beginip` |
|`string` **EndAddress**| IP段结束地址 | 原始`Json`传入:`endip` |
|`string` **Region**| 地理位置 | 原始`Json`传入:`region`<br/>格式：国家 省份 城市 |
|`string` **ISP**| 运营商名称 | 原始`Json`传入:`isp` |
|`string` **ASN**| 自治系统编号 | 原始`Json`传入:`asn` |
|`string` **LLC**| 归属机构 | 原始`Json`传入:`llc` |
|`decimal` **Latitude**| 纬度 | 原始`Json`传入:`latitude` |
|`decimal` **Longitude**| 经度 | 原始`Json`传入:`longitude` |
|`string` **District_Pro**| 行政区 | 原始`Json`传入:`district`<br/>**仅限商业查询** |