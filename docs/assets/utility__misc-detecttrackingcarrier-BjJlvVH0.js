const t={slug:"utility/misc-detecttrackingcarrier",html:`<h1 id="通过快递单号识别快递公司">通过快递单号识别快递公司</h1>
<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.DetectTrackingCarrier(string tracking_number)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li>**tracking_number: ** 快递单号</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.DetectedCarrierType&gt;</code></li>
<li><strong>返回值:</strong> <code>DetectedCarrierType</code> 对象</li>
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
<td style="text-align:left"><code>string</code> <strong>code</strong></td>
<td style="text-align:left">返回值</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>message</strong></td>
<td style="text-align:left">返回消息</td>
<td style="text-align:left"></td>
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
<td style="text-align:left"><code>string</code> <strong>tracking_number</strong></td>
<td>查询的快递单号</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>carrier_code</strong></td>
<td>最可能的快递公司编码</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>carrier_name</strong></td>
<td>最可能的快递公司名称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;AlternativesItem&gt;</code> <strong>alternatives</strong></td>
<td>其他可能的快递公司列表（如果存在）</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-alternativesitem-alternatives-嵌套类"><code>List&lt;AlternativesItem&gt;</code> <strong>alternatives</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>code</strong></td>
<td>快递公司编码</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>快递公司名称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
