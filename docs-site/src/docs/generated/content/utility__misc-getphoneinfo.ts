import type {DocContent} from '../../types';

const docContent: DocContent = {
  "slug": "utility/misc-getphoneinfo",
  "html": "<h1 id=\"获取手机号码的归属地信息\">获取手机号码的归属地信息</h1>\n<h2 id=\"请求示例\">请求示例</h2>\n<pre><code class=\"language-csharp\">var request = await UAPI.misc.GetPhoneInfo(string phoneNumber);\n</code></pre>\n<ul>\n<li>参数选项:\n<ul>\n<li><strong>phoneNumber:</strong> 指定要查询的中国大陆 11 位手机号码</li>\n</ul>\n</li>\n<li><strong>返回类型:</strong> <code>Task &lt;UAPI.misc.PhoneInfoType&gt;</code></li>\n<li><strong>返回值:</strong> <code>PhoneInfoType</code> 对象</li>\n<li><strong>异常:</strong>\n<ul>\n<li><code>IException.General.UAPIServerDown</code>: 请求源服务器发生错误</li>\n<li><code>UnauthorizedAccessException</code>: 未经授权的请求操作</li>\n<li><code>IException.General.UAPIUnknowException</code>: 未知的异常</li>\n</ul>\n</li>\n</ul>\n<h2 id=\"属性列表\">属性列表</h2>\n<h3 id=\"根属性\">根属性</h3>\n<table>\n<thead>\n<tr>\n<th style=\"text-align:left\">属性值</th>\n<th style=\"text-align:left\">注释</th>\n<th style=\"text-align:left\">备注</th>\n</tr>\n</thead>\n<tbody>\n<tr>\n<td style=\"text-align:left\"><code>string</code> <strong>province</strong></td>\n<td style=\"text-align:left\">省份归属地</td>\n<td style=\"text-align:left\"></td>\n</tr>\n<tr>\n<td style=\"text-align:left\"><code>string</code> <strong>city</strong></td>\n<td style=\"text-align:left\">城市或地区归属地</td>\n<td style=\"text-align:left\"></td>\n</tr>\n<tr>\n<td style=\"text-align:left\"><code>string</code> <strong>sp</strong></td>\n<td style=\"text-align:left\">运营商名称</td>\n<td style=\"text-align:left\"></td>\n</tr>\n</tbody>\n</table>\n"
};

export default docContent;
