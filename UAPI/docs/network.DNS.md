# DNS 解析查询

## 请求示例

```csharp
var request = await UAPI.Network.LookUpDNS(string domain, DNSRecordType DNSRecordType, string Authentication = "")
```

* 参数选项:
  
  * `domain` :  **指定要查询的主机**
  
  * `RecordType` : **选择查询 DNS 的类型, 枚举如下**
  
    | 枚举值  | 注释       |
    | :------ | ---------- |
    | `A`     | IPv4       |
    | `AAAA`  | IPv6       |
    | `CNAME` | 别名记录   |
    | `MX`    | 邮件服务器 |
    | `NS`    | 域名服务器 |
    | `TXT`   | 文本记录   |
  
  * `Authentication` : API Token Key
  
* 返回类型: `Task<DNSType>`

* 返回值: `DNSType` 对象

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **Domain**| 查询的主机 | |
|`string` **Type**| 查询到的DNS类型 | |
|`RecordsItem` **Records**| 查询到的记录 | |

___
#### `RecordsItem` **Records** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
| `string` **TargetIP** | 记录在表的IP | | |
