const t={slug:"utility/misc-getlunartime",html:`<h1 id="查询农历时间">查询农历时间</h1>
<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetLunarTime(string ts = &quot;&quot;, string timezone = &quot;Asia/Shanghai&quot;)
</code></pre>
<ul>
<li>参数选项:</li>
<li><strong>ts:</strong> Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。</li>
<li><strong>timezone</strong>: 时区名称。支持 IANA 时区（如 <code>Asia/Shanghai</code>）和别名（<code>Shanghai</code>、<code>Beijing</code>）。默认 <code>Asia/Shanghai</code>。</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.LunarTimeType&gt;</code></li>
<li><strong>返回值:</strong> <code>LunarTimeType</code> 对象</li>
<li><strong>异常:</strong></li>
</ul>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>: 未知的异常</li>
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
<td style="text-align:left"><code>string</code> <strong>query_timestamp</strong></td>
<td style="text-align:left">原始传入的时间戳</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>query_timezone</strong></td>
<td style="text-align:left">原始传入的<code>timezone</code>时区</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>timezone</strong></td>
<td style="text-align:left">解析后的时区</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>datetime</strong></td>
<td style="text-align:left">本地化时间</td>
<td style="text-align:left">格式 YYYY-MM-DD HH:mm:ss</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>datetime_rfc3339</strong></td>
<td style="text-align:left">RFC3339 时间格式</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>decimal</code> <strong>timestamp_unix</strong></td>
<td style="text-align:left">秒级 Unix 时间戳</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>weekday</strong></td>
<td style="text-align:left">星期英文</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>weekday_cn</strong></td>
<td style="text-align:left">星期中文</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>lunar_year</strong></td>
<td style="text-align:left">农历年份（数字）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>lunar_month</strong></td>
<td style="text-align:left">农历月份（数字）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>lunar_day</strong></td>
<td style="text-align:left">农历日期（数字）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>is_leap_month</strong></td>
<td style="text-align:left">是否闰月</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>lunar_year_cn</strong></td>
<td style="text-align:left">农历年份中文表示</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>lunar_month_cn</strong></td>
<td style="text-align:left">农历月份中文表示</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>lunar_day_cn</strong></td>
<td style="text-align:left">农历日期中文表示</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ganzhi_year</strong></td>
<td style="text-align:left">干支年</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ganzhi_month</strong></td>
<td style="text-align:left">干支月</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ganzhi_day</strong></td>
<td style="text-align:left">干支日</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>zodiac</strong></td>
<td style="text-align:left">生肖</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>solar_term</strong></td>
<td style="text-align:left">节气，无则为空字符串</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>lunar_festivals</strong></td>
<td style="text-align:left">农历节日数组</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>solar_festivals</strong></td>
<td style="text-align:left">公历节日数组</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
