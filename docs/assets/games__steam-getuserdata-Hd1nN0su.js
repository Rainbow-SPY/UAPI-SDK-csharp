const t={slug:"games/steam-getuserdata",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.Steam.GetUserData(string SteamID, string key, string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li><strong>Authentication</strong>: API Token, 默认为空</li>
</ul>
<ul>
<li>
<p><strong>SteamID:</strong> 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:</p>
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
<li>
<p><strong>key:</strong> Steam Web API 所需要的 <code>Key</code> , 这是一个可选参数，如果提供，它将覆盖API供应商提供的全局Key。这为你提供了更大的灵活性，但请务必注意Key的保密，不要在前端暴露。</p>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.Steam.SteamType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>SteamType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.Steam.SteamServiceError</code>: Steam Web API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
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
<td style="text-align:left"><code>string</code> <strong>SteamID64</strong></td>
<td style="text-align:left">SteamID64</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>steamid</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsCommunityVisibility</strong></td>
<td style="text-align:left">Steam社区状态是否可见</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>communityvisibilitystate</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsInitialized</strong></td>
<td style="text-align:left">是否已经填写了个人资料</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>profilestate</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td style="text-align:left">Steam用户名</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>personaname</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ProfileUrl</strong></td>
<td style="text-align:left">Steam个人主页</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>profileurl</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Avatar_32x32</strong></td>
<td style="text-align:left">Steam头像</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>avatar</code><br/>32*32图像</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Avatar_64x64</strong></td>
<td style="text-align:left">Steam头像</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>avatarmedium</code><br/>64*64图像</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Avatar_184x184</strong></td>
<td style="text-align:left">Steam头像</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>avatarfull</code><br/>184*184图像</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AvatarHash</strong></td>
<td style="text-align:left">头像的哈希值</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>avatarhash</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>PersonaState</strong></td>
<td style="text-align:left">Steam在线状态</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>personastate</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>RealName</strong></td>
<td style="text-align:left">Steam真实姓名</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>realname</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>PrimaryClanID</strong></td>
<td style="text-align:left">主要社区组</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>primaryclanid</code><br/>挂在主页的第一个社区组的ID</td>
</tr>
<tr>
<td style="text-align:left"><code>decimal</code> <strong>RegisterTimeUnix</strong></td>
<td style="text-align:left">Steam账号创建日期的时间戳</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>timecreated</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>RegisterTime</strong></td>
<td style="text-align:left">Steam账号创建日期</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>timecreated_str</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>BindLocationRegionCode</strong></td>
<td style="text-align:left">Steam账号绑定区域</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>loccountrycode</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>FriendCode</strong></td>
<td style="text-align:left">好友代码 (SteamID32)</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>friendcode</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SteamID3</strong></td>
<td style="text-align:left">SteamID3</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SteamID1</strong></td>
<td style="text-align:left">SteamID1</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
