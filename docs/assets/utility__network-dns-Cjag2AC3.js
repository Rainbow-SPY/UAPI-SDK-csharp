const t={slug:"utility/network-dns",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.Network.LookUpDNS(string domain, DNSRecordType DNSRecordType, string Authentication = &quot;&quot;)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><code>domain</code> :  <strong>指定要查询的主机</strong></p>
</li>
<li>
<p><code>RecordType</code> : <strong>选择查询 DNS 的类型, 枚举如下</strong></p>
<table>
<thead>
<tr>
<th style="text-align:left">枚举值</th>
<th>注释</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>A</code></td>
<td>IPv4</td>
</tr>
<tr>
<td style="text-align:left"><code>AAAA</code></td>
<td>IPv6</td>
</tr>
<tr>
<td style="text-align:left"><code>CNAME</code></td>
<td>别名记录</td>
</tr>
<tr>
<td style="text-align:left"><code>MX</code></td>
<td>邮件服务器</td>
</tr>
<tr>
<td style="text-align:left"><code>NS</code></td>
<td>域名服务器</td>
</tr>
<tr>
<td style="text-align:left"><code>TXT</code></td>
<td>文本记录</td>
</tr>
</tbody>
</table>
</li>
<li>
<p><code>Authentication</code> : API Token Key</p>
</li>
</ul>
</li>
<li>
<p>返回类型: <code>Task&lt;DNSType&gt;</code></p>
</li>
<li>
<p>返回值: <code>DNSType</code> 对象</p>
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
<td style="text-align:left"><code>string</code> <strong>Domain</strong></td>
<td style="text-align:left">查询的主机</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Type</strong></td>
<td style="text-align:left">查询到的DNS类型</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>RecordsItem</code> <strong>Records</strong></td>
<td style="text-align:left">查询到的记录</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="recordsitem-records-嵌套类"><code>RecordsItem</code> <strong>Records</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>TargetIP</strong></td>
<td>记录在表的IP</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
