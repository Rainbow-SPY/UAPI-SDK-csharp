# UAPI C# SDK 社区版

## 介绍
一个深度集成 [UApi](https://uapis.cn) 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生.

### 贡献者: 
  - [Rainbow-SPY](https://github.com/Rainbow-SPY)
  - [Shuakami](https://github.com/shuakami/)

## 📜 License / 许可证
Copyright (©) AxT-Team & UApi, Developer: Rainbow-SPY. All content is protected by copyright.

This project is licensed under **AGPL-3.0 + Attribution + Non-Commercial terms**.
- 🔍 **You must**:
    - Keep original author attribution and repository link.
    - Open-source any modified versions under AGPL-3.0.
- 🚫 **You cannot**:
    - Use this code (or derivatives) for commercial purposes.
- 📂 See [LICENSE](LICENSE) for full terms.

版权所有 (©) AxT-Team & UApi，开发者：Rainbow-SPY，所有内容均受版权保护。

本项目采用 **AGPL-3.0 + 署名 + 非商业附加条款** 许可协议。
- 🔍 **您必须**：
    - 保留原始作者署名及仓库链接。
    - 任何修改后的版本必须以 AGPL-3.0 协议开源。
- 🚫 **您不得**：
    - 将此代码（或衍生作品）用于商业用途。
- 📂 完整条款参见 [LICENSE](LICENSE)

## 目录
1. 

### 热榜请求
#### 请求 Bilibili 热榜
```csharp
var request = await UAPI.hotboard.GetBilibiliHotboard();
```
* **返回类型:** `Task <UAPI.hotboard.bilibiliType>`
* **返回值:** `bilibiliType` 对象
* **异常:** 
  - `UAPI.IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `$_Exception`:  指定为继承 `System.Exception` 的自定义异常

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
    - [ClaudiaIDE **(视觉 更改文本编辑器的背景)**](https://marketplace.visualstudio.com/items?itemName=kbuchi.ClaudiaIDE)
    - [Hide Main Menu, Title Bar, and Tabs 2026 **(视觉 隐藏Tab栏,主菜单)**](https://marketplace.visualstudio.com/items?itemName=ChrisTorng.MinimalisticView)
    - [IntelliSense Extender 2022 **(代码辅助 IntelliSense增强版)**](https://marketplace.visualstudio.com/items?itemName=Dreamescaper.IntelliSenseExtender2022)
    - [IntelliSense汉语拼音拓展 **(代码辅助 支持汉语拼音拓展)**](https://marketplace.visualstudio.com/items?itemName=stratos.ChinesePinyinIntelliSenseExtender)
    - [Markdown Editor v2 **(编辑器 支持编辑和实时显示Markdown)**](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor2)
    - [One Dark Pro 2026 **(视觉 主题)**](https://marketplace.visualstudio.com/items?itemName=Bayaraa.OneDarkPro2026)

___
<!--suppress HtmlDeprecatedAttribute -->
<div align="center">Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.</div>