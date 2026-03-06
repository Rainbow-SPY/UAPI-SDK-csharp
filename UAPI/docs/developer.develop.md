# 开发者文档 - 使用SDK开发自己的应用程序

为了让SDK更好的使用, 我们制作了这个开发文档

> Copyright (C) Rainbow-SPY & AxT-Team 2019-2026,All rights reserved.

## 了解这个项目SDK

一个深度集成 [UApi](https://uapis.cn) 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生.

### 贡献者:

- <img src="http://q.qlogo.cn/g?b=qq&nk=2716842407&s=640" width=48 height=48 alt=""/>&nbsp;[Rainbow-SPY](https://github.com/Rainbow-SPY)
- <img src="http://q.qlogo.cn/g?b=qq&nk=12519212&s=640" width=48 height=48 alt=""/>&nbsp;[Shuakami](https://github.com/shuakami/)

### License / 许可证

Copyright (©) AxT-Team & UApi, Developer: Rainbow-SPY. All content is protected by copyright.

This project is licensed under **AGPL-3.0 + Attribution + Non-Commercial terms**.

- **You must**:
  - Keep original author attribution and repository link.
  - Open-source any modified versions under AGPL-3.0.
- **You cannot**:
  - Use this code (or derivatives) for commercial purposes.
- See [LICENSE](LICENSE) for full terms.

版权所有 (©) AxT-Team & UApi，开发者：Rainbow-SPY，所有内容均受版权保护。

本项目采用 **AGPL-3.0 + 署名 + 非商业附加条款** 许可协议。

- **您必须**：
  - 保留原始作者署名及仓库链接。
  - 任何修改后的版本必须以 AGPL-3.0 协议开源。
- **您不得**：
  - 将此代码（或衍生作品）用于商业用途。
- 完整条款参见 [LICENSE](LICENSE)

## 添加包

### 在 NuGet CLi 添加包

```nuget
nuget add package UAPI-SDK-Community-csharp //示例, 还没有发行NuGet包
```

### 在 dotnet CLi 添加包

```dotnet
dotnet add package UAPI-SDK-Community-csharp //示例, 还没有发行NuGet包
```

### 在 Github Release 下载发行版

```github
https://github.com/Rainbow-SPY/UAPI-SDK-csharp/releases
```

下载最新的发行版`.zip`包后, 解压到一个指定要引用程序集的目录, 在 Visual Sutdio / IntelliJ Rider / IntelliJ ReShaper 中引用程序集依赖项即可.

### 主要文件

- 主程序集
  - UAPI-community-sdk-csharp.dll

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

  - 第三方程序集

    - AntdUI

      用于依赖项 Rox.Runtimes 的 `Reporter` 窗体渲染, 防止出现未知的异常

    - Newtonsoft.Json

      用于 `Json` 反序列化解析

    - Rox.Runtimes

      用于输出日志、引用字符串常量等

    - Rox.Text

      用于压缩 `Json` .后续会集成移除

  - 来自 Microsoft 的 NuGet 包扩展

      - System.Buffers

      - System.Diagnostics.DiagnosticSource

      - System.Memory

      - System.Numerics.Vectors

      - System.Runtime.CompilerServices.Unsafe

      - System.Net.Http
  

## 撰写一个基础请求方法

### 请求示例

```csharp
using System.Collections.Generic; // List<T>类
using System.Threading.Tasks; // Task 等待任务类
using System;// 处理Exception
using UAPI; // UAPI 核心请求类

bilibili.LiveRoomType request = await bilibili.GetLiveroomStatus.AsLiveroomID("22637261");// 以直播间ID作为传入参
Console.WriteLine($"直播间标题: {(string.IsNullOrEmpty(request.title) ? "未开播" : request.title)}");
// 输出: 
//		直播间标题: 康神开播了?!真的假的?!
// 或
// 		直播间标题: 未开播
```

* 参数选项&返回类型&返回值: 详见 [Github - Rainbow-SPY/UAPI-SDK-csharp/docs/各个方法的开发文档](https://github.com/Rainbow-SPY/UAPI-SDK-csharp/blob/master/UAPI/docs)

> [!TIP] 
>
> 如何查找?
>
> 开发文档和接口的源代码同名, 直接按照源代码文件名搜索相关的开发文档

现在你已经学会了请求接口了







## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`` ****|  | |
|`` ****|  | |
|`` ****|  | |

___
#### `$` **$** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`` ****|  | ||
|`` ****|  | ||
|`` ****|  | ||
|`` ****|  | ||
