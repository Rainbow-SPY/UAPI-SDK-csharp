const t={slug:"games/minecraft-gethistoryname",html:`<div class="gfm-alert gfm-alert-note"><div class="gfm-alert-title"><span class="gfm-alert-icon"><svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="12" cy="12" r="10"></circle><path d="M12 16v-4"></path><path d="M12 8h.01"></path></svg></span><span>Note</span></div><div class="gfm-alert-body"><p>所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 <code>404</code>等<code>StatusCode</code> .所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 <code>404</code>等<code>StatusCode</code> .</p>
</div></div><h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.minecraft.GetHistoryName(string _param, SearchType searchType, string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>_param:</strong> 指定要查询的用户UUID或昵称</p>
</li>
<li>
<p><strong>Authentication</strong>: API Token, 默认为空</p>
</li>
<li>
<p><strong>searchType:</strong> 指定查询的查找方式, 可供使用的枚举如下:</p>
<table>
<thead>
<tr>
<th style="text-align:center">枚举值</th>
<th style="text-align:center">注释</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center">UUID</td>
<td style="text-align:center">以UUID查找</td>
</tr>
<tr>
<td style="text-align:center">Name</td>
<td style="text-align:center">以昵称查找</td>
</tr>
</tbody>
</table>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.HistoryType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>HistoryType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.minecraft.MojangAPIServiceError</code>:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<h2 id="属性列表">属性列表</h2>
<p>此API接口较为特殊, 分为使用<code>name</code>参数查询返回的结果和<code>uuid</code>查询的结果.</p>
<h3 id="以-name-查询时返回的属性列表">以 <code>name</code> 查询时返回的属性列表</h3>
<h4 id="根属性">根属性</h4>
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
<td style="text-align:left"><code>string</code> <strong>NUserName</strong></td>
<td style="text-align:left">查询的用户名</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>query</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>NCount</strong></td>
<td style="text-align:left">匹配到的用户数量</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>count</code><br/>为 0 时表示未找到</td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;ResultsItem&gt;</code> <strong>NResults</strong></td>
<td style="text-align:left">匹配到的用户列表</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>results</code><br/>包含当前用户名或曾用名匹配的所有玩家</td>
</tr>
</tbody>
</table>
<hr>
<h5 id="list-resultsitem-nresults-嵌套类"><code>List&lt;ResultsItem&gt;</code> <strong>NResults</strong> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>UserName</strong></td>
<td>玩家当前的用户名</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>id</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>UUID</strong></td>
<td>玩家的UUID</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>uuid</code><br/>带连字符格式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>OldNameCount</strong></td>
<td>历史名称的总数</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>name_num</code></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;History&gt;</code> <strong>history</strong></td>
<td>历史用户名数组</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<hr>
<h6 id="list-history-history-嵌套类"><code>List&lt;History&gt;</code> <strong>history</strong> 嵌套类</h6>
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
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>历史上的昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>changedToAt</strong></td>
<td>何时改的昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h3 id="以-uuid-查询时返回的属性列表">以<code>UUID</code>查询时返回的属性列表</h3>
<h4 id="根属性-1">根属性</h4>
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
<td style="text-align:left"><code>string</code> <strong>U_UserName</strong></td>
<td style="text-align:left">玩家当前的用户名</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>id</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>U_UUID</strong></td>
<td style="text-align:left">被查询玩家的UUID</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>uuid</code><br/>带连字符格式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>U_OldNameCount</strong></td>
<td style="text-align:left">历史名称的总数</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>name_num</code><br/>包含当前用户名</td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;History&gt;</code> <strong>U_HistoryList</strong></td>
<td style="text-align:left">包含所有历史用户名的数组</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>history</code><br/>按时间倒序排列</td>
</tr>
</tbody>
</table>
<hr>
<h5 id="list-history-history-嵌套类-1"><code>List&lt;History&gt;</code> <strong>history</strong> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>历史上的昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>changedToAt</strong></td>
<td>何时改的昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
