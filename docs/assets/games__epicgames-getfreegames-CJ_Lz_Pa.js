const t={slug:"games/epicgames-getfreegames",html:`<h1 id="查询-epic-games-当前免费游戏的数据">查询 Epic Games 当前免费游戏的数据</h1>
<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.EpicGames.GetDataJson();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.EpicGames.EpicType&gt;</code></li>
<li><strong>返回值:</strong> <code>EpicType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.EpicGames.EpicGamesServerError</code>:  Epic Games 上游 API 服务异常</li>
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
<td style="text-align:left"><code>List&lt;GameData&gt;</code> <strong>data</strong></td>
<td style="text-align:left">免费游戏列表（数组）</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<h4 id="list-gamedata-data-嵌套类"><code>List&lt;GameData&gt;</code> data 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>id</strong></td>
<td style="text-align:left">游戏的唯一标识ID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>title</strong></td>
<td style="text-align:left">游戏的完整标题名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CoverImageUrl</strong></td>
<td style="text-align:left">游戏封面图片的URL地址</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>original_price</strong></td>
<td style="text-align:left">游戏的原价</td>
<td style="text-align:left">单位: 人民币</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>original_price_desc</strong></td>
<td style="text-align:left">格式化后的原价描述字符串</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>description</strong></td>
<td style="text-align:left">游戏的简介描述</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>seller</strong></td>
<td style="text-align:left">发行商</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsFreeNow</strong></td>
<td style="text-align:left">当前是否处于免费状态</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>FreeStartTime</strong></td>
<td style="text-align:left">免费开始时间, 可读字符串格式</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>FreeStartTimeUnix</strong></td>
<td style="text-align:left">免费开始时间, 13位毫秒时间戳</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>FreeEndTime</strong></td>
<td style="text-align:left">免费结束时间的可读字符串格式</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>FreeEndTimeUnix</strong></td>
<td style="text-align:left">免费结束时间的13位毫秒时间戳</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>link</strong></td>
<td style="text-align:left">游戏在Epic Games商店的详情页链接</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
