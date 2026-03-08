const t={slug:"utility/misc-getprogrammerhistorytoday",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetProgrammerHistoryToday();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.HistoryTodayType&gt;</code></li>
<li><strong>返回值:</strong> <code>HistoryTodayType</code> 对象</li>
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
<td style="text-align:left"><code>string</code> <strong>date</strong></td>
<td style="text-align:left">今日日期</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;EventItem&gt;</code> <strong>events</strong></td>
<td style="text-align:left">事件列表</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-eventitem-events-嵌套类"><code>List&lt;EventItem&gt;</code> <strong>events</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>int</code> <strong>year</strong></td>
<td>年</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>month</strong></td>
<td>月</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>day</strong></td>
<td>日</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Title</strong></td>
<td>标题</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Description</strong></td>
<td>描述</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>category</strong></td>
<td>类型</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>Tags</strong></td>
<td>标签</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>ImportanceLevel</strong></td>
<td>重要等级</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>source</strong></td>
<td>数据源</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
