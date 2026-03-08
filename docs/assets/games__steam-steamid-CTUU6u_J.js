const t={slug:"games/steam-steamid",html:`<h2 id="从任意-steamid-格式中获取-steam-好友代码">从任意 <code>SteamID</code> 格式中获取 Steam 好友代码</h2>
<h3 id="请求示例">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.Steam.GetFriendCode(string AnySteamID);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>AnySteamID:</strong> 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:</p>
<table>
<thead>
<tr>
<th style="text-align:center">ID类型</th>
<th style="text-align:left">正则表达式格式</th>
<th style="text-align:left">示例</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center">STEAM_ID</td>
<td style="text-align:left"><code> Regex: ^STEAM_[0-5]:[01]:\\d+$</code></td>
<td style="text-align:left">STEAM_1:1:728234856</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID3</td>
<td style="text-align:left"><code> Regex: ^\\[U:1:([0-9]+)\\]$</code></td>
<td style="text-align:left">[U:1:1456469713]</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID32</td>
<td style="text-align:left"><code> Regex: ^[0-9]{1,16}$</code></td>
<td style="text-align:left">1456469713</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID64</td>
<td style="text-align:left"><code> Regex: ^7656[0-9]*$</code></td>
<td style="text-align:left">76561199416735441</td>
</tr>
<tr>
<td style="text-align:center">Link</td>
<td style="text-align:left"><code>Regex: https://steamcommunity.com/*</code></td>
<td style="text-align:left"><a href="https://steamcommunity.com/id/Rainbow-SPY" target="_blank" rel="noreferrer">https://steamcommunity.com/id/Rainbow-SPY</a></td>
</tr>
</tbody>
</table>
</li>
</ul>
</li>
</ul>
<ul>
<li>返回类型: <code>string</code></li>
<li>返回值: 字符串格式的整数型好友代码</li>
<li>异常:
<ul>
<li><strong>ArgumentOutOfRangeException:</strong> 值超出变量列表时引发的异常</li>
</ul>
</li>
</ul>
<h2 id="获取指定的-steam-用户的在线状态">获取指定的 Steam 用户的在线状态</h2>
<h3 id="请求示例-1">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.Steam.GetPersonalState(SteamType steamType);
		   = UAPI.Steam.GetPersonalState(int PersonaState);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>steamType</strong>: 通过 <code>UAPI.Steam.GetUserData()</code> 请求返回的 <code>SteamType</code> 对象</li>
<li><strong>PersonaState</strong>: ???</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 当前的在线状态</li>
</ul>
<h2 id="获取指定的-steam-用户的社区可见性状态">获取指定的 Steam 用户的社区可见性状态</h2>
<h3 id="请求示例-2">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.Steam.GetCommunityVisibilityState(SteamType steamType);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>steamType</strong>: 通过 <code>UAPI.Steam.GetUserData()</code> 请求返回的 <code>SteamType</code> 对象</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 公开 / 私密</li>
</ul>
<h2 id="获取-steam-用户的个人资料状态">获取 Steam 用户的个人资料状态</h2>
<h3 id="请求示例-3">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.Steam.GetProfileState(SteamType steamType);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>steamType</strong>: 通过 <code>UAPI.Steam.GetUserData()</code> 请求返回的 <code>SteamType</code> 对象</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 已填写个人资料 / 未填写个人资料</li>
</ul>
<h2 id="将任意-steamid-转换为-steamid32">将任意 <code>SteamID</code> 转换为 <code>SteamID32</code></h2>
<h3 id="请求示例-4">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.SteamID.Convert.ToSteamID32(string SteamID);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>SteamID</strong>: 任意一种的 <code>SteamID</code>.</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 字符串格式的整数型 <code>SteamID32</code>.</li>
</ul>
<h2 id="将任意-steamid-转换为-steamid64">将任意 <code>SteamID</code> 转换为 <code>SteamID64</code></h2>
<h3 id="请求示例-5">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.SteamID.Convert.ToSteamID64(string SteamID);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>SteamID</strong>: 任意一种的 <code>SteamID</code>.</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 字符串格式的整数型 <code>SteamID64</code>.</li>
</ul>
<h2 id="将任意-steamid-转换为-steamid32-1">将任意 <code>SteamID</code> 转换为 <code>SteamID32</code></h2>
<h3 id="请求示例-6">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.SteamID.Convert.ToSteamID3(string SteamID);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>SteamID</strong>: 任意一种的 <code>SteamID</code>.</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 字符串格式的整数型 <code>SteamID3</code>.</li>
</ul>
<h2 id="将任意-steamid-转换为-steamid1">将任意 <code>SteamID</code> 转换为 <code>SteamID1</code></h2>
<h3 id="请求示例-7">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.SteamID.Convert.ToSteamID(string SteamID);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>SteamID</strong>: 任意一种的 <code>SteamID</code>.</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 字符串格式的整数型 <code>SteamID32</code>.</li>
</ul>
<h2 id="steamid-分析器"><code>SteamID</code> 分析器</h2>
<h3 id="请求示例-8">请求示例</h3>
<pre><code class="language-csharp">var result = UAPI.Steam.Identifier(string AnySteamID);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>AnySteamID:</strong> 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:</p>
<table>
<thead>
<tr>
<th style="text-align:center">ID类型</th>
<th style="text-align:left">正则表达式格式</th>
<th style="text-align:left">示例</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center">STEAM_ID</td>
<td style="text-align:left"><code> Regex: ^STEAM_[0-5]:[01]:\\d+$</code></td>
<td style="text-align:left">STEAM_1:1:728234856</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID3</td>
<td style="text-align:left"><code> Regex: ^\\[U:1:([0-9]+)\\]$</code></td>
<td style="text-align:left">[U:1:1456469713]</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID32</td>
<td style="text-align:left"><code> Regex: ^[0-9]{1,16}$</code></td>
<td style="text-align:left">1456469713</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID64</td>
<td style="text-align:left"><code> Regex: ^7656[0-9]*$</code></td>
<td style="text-align:left">76561199416735441</td>
</tr>
<tr>
<td style="text-align:center">Link</td>
<td style="text-align:left"><code>Regex: https://steamcommunity.com/*</code></td>
<td style="text-align:left"><a href="https://steamcommunity.com/id/Rainbow-SPY" target="_blank" rel="noreferrer">https://steamcommunity.com/id/Rainbow-SPY</a></td>
</tr>
</tbody>
</table>
</li>
</ul>
</li>
</ul>
<ul>
<li>
<p>返回类型: <code>SteamIDType</code></p>
</li>
<li>
<p>返回值: <code>SteamIDType</code> 对象</p>
<table>
<thead>
<tr>
<th style="text-align:center">ID枚举</th>
<th style="text-align:left">示例</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center">SteamIDType.SteamID</td>
<td style="text-align:left">STEAM_1:1:728234856</td>
</tr>
<tr>
<td style="text-align:center">SteamIDType.SteamID3</td>
<td style="text-align:left">[U:1:1456469713]</td>
</tr>
<tr>
<td style="text-align:center">SteamIDType.SteamID32</td>
<td style="text-align:left">1456469713</td>
</tr>
<tr>
<td style="text-align:center">SteamIDType.SteamID64</td>
<td style="text-align:left">76561199416735441</td>
</tr>
<tr>
<td style="text-align:center">SteamIDType.Invalid</td>
<td style="text-align:left">无效的 SteamID</td>
</tr>
</tbody>
</table>
</li>
</ul>
`};export{t as default};
