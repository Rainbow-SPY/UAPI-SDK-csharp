const t={slug:"utility/misc-getworldtime",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetWorldTime(string region, string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>region:</strong> 指定要查询天气的城市, 格式为 <strong>七大洲之一/地区</strong> 或 <strong>直接输入地区</strong></p>
<p>例: Asia/Shanghai, America/New_York, Tokyo</p>
</li>
<li>
<p><strong>Authentication</strong>: API Token, 默认为空</p>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.WorldTimeType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>WorldTimeType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<blockquote>
<p>因为这个接口没有什么所谓的上游, 因此也不会报出其他异常.</p>
</blockquote>
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
<td style="text-align:left">查询的时区</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>query</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Timezone</strong></td>
<td style="text-align:left">时区</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>timezone</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DateTime</strong></td>
<td style="text-align:left">查询时区的当前时间</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>datetime</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Weekday</strong></td>
<td style="text-align:left">星期</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>weekday</code></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>Timestamp_Unix</strong></td>
<td style="text-align:left">查询时区的当前 Unix 时间</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>timestamp_unix</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Timezone_OffsetsSeconds</strong></td>
<td style="text-align:left">时区秒数偏移量</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>offset_seconds</code><br/>计算公式: 3600 x $UTC<br/>以北京时间 UTC+8为例: 3600 x 8 = 28800</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Timezone_Offsets_str</strong></td>
<td style="text-align:left">查询时区的偏移字符串值</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>offset_string</code><br/>例: (UTC8)</td>
</tr>
</tbody>
</table>
`};export{t as default};
