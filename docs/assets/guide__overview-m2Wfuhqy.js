const n={slug:"guide/overview",html:`<h1 id="uapi-c-sdk-社区版">UAPI C# SDK 社区版</h1>
<h2 id="介绍">介绍</h2>
<p>一个深度集成 <a href="https://uapis.cn" target="_blank" rel="noreferrer">UApi</a> 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生.</p>
<h3 id="贡献者">贡献者:</h3>
<ul>
<li><img src="http://q.qlogo.cn/g?b=qq&nk=2716842407&s=640" width=48 height=48 alt=""/> <a href="https://github.com/Rainbow-SPY" target="_blank" rel="noreferrer">Rainbow-SPY</a></li>
<li><img src="http://q.qlogo.cn/g?b=qq&nk=12519212&s=640" width=48 height=48 alt=""/> <a href="https://github.com/shuakami/" target="_blank" rel="noreferrer">Shuakami</a></li>
</ul>
<h2 id="license-许可证">License / 许可证</h2>
<p>Copyright (©) AxT-Team &amp; UApi, Developer: Rainbow-SPY. All content is protected by copyright.</p>
<p>This project is licensed under <strong>AGPL-3.0 + Attribution + Non-Commercial terms</strong>.</p>
<ul>
<li><strong>You must</strong>:
<ul>
<li>Keep original author attribution and repository link.</li>
<li>Open-source any modified versions under AGPL-3.0.</li>
</ul>
</li>
<li><strong>You cannot</strong>:
<ul>
<li>Use this code (or derivatives) for commercial purposes.</li>
</ul>
</li>
<li>See <a href="https://github.com/Rainbow-SPY/UAPI-SDK-csharp/blob/master/LICENSE" target="_blank" rel="noreferrer">LICENSE</a> for full terms.</li>
</ul>
<p>版权所有 (©) AxT-Team &amp; UApi，开发者：Rainbow-SPY，所有内容均受版权保护。</p>
<p>本项目采用 <strong>AGPL-3.0 + 署名 + 非商业附加条款</strong> 许可协议。</p>
<ul>
<li><strong>您必须</strong>：
<ul>
<li>保留原始作者署名及仓库链接。</li>
<li>任何修改后的版本必须以 AGPL-3.0 协议开源。</li>
</ul>
</li>
<li><strong>您不得</strong>：
<ul>
<li>将此代码（或衍生作品）用于商业用途。</li>
</ul>
</li>
<li>完整条款参见 <a href="https://github.com/Rainbow-SPY/UAPI-SDK-csharp/blob/master/LICENSE" target="_blank" rel="noreferrer">LICENSE</a></li>
</ul>
<h2 id="目录">目录</h2>
<ol>
<li><a href="#社交类请求">社交类请求</a>
<ol>
<li><a href="#bilibili-相关请求">bilibili 相关请求</a>
<ol>
<li><a href="#请求-bilibili-热榜">请求bilibili热榜</a></li>
<li><a href="#获取指定up的所有稿件信息">获取指定UP的所有稿件信息</a></li>
<li><a href="#获取指定up的直播间信息">获取指定UP的直播间信息</a></li>
<li><a href="#获取指定用户的账户数据">获取指定用户的公开账户数据</a></li>
<li><a href="#获取指定视频的详细数据">获取指定视频的详细数据</a></li>
<li><a href="#获取指定视频的评论区数据">获取指定视频的评论区数据</a></li>
</ol>
</li>
<li><a href="#qq-相关请求">QQ 相关请求</a>
<ol>
<li><a href="#获取qq群相关信息">获取QQ群相关信息</a></li>
<li><a href="#获取qq用户相关信息">获取QQ用户相关信息</a></li>
</ol>
</li>
</ol>
</li>
<li><a href="#游戏功能性请求">游戏功能性请求</a>
<ol>
<li><a href="#获取epic-games每日免费游戏">获取Epic Games每日免费游戏</a></li>
<li><a href="#获取-minecraft-玩家历史昵称">获取 Minecraft 玩家历史昵称</a></li>
<li><a href="#获取-minecraft-服务器状态">获取 Minecraft 服务器状态</a></li>
<li><a href="#获取-minecraft-玩家信息">获取 Minecraft 玩家信息</a></li>
<li><a href="#获取-steam-个人用户的公开数据">获取 Steam 个人用户的公开数据</a></li>
</ol>
</li>
<li><a href="#获取本机的公网ip地址">网络类请求</a>
<ol>
<li><a href="#获取本机的公网ip地址">获取本机的公网IP地址</a></li>
</ol>
</li>
<li><a href="#杂项">杂项</a>
<ol>
<li><a href="#热榜请求">热榜请求</a>
<ol>
<li><a href="#请求-bilibili-热门排行榜">请求bilibili热榜</a></li>
<li><a href="#请求网易云音乐热榜">请求网易云音乐热榜</a></li>
</ol>
</li>
<li><a href="#天气请求">天气请求</a></li>
<li><a href="#获取全球时区时间">获取全球时区时间</a></li>
<li><a href="#获取手机号码的归属地信息">获取手机号码的归属地信息</a></li>
<li><a href="#获取一组随机数字">获取一组随机数字</a></li>
<li><a href="#获取程序员历史上的今天的事件">获取程序员历史上的今天的事件</a></li>
<li><a href="#转换-unix-时间戳">转换 Unix 时间戳</a></li>
<li><a href="#通过快递单号识别快递公司">通过快递单号识别快递公司</a></li>
<li><a href="#查询农历时间">查询农历时间</a></li>
<li><a href="#获取支持的快递公司列表">获取支持的快递公司列表</a></li>
<li><a href="#查询快递物流信息">查询快递物流信息</a></li>
<li><a href="#计算两个日期之间的差值">计算两个日期之间的差值</a></li>
</ol>
</li>
</ol>
<h2 id="社交类请求">社交类请求</h2>
<h3 id="bilibili-相关请求">bilibili 相关请求</h3>
<h4 id="请求-bilibili-热门排行榜">请求 bilibili 热门排行榜</h4>
<blockquote>
<p>转到 <a href="#请求-bilibili-热榜">热榜请求 - 请求 bilibili热榜</a></p>
</blockquote>
<hr>
<h4 id="获取指定up的所有稿件信息">获取指定UP的所有稿件信息</h4>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetArchives(string mid,
            ArchivesSearchType orderby = ArchivesSearchType.Pubdate,
            string keywords = &quot;&quot;,
            int ps = 20, int pn = 1)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li>
<p><strong>mid:</strong> 指定要查询的用户UID(mid)</p>
</li>
<li>
<p><strong>orderby:</strong> 指定以何种查询方式, 默认为 <code>Pubdate</code>. 可供使用的枚举有:</p>
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
</li>
<li>
<p><strong>keywords:</strong> 指定一个关键字作为查找内容并返回与之相关的内容, 默认为空.</p>
</li>
<li>
<p><strong>ps:</strong> 指定每页的稿件数量, 默认 <code>20</code>.</p>
</li>
<li>
<p><strong>pn:</strong> 指定一个页码并返回指定页码的稿件信息, 默认为 <code>1</code>.</p>
</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.ArchiveType&gt;</code></li>
<li><strong>返回值:</strong> <code>ArchiveType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.bilibili.BilibiliServiceError</code>:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
<li><strong>属性列表</strong>: <a href="?doc=social%2Fbilibili-getarchives" data-doc-slug="social/bilibili-getarchives">详见 bilibili.GetArchives.md</a></li>
</ul>
<hr>
<h4 id="获取指定up的直播间信息">获取指定UP的直播间信息</h4>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetLiveRoomStatus.AsID(string mid);
            = await UAPI.bilibili.GetLiveRoomStatus.AsLiveroomID(string room_id);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>mid:</strong> 指定要查询的用户UID(mid)</li>
<li><strong>room_id:</strong> 指定要查询的直播间ID, 和上述参数 <code>mid</code> 选其一即可.</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.LiveRoomType&gt;</code></li>
<li><strong>返回值:</strong> <code>LiveRoomType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.bilibili.BilibiliServiceError</code>:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h4 id="获取指定用户的账户数据">获取指定用户的账户数据</h4>
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
<hr>
<h4 id="获取指定视频的详细数据">获取指定视频的详细数据</h4>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetVideoData(string video_id, BiliVideoIDType IDType)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li>
<p><strong>mid:</strong> 指定要查询的用户UID(mid)</p>
</li>
<li>
<p><strong>IDType:</strong> 指定查询视频的ID格式, 可供使用的枚举如下:</p>
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
</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.VideoType&gt;</code></li>
<li><strong>返回值:</strong> <code>VideoType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.bilibili.BilibiliServiceError</code>:  bilibili API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h4 id="获取指定视频的评论区数据">获取指定视频的评论区数据</h4>
<pre><code class="language-csharp">var request = await UAPI.bilibili.GetRepliesList(string oid, string sort = &quot;0&quot;, int ps = 20, int pn = 1)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>oid:</strong> 指定要查询的目标评论区的ID。对于视频，这通常就是它的 <code>aid</code>/<code>bvid</code>.</li>
<li><strong>sort:</strong> 指定查询视频的排序方式。支持 <code>0/time（按时间）</code>、<code>1/like（按点赞）</code>、<code>2/reply（按回复数）</code>、
<code>3/hot/hottest/最热（按最热）</code>。默认为<code>0/time</code>。</li>
<li><strong>ps:</strong> 每页获取的评论数量，范围是<code>1</code>到<code>20</code>。默认为 <code>20</code>。</li>
<li><strong>pn:</strong> 要获取的页码，从<code>1</code>开始。默认为 <code>1</code>。</li>
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
<h3 id="qq-相关请求">QQ 相关请求</h3>
<h4 id="获取qq群相关信息">获取QQ群相关信息</h4>
<pre><code class="language-csharp">var request = await UAPI.QQ.GetGroupData(string group_id);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>group_id:</strong> 指定要查询的群ID</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.QQ.GroupType&gt;</code></li>
<li><strong>返回值:</strong> <code>GroupType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.QQ.QQServiceError()</code>:  QQ 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h4 id="获取qq用户相关信息">获取QQ用户相关信息</h4>
<pre><code class="language-csharp">var request = await UAPI.QQ.GetUserData(string qq);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>qq:</strong> 指定要查询的用户QQ号</li>
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
<h3 id="获取-github-仓库信息">获取 Github 仓库信息</h3>
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
<h2 id="游戏功能性请求">游戏功能性请求</h2>
<h3 id="获取epic-games每日免费游戏">获取Epic Games每日免费游戏</h3>
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
<hr>
<blockquote>
<p>[!NOTE]<br>
所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 <code>404</code>等<code>StatusCode</code> .</p>
</blockquote>
<h3 id="获取-minecraft-玩家历史昵称">获取 Minecraft 玩家历史昵称</h3>
<pre><code class="language-csharp">var request = await UAPI.minecraft.GetHistoryName(string _param, SearchType searchType);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li>
<p><strong>_param:</strong> 指定要查询的用户UUID或昵称</p>
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
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.bilibili.HistoryType&gt;</code></li>
<li><strong>返回值:</strong> <code>HistoryType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.minecraft.MojangAPIServiceError</code>:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取-minecraft-服务器状态">获取 Minecraft 服务器状态</h3>
<pre><code class="language-csharp">var request = await UAPI.minecraft.GetServerStatus(string server, int port = 25565);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>server:</strong> 指定要查询的服务器地址</li>
<li><strong>port:</strong> 指定查询的服务器的端口, 默认为 <code>25565</code>.</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.minecraft.ServerType&gt;</code></li>
<li><strong>返回值:</strong> <code>ServerType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.minecraft.MojangAPIServiceError</code>:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取-minecraft-玩家信息">获取 Minecraft 玩家信息</h3>
<pre><code class="language-csharp">var request = await UAPI.minecraft.GetUserData(string username)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>username:</strong> 指定要查询的用户名</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.minectaft.UserType&gt;</code></li>
<li><strong>返回值:</strong> <code>UserType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.minecraft.MojangAPIServiceError</code>:  Mojang API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取-steam-个人用户的公开数据">获取 Steam 个人用户的公开数据</h3>
<pre><code class="language-csharp">var request = await UAPI.Steam.GetUserData(string SteamID, string key);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>SteamID:</strong> 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下:</p>
<table>
<thead>
<tr>
<th style="text-align:center">ID类型</th>
<th style="text-align:left">正则表达式格式</th>
<th style="text-align:left">示例</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center">STEAM_ID</td>
<td style="text-align:left"><code> Regex: ^STEAM_[0-5]:[01]:\\d+$</code></td>
<td style="text-align:left">STEAM_1:1:728234856</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID3</td>
<td style="text-align:left"><code> Regex: ^\\[U:1:([0-9]+)\\]$</code></td>
<td style="text-align:left">[U:1:1456469713]</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID32</td>
<td style="text-align:left"><code> Regex: ^[0-9]{1,16}$</code></td>
<td style="text-align:left">1456469713</td>
</tr>
<tr>
<td style="text-align:center">STEAM_ID64</td>
<td style="text-align:left"><code> Regex: ^7656[0-9]*$</code></td>
<td style="text-align:left">76561199416735441</td>
</tr>
<tr>
<td style="text-align:center">Link</td>
<td style="text-align:left"><code>Regex: https://steamcommunity.com/*</code></td>
<td style="text-align:left"><a href="https://steamcommunity.com/id/Rainbow-SPY" target="_blank" rel="noreferrer">https://steamcommunity.com/id/Rainbow-SPY</a></td>
</tr>
</tbody>
</table>
</li>
<li>
<p><strong>key:</strong> Steam Web API 所需要的 <code>Key</code>  , 这是一个可选参数，如果提供，它将覆盖API供应商提供的全局Key。这为你提供了更大的灵活性，但请务必注意Key的保密，不要在前端暴露。</p>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.Steam.SteamType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>SteamType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.Steam.SteamServiceError</code>:  Steam Web API 上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h2 id="网络类请求">网络类请求</h2>
<h3 id="获取本机的公网ip地址">获取本机的公网IP地址</h3>
<pre><code class="language-csharp">var request = await UAPI.Network.GetMyIP(bool commercial = false);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>commercial:</strong> 指定是否使用商业级的数据源, 默认为 <code>false</code></li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.Network.IPType&gt;</code></li>
<li><strong>返回值:</strong> <code>IPType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>HttpRequestException</code>:  引发的异常的基类 <code>HttpClient</code> 和 <code>HttpMessageHandler</code> 类 , 使用此异常通常是这个接口没有上游服务, 多数异常来源于服务器和连接过程.</li>
</ul>
</li>
</ul>
<hr>
<h2 id="杂项">杂项</h2>
<h3 id="热榜请求">热榜请求</h3>
<h4 id="请求-bilibili-热榜">请求 Bilibili 热榜</h4>
<pre><code class="language-csharp">var request = await UAPI.hotboard.GetBilibiliHotboard();
</code></pre>
<ul>
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
<hr>
<h4 id="请求网易云音乐热榜">请求网易云音乐热榜</h4>
<pre><code class="language-csharp">var request = await UAPI.hotboard.GetNeteaseMusicHotboard();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.hotboard.NeteaseType&gt;</code></li>
<li><strong>返回值:</strong> <code>NeteaseType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>Hotboard.HotboardUpstreamServiceError</code>:  上游服务异常, 这可能是他们的服务暂时中断.</li>
</ul>
</li>
</ul>
<hr>
<h3 id="天气请求">天气请求</h3>
<pre><code class="language-csharp">var request = await UAPI.Weather.GetWeatherDataJson(string city,
                    bool extended = false, bool indices = false,
                    bool forecast = false, bool hourly = false,
                    bool minutely = false);
    		= await UAPI.Weather.GetWeatherDataJson(int adcode, 
                    bool extended = false, bool indices = false, 
                    bool forecast = false, bool hourly = false,
                    bool minutely = false);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>city:</strong> 指定要查询天气的城市</li>
<li><strong>adcode:</strong> 指定要查询天气的城市的高德地图的6位数字城市编码</li>
<li><strong>extended:</strong> 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 <code>false</code></li>
<li><strong>indices:</strong> 是否返回生活指数（穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度）, 默认为 <code>false</code></li>
<li><strong>forecast:</strong> 是否返回预报数据（当日最高/最低气温及未来3天天气预报）, 默认为 <code>false</code></li>
<li><strong>hourly</strong>: 是否返回逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等</li>
<li><strong>minutely</strong>:是否返回分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.Weather.WeatherType&gt;</code></li>
<li><strong>返回值:</strong> <code>WeatherType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.Weather.WeatherServiceError()</code>:  天气供应商的上游服务不可用, 这可能是他们的服务暂时中断</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取全球指定时区的当地时间">获取全球指定时区的当地时间</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetWorldTime(string region);
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>region:</strong> 指定要查询天气的城市, 格式为 <strong>七大洲之一/地区</strong> 或 <strong>直接输入地区</strong></p>
<p>例: Asia/Shanghai, America/New_York, Tokyo</p>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.WorldTimeType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>WorldTimeType</code> 对象</p>
</li>
<li>
<p><strong>异常:</strong></p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<blockquote>
<p>因为这个接口没有什么所谓的上游, 因此也不会报出其他异常.</p>
</blockquote>
<hr>
<h3 id="获取手机号码的归属地信息">获取手机号码的归属地信息</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetPhoneInfo(string phoneNumber)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>phoneNumber:</strong> 指定要查询的中国大陆的11位手机号码</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.PhoneInfoType&gt;</code></li>
<li><strong>返回值:</strong> <code>PhoneInfoType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取一组随机数字">获取一组随机数字</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetRandomNumberList(int min = 0, int max = 0, int count = 0,bool allow_repeat = false, bool allow_decimal = false, int decimal_places = 0);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>min:</strong> 生成随机数的最小值（包含）。</li>
<li><strong>max:</strong> 生成随机数的最大值（包含）。</li>
<li><strong>count:</strong> 需要生成的随机数的数量。</li>
<li><strong>allow_repeat:</strong> 是否允许生成的多个数字中出现重复值。</li>
<li><strong>allow_decimal:</strong> 是否生成小（浮点）数。如果为 <code>false</code>，则只生成整数。</li>
<li><strong>decimal_places:</strong> 如果 <code>allow_decimal=true</code>，这里可以指定小数的位数。</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.RandomNumberType&gt;</code></li>
<li><strong>返回值:</strong> <code>RandomNumberType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException()</code>:  未知异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取程序员历史上的今天的事件">获取程序员历史上的今天的事件</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetProgrammerHistoryToday();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.HistoryTodayType&gt;</code></li>
<li><strong>返回值:</strong> <code>HistoryTodayType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="转换-unix-时间戳">转换 Unix 时间戳</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.CovertTimestamp(string ts);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>ts</strong> : Unix 时间戳, 支持10位（秒）或13位（毫秒）。</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.TimestampType&gt;</code></li>
<li><strong>返回值:</strong> <code>TimestampType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="通过快递单号识别快递公司">通过快递单号识别快递公司</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.DetectTrackingCarrier(string tracking_number);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li>**tracking_number: ** 快递单号</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.DetectedCarrierType&gt;</code></li>
<li><strong>返回值:</strong> <code>DetectedCarrierType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="查询农历时间">查询农历时间</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetLunarTime(string ts = &quot;&quot;, string timezone = &quot;Asia/Shanghai&quot;)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li>**ts: ** Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。</li>
<li><strong>timezone</strong>: 时区名称。支持 IANA 时区（如 <code>Asia/Shanghai</code>）和别名（<code>Shanghai</code>、<code>Beijing</code>）。默认 <code>Asia/Shanghai</code>。</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.LunarTimeType&gt;</code></li>
<li><strong>返回值:</strong> <code>LunarTimeType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="获取支持的快递公司列表">获取支持的快递公司列表</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetTrackingCarriers();
</code></pre>
<ul>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.CarriersType&gt;</code></li>
<li><strong>返回值:</strong> <code>CarriersType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="查询快递物流信息">查询快递物流信息</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.GetTrackingInfo(string tracking_number, string carrier_code = &quot;&quot;,string phone = &quot;&quot;);
</code></pre>
<ul>
<li>参数列表
<ul>
<li><strong>tracking_number</strong>: 快递单号，通常是一串10-20位的数字或字母数字组合。</li>
<li><strong>carrier_code</strong>: 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。</li>
<li><strong>phone</strong>: 收件人手机尾号，4位数字（可选）。部分快递公司需要验证手机尾号才能查询详细物流信息。</li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.TrackingInfoType&gt;</code></li>
<li><strong>返回值:</strong> <code>TrackingInfoType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<hr>
<h3 id="计算两个日期之间的差值">计算两个日期之间的差值</h3>
<pre><code class="language-csharp">var request = await UAPI.misc.PostDateDiff(string start_date, string end_date,string format = &quot;YYYY-MM-DD&quot;);
</code></pre>
<ul>
<li>参数列表
<ul>
<li><strong>start_date</strong>: 开始时间/日期</li>
<li><strong>end_date</strong>: 结束时间/日期</li>
<li><strong>format</strong>: 时间格式, 默认为 <code>YYYY-MM-DD</code></li>
</ul>
</li>
<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.DateDiffType&gt;</code></li>
<li><strong>返回值:</strong> <code>DateDiffType</code> 对象</li>
<li><strong>异常:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
<h2 id="开发环境">开发环境</h2>
<ul>
<li>
<h4 id="ide">IDE</h4>
<ul>
<li>
<p><a href="https://www.jetbrains.com/zh-cn/rider/" target="_blank" rel="noreferrer">IntelliJ JetBrains Rider</a></p>
<ul>
<li><a href="https://www.jetbrains.com.cn/dotnet/download/system-requirements/" target="_blank" rel="noreferrer">系统要求</a>
<ul>
<li>Windows 10 版本1809 或更高版本</li>
<li>64 位操作系统, 基于 x64 的处理器</li>
<li>.NET Framework 4.7.2 或更高版本</li>
<li>在 Windows 上不得禁用<strong>强名称跳过</strong>功能</li>
</ul>
</li>
</ul>
</li>
<li>
<p><a href="https://visualstudio.microsoft.com/zh-hans/vs" target="_blank" rel="noreferrer">Visual Studio 2026</a></p>
<ul>
<li>
<p><a href="https://learn.microsoft.com/zh-cn/visualstudio/releases/2026/vs-system-requirements" target="_blank" rel="noreferrer">系统要求</a></p>
<ul>
<li>Windows 11 版本 21H2 或更高版本：家庭版、专业版、专业教育版、专业工作站版、企业版和教育版</li>
<li>Windows 10 版本 1909 或更高版本：家庭版、专业版、教育版和企业版。</li>
<li>64 位操作系统, 基于 x64 的处理器</li>
</ul>
</li>
<li>
<p>工作负荷</p>
<ul>
<li>桌面应用和移动应用
<ul>
<li>[x] .NET 桌面开发</li>
</ul>
</li>
</ul>
</li>
</ul>
</li>
</ul>
</li>
<li>
<p>编译语言</p>
<ul>
<li>C# .NET Framework 4.7.2</li>
</ul>
</li>
<li>
<p>依赖项</p>
<ul>
<li>
<p>第三方程序集</p>
<ul>
<li>
<p>AntdUI</p>
<p>用于依赖项 Rox.Runtimes 的 <code>Reporter</code> 窗体渲染, 防止出现未知的异常</p>
</li>
<li>
<p><a href="https://www.nuget.org/packages/newtonsoft.json" target="_blank" rel="noreferrer">Newtonsoft.Json</a></p>
<p>用于 <code>Json</code> 反序列化解析</p>
</li>
<li>
<p><a href="https://github.com/Rainbow-SPY/Rox" target="_blank" rel="noreferrer">Rox.Runtimes</a></p>
<p>用于输出日志、引用字符串常量等</p>
</li>
<li>
<p><a href="https://github.com/Rainbow-SPY/Rox" target="_blank" rel="noreferrer">Rox.Text</a></p>
<p>用于压缩 <code>Json</code> .后续会集成移除</p>
</li>
</ul>
</li>
<li>
<p>来自 Microsoft 的 NuGet 包扩展</p>
<ul>
<li>
<p>System.Buffers</p>
</li>
<li>
<p>System.Diagnostics.DiagnosticSource</p>
</li>
<li>
<p>System.Memory</p>
</li>
<li>
<p>System.Numerics.Vectors</p>
</li>
<li>
<p>System.Runtime.CompilerServices.Unsafe</p>
</li>
<li>
<p>System.Net.Http</p>
</li>
</ul>
</li>
</ul>
</li>
</ul>
<hr>
<!--suppress HtmlDeprecatedAttribute -->
<div align="center">Copyright (C) Rainbow-SPY & AxT-Team & UAPI 2019-2026 , All rights reserved.</div>
`};export{n as default};
