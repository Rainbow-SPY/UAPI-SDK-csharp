# UAPI 常规方法内部接口

> 供开发者使用

## 公共API获取请求

### 请求示例

```csharp
var (result, statuscode) = await Interface.GetResult<T>(string requestUrl,
            SendRequestType type = SendRequestType.GET, string postContent = "",
            string contentType = "application/json",
            string AuthenticationAPITokenKey = "")
```

* 参数选项:
  * **requestUrl**: 指定要请求的API地址
  * **type**: 指定请求的方式: `SendRequestType.GET`和`SendRequestType.POST`, 默认为 `GET`请求.
  * **postContent**: 当请求方式为`POST`时, 此值为请求内容, 为`GET`时此值无效, 默认为空.
  * **contentType**: 当请求方式为`POST`时, 此值为请求内容的类型, 为`GET`时此值无效, 默认为 `application/json`.
  * **AuthenticationAPITokenKey**: UAPI API Token Key, 默认为空.
  * **T**: 泛式类型对象, 与返回类型相同
  
* 返回类型: `T` 泛式类型对象
* 返回值:
  * `result`: 返回的泛式类型`<T>`对象
  * `statuscode`: `HttpClient` 返回的`StatusCode` 值.

* 异常 (继承于 `Interface.common.IsGetSuccessful<T>`):
  * `JsonSerializationException`: `Newtonsoft.Json` 反序列化失败
  * `HttpRequestException`: `HttpClient` 请求失败.


## 检查是否请求成功的分析方法

### 请求示例

```csharp
bool result = Interface.common.IsGetSuccessful<T>(T Type, string NullValue,
			int StatusCode, Exception _Exception,
            string _Error_Type,
            string Error_Code = "")
```

* 参数选项:
  * **Type**: 指定为继承 `Interface.TypeInterface` 的公共类
  * **NullValue**: 当返回值为 400 时的提示参数.
  * **StatusCode**: 指定从`Interface.common.GetResult<T>`的传入的`statuscode`值
  * **_Exception**: 指定为继承 `System.Exception` 的自定义异常
  * **_Error_Type**: 出现异常的类别
  * **Error_Code**: 当出现异常时的自定义错误代码, 默认为空.
  * **T**: 指定为继承`Interface.TypeInterface`的公共类的泛式类.
* 返回类型: `bool`
* 返回值: 当请求成功并返回 `StatusCode=200`时返回`true`, 反之返回 `false` 或 `throw` 异常.
* 异常:
  * `IException.General.UAPIServerDown`: 请求源服务器发生错误
  * `UnauthorizedAccessException`: 未经授权的请求操作
  * `IException.General.UAPIUnknowException`: 未知的异常
  * `IException.General.UAPIServiceUnavailable` 当前请求的服务不可用
  * `$CustomException`: 指定为继承 `System.Exception` 的自定义的异常

|返回值|注释|
|:--:|:---|
|200|请求成功|
|400|请求的参数 `$NullValue`不能为`null`或空|
|401|未经授权的指定操作, `throw UnauthorizedAccessException()`.|
|403|因请求量过大被限制了请求.|
|404|未找到指定请求的所需结果|
|429|请求量过大, 错误代码 `429 Too Many Requests`.|
|500|UAPI 服务器内部错误, `throw IException.General.UAPIServerDown()`|
|502|上游API请求错误, `throw $_Exception`.|
|503|指定的服务当前不可用, `throw IException.General.UAPIServiceUnavailable()`.|
|-1|请求失败, 未指定的错误|
|<code>default</code>|未知的错误|