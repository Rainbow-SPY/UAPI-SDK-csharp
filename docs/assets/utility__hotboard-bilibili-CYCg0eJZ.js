const t={slug:"utility/hotboard-bilibili",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.hotboard.GetBilibiliHotboard(string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li><strong>参数选项</strong>:
<ul>
<li><strong>Authentication</strong>: API Token, 默认为空</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.hotboard.bilibiliType&gt;</code></li>
<li><strong>返回值:</strong> <code>bilibiliType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>Hotboard.HotboardUpstreamServiceError()</code>: 上游服务异常, 这可能是他们的服务暂时中断.</li>
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
<td style="text-align:left"><code>List&lt;lists&gt;</code> <strong>list</strong></td>
<td style="text-align:left">bilibili热榜排行榜列表</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-lists-lists-嵌套类"><code>List&lt;lists&gt;</code> <strong>lists</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>Extra</code> extra</td>
<td>视频的额外信息</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<hr>
<h5 id="extra-extra-嵌套类"><code>Extra</code> extra 嵌套类</h5>
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
<td style="text-align:left"><code>long</code> <strong>aid</strong></td>
<td>av号</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>bvid</strong></td>
<td>BV号</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>desc</strong></td>
<td>简介文本</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>durations</strong></td>
<td>总计时长</td>
<td style="text-align:left"></td>
<td>格式化为分钟+秒</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>seconds</strong></td>
<td>总计时长</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>duration</code><br/>以秒为单位</td>
</tr>
<tr>
<td style="text-align:left"><code>Owner</code> <strong>owner</strong></td>
<td>UP主信息</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CoverImageUrl</strong></td>
<td>视频封面链接</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>pic</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>pubdate_str</strong></td>
<td>发布时间</td>
<td style="text-align:left">YYYY-MM-DD HH:mm:ss</td>
<td>格式化后</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>pubdate</strong></td>
<td>发布时间</td>
<td style="text-align:left">YYYY-MM-DDT HH:mm:ssZ</td>
<td>ISO 8601格式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>rcmd_reason</strong></td>
<td>视频荣誉</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>short_link</strong></td>
<td>视频短链接</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>Stat</code> <strong>stat</strong></td>
<td>视频统计信息</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>tname</strong></td>
<td>视频分区名称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h6 id="owner-owner-嵌套类"><code>Owner</code> owner 嵌套类</h6>
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
<td style="text-align:left"><code>string</code> <strong>AvatarImageUrl</strong></td>
<td>头像链接</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入: <code>face</code></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>Mid</strong></td>
<td>UID</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td>昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h6 id="stat-stat嵌套类"><code>Stat</code> stat嵌套类</h6>
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
<td style="text-align:left"><code>string</code> <strong>Coin_str</strong></td>
<td>投币量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Coin_int</strong></td>
<td>投币量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>coin</code><br/>纯数字形式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Danmaku_str</strong></td>
<td>弹幕量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Danmaku_int</strong></td>
<td>弹幕量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>danmaku</code><br/>纯数字形式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Favorite_str</strong></td>
<td>收藏量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Favorite_int</strong></td>
<td>收藏量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>favorite</code><br/>纯数字形式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Like_str</strong></td>
<td>点赞量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Like_int</strong></td>
<td>点赞量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>like</code><br/>纯数字形式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Reply_str</strong></td>
<td>评论量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Reply_int</strong></td>
<td>评论量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>reply</code><br/>纯数字形式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Share_str</strong></td>
<td>分享量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Share_int</strong></td>
<td>分享量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>share</code><br/>纯数字形式</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>view_str</strong></td>
<td>观看量</td>
<td style="text-align:left"></td>
<td>以<strong>万</strong>为单位的形式</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>View_int</strong></td>
<td>观看量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>view</code><br/>纯数字形式</td>
</tr>
</tbody>
</table>
`};export{t as default};
