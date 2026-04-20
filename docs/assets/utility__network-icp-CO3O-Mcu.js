const t={slug:"utility/network-icp",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.Network.GetICPInfo(string domain, string Authentication = &quot;&quot;)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li><strong>domain</strong>: 指定要查询的主机</li>
<li><strong>Anthentication</strong>: API Token Key</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.Type.ICPType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>ICPType</code> 对象</p>
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
<td style="text-align:left">返回的状态码</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Domain</strong></td>
<td style="text-align:left">查询的主机</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ServiceLicence</strong></td>
<td style="text-align:left">ICP备案号</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>UnitName</strong></td>
<td style="text-align:left">主办单位名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>NatureName</strong></td>
<td style="text-align:left">主办单位的性质 (企业/个人)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>msg</strong></td>
<td style="text-align:left">返回的消息</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
