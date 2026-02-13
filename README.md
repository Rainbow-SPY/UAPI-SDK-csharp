# UAPI C# SDK 社区版

## 介绍

一个深度集成 [UApi](https://uapis.cn) 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生.

### 贡献者:

- [Rainbow-SPY](https://github.com/Rainbow-SPY)
- [Shuakami](https://github.com/shuakami/)

##  License / 许可证

Copyright (©) AxT-Team & UApi, Developer: Rainbow-SPY. All content is protected by copyright.

This project is licensed under **AGPL-3.0 + Attribution + Non-Commercial terms**.

-  **You must**:
    - Keep original author attribution and repository link.
    - Open-source any modified versions under AGPL-3.0.
-  **You cannot**:
    - Use this code (or derivatives) for commercial purposes.
-  See [LICENSE](LICENSE) for full terms.

版权所有 (©) AxT-Team & UApi，开发者：Rainbow-SPY，所有内容均受版权保护。

本项目采用 **AGPL-3.0 + 署名 + 非商业附加条款** 许可协议。

-  **您必须**：
    - 保留原始作者署名及仓库链接。
    - 任何修改后的版本必须以 AGPL-3.0 协议开源。
-  **您不得**：
    - 将此代码（或衍生作品）用于商业用途。
-  完整条款参见 [LICENSE](LICENSE)

## 目录
1. [社交类请求](#社交类请求)
   1. [bilibili 相关请求](#bilibili-相关请求)
       1. [请求bilibili热榜](#请求-bilibili-热榜)
       2. [获取指定UP的所有稿件信息](#获取指定up的所有稿件信息)
       3. [获取指定UP的直播间信息](#获取指定up的直播间信息)
       4. [获取指定用户的公开账户数据](#获取指定用户的账户数据)
       5. [获取指定视频的详细数据](#获取指定视频的详细数据)
   2. [QQ 相关请求](#qq-相关请求)
       1. [获取QQ群相关信息](#获取qq群相关信息)
       2. [获取QQ用户相关信息](#获取qq用户相关信息) 
4. [游戏功能性请求](#游戏功能性请求)
    1. [获取Epic Games每日免费游戏](#获取epic-games每日免费游戏)
    2. [获取 Minecraft 玩家历史昵称](#获取-minecraft-玩家历史昵称)
    3. [获取 Minecraft 服务器状态](#获取-minecraft-服务器状态)
    4. [获取 Minecraft 玩家信息](#获取-minecraft-玩家信息) 
    5. [获取 Steam 个人用户的公开数据](#获取-steam-个人用户的公开数据)
5. [网络类请求](#获取本机的公网ip地址)
    1. [获取本机的公网IP地址](#获取本机的公网ip地址)
5. [杂项](#杂项)
   1. [热榜请求](#热榜请求)
      1. [请求bilibili热榜](#请求-bilibili-热门排行榜)
      2. [请求网易云音乐热榜](#请求网易云音乐热榜)
   2. [天气请求](#天气请求)

## 社交类请求

### bilibili 相关请求

#### 请求 bilibili 热门排行榜

> 转到 [热榜请求 - 请求 bilibili热榜](#请求-bilibili-热榜)

____

#### 获取指定UP的所有稿件信息

```csharp
var request = await UAPI.bilibili.GetArchives(string mid,
            ArchivesSearchType orderby = ArchivesSearchType.Pubdate,
            string keywords = "",
            int ps = 20, int pn = 1)
```

* 参数选项:
    * **mid:** 指定要查询的用户UID(mid)
    * **orderby:** 指定以何种查询方式, 默认为 `Pubdate`. 可供使用的枚举有:

      | 枚举值 | 注释 |
      |------:|:---------:|
      | `Pubdate` | 以最新发布顺序排列 |
      | `Views` | 以播放量排列 |
    * **keywords:** 指定一个关键字作为查找内容并返回与之相关的内容, 默认为空.
    * **ps:** 指定每页的稿件数量, 默认 `20`.
    * **pn:** 指定一个页码并返回指定页码的稿件信息, 默认为 `1`.
* **返回类型:** `Task <UAPI.bilibili.ArchiveType>`
* **返回值:** `ArchiveType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.bilibili.BilibiliServiceError`:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

____

#### 获取指定UP的直播间信息

```csharp
var request = await UAPI.bilibili.GetLiveRoomStatus.AsID(string mid);
            = await UAPI.bilibili.GetLiveRoomStatus.AsLiveroomID(string room_id);
```

* 参数选项:
    * **mid:** 指定要查询的用户UID(mid)
    * **room_id:** 指定要查询的直播间ID, 和上述参数 `mid` 选其一即可.
* **返回类型:** `Task <UAPI.bilibili.LiveRoomType>`
* **返回值:** `LiveRoomType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.bilibili.BilibiliServiceError`:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

____

#### 获取指定用户的账户数据

```csharp
var request = await UAPI.bilibili.GetUserData(string mid);
```

* 参数选项:
    * **mid:** 指定要查询的用户UID(mid)
* **返回类型:** `Task <UAPI.bilibili.UserType>`
* **返回值:** `UserType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.bilibili.BilibiliServiceError`:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

____

##### 获取指定视频的详细数据

```csharp
var request = await UAPI.bilibili.GetVideoData(string video_id, BiliVideoIDType IDType)
```

* 参数选项:
    * **mid:** 指定要查询的用户UID(mid)
    * **IDType:** 指定查询视频的ID格式, 可供使用的枚举如下:

      | 枚举值 | 注释 |
      |:----:|:-------------:|
      | AID | 视频的AV号 (aid)  |
      | BVID | 视频的BV号 (bvid) |
* **返回类型:** `Task <UAPI.bilibili.VideoType>`
* **返回值:** `VideoType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.bilibili.BilibiliServiceError`:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.

### QQ 相关请求

#### 获取QQ群相关信息

```csharp
var request = await UAPI.QQ.GetGroupData(string group_id)
```

* 参数选项:
  * **group_id:** 指定要查询的群ID
* **返回类型:** `Task <UAPI.QQ.GroupType>`
* **返回值:** `GroupType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.QQ.QQServiceError()`:  QQ 上游服务异常, 这可能是他们的服务暂时中断.

____

#### 获取QQ用户相关信息

```csharp
var request = await UAPI.QQ.GetUserData(string qq)
```

* 参数选项:
  * **qq:** 指定要查询的用户QQ号
* **返回类型:** `Task <UAPI.QQ.UserType>`
* **返回值:** `UserType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.QQ.QQServiceError()`:  QQ 上游服务异常, 这可能是他们的服务暂时中断.

## 游戏功能性请求

### 获取Epic Games每日免费游戏

```csharp
var request = await UAPI.EpicGames.GetDataJson();
```

* **返回类型:** `Task <UAPI.EpicGames.EpicType>`
* **返回值:** `EpicType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.EpicGames.EpicGamesServerError`:  Epic Games 上游 API 服务异常

____

> [!NOTE]  
> 所有 Minecraft 相关请求的用户必须均为正版, 否则返回 `404`等`StatusCode` .


### 获取 Minecraft 玩家历史昵称

```csharp
var request = await UAPI.minecraft.GetHistoryName(string _param, SearchType searchType);
```

* 参数选项:
    * **_param:** 指定要查询的用户UUID或昵称
    * **searchType:** 指定查询的查找方式, 可供使用的枚举如下:

      | 枚举值 | 注释 |
      |:-----:|:--------:|
      | UUID | 以UUID查找 |
      | Name | 以昵称查找 |
* **返回类型:** `Task <UAPI.bilibili.HistoryType>`
* **返回值:** `HistoryType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.minecraft.MojangAPIServiceError`:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.

____

### 获取 Minecraft 服务器状态

```csharp
var request = await UAPI.minecraft.GetServerStatus(string server);
            = await UAPI.minecraft.GetServerStatus(string server, int port = 25565);
```

* 参数选项:
    * **server:** 指定要查询的服务器地址
    * **port:** 指定查询的服务器的端口, 默认为 `25565`.
* **返回类型:** `Task <UAPI.minecraft.ServerType>`
* **返回值:** `ServerType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.minecraft.MojangAPIServiceError`:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.

____

### 获取 Minecraft 玩家信息

```csharp
var request = await UAPI.minecraft.GetUserData(string username)
```

* 参数选项:
  * **username:** 指定要查询的用户名
* **返回类型:** `Task <UAPI.minectaft.UserType>`
* **返回值:** `UserType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.minecraft.MojangAPIServiceError`:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.

____

### 获取 Steam 个人用户的公开数据

```csharp
var request = await UAPI.Steam.GetUserData(string SteamID)
    		= await UAPI.Steam.GetUserData(string SteamID, string key)
```

- 参数选项:

  - **SteamID:** 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:

    |  ID类型   | 正则表达式         | 示例 
    | :-------: | :----------------- | :--- |
    | STEAM_ID | ``` Regex: ^STEAM_[0-5]:[01]:\d+$``` | STEAM_1:1:728234856 |
    | STEAM_ID3 | ``` Regex: ^\[U:1:([0-9]+)\]$``` | [U:1:1456469713] |
    | STEAM_ID32 | ``` Regex: ^[0-9]{1,16}$``` | 1456469713 |
    | STEAM_ID64 | ``` Regex: ^7656[0-9]*$``` | 76561199416735441 |
    | Link | ```Regex: https://steamcommunity.com/*``` | https://steamcommunity.com/id/Rainbow-SPY |
    
  - **key:** Steam Web API 所需要的 `Key`  , 这是一个可选参数，如果提供，它将覆盖API供应商提供的全局Key。这为你提供了更大的灵活性，但请务必注意Key的保密，不要在前端暴露。
  
- **返回类型:** `Task <UAPI.Steam.SteamType>`

- **返回值:** `SteamType` 对象

- **异常:**

  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.Steam.SteamServiceError`:  Steam Web API 上游服务异常, 这可能是他们的服务暂时中断.

___

## 网络类请求

### 获取本机的公网IP地址

```csharp
var request = await UAPI.Network.GetMyIP(bool commercial = false)
```

* 参数选项:
  * **commercial:** 指定是否使用商业级的数据源, 默认为 `false` 
* **返回类型:** `Task <UAPI.Network.IPType>`
* **返回值:** `IPType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `HttpRequestException`:  引发的异常的基类 `HttpClient` 和 `HttpMessageHandler` 类 , 使用此异常通常是这个接口没有上游服务, 多数异常来源于服务器和连接过程.



____

## 杂项

### 热榜请求

#### 请求 Bilibili 热榜

```csharp
var request = await UAPI.hotboard.GetBilibiliHotboard();
```

* **返回类型:** `Task <UAPI.hotboard.bilibiliType>`
* **返回值:** `bilibiliType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `Hotboard.HotboardUpstreamServiceError()`: 上游服务异常, 这可能是他们的服务暂时中断.

___

#### 请求网易云音乐热榜

```csharp
var request = await UAPI.hotboard.GetNeteaseMusicHotboard();
```

* **返回类型:** `Task <UAPI.hotboard.NeteaseType>`
* **返回值:** `NeteaseType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `Hotboard.HotboardUpstreamServiceError`:  上游服务异常, 这可能是他们的服务暂时中断.

### 天气请求

```csharp
var request = await UAPI.Weather.GetWeatherDataJson(string city, bool extended = false, bool indices = false, bool forecast = false)
    		= await UAPI.Weather.GetWeatherDataJson(int adcode, bool extended = false, bool indices = false, bool forecast = false
```

* 参数选项:
  * **city:** 指定要查询天气的城市
  * **adcode:** 指定要查询天气的城市的高德地图的6位数字城市编码
  * **extended:** 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 `false`
  * **indices:** 是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）, 默认为 `false`
  * **forecast:** 是否返回预报数据（当日最高/最低气温及未来3天天气预报）, 默认为 `false`
* **返回类型:** `Task <UAPI.Weather.WeatherType>`
* **返回值:** `WeatherType` 对象
* **异常:**
  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.Weather.WeatherServiceError()`:  天气供应商的上游服务不可用, 这可能是他们的服务暂时中断

____



## 开发环境

- #### IDE

  - [IntelliJ JetBrains Rider](https://www.jetbrains.com/zh-cn/rider/)
    - [系统要求](https://www.jetbrains.com.cn/dotnet/download/system-requirements/)
      - Windows 10 版本1809 或更高版本
      - 64 位操作系统, 基于 x64 的处理器
      - .NET Framework 4.7.2 或更高版本
      - 在 Windows 上不得禁用**强名称跳过**功能

  - [Visual Studio 2026](https://visualstudio.microsoft.com/zh-hans/vs)

    - [系统要求](https://learn.microsoft.com/zh-cn/visualstudio/releases/2026/vs-system-requirements)
        - Windows 11 版本 21H2 或更高版本：家庭版、专业版、专业教育版、专业工作站版、企业版和教育版
        - Windows 10 版本 1909 或更高版本：家庭版、专业版、教育版和企业版。
        - 64 位操作系统, 基于 x64 的处理器

    - 工作负荷
        - 桌面应用和移动应用
          - [x] .NET 桌面开发


- 编译语言
  - C# .NET Framework 4.7.2

- 依赖项
    - System.Diagnostics.DiagnosticSource
    - [Rox](https://github.com/Rainbow-SPY/Rox)
      - Rox.Text
        - Rox.Runtimes
    - System.Buffers
    - System.Net.Http
    - [Newtonsoft.Json ](https://www.nuget.org/packages/newtonsoft.json)

___
<!--suppress HtmlDeprecatedAttribute -->

<div align="center">Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.</div>
