const t={slug:"social/bilibili-getvideodata",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetVideoData(string video_id, BiliVideoIDType IDType)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
</li>
<li>
<p><strong>mid:</strong> 指定要查询的用户UID(mid)</p>
</li>
<li>
<p><strong>IDType:</strong> 指定查询视频的ID格式, 可供使用的枚举如下:</p>
</li>
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
<td style="text-align:center">AID</td>
<td style="text-align:center">视频的AV号 (aid)</td>
</tr>
<tr>
<td style="text-align:center">BVID</td>
<td style="text-align:center">视频的BV号 (bvid)</td>
</tr>
</tbody>
</table>
<ul>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.VideoType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>VideoType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
</li>
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
<td style="text-align:left"><code>string</code> <strong>bvid</strong></td>
<td style="text-align:left">稿件的BV号</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>aid</strong></td>
<td style="text-align:left">稿件的AV号</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>videos</strong></td>
<td style="text-align:left">稿件分P总数。如果是单P视频，则为1</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>tid</strong></td>
<td style="text-align:left">视频所属的子分区ID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>tname</strong></td>
<td style="text-align:left">视频所属的子分区名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Copyright</strong></td>
<td style="text-align:left">视频版权类型</td>
<td style="text-align:left">返回 “原创”/“转载”</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>IsCopyrightOwner</strong></td>
<td style="text-align:left">是否为版权拥有者</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>copyright</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>CoverImageUrl</strong></td>
<td style="text-align:left">稿件封面图片的URL</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>pic</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>title</strong></td>
<td style="text-align:left">稿件的标题</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>pubdate</strong></td>
<td style="text-align:left">稿件发布时间的Unix时间戳（秒）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>pubdate_str</strong></td>
<td style="text-align:left">稿件发布的字符串时间（秒）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>ctime</strong></td>
<td style="text-align:left">用户投稿时间的Unix时间戳（秒）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ctime_str</strong></td>
<td style="text-align:left">用户投稿的字符串时间（秒）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>desc</strong></td>
<td style="text-align:left">视频简介, 可能会包含HTML换行符</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;Desc_v2&gt;</code> <strong>desc_v2</strong></td>
<td style="text-align:left">详细的视频简介</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsDeleted</strong></td>
<td style="text-align:left">视频是否被删除</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>state</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>state_str</strong></td>
<td style="text-align:left">视频状态</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>duration</strong></td>
<td style="text-align:left">稿件总时长（所有分P累加），单位为秒</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Rights</code> <strong>rights</strong></td>
<td style="text-align:left">视频的各种权限开关（如是否允许转载）</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Owner</code> <strong>owner</strong></td>
<td style="text-align:left">视频UP主信息</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Stat</code> <strong>stat</strong></td>
<td style="text-align:left">统计数据, 播放、点赞、硬币等数据</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>dynamic</strong></td>
<td style="text-align:left">动态的文字, 投稿时附带的动态描述</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>cid</strong></td>
<td style="text-align:left">弹幕 ID (CID), 视频资源（分P）的唯一 ID</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Dimension</code> <strong>dimension</strong></td>
<td style="text-align:left">分辨率信息, 视频宽高等</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>no_cache</strong></td>
<td style="text-align:left">不缓存, 一般为 false</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;Pages&gt;</code> <strong>stat</strong></td>
<td style="text-align:left">视频分P列表。即使是单P视频，该数组也包含一个元素。</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Subtitle</code> <strong>subtitle</strong></td>
<td style="text-align:left">字幕</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;string&gt;</code> <strong>staff</strong></td>
<td style="text-align:left">合作UP主, 联合投稿人列表 (非赞助商)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>ugc_season</strong></td>
<td style="text-align:left">合集信息	如果视频属于某个合集，这里会有数据</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>is_chargeable_season</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>is_story</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left">???</td>
</tr>
<tr>
<td style="text-align:left"><code>Honor_reply</code> <strong>honor_reply</strong></td>
<td style="text-align:left">视频所得荣誉</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-desc-v2-desc-v2-嵌套类"><code>List&lt;Desc_v2&gt;</code> <strong>desc_v2</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>Text</strong></td>
<td>简介文本</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>raw_text</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Type</strong></td>
<td></td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>type</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>biz_id</strong></td>
<td>业务 ID, 被关联对象的 ID</td>
<td style="text-align:left">当 type=1 时，这里是 mid (用户ID)</td>
<td></td>
</tr>
</tbody>
</table>
<h4 id="rights-rights-嵌套类"><code>Rights</code> <strong>rights</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>bool</code> <strong>IsBangumiPay</strong></td>
<td>是否可以承包/付费 (老番剧字段)</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>bp</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowElectronicPay</strong></td>
<td>是否允许付费充电</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>elec</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowDownload</strong></td>
<td>是否允许缓存/下载</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>download</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsMovie</strong></td>
<td>是否是电影</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>movie</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsPay</strong></td>
<td>是否需要付费观看</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>pay</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsHighBitrate</strong></td>
<td>(古早字段) 是否有高码率</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>hd5</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowReprint</strong></td>
<td>是否允许转载</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>no_reprint</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowAutoPlay</strong></td>
<td>是否允许自动播放</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>autoplay</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsUGCPay</strong></td>
<td>是否为UGC 付费</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>ugc_pay</code><br/>&quot;B站课堂&quot;之类的付费课程</td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsCooperation</strong></td>
<td>是否为合作视频</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>is_cooperation</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowPayPreview</strong></td>
<td>是否允许付费视频预览</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>ugc_pay_preview</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>no_background</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsCleanMode</strong></td>
<td>是否为纯净模式</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>clean_mode</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsSteinGate</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>s_stein_gate</code><br/>???</td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>Is360PanoramicVideo</strong></td>
<td>是否为360°全景视频</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>is_360</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowShare</strong></td>
<td>是否允许分享</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>no_share</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsArcPayVideo</strong></td>
<td>是否为付费视频</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>arc_pay</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>IsAllowFreePreviewInPayVideo</strong></td>
<td>是否允许付费视频中的免费试看</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>free_watch</code></td>
</tr>
</tbody>
</table>
<h4 id="owner-owner-嵌套类"><code>Owner</code> <strong>Owner</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>int</code> <strong>mid</strong></td>
<td>UP主的UID</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td>UP主昵称</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>name</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AvatarImageUrl</strong></td>
<td>UP主头像的URL</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>face</code></td>
</tr>
</tbody>
</table>
<h4 id="stat-stat-嵌套类"><code>Stat</code> <strong>stat</strong> 嵌套类</h4>
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
<td>AV号</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Views</strong></td>
<td>播放量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>view</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Danmaku</strong></td>
<td>弹幕量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>danmaku</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Like</strong></td>
<td>点赞量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>like</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>reply</strong></td>
<td>评论量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>reply</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Favorite</strong></td>
<td>收藏量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>favorite</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Coin</strong></td>
<td>投币量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>coin</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Share</strong></td>
<td>分享量</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>share</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>NowRank</strong></td>
<td>当前全站/分区排名</td>
<td style="text-align:left">无排名<br/>/ <code>int.Parse(NowRank)</code></td>
<td>原始<code>Json</code>传入:<code>now_rank</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>HistoryRank</strong></td>
<td>历史排名</td>
<td style="text-align:left">无排名<br/>/ <code>int.Parse(HistoryRank)</code></td>
<td>原始<code>Json</code>传入:<code>his_rank</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>dislike</strong></td>
<td>(古早字段) 点踩量</td>
<td style="text-align:left">0</td>
<td>API 通常返回 0，前端不显示</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>evaluation</strong></td>
<td>(古早字段) 评分/评估</td>
<td style="text-align:left">&lt;empty&gt;</td>
<td>通常为空，古早版本用于视频评分</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>VideoType_old</strong></td>
<td>(古早字段) 视频类型</td>
<td style="text-align:left">0</td>
<td>原始<code>Json</code>传入:<code>vt</code></td>
</tr>
</tbody>
</table>
<h4 id="dimension-dimension-嵌套类"><code>Dimension</code> <strong>dimension</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>int</code> <strong>Width</strong></td>
<td>视频宽度</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>width</code></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Height</strong></td>
<td>视频高度</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>height</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Rotate</strong></td>
<td>旋转角度</td>
<td style="text-align:left">“正常” <br/>“90度旋转” (通常手机拍摄上传会有此标记)</td>
<td>原始<code>Json</code>传入:<code>rotate</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>VideoDimension</strong></td>
<td>视频分辨率</td>
<td style="text-align:left">1920x1080</td>
<td></td>
</tr>
</tbody>
</table>
<h4 id="pages-pages-嵌套类"><code>Pages</code> <strong>pages</strong> 嵌套类</h4>
<table>
<thead>
<tr>
<th style="text-align:left">属性值</th>
<th style="text-align:left">注释</th>
<th style="text-align:left">示例</th>
<th>备注</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>int</code> <strong>cid</strong></td>
<td style="text-align:left">分P的唯一标识CID，用于获取弹幕等</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>page</strong></td>
<td style="text-align:left">分P的序号，</td>
<td style="text-align:left"></td>
<td><strong>从1开始 (非 0)</strong></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SourceWhere</strong></td>
<td style="text-align:left">来源</td>
<td style="text-align:left">B站直传</td>
<td>原始<code>Json</code>传入:<code>from</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>PartTitle</strong></td>
<td style="text-align:left">分P的标题</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>part</code><br/>对于单P视频, 通常是视频主标题</td>
</tr>
<tr>
<td style="text-align:left"><code>long</code> <strong>duration</strong></td>
<td style="text-align:left">该分P的持续时间</td>
<td style="text-align:left"></td>
<td>单位为秒</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>vid</strong></td>
<td style="text-align:left">外部视频源 ID, 现大多为空</td>
<td style="text-align:left">&lt;empty&gt;</td>
<td>如果 <code>SourceWhere</code> 不是&quot;B站直传&quot;, 则为外部视频源ID</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>weblink</strong></td>
<td style="text-align:left">跳转外部链接</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>weblink</code><br/>极少用到</td>
</tr>
<tr>
<td style="text-align:left"><code>Dimension</code> <strong>dimension</strong></td>
<td style="text-align:left">分P视频的分辨率</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h4 id="subtitle-subtitle-嵌套类"><code>Subtitle</code> subtitle 嵌套类</h4>
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
<td style="text-align:left"><code>bool</code> <strong>IsAllowSubmitSubtitle</strong></td>
<td>允许观众投稿 CC 字幕</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>allow_submit</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Name</strong></td>
<td>UP主昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;Subtitles&gt;</code> <strong>list</strong></td>
<td>字幕列表</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h5 id="list-subtitles-list-嵌套类"><code>List&lt;Subtitles&gt;</code> list 嵌套类</h5>
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
<td style="text-align:left"><code>long</code> <strong>id</strong></td>
<td>字幕ID</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LanguageCode</strong></td>
<td>语言代码</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>lan</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LanguageName</strong></td>
<td>语言名称</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>lan_doc</code></td>
</tr>
<tr>
<td style="text-align:left"><code>bool</code> <strong>is_lock</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>author_mid</strong></td>
<td>字幕作者的UID</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>subtitle_url</strong></td>
<td>???</td>
<td style="text-align:left">???</td>
<td>???</td>
</tr>
<tr>
<td style="text-align:left"><code>SubtitleAuthor</code> <strong>author</strong></td>
<td>字幕作者信息</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h6 id="subtitleauthor-author-嵌套类"><code>SubtitleAuthor</code> author 嵌套类</h6>
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
<td style="text-align:left"><code>int</code> <strong>mid</strong></td>
<td>作者的UID</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>作者昵称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AvatarImageUrl</strong></td>
<td>作者头像链接</td>
<td style="text-align:left"></td>
<td>原始<code>Json</code>传入:<code>face</code></td>
</tr>
</tbody>
</table>
<h4 id="honnor-reply-honor-reply-嵌套类"><code>Honnor_reply</code> honor_reply 嵌套类</h4>
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
<td style="text-align:left"><code>List&lt;Honnors&gt;</code> <strong>honor</strong></td>
<td>视频所得荣誉</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h5 id="list-honnors-honor-嵌套类"><code>List&lt;Honnors&gt;</code> honor 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>desc</strong></td>
<td>荣誉名称</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>object</code> <strong>type</strong></td>
<td>荣誉类型</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
