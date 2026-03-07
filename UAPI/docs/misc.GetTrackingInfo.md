# 查询快递物流信息

## 请求示例

```csharp
var request = await UAPI.misc.GetTrackingInfo(string tracking_number, string carrier_code = "",string phone = "");
```

* 参数列表
  - **tracking_number**: 快递单号，通常是一串10-20位的数字或字母数字组合。
  - **carrier_code**: 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。
  - **phone**: 收件人手机尾号，4位数字（可选）。部分快递公司需要验证手机尾号才能查询详细物流信息。
* **返回类型:** `Task <UAPI.misc.TrackingInfoType>`
* **返回值:** `TrackingInfoType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **code**| 状态码 | |
|`string` **message**| 消息 | |
|`Data` **data**| 返回的数据 | |

___
#### `Data` **data** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **tracking_number**| 快递公司编码 | ||
|`string` **carrier_code**| 快递公司编码 | ||
|`string` **carrier_name**| 快递公司名称 | ||
|`int` **track_count**| 物流轨迹数量 | ||
|`List<TracksItem>` **tracks**| 物流轨迹列表 | | 按时间倒序排列 |
___

#### `List<TracksItem>` **tracks** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **time**| 物流更新时间 | | |
|`string` **context**| 物流状态描述 | | |