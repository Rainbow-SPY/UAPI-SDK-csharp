# 获取一组随机数字

## 请求示例

```csharp
var request = await UAPI.misc.GetRandomNumberList(int min = 0, int max = 0, 
              int count = 0,
              bool allow_repeat = false,
              bool allow_decimal = false, 
              int decimal_places = 0);
```

* 参数选项:
  * **min:** 生成随机数的最小值（包含）。
  * **max:** 生成随机数的最大值（包含）。
  * **count:** 需要生成的随机数的数量。
  * **allow_repeat:** 是否允许生成的多个数字中出现重复值。
  * **allow_decimal:** 是否生成小（浮点）数。如果为 `false`，则只生成整数。
  * **decimal_places:** 如果 `allow_decimal=true`，这里可以指定小数的位数。
* **返回类型:** `Task <UAPI.misc.RandomNumberType>`
* **返回值:** `RandomNumberType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException()`:  未知异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`List<decimal>` **Numbers**| 生成的随机数组 | 原始`Json`传入:`numbers`<br/> |
