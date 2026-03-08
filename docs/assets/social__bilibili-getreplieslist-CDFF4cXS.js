const t={slug:"social/bilibili-getreplieslist",html:`<h1 id="查询-bilibili-指定视频的评论数据">查询 bilibili 指定视频的评论数据</h1>
<div class="gfm-alert gfm-alert-important"><div class="gfm-alert-title">Important</div><div class="gfm-alert-body"><p>此页面需要补充此页面需要补充</p>
</div></div><h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetRepliesList(string oid, string sort = &quot;0&quot;, int ps = 20, int pn = 1)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>oid:</strong> 指定要查询的目标评论区的ID对于视频，这通常就是它的 <code>aid</code>/<code>bvid</code>.</li>
<li><strong>sort:</strong> 指定查询视频的排序方式支持 <code>0/time（按时间）</code>、<code>1/like（按点赞）</code>、<code>2/reply（按回复数）</code>、<code>3/hot/hottest/最热（按最热）</code>默认为<code>0/time</code></li>
<li><strong>ps:</strong> 每页获取的评论数量，范围是<code>1</code>到<code>20</code>默认为 <code>20</code></li>
<li><strong>pn:</strong> 要获取的页码，从<code>1</code>开始默认为 <code>1</code></li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.RepliesListType&gt;</code></li>
<li><strong>返回值:</strong> <code>RepliesListType</code> 对象</li>
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
<th style="text-align:center">注释</th>
<th style="text-align:left">备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>Page</code> <strong>page</strong></td>
<td style="text-align:center">分页信息</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>config</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;RepliesItem&gt;</code> <strong>replies</strong></td>
<td style="text-align:center">当前页的评论列表</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;object&gt;</code> <strong>hots</strong></td>
<td style="text-align:center">热门评论列表结构与 <code>replies</code> 中的对象一致.<br/>如果当前页是第一页，且有热门评论，则此数组非空</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>upper</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>top</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>notice</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>vote</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>folder</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>control</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>cursor</strong></td>
<td style="text-align:center">???</td>
<td style="text-align:left">???</td>
</tr>
</tbody>
</table>
<hr>
<h4 id="page-page-嵌套类"><code>Page</code> <strong>page</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>int</code> <strong>num</strong></td>
<td>当前的页码</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>size</strong></td>
<td>每页的评论个数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>count</strong></td>
<td>根评论（即直接评论视频的评论）的总数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>acount</strong></td>
<td>评论区总评论数，包含了所有的楼中楼回复</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h4 id="list-repliesitem-replies-嵌套类"><code>List&lt;RepliesItem&gt;</code> <strong>replies</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>long</code> <strong>ReplyID</strong></td>
<td>评论的唯一ID (Reply ID)</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>oid</strong></td>
<td>评论区对象ID，即视频的aid</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ReplyLocaleType</strong></td>
<td>以字符串格式返回评论区父级分类, 参见 <a href="#评论区父级分类">评论区父级分类</a></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>type</strong></td>
<td>评论区父级分类代码, 参见 <a href="#评论区父级分类">评论区父级分类</a></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>mid</strong></td>
<td>发表评论的用户的mid</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>root</strong></td>
<td>根评论的rpid如果为0，表示这条评论是根评论</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsRootReply</strong></td>
<td>该评论是否为根评论</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>parent</strong></td>
<td>回复的父级评论的rpid如果为0，表示是根评论</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>dialog</strong></td>
<td>回复对方 rpid</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>count</strong></td>
<td>这条评论下的回复（楼中楼）数量</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>rcount</strong></td>
<td>回复评论条数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsHidden</strong></td>
<td>是否被系统隐藏</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsHadFanTag</strong></td>
<td>是否具有粉丝标签</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>attr</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>ctime</strong></td>
<td>评论发送时间的Unix时间戳（秒）</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>like</strong></td>
<td>该评论获得的点赞数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Like_str</strong></td>
<td>该评论获得的点赞数, 返回以&quot;万&quot;为单位的字符串</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>action</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>Member</code> <strong>member</strong></td>
<td>发表评论的用户信息</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>Content</code> <strong>content</strong></td>
<td>评论内容</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;RepliesItem&gt;</code> <strong>replies</strong></td>
<td>楼中楼回复列表结构与顶层评论对象一致，但通常此数组为空，需要单独请求</td>
<td style="text-align:left">通常为空</td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>Reply_control</code> <strong>reply_control</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
</tbody>
</table>
<h5 id="member-member-嵌套类"><code>Member</code> <strong>member</strong> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>mid</strong></td>
<td>用户的 UID</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td>用户昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Sex</strong></td>
<td>用户性别</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>sign</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AvatarUrl</strong></td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>rank</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>Level_info</code> <strong>level_info</strong></td>
<td>用户的B站等级</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>Official_verify</code> <strong>official_verify</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>Vip</code> <strong>vip</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
</tbody>
</table>
<h6 id="level-info-level-info-嵌套类"><code>Level_info</code> <strong>level_info</strong> 嵌套类</h6>
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
<td style="text-align:left"><code>int</code> <strong>current_level</strong></td>
<td>用户的B站等级</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h6 id="official-verify-official-verify-嵌套类"><code>Official_verify</code> <strong>official_verify</strong> 嵌套类</h6>
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
<td style="text-align:left"><code>int</code> <strong>type</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>desc</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
</tbody>
</table>
<h6 id="vip-vip-嵌套类"><code>Vip</code> <strong>vip</strong> 嵌套类</h6>
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
<td style="text-align:left"><code>int</code> <strong>vipType</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>vipStatus</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>vipDueDate</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
</tbody>
</table>
<h5 id="content-content-嵌套类"><code>Content</code> <strong>content</strong> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>message</strong></td>
<td>评论的文本内容</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>emote</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>members</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>jump_url</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
</tbody>
</table>
<h5 id="reply-control-reply-control-嵌套类"><code>Reply_control</code> <strong>reply_control</strong> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>time_desc</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>location</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
</tbody>
</table>
<h3 id="评论区父级分类">评论区父级分类</h3>
<table>
<thead>
<tr>
<th>数值</th>
<th>描述</th>
</tr>
</thead>
<tbody>
<tr>
<td>1</td>
<td>视频稿件</td>
</tr>
<tr>
<td>2</td>
<td>话题</td>
</tr>
<tr>
<td>4</td>
<td>活动</td>
</tr>
<tr>
<td>5</td>
<td>小视频</td>
</tr>
<tr>
<td>6</td>
<td>小黑屋封禁信息</td>
</tr>
<tr>
<td>7</td>
<td>公告信息</td>
</tr>
<tr>
<td>8</td>
<td>直播活动</td>
</tr>
<tr>
<td>9</td>
<td>活动稿件</td>
</tr>
<tr>
<td>10</td>
<td>直播公告</td>
</tr>
<tr>
<td>11</td>
<td>相簿（图片动态）</td>
</tr>
<tr>
<td>12</td>
<td>专栏</td>
</tr>
<tr>
<td>13</td>
<td>票务</td>
</tr>
<tr>
<td>14</td>
<td>音频</td>
</tr>
<tr>
<td>15</td>
<td>风纪委员会</td>
</tr>
<tr>
<td>16</td>
<td>点评</td>
</tr>
<tr>
<td>17</td>
<td>动态（纯文字动态&amp;分享）</td>
</tr>
<tr>
<td>18</td>
<td>播单</td>
</tr>
<tr>
<td>19</td>
<td>音乐播单</td>
</tr>
<tr>
<td>20/21/22</td>
<td>漫画</td>
</tr>
<tr>
<td>33</td>
<td>课程</td>
</tr>
</tbody>
</table>
`};export{t as default};
