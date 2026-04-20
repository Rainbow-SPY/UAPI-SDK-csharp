# 查询IP的相关信息

## 请求示例

```csharp
var request = await UAPI.Network.GetIPInfo(string ip, bool IsUseCommercial = false,
            string Authentication = "")
```

* 参数选项:
  * **ip**: 指定要查询的IP
  
  * **IsUseCommercial**: 是否使用商业数据源, 扣除的积分可能会增加.
  
  * **Authentication**: API Token Key
  
* **返回类型:** `Task <IPInfoType>`
* **返回值:** `IPInfoType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.General.UAPIUnknowException`:  未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **IP**| 解析的IP地址 | |
|`string` **Region**| 解析后的国家/地区 | |
|`string` **ISP**| 运营商名称 | |
|`string` **ASN**| 自治系统编号 | |
|`string` **LLC**| 归属机构 | |
|`double` **Latitude**| 纬度 | |
|`double` **Longitude**| 经度 | |
|`string` **AreaCode**| `Region` 解析的地区 Adcode 代码 | |
|`string` **ZIPCode**| 邮政编码 (Zone Improvement Plan Code) | |
|`string` **Timezone**| 时区 | |
|`string` **BeginIP**| IP段起始地址 | 标准查询可用 |
|`string` **EndIP**| IP段结束地址 | 标准查询可用 |
