# Markdown 转换为 HTML

## 请求示例

```csharp
var request = await Text.Markdown.ToHTML.ReturnedHTMLCode(string _text, bool _sanitize = true,string Authentication = "")
    									.ReturnedJson(+1)
```

>  [!NOTE]
>
> 当方法为 `.ReturnedHTMLCode` 时, 返回类型为 `Task<string>`, 直接返回 HTML 源代码;
>
>  反之则为 `Task<MarkdownType>` , 返回 `Json` 对象.

* 参数选项:
    * **_text**: 指定要转换为 HTML 的文本, 最大不超过1MB

    * **_sanitize**: 指定是否开启安全模式, 以过滤 `_text` 输入的风险脚本.

    * **Authentication**: API Token Key

* **返回类型:** `Task<Type.MarkdownType>`
* **返回值:** `Type.MarkdownType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.General.UAPIUnknowException`:  未知的异常

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`Data` **data**| 输入的数据 | |

___
#### `Data` **data** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`string` **html**| HTML 源代码 | | |

# Markdown 转换为 PDF

## 请求实例

```csharp
var result = await Text.Markdown.ToPDF(string _text, Theme _theme = Theme.github, Size size = Size.A4,string Authentication = "")
```

- 参数选项:

  - **_text**: 指定要转换的文本, 最大不超过 1MB.

  - **_theme**: 指定PDF转换的样式, 枚举如下

    | 枚举值  | 注释                                         |
    | ------- | -------------------------------------------- |
    | github  | github 的样式, 特点是 `> [!NOTE]` 等高亮提示 |
    | minimal | 最小的?                                      |
    | light   | 浅色模式                                     |
    | dark    | 深色模式                                     |

  - **size**: 指定PDF的纸张大小, 枚举如下

    | 大小   | 注释 |
    | ------ | ---- |
    | A4     |      |
    | Letter | 信纸 |

  - **Authentication**: API Token Key

- 返回类型: `byte[]`

- 返回值: 二进制 `byte[]` PDF 文档

- 异常:

  - `IException.General.UAPIServerDown`: 请求源服务器发生错误
  - `UnauthorizedAccessException`: 未经授权的请求操作
  - `IException.General.UAPIUnknowException`:  未知的异常
