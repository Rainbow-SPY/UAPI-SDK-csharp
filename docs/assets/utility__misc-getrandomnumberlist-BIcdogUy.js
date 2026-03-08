const n={slug:"utility/misc-getrandomnumberlist",html:`<h2 id="请求示例">请求示例</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetRandomNumberList(int min = 0, int max = 0, 
              int count = 0,
              bool allow_repeat = false,
              bool allow_decimal = false, 
              int decimal_places = 0);
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
<td style="text-align:left"><code>List&lt;decimal&gt;</code> <strong>numbers</strong></td>
<td style="text-align:left">生成的随机数组</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{n as default};
