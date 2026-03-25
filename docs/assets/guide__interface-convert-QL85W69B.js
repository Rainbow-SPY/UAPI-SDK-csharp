const e={slug:"guide/interface-convert",html:`<h2 id="格式化-播放量-点赞量-等原始-int-值">格式化 播放量/点赞量 等原始 <code>int</code> 值</h2>
<blockquote>
<p>单位为<strong>万</strong></p>
</blockquote>
<h3 id="示例">示例</h3>
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
<h3 id="示例-1">示例</h3>
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
<h3 id="示例-2">示例</h3>
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
<h3 id="示例-3">示例</h3>
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
<h2 id="适用于-newtonsoft-json-jsonconverter-的-int-型-json-属性转换为-bool-的字段属性">适用于<code>Newtonsoft.Json.JsonConverter</code>的<code>int</code>型<code>Json</code>属性转换为<code>bool</code>的字段属性</h2>
<h3 id="覆写方法">覆写方法</h3>
<pre><code class="language-csharp">internal class BooleanConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) =&gt; objectType == typeof(bool);

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = reader.Value?.ToString()?.Trim();
        return value == &quot;1&quot; || value == &quot;true&quot;;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =&gt; writer.WriteValue(value is bool b &amp;&amp; b ? 1 : 0);
}
</code></pre>
<h3 id="示例-4">示例</h3>
<pre><code class="language-csharp">[JsonProperty(&quot;zhen-de-jia-de&quot;)]
[JsonConverter(typeof(BooleanConverter))]
public bool Kskbl
{
    get =&gt; cxy == 0 );
    set =&gt; cxy = value ? 1 : 0;
}

</code></pre>
`};export{e as default};
