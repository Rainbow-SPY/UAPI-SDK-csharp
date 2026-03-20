const t={slug:"utility/misc-gettrackinginfo",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetTrackingInfo(string tracking_number, string carrier_code = &quot;&quot;,string phone = &quot;&quot;);
</code></pre>
<ul>
<li>参数列表
<ul>
<li><strong>tracking_number</strong>: 快递单号，通常是一串10-20位的数字或字母数字组合。</li>
<li><strong>carrier_code</strong>: 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。</li>
<li><strong>phone</strong>: 收件人手机尾号，4位数字（可选）。部分快递公司需要验证手机尾号才能查询详细物流信息。</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.TrackingInfoType&gt;</code></li>
<li><strong>返回值:</strong> <code>TrackingInfoType</code> 对象</li>
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
<td style="text-align:left"><code>string</code> <strong>Code</strong></td>
<td style="text-align:left">状态码</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>code</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Message</strong></td>
<td style="text-align:left">消息</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>message</code></td>
</tr>
<tr>
<td style="text-align:left"><code>Data</code> <strong>data</strong></td>
<td style="text-align:left">返回的数据</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="data-data-嵌套类"><code>Data</code> <strong>data</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>TrackingNumber</strong></td>
<td>快递公司编码</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>tracking_number</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CarrierCode</strong></td>
<td>快递公司编码</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>carrier_code</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CarrierName</strong></td>
<td>快递公司名称</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>carrier_name</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>TrackCount</strong></td>
<td>物流轨迹数量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>track_count</code></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;TracksItem&gt;</code> <strong>Tracks</strong></td>
<td>物流轨迹列表</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>tracks</code><br/>按时间倒序排列</td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-tracksitem-tracks-嵌套类"><code>List&lt;TracksItem&gt;</code> <strong>tracks</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>Time</strong></td>
<td>物流更新时间</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>time</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Context</strong></td>
<td>物流状态描述</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>context</code></td>
</tr>
</tbody>
</table>
`};export{t as default};
