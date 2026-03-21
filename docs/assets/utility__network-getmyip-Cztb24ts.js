const t={slug:"utility/network-getmyip",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.Network.GetMyIP(bool commercial = false, string Authentication = &quot;&quot;);
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>commercial:</strong> 指定是否使用商业级的数据源, 默认为 <code>false</code></li>
<li><strong>Authentication</strong>: API Token, 默认为空</li>
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
<td style="text-align:left"><code>string</code> <strong>IP</strong></td>
<td style="text-align:left">你的公网IP地址</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>ip</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>BeginAddress</strong></td>
<td style="text-align:left">IP段起始地址</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>beginip</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>EndAddress</strong></td>
<td style="text-align:left">IP段结束地址</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>endip</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Region</strong></td>
<td style="text-align:left">地理位置</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>region</code><br/>格式：国家 省份 城市</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ISP</strong></td>
<td style="text-align:left">运营商名称</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>isp</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ASN</strong></td>
<td style="text-align:left">自治系统编号</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>asn</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LLC</strong></td>
<td style="text-align:left">归属机构</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>llc</code></td>
</tr>
<tr>
<td style="text-align:left"><code>decimal</code> <strong>Latitude</strong></td>
<td style="text-align:left">纬度</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>latitude</code></td>
</tr>
<tr>
<td style="text-align:left"><code>decimal</code> <strong>Longitude</strong></td>
<td style="text-align:left">经度</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>longitude</code></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>District_Pro</strong></td>
<td style="text-align:left">行政区</td>
<td style="text-align:left">原始<code>Json</code>传入:<code>district</code><br/><strong>仅限商业查询</strong></td>
</tr>
</tbody>
</table>
`};export{t as default};
