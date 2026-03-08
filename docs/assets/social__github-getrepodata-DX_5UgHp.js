const t={slug:"social/github-getrepodata",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.github.GetReposData(string owner_and_repo)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>owner_and_repo:</strong> 指定要查询的用户+仓库, 例: <code>&quot;torvalds/linux&quot;</code></li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.github.ReposType&gt;</code></li>
<li><strong>返回值:</strong> <code>ReposType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.github.GithubAPIServiceError()</code>:  Github 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>string</code> <strong>FullName</strong></td>
<td style="text-align:left">仓库完整名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Description</strong></td>
<td style="text-align:left">简介</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>HomePage</strong></td>
<td style="text-align:left">主页链接</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DefaultBranch</strong></td>
<td style="text-align:left">默认分支</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>PrimaryBranch</strong></td>
<td style="text-align:left">主要分支</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>Visibility</strong></td>
<td style="text-align:left">可见性</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsArchived</strong></td>
<td style="text-align:left">是否归档</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsDisabled</strong></td>
<td style="text-align:left">是否禁用</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>vip_status</strong></td>
<td style="text-align:left">大会员状态</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>MainLanguage</strong></td>
<td style="text-align:left">主要语言</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>Topics</strong></td>
<td style="text-align:left">话题</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>License</strong></td>
<td style="text-align:left">许可证</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Stargazers</strong></td>
<td style="text-align:left">星星数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Forks</strong></td>
<td style="text-align:left">Fork 数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>OpenIssues</strong></td>
<td style="text-align:left">开放问题数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Watchers</strong></td>
<td style="text-align:left">关注者数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>PushedTime_ISO8601</strong></td>
<td style="text-align:left">最后推送时间（ISO 8601 格式）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CreatedTime_ISO8601</strong></td>
<td style="text-align:left">创建时间（ISO 8601 格式）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>UpdatedTime_ISO8601</strong></td>
<td style="text-align:left">更新时间（ISO 8601 格式）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code> Dictionary&lt;string, int&gt;</code> <strong>LanguagesStats</strong></td>
<td style="text-align:left">语言统计</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>Collaborators</strong></td>
<td style="text-align:left">协作者</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Maintainer[]</code> <strong>Maintainers</strong></td>
<td style="text-align:left">维护者</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DefaultBranchSHAHash</strong></td>
<td style="text-align:left">默认分支的 SHA 值</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>PushedTime_String</strong></td>
<td style="text-align:left">最后推送时间 (字符串格式)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CreatedTime_String</strong></td>
<td style="text-align:left">创建时间 (字符串格式)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>UpdatedTime_Str</strong></td>
<td style="text-align:left">更新时间 (字符串格式)</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<h4 id="maintainer-maintainers-嵌套类"><code>Maintainer</code> Maintainers 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>login</strong></td>
<td style="text-align:left">登录名</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td style="text-align:left">名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>email</strong></td>
<td style="text-align:left">邮件</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>url</strong></td>
<td style="text-align:left">URL</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
