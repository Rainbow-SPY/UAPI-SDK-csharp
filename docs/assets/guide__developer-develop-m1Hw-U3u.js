const n={slug:"guide/developer-develop",html:`<h1 id="开发者文档-使用sdk开发自己的应用程序">开发者文档 - 使用SDK开发自己的应用程序</h1>
<p>为了让SDK更好的使用, 我们制作了这个开发文档</p>
<blockquote>
<p>Copyright © Rainbow-SPY &amp; AxT-Team 2019-2026,All rights reserved.</p>
</blockquote>
<h2 id="了解这个项目sdk">了解这个项目SDK</h2>
<p>一个深度集成 <a href="https://uapis.cn" target="_blank" rel="noreferrer">UApi</a> 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生.</p>
<h3 id="贡献者">贡献者:</h3>
<ul>
<li><img src="http://q.qlogo.cn/g?b=qq&nk=2716842407&s=640" width=48 height=48 alt=""/> <a href="https://github.com/Rainbow-SPY" target="_blank" rel="noreferrer">Rainbow-SPY</a></li>
<li><img src="http://q.qlogo.cn/g?b=qq&nk=12519212&s=640" width=48 height=48 alt=""/> <a href="https://github.com/shuakami/" target="_blank" rel="noreferrer">Shuakami</a></li>
</ul>
<h3 id="license-许可证">License / 许可证</h3>
<p>Copyright (©) AxT-Team &amp; UApi, Developer: Rainbow-SPY. All content is protected by copyright.</p>
<p>This project is licensed under <strong>AGPL-3.0 + Attribution + Non-Commercial terms</strong>.</p>
<ul>
<li><strong>You must</strong>:
<ul>
<li>Keep original author attribution and repository link.</li>
<li>Open-source any modified versions under AGPL-3.0.</li>
</ul>
</li>
<li><strong>You cannot</strong>:
<ul>
<li>Use this code (or derivatives) for commercial purposes.</li>
</ul>
</li>
<li>See <a href="LICENSE">LICENSE</a> for full terms.</li>
</ul>
<p>版权所有 (©) AxT-Team &amp; UApi，开发者：Rainbow-SPY，所有内容均受版权保护。</p>
<p>本项目采用 <strong>AGPL-3.0 + 署名 + 非商业附加条款</strong> 许可协议。</p>
<ul>
<li><strong>您必须</strong>：
<ul>
<li>保留原始作者署名及仓库链接。</li>
<li>任何修改后的版本必须以 AGPL-3.0 协议开源。</li>
</ul>
</li>
<li><strong>您不得</strong>：
<ul>
<li>将此代码（或衍生作品）用于商业用途。</li>
</ul>
</li>
<li>完整条款参见 <a href="LICENSE">LICENSE</a></li>
</ul>
<h2 id="添加包">添加包</h2>
<h3 id="在-nuget-cli-添加包">在 NuGet CLi 添加包</h3>
<pre><code class="language-nuget">nuget add package UAPI-SDK-Community-csharp //示例, 还没有发行NuGet包
</code></pre>
<h3 id="在-dotnet-cli-添加包">在 dotnet CLi 添加包</h3>
<pre><code class="language-dotnet">dotnet add package UAPI-SDK-Community-csharp //示例, 还没有发行NuGet包
</code></pre>
<h3 id="在-github-release-下载发行版">在 Github Release 下载发行版</h3>
<pre><code class="language-github">https://github.com/Rainbow-SPY/UAPI-SDK-csharp/releases
</code></pre>
<p>下载最新的发行版<code>.zip</code>包后, 解压到一个指定要引用程序集的目录, 在 Visual Sutdio / IntelliJ Rider / IntelliJ ReShaper 中引用程序集依赖项即可.</p>
<h3 id="主要文件">主要文件</h3>
<ul>
<li>主程序集
<ul>
<li>UAPI-community-sdk-csharp.dll</li>
</ul>
</li>
</ul>
<h2 id="开发环境">开发环境</h2>
<ul>
<li>
<h4 id="ide">IDE</h4>
<ul>
<li>
<p><a href="https://www.jetbrains.com/zh-cn/rider/" target="_blank" rel="noreferrer">IntelliJ JetBrains Rider</a></p>
<ul>
<li><a href="https://www.jetbrains.com.cn/dotnet/download/system-requirements/" target="_blank" rel="noreferrer">系统要求</a>
<ul>
<li>Windows 10 版本1809 或更高版本</li>
<li>64 位操作系统, 基于 x64 的处理器</li>
<li>.NET Framework 4.7.2 或更高版本</li>
<li>在 Windows 上不得禁用<strong>强名称跳过</strong>功能</li>
</ul>
</li>
</ul>
</li>
<li>
<p><a href="https://visualstudio.microsoft.com/zh-hans/vs" target="_blank" rel="noreferrer">Visual Studio 2026</a></p>
<ul>
<li>
<p><a href="https://learn.microsoft.com/zh-cn/visualstudio/releases/2026/vs-system-requirements" target="_blank" rel="noreferrer">系统要求</a></p>
<ul>
<li>Windows 11 版本 21H2 或更高版本：家庭版、专业版、专业教育版、专业工作站版、企业版和教育版</li>
<li>Windows 10 版本 1909 或更高版本：家庭版、专业版、教育版和企业版。</li>
<li>64 位操作系统, 基于 x64 的处理器</li>
</ul>
</li>
<li>
<p>工作负荷</p>
<ul>
<li>桌面应用和移动应用
<ul>
<li>[x] .NET 桌面开发</li>
</ul>
</li>
</ul>
</li>
</ul>
</li>
</ul>
</li>
<li>
<p>编译语言</p>
<ul>
<li>C# .NET Framework 4.7.2</li>
</ul>
</li>
<li>
<p>依赖项</p>
<ul>
<li>
<p>第三方程序集</p>
<ul>
<li>
<p>AntdUI</p>
<p>用于依赖项 Rox.Runtimes 的 <code>Reporter</code> 窗体渲染, 防止出现未知的异常</p>
</li>
<li>
<p>Newtonsoft.Json</p>
<p>用于 <code>Json</code> 反序列化解析</p>
</li>
<li>
<p>Rox.Runtimes</p>
<p>用于输出日志、引用字符串常量等</p>
</li>
<li>
<p>Rox.Text</p>
<p>用于压缩 <code>Json</code> .后续会集成移除</p>
</li>
</ul>
</li>
<li>
<p>来自 Microsoft 的 NuGet 包扩展</p>
<ul>
<li>
<p>System.Buffers</p>
</li>
<li>
<p>System.Diagnostics.DiagnosticSource</p>
</li>
<li>
<p>System.Memory</p>
</li>
<li>
<p>System.Numerics.Vectors</p>
</li>
<li>
<p>System.Runtime.CompilerServices.Unsafe</p>
</li>
<li>
<p>System.Net.Http</p>
</li>
</ul>
</li>
</ul>
</li>
</ul>
<h2 id="撰写一个基础请求方法">撰写一个基础请求方法</h2>
<h3 id="请求示例">请求示例</h3>
<pre><code class="language-csharp">using System.Collections.Generic; // List&lt;T&gt;类
using System.Threading.Tasks; // Task 等待任务类
using System;// 处理Exception
using UAPI; // UAPI 核心请求类

bilibili.LiveRoomType request = await bilibili.GetLiveroomStatus.AsLiveroomID(&quot;22637261&quot;);// 以直播间ID作为传入参
Console.WriteLine($&quot;直播间标题: {(string.IsNullOrEmpty(request.title) ? &quot;未开播&quot; : request.title)}&quot;);
// 输出: 
//		直播间标题: 康神开播了?!真的假的?!
// 或
// 		直播间标题: 未开播
</code></pre>
<ul>
<li>参数选项&amp;返回类型&amp;返回值: 详见 <a href="https://github.com/Rainbow-SPY/UAPI-SDK-csharp/blob/master/UAPI/docs" target="_blank" rel="noreferrer">Github - Rainbow-SPY/UAPI-SDK-csharp/docs/各个方法的开发文档</a></li>
</ul>
<div class="gfm-alert gfm-alert-tip"><div class="gfm-alert-title"><span class="gfm-alert-icon"><svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M15 14c.2-.63.5-1.2.92-1.68A6 6 0 1 0 8.08 12.3c.42.48.72 1.05.92 1.7"></path><path d="M9 18h6"></path><path d="M10 22h4"></path></svg></span><span>Tip</span></div><div class="gfm-alert-body"><p>如何查找?</p>
<p>开发文档和接口的源代码同名, 直接按照源代码文件名搜索相关的开发文档</p>
</div></div><p>现在你已经学会了请求接口了</p>
<h2 id="属性列表">属性列表</h2>
<h3 id="根属性">根属性</h3>
<table>
<thead>
<tr>
<th style="text-align:left">属性值</th>
<th style="text-align:left">注释</th>
<th style="text-align:left">备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left">\`\` ****</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="嵌套类"><code>$</code> <strong>$</strong> 嵌套类</h4>
<table>
<thead>
<tr>
<th style="text-align:left">属性值</th>
<th>注释</th>
<th style="text-align:left">示例</th>
<th>备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{n as default};
