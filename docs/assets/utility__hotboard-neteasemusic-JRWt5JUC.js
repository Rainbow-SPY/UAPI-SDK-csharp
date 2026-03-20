const t={slug:"utility/hotboard-neteasemusic",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.hotboard.GetNeteaseMusicHotboard();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.hotboard.NeteaseType&gt;</code></li>
<li><strong>返回值:</strong> <code>NeteaseType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>Hotboard.HotboardUpstreamServiceError</code>:  上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>List&lt;MainLists&gt;</code> <strong>list</strong></td>
<td style="text-align:left">主要的歌曲热榜列表信息</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-mainlists-mainlists-嵌套类"><code>List&lt;MainLists&gt;</code> <strong>MainLists</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>CoverImageUrl</strong></td>
<td>歌曲专辑封面链接</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>cover</code></td>
</tr>
<tr>
<td style="text-align:left"><code>Extra</code> <strong>extra</strong></td>
<td>歌曲额外元数据</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="extra-extra-嵌套类"><code>Extra</code> <strong>extra</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>album</strong></td>
<td>专辑名称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>artist_names</strong></td>
<td>歌手名称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>duration_text</strong></td>
<td>歌曲时长</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>ID</strong></td>
<td>歌曲在网易云音乐的唯一ID</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>id</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>last_rank</strong></td>
<td>上次的热榜排名</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>popularity</strong></td>
<td>受欢迎程度</td>
<td style="text-align:left"></td>
<td>暂时没有具体用法</td>
</tr>
</tbody>
</table>
`};export{t as default};
