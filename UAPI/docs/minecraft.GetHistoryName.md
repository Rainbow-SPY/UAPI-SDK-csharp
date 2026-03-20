# 获取 Minecraft 玩家历史昵称
> [!NOTE]
> 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 `404`等`StatusCode` .
## 请求示例

```csharp
var request = await UAPI.minecraft.GetHistoryName(string _param, SearchType searchType);
```

* 参数选项:

  * **_param:** 指定要查询的用户UUID或昵称

  * **searchType:** 指定查询的查找方式, 可供使用的枚举如下:

    | 枚举值 | 注释 |
    | :----: | :--------: |
    | UUID | 以UUID查找 |
    | Name | 以昵称查找 |

* **返回类型:** `Task <UAPI.bilibili.HistoryType>`

* **返回值:** `HistoryType` 对象

* **异常:**

  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.minecraft.MojangAPIServiceError`:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

此API接口较为特殊, 分为使用`name`参数查询返回的结果和`uuid`查询的结果.

### 以 `name` 查询时返回的属性列表

#### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **NUserName**| 查询的用户名 | 原始`Json`传入:`query` |
|`int` **NCount**| 匹配到的用户数量 | 原始`Json`传入:`count`<br/>为 0 时表示未找到 |
|`List<ResultsItem>` **NResults**| 匹配到的用户列表 | 原始`Json`传入:`results`<br/>包含当前用户名或曾用名匹配的所有玩家 |

___
##### `List<ResultsItem>` **NResults** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **UserName**| 玩家当前的用户名 | |原始`Json`传入:`id`|
|`string` **UUID**| 玩家的UUID | |原始`Json`传入:`uuid`<br/>带连字符格式|
|`int` **OldNameCount**| 历史名称的总数 | |原始`Json`传入:`name_num`|
|`List<History>` **history**| 历史用户名数组 | ||
___
###### `List<History>` **history** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **name**| 历史上的昵称 | ||
|`string` **changedToAt**| 何时改的昵称 | ||

### 以`UUID`查询时返回的属性列表

#### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **U_UserName**| 玩家当前的用户名 | 原始`Json`传入:`id` |
|`string` **U_UUID**| 被查询玩家的UUID | 原始`Json`传入:`uuid`<br/>带连字符格式 |
|`int` **U_OldNameCount**| 历史名称的总数 | 原始`Json`传入:`name_num`<br/>包含当前用户名 |
|`List<History>` **U_HistoryList**| 包含所有历史用户名的数组 | 原始`Json`传入:`history`<br/>按时间倒序排列 |

___
##### `List<History>` **history** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **name**| 历史上的昵称 | ||
|`string` **changedToAt**| 何时改的昵称 | ||
