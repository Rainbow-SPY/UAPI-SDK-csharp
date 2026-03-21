const t={slug:"social/bilibili-getliveroomstatus",html:`<div class="gfm-alert gfm-alert-important"><div class="gfm-alert-title"><span class="gfm-alert-icon"><svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M7 10h10"></path><path d="M7 14h6"></path><path d="M17 21l-5-3-5 3V5a2 2 0 0 1 2-2h6a2 2 0 0 1 2 2z"></path></svg></span><span>Important</span></div><div class="gfm-alert-body"><p>此页面需要补充此页面需要补充</p>
</div></div><h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetLiveRoomStatus.AsID(string mid, string Authentication = &quot;&quot;);
 = await UAPI.bilibili.GetLiveRoomStatus.AsLiveroomID(string room_id, string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li>参数选项:</li>
<li><strong>mid:</strong> 指定要查询的用户UID(mid)</li>
<li><strong>room_id:</strong> 指定要查询的直播间ID, 和上述参数 <code>mid</code> 选其一即可.</li>
<li><strong>Authentication</strong>: API Token, 默认为空</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.LiveRoomType&gt;</code></li>
<li><strong>返回值:</strong> <code>LiveRoomType</code> 对象</li>
<li><strong>异常:</strong></li>
</ul>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.bilibili.BilibiliServiceError</code>: bilibili API 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>long</code> <strong>uid</strong></td>
<td style="text-align:left">主播的用户ID (mid)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>LiveroomID</strong></td>
<td style="text-align:left">直播间的真实房间号（长号）</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>LiveroomID</code></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>short_id</strong></td>
<td style="text-align:left">直播间的短号（靓号）如果没有设置，则为0</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>Fans</strong></td>
<td style="text-align:left">主播的粉丝数（关注数量）</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>attention</code></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>PopularValue</strong></td>
<td style="text-align:left">直播间当前的人气值, 注意! 这不是真实在线人数</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>online</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>is_portrait</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>live_status</strong></td>
<td style="text-align:left">直播状态0:未开播, 1:直播中, 2:轮播中</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsLiveNow</strong></td>
<td style="text-align:left">当前是否正在直播? (包括直播和轮播)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>parent_area_name</strong></td>
<td style="text-align:left">父分区名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>parent_area_id</strong></td>
<td style="text-align:left">父分区ID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>area_name</strong></td>
<td style="text-align:left">子分区名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>area_id</strong></td>
<td style="text-align:left">子分区ID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>BackgroundImageUrl</strong></td>
<td style="text-align:left">直播间背景图的URL</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>background</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>title</strong></td>
<td style="text-align:left">当前直播间的标题</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CoverImageUrl</strong></td>
<td style="text-align:left">用户设置的直播间封面URL</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>user_cover</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>description</strong></td>
<td style="text-align:left">直播间公告或描述，支持换行符</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>live_time</strong></td>
<td style="text-align:left">本次直播开始的时间，格式为 <code>YYYY-MM-DD HH:mm:ss</code>, 如果未开播，则为空字符串</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>keyframe</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>tags</strong></td>
<td style="text-align:left">直播间设置的标签，以逗号分隔</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>hot_words</strong></td>
<td style="text-align:left">直播间热词列表，通常用于弹幕互动</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><a href="#pendants-new-pendants-嵌套类"><code>Pendants</code> <strong>new_pendants</strong></a></td>
<td style="text-align:left">主播佩戴的头像框、大航海等级等信息</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h3 id="pendants-new-pendants-嵌套类"><code>Pendants</code> <strong>new_pendants</strong> 嵌套类</h3>
<table>
<thead>
<tr>
<th style="text-align:left">属性值</th>
<th>注释</th>
<th style="text-align:left">示例</th>
<th style="text-align:left">备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><a href="#frame-frame-嵌套类"><code>Frame</code> <strong>frame</strong></a></td>
<td>头像框</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><a href="#badge-badge-嵌套类"><code>Badge</code> <strong>badge</strong></a></td>
<td>称号</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<h3 id="frame-frame-嵌套类"><code>Frame</code> <strong>frame</strong> 嵌套类</h3>
<table>
<thead>
<tr>
<th style="text-align:left">属性值</th>
<th>注释</th>
<th style="text-align:left">示例</th>
<th style="text-align:left">备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>头像框</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>value</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>desc</strong></td>
<td>称号</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<h3 id="badge-badge-嵌套类"><code>Badge</code> <strong>badge</strong> 嵌套类</h3>
<table>
<thead>
<tr>
<th style="text-align:left">属性值</th>
<th>注释</th>
<th style="text-align:left">示例</th>
<th style="text-align:left">备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>头像框</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>desc</strong></td>
<td>称号</td>
<td style="text-align:left"></td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
