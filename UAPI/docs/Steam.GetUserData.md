# 获取 Steam 个人用户的公开数据

## 请求示例

```csharp
var request = await UAPI.Steam.GetUserData(string SteamID, string key);
```

- 参数选项:

  - **SteamID:** 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:

     | ID类型 | 正则表达式格式 | 示例 |
     | :---: | :-------- | :-- |
     | STEAM_ID | ``` Regex: ^STEAM_[0-5]:[01]:\d+$``` | STEAM_1:1:728234856 |
     | STEAM_ID3 | ``` Regex: ^\[U:1:([0-9]+)\]$``` | [U:1:1456469713] |
     | STEAM_ID32 | ``` Regex: ^[0-9]{1,16}$``` | 1456469713 |
     | STEAM_ID64 | ``` Regex: ^7656[0-9]*$``` | 76561199416735441 |
     | Link | ```Regex: https://steamcommunity.com/*``` | https://steamcommunity.com/id/Rainbow-SPY |

  - **key:** Steam Web API 所需要的 `Key` , 这是一个可选参数，如果提供，它将覆盖API供应商提供的全局Key。这为你提供了更大的灵活性，但请务必注意Key的保密，不要在前端暴露。

- **返回类型:** `Task <UAPI.Steam.SteamType>`

- **返回值:** `SteamType` 对象

- **异常:**

  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.Steam.SteamServiceError`: Steam Web API 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **SteamID64**| SteamID64 | |
|`bool` **IsCommunityVisibility**| Steam社区状态是否可见 | |
|`bool` **IsInitialized**| 是否已经填写了个人资料 | |
|`string` **Name**| Steam用户名 | |
|`string` **ProfileUrl**| Steam个人主页 | |
|`string` **Avatar_32x32**| Steam头像 | 32\*32图像 |
|`string` **Avatar_64x64**| Steam头像 | 64\*64图像 |
|`string` **Avatar_184x184**| Steam头像 | 184\*184图像 |
|`string` **AvatarHash**| 头像的哈希值 | |
|`string` **PersonaState**| Steam在线状态 | |
|`string` **RealName**| Steam真实姓名 | |
|`string` **PrimaryClanID**| 主要社区组 | 挂在主页的第一个社区组的ID |
|`decimal` **RegisterTimeUnix**| Steam账号创建日期的时间戳 | |
|`string` **RegisterTime**| Steam账号创建日期 | |
|`string` **BindLocationRegionCode**| Steam账号绑定区域 | |
|`string` **FriendCode**| 好友代码 (SteamID32) | |
|`string` **SteamID3**| SteamID3 | |
|`string` **SteamID1**| SteamID1 | |