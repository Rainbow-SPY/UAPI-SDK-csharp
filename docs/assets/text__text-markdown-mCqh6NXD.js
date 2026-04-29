const t={slug:"text/text-markdown",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await Text.Markdown.ToHTML.ReturnedHTMLCode(string _text, bool _sanitize = true,string Authentication = &quot;&quot;)
    									.ReturnedJson(+1)
</code></pre>
<div class="gfm-alert gfm-alert-note"><div class="gfm-alert-title"><span class="gfm-alert-icon"><svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="12" cy="12" r="10"></circle><path d="M12 16v-4"></path><path d="M12 8h.01"></path></svg></span><span>Note</span></div><div class="gfm-alert-body"><p>当方法为 <code>.ReturnedHTMLCode</code> 时, 返回类型为 <code>Task&lt;string&gt;</code>, 直接返回 HTML 源代码;</p>
<p>反之则为 <code>Task&lt;MarkdownType&gt;</code> , 返回 <code>Json</code> 对象.</p>
</div></div><ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>_text</strong>: 指定要转换为 HTML 的文本, 最大不超过1MB</p>
</li>
<li>
<p><strong>_sanitize</strong>: 指定是否开启安全模式, 以过滤 <code>_text</code> 输入的风险脚本.</p>
</li>
<li>
<p><strong>Authentication</strong>: API Token Key</p>
</li>
</ul>
</li>
<li>
<p><strong>返回类型:</strong> <code>Task&lt;Type.MarkdownType&gt;</code></p>
</li>
<li>
<p><strong>返回值:</strong> <code>Type.MarkdownType</code> 对象</p>
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
<td style="text-align:left"><code>Data</code> <strong>data</strong></td>
<td style="text-align:left">输入的数据</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="data-data-嵌套类"><code>Data</code> <strong>data</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>html</strong></td>
<td>HTML 源代码</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h1 id="markdown-转换为-pdf">Markdown 转换为 PDF</h1>
<h2 id="请求实例">请求实例</h2>
<pre><code class="language-csharp">var result = await Text.Markdown.ToPDF(string _text, Theme _theme = Theme.github, Size size = Size.A4,string Authentication = &quot;&quot;)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li>
<p><strong>_text</strong>: 指定要转换的文本, 最大不超过 1MB.</p>
</li>
<li>
<p><strong>_theme</strong>: 指定PDF转换的样式, 枚举如下</p>
<table>
<thead>
<tr>
<th>枚举值</th>
<th>注释</th>
</tr>
</thead>
<tbody>
<tr>
<td>github</td>
<td>github 的样式, 特点是 <code>&gt; [!NOTE]</code> 等高亮提示</td>
</tr>
<tr>
<td>minimal</td>
<td>最小的?</td>
</tr>
<tr>
<td>light</td>
<td>浅色模式</td>
</tr>
<tr>
<td>dark</td>
<td>深色模式</td>
</tr>
</tbody>
</table>
</li>
<li>
<p><strong>size</strong>: 指定PDF的纸张大小, 枚举如下</p>
<table>
<thead>
<tr>
<th>大小</th>
<th>注释</th>
</tr>
</thead>
<tbody>
<tr>
<td>A4</td>
<td></td>
</tr>
<tr>
<td>Letter</td>
<td>信纸</td>
</tr>
</tbody>
</table>
</li>
<li>
<p><strong>Authentication</strong>: API Token Key</p>
</li>
</ul>
</li>
<li>
<p>返回类型: <code>byte[]</code></p>
</li>
<li>
<p>返回值: 二进制 <code>byte[]</code> PDF 文档</p>
</li>
<li>
<p>异常:</p>
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>:  未知的异常</li>
</ul>
</li>
</ul>
`};export{t as default};
