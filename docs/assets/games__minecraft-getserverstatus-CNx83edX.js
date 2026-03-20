const t={slug:"games/minecraft-getserverstatus",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.minecraft.GetServerStatus(string server, int port=25565);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li><strong>server:</strong> 指定要查询的服务器地址</li>
<li><strong>port:</strong> 指定查询的服务器的端口, 默认为 <code>25565</code>.</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.minecraft.ServerType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>ServerType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.minecraft.MojangAPIServiceError</code>: Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>string</code> <strong>FaviconUrlWithBase64</strong></td>
<td style="text-align:left">服务器图标的 Base64 Data Url</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>favicon_url</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>IP</strong></td>
<td style="text-align:left">解析后的IP地址</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>ip</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>MaxPlayers</strong></td>
<td style="text-align:left">服务器配置的最大玩家数量</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>max_players</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>motd_clean</strong></td>
<td style="text-align:left">纯文本格式的服务器MOTD（每日消息）</td>
<td style="text-align:left">去除了所有颜色和格式代码</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>motd_html</strong></td>
<td style="text-align:left">HTML格式的服务器MOTD</td>
<td style="text-align:left">保留了颜色和样式</td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsServerOnline</strong></td>
<td style="text-align:left">服务器是否在线</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>online</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>CurrentPlayers</strong></td>
<td style="text-align:left">当前的玩家数量</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>players</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Port</strong></td>
<td style="text-align:left">使用的端口号</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>port</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>version</strong></td>
<td style="text-align:left">服务器报告的版本信息</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
