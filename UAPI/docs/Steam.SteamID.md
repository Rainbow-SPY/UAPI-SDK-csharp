# SteamID 便携方法

## 从任意 `SteamID` 格式中获取 Steam 好友代码 

### 请求示例

```csharp
var result = UAPI.Steam.GetFriendCode(string AnySteamID);
```

* 参数选项:
  
  * **AnySteamID:** 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:
  
    | ID类型 | 正则表达式格式 | 示例 |
    | :--------: | :---------------------------------------- | :---------------------------------------- |
    | STEAM_ID | ``` Regex: ^STEAM_[0-5]:[01]:\d+$``` | STEAM_1:1:728234856 |
    | STEAM_ID3 | ``` Regex: ^\[U:1:([0-9]+)\]$``` | [U:1:1456469713] |
    | STEAM_ID32 | ``` Regex: ^[0-9]{1,16}$``` | 1456469713 |
    | STEAM_ID64 | ``` Regex: ^7656[0-9]*$``` | 76561199416735441 |
    | Link | ```Regex: https://steamcommunity.com/*``` | https://steamcommunity.com/id/Rainbow-SPY |
  

- 返回类型: `string`
- 返回值: 字符串格式的整数型好友代码
- 异常:
  - **ArgumentOutOfRangeException** : 值超出变量列表时引发的异常

## 获取指定的 Steam 用户的在线状态

### 请求示例

```csharp
var result = UAPI.Steam.GetPersonalState(SteamType steamType);
		   = UAPI.Steam.GetPersonalState(int PersonaState);
```

- 参数选项:
  - **steamType**: 通过 `UAPI.Steam.GetUserData()` 请求返回的 `SteamType` 对象
  - **PersonaState**: ?????
- 返回类型: `string`
- 返回值: 当前的在线状态

## 获取指定的 Steam 用户的社区可见性状态

### 请求示例

```csharp
var result = UAPI.Steam.GetCommunityVisibilityState(SteamType steamType);
```

- 参数选项:
  - **steamType**: 通过 `UAPI.Steam.GetUserData()` 请求返回的 `SteamType` 对象
- 返回类型: `string`
- 返回值: 公开 / 私密

## 获取 Steam 用户的个人资料状态

### 请求示例

```csharp
var result = UAPI.Steam.GetProfileState(SteamType steamType);
```

- 参数选项:
  - **steamType**: 通过 `UAPI.Steam.GetUserData()` 请求返回的 `SteamType` 对象
- 返回类型: `string`
- 返回值: 已填写个人资料 / 未填写个人资料

## 将任意 `SteamID` 转换为 `SteamID32` 

### 请求示例

```csharp
var result = UAPI.SteamID.Convert.ToSteamID32(string SteamID);
```

- 参数选项:
  - **SteamID**: 任意一种的 `SteamID`.
- 返回类型: `string`
- 返回值: 字符串格式的整数型 `SteamID32`.

## 将任意 `SteamID` 转换为 `SteamID64` 

### 请求示例

```csharp
var result = UAPI.SteamID.Convert.ToSteamID64(string SteamID);
```

- 参数选项:
  - **SteamID**: 任意一种的 `SteamID`.
- 返回类型: `string`
- 返回值: 字符串格式的整数型 `SteamID64`.

## 将任意 `SteamID` 转换为 `SteamID32`

### 请求示例

```csharp
var result = UAPI.SteamID.Convert.ToSteamID3(string SteamID);
```

- 参数选项:
  - **SteamID**: 任意一种的 `SteamID`.
- 返回类型: `string`
- 返回值: 字符串格式的整数型 `SteamID3`.

## 将任意 `SteamID` 转换为 `SteamID1` 

### 请求示例

```csharp
var result = UAPI.SteamID.Convert.ToSteamID(string SteamID);
```

- 参数选项:
  - **SteamID**: 任意一种的 `SteamID`.
- 返回类型: `string`
- 返回值: 字符串格式的整数型 `SteamID32`.

## `SteamID` 分析器

### 请求示例

```csharp
var result = UAPI.Steam.Identifier(string AnySteamID);
```

* 参数选项:

  * **AnySteamID:** 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:

    | ID类型 | 正则表达式格式 | 示例 |
    | :--------: | :---------------------------------------- | :---------------------------------------- |
    | STEAM_ID | ``` Regex: ^STEAM_[0-5]:[01]:\d+$``` | STEAM_1:1:728234856 |
    | STEAM_ID3 | ``` Regex: ^\[U:1:([0-9]+)\]$``` | [U:1:1456469713] |
    | STEAM_ID32 | ``` Regex: ^[0-9]{1,16}$``` | 1456469713 |
    | STEAM_ID64 | ``` Regex: ^7656[0-9]*$``` | 76561199416735441 |
    | Link | ```Regex: https://steamcommunity.com/*``` | https://steamcommunity.com/id/Rainbow-SPY |

- 返回类型: `SteamIDType`

- 返回值: `SteamIDType` 对象
    | ID枚举 | 示例 |
    | :-------------------: | :------------------ |
    | SteamIDType.SteamID | STEAM_1:1:728234856 |
    | SteamIDType.SteamID3 | [U:1:1456469713] |
    | SteamIDType.SteamID32 | 1456469713 |
    | SteamIDType.SteamID64 | 76561199416735441 |
    | SteamIDType.Invalid | 无效的 SteamID |
