const t={slug:"social/bilibili-getarchives",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetArchives(string mid,
 ArchivesSearchType orderby = ArchivesSearchType.Pubdate,
 string keywords = &quot;&quot;,
 int ps = 20, int pn = 1)
</code></pre>
<ul>
<li>参数选项:</li>
<li><strong>mid:</strong> 指定要查询的用户UID(mid)</li>
<li><strong>orderby:</strong> 指定以何种查询方式, 默认为 <code>Pubdate</code>. 可供使用的枚举有:</li>
</ul>
<table>
<thead>
<tr>
<th style="text-align:center">枚举值</th>
<th style="text-align:center">注释</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center"><code>Pubdate</code></td>
<td style="text-align:center">以最新发布顺序排列</td>
</tr>
<tr>
<td style="text-align:center"><code>Views</code></td>
<td style="text-align:center">以播放量排列</td>
</tr>
</tbody>
</table>
<ul>
<li><strong>keywords:</strong> 指定一个关键字作为查找内容并返回与之相关的内容, 默认为空.</li>
<li><strong>ps:</strong> 指定每页的稿件数量, 默认 <code>20</code>.</li>
<li><strong>pn:</strong> 指定一个页码并返回指定页码的稿件信息, 默认为 <code>1</code>.</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.ArchiveType&gt;</code></li>
<li><strong>返回值:</strong> <code>ArchiveType</code> 对象</li>
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
<th style="text-align:center">属性值</th>
<th style="text-align:center">注释</th>
<th style="text-align:center">备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center"><code>int</code> <strong>total</strong></td>
<td style="text-align:center">投搞的视频总数量</td>
<td style="text-align:center">所公开的全部视频数量</td>
</tr>
<tr>
<td style="text-align:center"><code>int</code> <strong>page</strong></td>
<td style="text-align:center">页码数量</td>
<td style="text-align:center">默认在个人资料显示的全部视频页数</td>
</tr>
<tr>
<td style="text-align:center"><code>int</code> <strong>size</strong></td>
<td style="text-align:center">每页的数量</td>
<td style="text-align:center">总数量 = 页码数量 x 每页的数量</td>
</tr>
<tr>
<td style="text-align:center"><a href="#listvideos-video-嵌套类"><code>List&lt;Videos&gt;</code> <strong>videos</strong></a></td>
<td style="text-align:center">视频的综合数据</td>
<td style="text-align:center">一个公共嵌套类, 使用<br/> <code>foreach/for</code> 循环读取</td>
</tr>
</tbody>
</table>
<hr>
<h3 id="list-videos-video-嵌套类"><code>List&lt;videos&gt;</code> <strong>Video</strong> 嵌套类</h3>
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
<td style="text-align:left"><code>long</code> <strong>aid</strong></td>
<td>视频的AID</td>
<td style="text-align:left"><code>AV55</code><br/>2020年后的a<head/>v号将突破 <code>Int_MAX</code><br/>例:<code>av116114575072948</code></td>
<td style="text-align:left">经典老版的 A<head/>V 号</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>bvid</strong></td>
<td>视频的bv号</td>
<td style="text-align:left"><code>BV1xx411c7Ug</code> (同上转换得来)</td>
<td style="text-align:left">2020年3月23日 之后更新的 BV 号<br/>如</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>title</strong></td>
<td>视频的标题</td>
<td style="text-align:left">【天哥版】最春哥</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>cover</strong></td>
<td>视频的封面 ( Url )</td>
<td style="text-align:left"><code>http://i1.hdslb.com/bfs/archive/$MD5...jpg</code></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>duration</strong></td>
<td>一个视频内所有选集的总时长(秒)</td>
<td style="text-align:left">98</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>play_count</strong></td>
<td>播放量</td>
<td style="text-align:left">1974600</td>
<td style="text-align:left">整数型的 <code>long</code> 格式属性<br/>如果要使用以’万’为单位的<br/>请使用UAPI的接口函数 <code>UAPI.Interface.FormatPlayCount(int _Count)</code><br/>返回以’万’为单位的字符串格式的播放量数据</td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>publish_time</strong></td>
<td>视频发布的时间 (<strong>时间戳</strong>格式)</td>
<td style="text-align:left">1247496094</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>publish_time_str</strong></td>
<td>视频发布的时间 (<strong>字符串</strong>格式)</td>
<td style="text-align:left">2009/7/13 22:41:34</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>create_time</strong></td>
<td>视频创建的时间 (<strong>时间戳</strong>格式)</td>
<td style="text-align:left">1247496094</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>create_time_str</strong></td>
<td>视频创建的时间 (<strong>字符串</strong>格式)</td>
<td style="text-align:left">2009/7/13 22:41:34</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>state</strong></td>
<td>当前状态</td>
<td style="text-align:left">0</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsPayVideo</strong></td>
<td>是否为充电视频</td>
<td style="text-align:left"><code>True</code>/<code>False</code></td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>IsPayVideo_str</strong></td>
<td>是否为充电视频 (<strong>字符串</strong>格式)</td>
<td style="text-align:left">免费/付费</td>
<td style="text-align:left">原始<code>Json</code>传入: <code>is_ugc_pay</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsInteractive</strong></td>
<td>是否为共创视频</td>
<td style="text-align:left"><code>True</code>/<code>False</code></td>
<td style="text-align:left">原始<code>Json</code>传入: <code>is_interactive</code></td>
</tr>
</tbody>
</table>
`};export{t as default};
