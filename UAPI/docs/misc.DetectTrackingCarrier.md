# 通过快递单号识别快递公司

## 请求示例

```csharp
var request = await UAPI.misc.DetectTrackingCarrier(string tracking_number)
```

* 参数选项:
  * **tracking_number: ** 快递单号
* **返回类型:** `Task <UAPI.misc.DetectedCarrierType>`
* **返回值:** `DetectedCarrierType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常

____

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **code**| 返回值 | |
|`string` **message**| 返回消息 | |
|`Data` **data**| 返回的数据 | |

___
#### `Data` **data** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **tracking_number**| 查询的快递单号 | |
|`string` **carrier_code**| 最可能的快递公司编码 | |
|`string` **carrier_name**| 最可能的快递公司名称 | |
|`List<AlternativesItem>` **alternatives**| 其他可能的快递公司列表（如果存在） | |

___
#### `List<AlternativesItem>` **alternatives** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **code**| 快递公司编码 | |
|`string` **name**| 快递公司名称 | |
