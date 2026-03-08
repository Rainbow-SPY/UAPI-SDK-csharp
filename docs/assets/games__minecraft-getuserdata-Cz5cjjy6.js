const t={slug:"games/minecraft-getuserdata",html:`<h1 id="获取-minecraft-玩家信息">获取 Minecraft 玩家信息</h1>
<blockquote>
<p>[!NOTE]</p>
<p>所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 <code>404</code>等<code>StatusCode</code> .</p>
</blockquote>
<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.minecraft.GetUserData(string username);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>username:</strong> 指定要查询的用户名</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.minectaft.UserType&gt;</code></li>
<li><strong>返回值:</strong> <code>UserType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.minecraft.MojangAPIServiceError</code>:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>string</code> <strong>UserName</strong></td>
<td style="text-align:left">用户名</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>UUID</strong></td>
<td style="text-align:left">玩家的32位无破折号UUID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SkinImageUrl</strong></td>
<td style="text-align:left">玩家当前使用的皮肤图片URL</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
