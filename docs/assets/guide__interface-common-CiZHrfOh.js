const t={slug:"guide/interface-common",html:`<blockquote>
<p>供开发者使用</p>
</blockquote>
<h2 id="公共api获取请求">公共API获取请求</h2>
<h3 id="请求示例">请求示例</h3>
<pre><code class="language-csharp">var (result, statuscode) = await Interface.GetResult&lt;T&gt;(string requestUrl,
            SendRequestType type = SendRequestType.GET, string postContent = &quot;&quot;,
            string contentType = &quot;application/json&quot;,
            string AuthenticationAPITokenKey = &quot;&quot;)
</code></pre>
<ul>
<li>
<p>参数选项:</p>
<ul>
<li><strong>requestUrl</strong>: 指定要请求的API地址</li>
<li><strong>type</strong>: 指定请求的方式: <code>SendRequestType.GET</code>和<code>SendRequestType.POST</code>, 默认为 <code>GET</code>请求.</li>
<li><strong>postContent</strong>: 当请求方式为<code>POST</code>时, 此值为请求内容, 为<code>GET</code>时此值无效, 默认为空.</li>
<li><strong>contentType</strong>: 当请求方式为<code>POST</code>时, 此值为请求内容的类型, 为<code>GET</code>时此值无效, 默认为 <code>application/json</code>.</li>
<li><strong>AuthenticationAPITokenKey</strong>: UAPI API Token Key, 默认为空.</li>
<li><strong>T</strong>: 泛式类型对象, 与返回类型相同</li>
</ul>
</li>
<li>
<p>返回类型: <code>T</code> 泛式类型对象</p>
</li>
<li>
<p>返回值:</p>
<ul>
<li><code>result</code>: 返回的泛式类型<code>&lt;T&gt;</code>对象</li>
<li><code>statuscode</code>: <code>HttpClient</code> 返回的<code>StatusCode</code> 值.</li>
</ul>
</li>
<li>
<p>异常 (继承于 <code>Interface.common.IsGetSuccessful&lt;T&gt;</code>):</p>
<ul>
<li><code>JsonSerializationException</code>: <code>Newtonsoft.Json</code> 反序列化失败</li>
<li><code>HttpRequestException</code>: <code>HttpClient</code> 请求失败.</li>
</ul>
</li>
</ul>
<h2 id="检查是否请求成功的分析方法">检查是否请求成功的分析方法</h2>
<h3 id="请求示例-1">请求示例</h3>
<pre><code class="language-csharp">bool result = Interface.common.IsGetSuccessful&lt;T&gt;(T Type, string NullValue,
			int StatusCode, Exception _Exception,
            string _Error_Type,
            string Error_Code = &quot;&quot;)
</code></pre>
<ul>
<li>参数选项:
<ul>
<li><strong>Type</strong>: 指定为继承 <code>Interface.TypeInterface</code> 的公共类</li>
<li><strong>NullValue</strong>: 当返回值为 400 时的提示参数.</li>
<li><strong>StatusCode</strong>: 指定从<code>Interface.common.GetResult&lt;T&gt;</code>的传入的<code>statuscode</code>值</li>
<li><strong>_Exception</strong>: 指定为继承 <code>System.Exception</code> 的自定义异常</li>
<li><strong>_Error_Type</strong>: 出现异常的类别</li>
<li><strong>Error_Code</strong>: 当出现异常时的自定义错误代码, 默认为空.</li>
<li><strong>T</strong>: 指定为继承<code>Interface.TypeInterface</code>的公共类的泛式类.</li>
</ul>
</li>
<li>返回类型: <code>bool</code></li>
<li>返回值: 当请求成功并返回 <code>StatusCode=200</code>时返回<code>true</code>, 反之返回 <code>false</code> 或 <code>throw</code> 异常.</li>
<li>异常:
<ul>
<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>
<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>
<li><code>IException.General.UAPIUnknowException</code>: 未知的异常</li>
<li><code>IException.General.UAPIServiceUnavailable</code> 当前请求的服务不可用</li>
<li><code>$CustomException</code>: 指定为继承 <code>System.Exception</code> 的自定义的异常</li>
</ul>
</li>
</ul>
<table>
<thead>
<tr>
<th style="text-align:center">返回值</th>
<th style="text-align:left">注释</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:center">200</td>
<td style="text-align:left">请求成功</td>
</tr>
<tr>
<td style="text-align:center">400</td>
<td style="text-align:left">请求的参数 <code>$NullValue</code>不能为<code>null</code>或空</td>
</tr>
<tr>
<td style="text-align:center">401</td>
<td style="text-align:left">未经授权的指定操作, <code>throw UnauthorizedAccessException()</code>.</td>
</tr>
<tr>
<td style="text-align:center">403</td>
<td style="text-align:left">因请求量过大被限制了请求.</td>
</tr>
<tr>
<td style="text-align:center">404</td>
<td style="text-align:left">未找到指定请求的所需结果</td>
</tr>
<tr>
<td style="text-align:center">429</td>
<td style="text-align:left">请求量过大, 错误代码 <code>429 Too Many Requests</code>.</td>
</tr>
<tr>
<td style="text-align:center">500</td>
<td style="text-align:left">UAPI 服务器内部错误, <code>throw IException.General.UAPIServerDown()</code></td>
</tr>
<tr>
<td style="text-align:center">502</td>
<td style="text-align:left">上游API请求错误, <code>throw $_Exception</code>.</td>
</tr>
<tr>
<td style="text-align:center">503</td>
<td style="text-align:left">指定的服务当前不可用, <code>throw IException.General.UAPIServiceUnavailable()</code>.</td>
</tr>
<tr>
<td style="text-align:center">-1</td>
<td style="text-align:left">请求失败, 未指定的错误</td>
</tr>
<tr>
<td style="text-align:center"><code>default</code></td>
<td style="text-align:left">未知的错误</td>
</tr>
</tbody>
</table>
`};export{t as default};
