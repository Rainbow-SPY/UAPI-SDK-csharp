const t={slug:"utility/misc-postdatediff",html:`<h1 id="计算两个日期之间的差值">计算两个日期之间的差值</h1>
<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.PostDateDiff(string start_date, string end_date,string format = &quot;YYYY-MM-DD&quot;);
</code></pre>
<ul>
<li>参数列表
<ul>
<li><strong>start_date</strong>: 开始时间/日期</li>
<li><strong>end_date</strong>: 结束时间/日期</li>
<li><strong>format</strong>: 时间格式, 默认为 <code>YYYY-MM-DD</code></li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.DateDiffType&gt;</code></li>
<li><strong>返回值:</strong> <code>DateDiffType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
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
<td style="text-align:left"><code>long</code> <strong>days</strong></td>
<td style="text-align:left">总天数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>hours</strong></td>
<td style="text-align:left">总小时数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>minutes</strong></td>
<td style="text-align:left">总分钟数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>seconds</strong></td>
<td style="text-align:left">总秒数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>weeks</strong></td>
<td style="text-align:left">总周数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>human_readable</strong></td>
<td style="text-align:left">人性化显示格式</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
