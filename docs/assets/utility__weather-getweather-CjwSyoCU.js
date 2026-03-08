const t={slug:"utility/weather-getweather",html:`<h2 id="请求示例">请求示例</h2>
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
<td style="text-align:left"><code>string</code> <strong>Province</strong></td>
<td style="text-align:left">省份名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>City</strong></td>
<td style="text-align:left">城市名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>District</strong></td>
<td style="text-align:left">区县名称</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>int</code> <strong>Adcode</strong></td>
<td style="text-align:left">高德地图的6位数字城市编码</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Weather</strong></td>
<td style="text-align:left">天气状况</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>WeatherIcon</strong></td>
<td style="text-align:left">和风天气的Weather Icon, 用于前端显示</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Temperature</strong></td>
<td style="text-align:left">温度</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>WindDirection</strong></td>
<td style="text-align:left">风向</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>WindPower</strong></td>
<td style="text-align:left">风力等级</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Humidity</strong></td>
<td style="text-align:left">湿度</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>ReportTime</strong></td>
<td style="text-align:left">数据更新时间</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>MaxTemperature</strong></td>
<td style="text-align:left">一天中的最高温度</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>MinTemperature</strong></td>
<td style="text-align:left">一天中的最低温度</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;Forecast&gt;</code> <strong>forecast</strong></td>
<td style="text-align:left">未来三天的天气预报</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>FeelsLikeTemperature</strong></td>
<td style="text-align:left">体感温度</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Visibility</strong></td>
<td style="text-align:left">能见度</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Pressure</strong></td>
<td style="text-align:left">气压</td>
<td style="text-align:left"><code>extended=true 时返回</code></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>UV</strong></td>
<td style="text-align:left">紫外线指数</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>AQI</strong></td>
<td style="text-align:left">空气质量指数</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>AQILevel</strong></td>
<td style="text-align:left">空气质量指数等级</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AQICategory</strong></td>
<td style="text-align:left">AQI 等级描述</td>
<td style="text-align:left">优/良/轻度污染/中度污染/重度污染/严重污染<br/> <code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AQIPrimary</strong></td>
<td style="text-align:left">主要污染物</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>AirPollutants</strong></td>
<td style="text-align:left">空气污染物分项数据</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Precipitation</strong></td>
<td style="text-align:left">降水量</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Cloud</strong></td>
<td style="text-align:left">云量</td>
<td style="text-align:left"><code>extended=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>minutely_Precipitation</code> <strong>MinutelyPrecipitation</strong></td>
<td style="text-align:left">分钟级降水预报</td>
<td style="text-align:left"><code>minutely=true</code> 时返回</td>
</tr>
<tr>
<td style="text-align:left"><code>Life_Indices</code> <strong>life_indices</strong></td>
<td style="text-align:left">生活指数</td>
<td style="text-align:left"></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;Hourly_forecastItem&gt;</code> <strong>HourlyForecast</strong></td>
<td style="text-align:left">每小时天气预报</td>
<td style="text-align:left"></td>
</tr>
</tbody>
</table>
<hr>
<h4 id="list-forecast-forecast-嵌套类"><code>List&lt;Forecast&gt;</code> <strong>forecast</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>date</strong></td>
<td>预告日期</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>week</strong></td>
<td>星期几</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>MaxTemperature</strong></td>
<td>一天中的最高温度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>MinTemperature</strong></td>
<td>一天中的最低温度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DayWeather</strong></td>
<td>白天天气</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DayWindDirection</strong></td>
<td>白天风向</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>NightWindDirection</strong></td>
<td>夜间风向</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>DayWindPower</strong></td>
<td>白天风力</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>NightWindPower</strong></td>
<td>夜间风力</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>NightWeather</strong></td>
<td>夜间天气</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>DayWindSpeed</strong></td>
<td>白天风速</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>NightWindSpeed</strong></td>
<td>夜间风速</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Humidity</strong></td>
<td>湿度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Precipitation</strong></td>
<td>降水量</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Visibility</strong></td>
<td>能见度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>UV</strong></td>
<td>紫外线指数</td>
<td style="text-align:left"></td>
<td>0-11+</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SunriseTime</strong></td>
<td>日出时间</td>
<td style="text-align:left"></td>
<td>格式 HH:MM</td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>SunsetTime</strong></td>
<td>日落时间</td>
<td style="text-align:left"></td>
<td>格式 HH:MM</td>
</tr>
</tbody>
</table>
<hr>
<h4 id="life-indices-life-indices-嵌套类"><code>Life_Indices</code> <strong>life_indices</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>IndicesLevel</code> <strong>Clothing</strong></td>
<td>穿衣指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>UV</strong></td>
<td>紫外线指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>CarWash</strong></td>
<td>洗车指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Drying</strong></td>
<td>晾晒指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>AirConditioner</strong></td>
<td>空调指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>ColdRisk</strong></td>
<td>感冒指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Exercise</strong></td>
<td>运动指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Comfort</strong></td>
<td>舒适度指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Travel</strong></td>
<td>出行指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Fishing</strong></td>
<td>钓鱼指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Allergy</strong></td>
<td>过敏指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>SunScreen</strong></td>
<td>防晒指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Mood</strong></td>
<td>心情指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Beer</strong></td>
<td>啤酒指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Umbrella</strong></td>
<td>雨伞指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Traffic</strong></td>
<td>交通指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>AirPurifier</strong></td>
<td>空气净化器指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>IndicesLevel</code> <strong>Pollen</strong></td>
<td>花粉扩散指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h5 id="indiceslevel-嵌套类"><code>IndicesLevel</code> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>Level</strong></td>
<td>等级</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Brief</strong></td>
<td>简述</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Advice</strong></td>
<td>建议</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h4 id="list-hourly-forecastitem-hourlyforecast-嵌套类"><code>List&lt;Hourly_forecastItem&gt;</code> <strong>HourlyForecast</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>Time</strong></td>
<td>预报时间</td>
<td style="text-align:left"></td>
<td>格式 ISO8601 或 YYYY-MM-DD HH:MM</td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Temperature</strong></td>
<td>温度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>Weather</strong></td>
<td>天气状况</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>WindDirection</strong></td>
<td>风向</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>WindSpeed</strong></td>
<td>风速</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>WindPower</strong></td>
<td>风力等级</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Pressure</strong></td>
<td>湿度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Precipitation</strong></td>
<td>降水量</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Cloud</strong></td>
<td>云量</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>FeelsLikeTemperature</strong></td>
<td>体感温度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>dew_point</strong></td>
<td>露点温度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>Visibility</strong></td>
<td>能见度</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>pop</strong></td>
<td>降水概率</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code> <strong>UV</strong></td>
<td>紫外线指数</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h4 id="minutely-precipitation-minutelyprecipitation-嵌套类"><code>minutely_Precipitation</code> <strong>MinutelyPrecipitation</strong> 嵌套类</h4>
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
<td style="text-align:left"><code>string</code> <strong>summary</strong></td>
<td>分钟级降水预报</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>string</code> <strong>UpdateTime_ISO8601</strong></td>
<td>更新时间</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>List&lt;min_data&gt;</code> <strong>data</strong></td>
<td>每5分钟一个数据点，共24个</td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
<h5 id="list-min-data-data-嵌套类"><code>List&lt;min_data&gt;</code> <strong>data</strong> 嵌套类</h5>
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
<td style="text-align:left"><code>string</code> <strong>time</strong></td>
<td>预报时间</td>
<td style="text-align:left"></td>
<td></td>
</tr>
<tr>
<td style="text-align:left"><code>double</code></td>
<td></td>
<td style="text-align:left"></td>
<td></td>
</tr>
</tbody>
</table>
`};export{t as default};
