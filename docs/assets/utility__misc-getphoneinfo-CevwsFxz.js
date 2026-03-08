const t={slug:"utility/misc-getphoneinfo",html:`<h1 id="获取手机号码的归属地信息">获取手机号码的归属地信息</h1>
<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await 
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>phoneNumber:</strong> 指定要查询的中国大陆的11位手机号码</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.PhoneInfoType&gt;</code></li>
<li><strong>返回值:</strong> <code>PhoneInfoType</code> 对象</li>
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
<td style="text-align:left">\`\` ****</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="嵌套类"><code>$</code> <strong>$</strong> 嵌套类</h4>
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
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left">\`\` ****</td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
