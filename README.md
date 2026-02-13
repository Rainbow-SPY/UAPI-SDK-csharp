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

1. [热榜请求](#热榜请求)
    1. [请求bilibili热榜](#%E8%AF%B7%E6%B1%82-bilibili-%E7%83%AD%E6%A6%9C)
    2. [请求网易云音乐热榜](#请求网易云音乐热榜)
2. [bilibili 相关请求](#bilibili-相关请求)
    1. [请求bilibili热榜](#请求-bilibili-热榜)
    2. [获取指定UP的所有稿件信息](#获取指定up的所有稿件信息)
    3. [获取指定UP的直播间信息](#获取指定up的直播间信息)
    4. [获取指定用户的公开账户数据](#获取指定用户的账户数据)
    5. [获取指定视频的详细数据](#获取指定视频的详细数据)
3. [游戏功能性请求](#游戏功能性请求)
    1. [获取Epic Games每日免费游戏](#获取epic-games每日免费游戏)

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

### bilibili 相关请求

#### [请求 bilibili热榜](#请求-bilibili-热榜)

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

#### 获取指定视频的详细数据

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

### 游戏功能性请求

#### 获取Epic Games每日免费游戏

```csharp
var request = await UAPI.EpicGames.GetDataJson();
```

* **返回类型:** `Task <UAPI.EpicGames.EpicType>`
* **返回值:** `EpicType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.EpicGames.EpicGamesServerError`:  Epic Games 上游 API 服务异常

#### 获取 Minecraft 玩家历史昵称

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

#### 获取 Minecraft 服务器状态

```csharp
var request = await UAPI.minecraft.GetServerStatus(string server);
            = await UAPI.minecraft.GetServerStatus(string server, int port = 25565);
```

* 参数选项:
    * **server:** 指定要查询的服务器地址
    * **port:** 指定查询的服务器的端口, 默认为 `25565`.
* **返回类型:** `Task <UAPI.bilibili.ServerType>`
* **返回值:** `ServerType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.minecraft.MojangAPIServiceError`:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.

____

#### 获取 Steam 个人用户的公开数据

```csharp
var request = await UAPI.Steam.GetUserData(string SteamID)
    		  await UAPI.Steam.GetUserData(string SteamID, string key)
```

- 参数选项:

  - **SteamID:** 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:

    |  ID类型   | 正则表达式         | 示例 |
    | :-------: | ------------------ | ---- |
    | STEAM_ID | ``` Regex: ^STEAM_[0-5]:[01]:\d+$``` | STEAM_1:1:728234856 |
    | STEAM_ID3 | ``` Regex: ^\[U:1:([0-9]+)\]$``` | [U:1:1456469713] |
    | STEAM_ID32 | ``` Regex: ^[0-9]{1,16}$``` | 1456469713 |
    | STEAM_ID64 | ``` Regex: ^7656[0-9]*$``` | 76561199416735441 |

    





## 开发环境

[Visual Studio 2026](https://visualstudio.microsoft.com/zh-hans/vs)<br>
[IntelliJ JetBrains Rider](https://www.jetbrains.com/zh-cn/rider/)

- 系统要求
    - [Windows 11 版本 21H2 或更高版本：家庭版、专业版、专业教育版、专业工作站版、企业版和教育版](https://learn.microsoft.com/zh-cn/visualstudio/releases/2026/vs-system-requirements)
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
      > (部分使用, 大部分使用 `Rox.Text.Json` 进行简单反/序列化)
- 扩展
  > 以下扩展均为 Visual Studio 2026 版本适用的扩展
    - [ClaudiaIDE **(视觉 更改文本编辑器的背景)
      **](https://marketplace.visualstudio.com/items?itemName=kbuchi.ClaudiaIDE)
    - [Hide Main Menu, Title Bar, and Tabs 2026 **(视觉 隐藏Tab栏,主菜单)
      **](https://marketplace.visualstudio.com/items?itemName=ChrisTorng.MinimalisticView)
    - [IntelliSense Extender 2022 **(代码辅助 IntelliSense增强版)
      **](https://marketplace.visualstudio.com/items?itemName=Dreamescaper.IntelliSenseExtender2022)
    - [IntelliSense汉语拼音拓展 **(代码辅助 支持汉语拼音拓展)
      **](https://marketplace.visualstudio.com/items?itemName=stratos.ChinesePinyinIntelliSenseExtender)
    - [Markdown Editor v2 **(编辑器 支持编辑和实时显示Markdown)
      **](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor2)
    - [One Dark Pro 2026 **(视觉 主题)**](https://marketplace.visualstudio.com/items?itemName=Bayaraa.OneDarkPro2026)

___
<!--suppress HtmlDeprecatedAttribute -->
<div align="center">Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.</div>
