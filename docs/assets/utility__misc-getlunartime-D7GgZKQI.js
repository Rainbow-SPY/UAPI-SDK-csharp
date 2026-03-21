const t={slug:"utility/misc-getlunartime",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetLunarTime(string ts = &quot;&quot;, string timezone = &quot;Asia/Shanghai&quot;, string Authentication = &quot;&quot;)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li><strong>ts:</strong> Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。</li>
<li><strong>timezone</strong>: 时区名称。支持 IANA 时区（如 <code>Asia/Shanghai</code>）和别名（<code>Shanghai</code>、<code>Beijing</code>）。默认 <code>Asia/Shanghai</code>。</li>
<li><strong>Authentication</strong>: API Token, 默认为空</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.LunarTimeType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>LunarTimeType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li>
<p><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</p>
</li>
<li>
<p><code>UnauthorizedAccessException</code>: 未经授权的请求操作</p>
</li>
<li>
<p><code>IException.General.UAPIUnknowException</code>: 未知的异常</p>
</li>
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
<td style="text-align:left"><code>string</code> <strong>InputTimestamp</strong></td>
<td style="text-align:left">原始传入的时间戳</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>query_timestamp</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>InputTimezone</strong></td>
<td style="text-align:left">原始传入的<code>timezone</code>时区</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>query_timezone</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Timezone</strong></td>
<td style="text-align:left">解析后的时区</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>timezone</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DateTime</strong></td>
<td style="text-align:left">本地化时间</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>datetime</code><br/>格式 YYYY-MM-DD HH:mm:ss</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DateTime_RFC3339</strong></td>
<td style="text-align:left">RFC3339 时间格式</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>datetime_rfc3339</code></td>
</tr>
<tr>
<td style="text-align:left"><code>decimal</code> <strong>Timestamp_Unix</strong></td>
<td style="text-align:left">秒级 Unix 时间戳</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>timestamp_unix</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Weekday</strong></td>
<td style="text-align:left">星期英文</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>weekday</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Weekday_CN</strong></td>
<td style="text-align:left">星期中文</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>weekday_CN</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>LunarYear</strong></td>
<td style="text-align:left">农历年份（数字）</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>Lunar_year</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>LunarMonth</strong></td>
<td style="text-align:left">农历月份（数字）</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>Lunar_month</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>LunarDay</strong></td>
<td style="text-align:left">农历日期（数字）</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>Lunar_day</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsLeapMonth</strong></td>
<td style="text-align:left">是否闰月</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>is_leap_month</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LunarYear_CN</strong></td>
<td style="text-align:left">农历年份中文表示</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>cLunar_year_CNin</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LunarMonth_CN</strong></td>
<td style="text-align:left">农历月份中文表示</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>Lunar_month_CN</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LunarDay_CN</strong></td>
<td style="text-align:left">农历日期中文表示</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>Lunar_day_CN</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>GanzhiYear</strong></td>
<td style="text-align:left">干支年</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>ganzhi_year</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>GanzhiMonth</strong></td>
<td style="text-align:left">干支月</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>ganzhi_month</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>GanzhiDay</strong></td>
<td style="text-align:left">干支日</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>ganzhi_day</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Zodiac</strong></td>
<td style="text-align:left">生肖</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>zodiac</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SolarTerm</strong></td>
<td style="text-align:left">节气，无则为空字符串</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>solar_term</code></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>LunarFestivals</strong></td>
<td style="text-align:left">农历节日数组</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>Lunar_festivals</code></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>SolarFestivals</strong></td>
<td style="text-align:left">公历节日数组</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>solar_festivals</code></td>
</tr>
</tbody>
</table>
`};export{t as default};
