const t={slug:"utility/misc-detecttrackingcarrier",html:`<h1 id="section">???</h1>
<h2 id="section-1">???</h2>
<pre><code class="language-csharp">var request = await UAPI.misc.DetectTrackingCarrier(string tracking_number);
</code></pre>
<ul>
<li>???:
<ul>
<li><strong>tracking_number:</strong> ???</li>
</ul>
</li>
<li><strong>???:</strong> <code>Task &lt;UAPI.misc.DetectedCarrierType&gt;</code></li>
<li><strong>???:</strong> <code>DetectedCarrierType</code> ??</li>
<li><strong>??:</strong>
<ul>
<li><code>IException.General.UAPIServerDown</code>: ???</li>
<li><code>UnauthorizedAccessException</code>: ???</li>
<li><code>IException.General.UAPIUnknowException</code>: ???</li>
</ul>
</li>
</ul>
<hr>
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
<td style="text-align:left"><code>string</code> <strong>code</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>message</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>Data</code> <strong>data</strong></td>
<td style="text-align:left">???</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="data-data"><code>Data</code> <strong>data</strong> ???</h4>
<table>
<thead>
<tr>
<th style="text-align:left">???</th>
<th>??</th>
<th style="text-align:left">??</th>
<th>??</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>string</code> <strong>tracking_number</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>carrier_code</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>carrier_name</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;AlternativesItem&gt;</code> <strong>alternatives</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-alternativesitem-alternatives"><code>List&lt;AlternativesItem&gt;</code> <strong>alternatives</strong> ???</h4>
<table>
<thead>
<tr>
<th style="text-align:left">???</th>
<th>??</th>
<th style="text-align:left">??</th>
<th>??</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left"><code>string</code> <strong>code</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>name</strong></td>
<td>???</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
