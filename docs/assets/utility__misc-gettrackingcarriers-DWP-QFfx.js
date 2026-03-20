const t={slug:"utility/misc-gettrackingcarriers",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetTrackingCarriers();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.CarriersType&gt;</code></li>
<li><strong>返回值:</strong> <code>CarriersType</code> 对象</li>
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
<td style="text-align:left"><code>List&lt;CarriersItem&gt;</code> <strong>Carriers</strong></td>
<td style="text-align:left">快递公司列表</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>carriers</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Total</strong></td>
<td style="text-align:left">支持的快递公司总数</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>total</code></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-carriersitem-carriers-嵌套类"><code>List&lt;CarriersItem&gt;</code> <strong>carriers</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>Code</strong></td>
<td>快递公司编码，用于API调用时的 <code>carrier_code</code> 参数</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>code</code></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td>快递公司中文名称，用于界面显示</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>name</code></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
