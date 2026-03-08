const n={slug:"guide/interface-convert",html:`<h1 id="常用转换方法">常用转换方法</h1>
<h2 id="格式化-播放量-点赞量-等原始-int-值">格式化 播放量/点赞量 等原始 <code>int</code> 值</h2>
<blockquote>
<p>单位为<strong>万</strong></p>
</blockquote>
<h3 id="请求示例">请求示例</h3>
<pre><code class="language-csharp">string request = Interface.FormatPlayCount(int _Count) 
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li><strong>_Count</strong>: 原始<code>int</code>播放量/点赞量等数据</li>
</ul>
</li>
<li>
<p>返回类型: <code>string</code></p>
</li>
<li>
<p>返回值: 格式化后的以万为单位的字符串</p>
</li>
</ul>
<h2 id="unix-时间戳转换字符串">Unix 时间戳转换字符串</h2>
<h3 id="请求示例-1">请求示例</h3>
<pre><code class="language-csharp">string request = Interface.FormatUnixTime(object _time)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>_time</strong>: 不指定参数类型的字符串/整数Unix时间戳.</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 以 <code>YYYY-MM-DD HH:mm:ss</code> 格式的时间字符串</li>
</ul>
<h2 id="iso-8601格式的时间转换字符串">ISO 8601格式的时间转换字符串</h2>
<h3 id="请求示例-2">请求示例</h3>
<pre><code class="language-csharp">string request = Interface.FormatISO8601TimeToLocal(string iso8601Time)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>iso8601Time</strong>: ISO 8601 格式(<code>YYYY-MM-DDTHH:mm:ss[.fff]Z</code>)的时间字符串（带Z后缀，可选含毫秒）</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: 以 <code>YYYY-MM-DD HH:mm:ss</code> 格式的本地时间字符串</li>
</ul>
<h2 id="识别总长时间并转换为可读字符串的时间">识别总长时间并转换为可读字符串的时间</h2>
<h3 id="请求示例-3">请求示例</h3>
<pre><code class="language-csharp">string request = Interface.FormatSecondsTime(int _time) 
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>_time</strong>: 整数时间 (秒)</li>
</ul>
</li>
<li>返回类型: <code>string</code></li>
<li>返回值: <code>HH:mm:ss</code> 格式的时间字符串</li>
</ul>
`};export{n as default};
