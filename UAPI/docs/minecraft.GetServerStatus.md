# 获取 Minecraft 服务器状态

## 请求示例

```csharp
var request = await UAPI.minecraft.GetServerStatus(string server, int port=25565);
```

* 参数选项:
 * **server:** 指定要查询的服务器地址
 * **port:** 指定查询的服务器的端口, 默认为 `25565`.
* **返回类型:** `Task <UAPI.minecraft.ServerType>`
* **返回值:** `ServerType` 对象
* **异常:**
 - `IException.General.UAPIServerDown`: 请求源服务器发生错误
 - `UnauthorizedAccessException`: 未经授权的请求操作
 - `IException.minecraft.MojangAPIServiceError`: Mojang API 上游服务异常, 这可能是他们的服务暂时中断.
## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **FaviconUrlWithBase64**| 服务器图标的 Base64 Data Url | |
|`string` **IP**| 解析后的IP地址 | |
|`int` **MaxPlayers**| 服务器配置的最大玩家数量 | |
|`string` **motd_clean**| 纯文本格式的服务器MOTD（每日消息） | 去除了所有颜色和格式代码 |
|`string` **motd_html**| HTML格式的服务器MOTD | 保留了颜色和样式 |
|`bool` **IsServerOnline**| 服务器是否在线 | |
| `int` **CurrentPlayers** | 当前的玩家数量 | |
| `int` **Port** | 使用的端口号 | |
|`string` **version**| 服务器报告的版本信息 | |