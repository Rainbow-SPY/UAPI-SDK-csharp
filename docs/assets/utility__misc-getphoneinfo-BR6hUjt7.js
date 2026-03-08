const t={slug:"utility/misc-getphoneinfo",html:`<h1 id="section">???</h1>
<h2 id="section-1">???</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.GetPhoneInfo(string phoneNumber);
</code></pre>
<ul>
<li>???:
<ul>
<li><strong>phoneNumber:</strong> ??? 11 ???</li>
</ul>
</li>
<li><strong>???:</strong> <code>Task &lt;UAPI.misc.PhoneInfoType&gt;</code></li>
<li><strong>???:</strong> <code>PhoneInfoType</code> ??</li>
<li><strong>??:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: ???</li>
<li><code>UnauthorizedAccessException</code>: ???</li>
<li><code>IException.General.UAPIUnknowException</code>: ???</li>
</ul>
</li>
</ul>
<h2 id="section-2">???</h2>
<h3 id="section-3">???</h3>
<table>
<thead>
<tr>
<th style="text-align:left">???</th>
<th style="text-align:left">??</th>
<th style="text-align:left">??</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>string</code> <strong>province</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>city</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>sp</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
`};export{t as default};
