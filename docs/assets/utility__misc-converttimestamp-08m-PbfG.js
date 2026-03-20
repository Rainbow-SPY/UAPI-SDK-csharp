const t={slug:"utility/misc-converttimestamp",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.CovertTimestamp(string ts);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>ts:</strong> Unix 时间戳, 支持10位（秒）或13位（毫秒）。</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.TimestampType&gt;</code></li>
<li><strong>返回值:</strong> <code>TimestampType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
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
<td style="text-align:left"><code>string</code> <strong>InputValue</strong></td>
<td style="text-align:left">输入的值</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>input</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Type</strong></td>
<td style="text-align:left">转换的类型</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>type</code></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>UnixTimestamp</strong></td>
<td style="text-align:left">Unix 时间戳</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>unix_timestamp</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DateTime_UTC</strong></td>
<td style="text-align:left">UTC+0:00 (世界协调时间) 格式的字符串</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>datetime_utc</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DateTime_Local</strong></td>
<td style="text-align:left">以IP地址推断的世界协调时间的本地时间</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>datetime_local</code><br/>在中国一般指北京时间 UTC +8:00</td>
</tr>
</tbody>
</table>
`};export{t as default};
