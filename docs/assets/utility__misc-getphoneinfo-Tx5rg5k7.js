const t={slug:"utility/misc-getphoneinfo",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetPhoneInfo(string phoneNumber);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>phoneNumber:</strong> 指定要查询的中国大陆 11 位手机号码</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.PhoneInfoType&gt;</code></li>
<li><strong>返回值:</strong> <code>PhoneInfoType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>: 未知的异常</li>
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
<td style="text-align:left"><code>string</code> <strong>Province</strong></td>
<td style="text-align:left">省份归属地</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>province</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>City</strong></td>
<td style="text-align:left">城市或地区归属地</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>city</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LSP</strong></td>
<td style="text-align:left">运营商名称</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>sp</code></td>
</tr>
</tbody>
</table>
`};export{t as default};
