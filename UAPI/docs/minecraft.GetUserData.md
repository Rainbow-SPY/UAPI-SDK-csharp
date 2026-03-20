# 获取 Minecraft 玩家信息 

> [!NOTE]
>
> 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 `404`等`StatusCode` .

## 请求示例

```csharp
var request = await UAPI.minecraft.GetUserData(string username);
```

* 参数选项:
  * **username:** 指定要查询的用户名
* **返回类型:** `Task <UAPI.minectaft.UserType>`
* **返回值:** `UserType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.minecraft.MojangAPIServiceError`:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **UserName**| 用户名 | 原始`Json`传入:`username` |
|`string` **UUID**| 玩家的32位无破折号UUID | 原始`Json`传入:`uuid` |
|`string` **SkinImageUrl**| 玩家当前使用的皮肤图片URL | 原始`Json`传入:`skin_url` |
