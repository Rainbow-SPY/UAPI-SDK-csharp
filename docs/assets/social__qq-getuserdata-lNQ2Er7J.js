const t={slug:"social/qq-getuserdata",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.QQ.GetUserData(string qq, string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>qq:</strong> 指定要查询的用户QQ号</li>
<li><strong>Authentication</strong>: API Token, 默认为空</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.QQ.UserType&gt;</code></li>
<li><strong>返回值:</strong> <code>UserType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.QQ.QQServiceError()</code>:  QQ 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>string</code> <strong>QQ</strong></td>
<td style="text-align:left">QQ号</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>qq</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td style="text-align:left">昵称</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>nickname</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CustomSignText</strong></td>
<td style="text-align:left">个性签名</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>long_nick</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AvatarImageUrl</strong></td>
<td style="text-align:left">头像链接</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>avatar_url</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Age</strong></td>
<td style="text-align:left">年龄</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>age</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Sex</strong></td>
<td style="text-align:left">性别</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>sex</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>QID</strong></td>
<td style="text-align:left">QQ个性域名</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>qid</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>QQLevel</strong></td>
<td style="text-align:left">QQ等级</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>qq_level</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Location</strong></td>
<td style="text-align:left">地理位置</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>location</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Email</strong></td>
<td style="text-align:left">电子邮箱</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>email</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsVip</strong></td>
<td style="text-align:left">是否开通了SVIP</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>is_vip</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>VipLevel</strong></td>
<td style="text-align:left">会员等级</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>vip_level</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>RegisterTime_ISO8601</strong></td>
<td style="text-align:left">注册时间</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>reg_time</code><br/>ISO 8601 格式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>RegisterTime</strong></td>
<td style="text-align:left">注册时间</td>
<td style="text-align:left">字符串格式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LastUpdatedTime_ISO8601</strong></td>
<td style="text-align:left">最后更新时间</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>last_updated</code><br/>ISO 8601 格式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LastUpdatedTime</strong></td>
<td style="text-align:left">最后更新时间</td>
<td style="text-align:left">字符串格式</td>
</tr>
</tbody>
</table>
`};export{t as default};
