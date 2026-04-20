const t={slug:"utility/network-ipinfo",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.Network.GetIPInfo(string ip, bool IsUseCommercial = false,
            string Authentication = &quot;&quot;)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>ip</strong>: 指定要查询的IP</p>
</li>
<li>
<p><strong>IsUseCommercial</strong>: 是否使用商业数据源, 扣除的积分可能会增加.</p>
</li>
<li>
<p><strong>Authentication</strong>: API Token Key</p>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task &lt;IPInfoType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>IPInfoType</code> 对象</p>
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
<td style="text-align:left">解析的IP地址</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Region</strong></td>
<td style="text-align:left">解析后的国家/地区</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ISP</strong></td>
<td style="text-align:left">运营商名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ASN</strong></td>
<td style="text-align:left">自治系统编号</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>LLC</strong></td>
<td style="text-align:left">归属机构</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Latitude</strong></td>
<td style="text-align:left">纬度</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Longitude</strong></td>
<td style="text-align:left">经度</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AreaCode</strong></td>
<td style="text-align:left"><code>Region</code> 解析的地区 Adcode 代码</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ZIPCode</strong></td>
<td style="text-align:left">邮政编码 (Zone Improvement Plan Code)</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Timezone</strong></td>
<td style="text-align:left">时区</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>BeginIP</strong></td>
<td style="text-align:left">IP段起始地址</td>
<td style="text-align:left">标准查询可用</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>EndIP</strong></td>
<td style="text-align:left">IP段结束地址</td>
<td style="text-align:left">标准查询可用</td>
</tr>
</tbody>
</table>
`};export{t as default};
