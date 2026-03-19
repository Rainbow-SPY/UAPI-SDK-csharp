const t={slug:"social/bilibili-getuserdata",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetUserData(string mid);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>mid:</strong> 指定要查询的用户UID(mid)</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.UserType&gt;</code></li>
<li><strong>返回值:</strong> <code>UserType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.bilibili.BilibiliServiceError</code>:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>string</code> <strong>mid</strong></td>
<td style="text-align:left">bilibili 用户的 UID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td style="text-align:left">昵称</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>name</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Sex</strong></td>
<td style="text-align:left">性别</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>sex</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AvatarImageUrl</strong></td>
<td style="text-align:left">头像链接</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>face</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>sign</strong></td>
<td style="text-align:left">签名</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>level</strong></td>
<td style="text-align:left">等级</td>
<td style="text-align:left">最大为6</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>birthday</strong></td>
<td style="text-align:left">生日</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>vip_type</strong></td>
<td style="text-align:left">大会员等级</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>vip_status</strong></td>
<td style="text-align:left">大会员状态</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>following</strong></td>
<td style="text-align:left">关注数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Fans</strong></td>
<td style="text-align:left">粉丝数</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>follower</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>archive_count</strong></td>
<td style="text-align:left">稿件数量</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>article_count</strong></td>
<td style="text-align:left">文章数量</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
