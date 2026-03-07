# 获取支持的快递公司列表

## 请求示例

```csharp
var request = await UAPI.misc.GetTrackingCarriers();
```

* **返回类型:** `Task <UAPI.misc.CarriersType>`
* **返回值:** `CarriersType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`List<CarriersItem>` **carriers**| 快递公司列表 | |
|`int` **total**| 支持的快递公司总数 | |

___
#### `List<CarriersItem>` **carriers** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **code**| 快递公司编码，用于API调用时的 `carrier_code` 参数 | |
|`string` **name**| 快递公司中文名称，用于界面显示 | |
