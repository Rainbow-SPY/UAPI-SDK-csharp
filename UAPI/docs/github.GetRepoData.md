# 查询 github 公开仓库的数据

## 请求示例

```csharp
var request = await UAPI.github.GetReposData(string owner_and_repo, string Authentication = "")
```

* 参数选项:
    * **owner_and_repo:** 指定要查询的用户+仓库, 例: `"torvalds/linux"`
    * **Authentication**: API Token, 默认为空
* **返回类型:** `Task <UAPI.github.ReposType>`
* **返回值:** `ReposType` 对象
* **异常:**
    - `IException.General.UAPIServerDown`: 请求源服务器发生错误
    - `UnauthorizedAccessException`: 未经授权的请求操作
    - `IException.github.GithubAPIServiceError()`:  Github 上游服务异常, 这可能是他们的服务暂时中断.

## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **FullName**| 仓库完整名称 | 原始`Json`传入:`full_name` |
|`string` **Description**| 简介 | 原始`Json`传入:`description` |
|`string` **HomePage**| 主页链接 | 原始`Json`传入:`homepage` |
|`string` **DefaultBranch**| 默认分支 | 原始`Json`传入:`default_branch` |
|`string` **PrimaryBranch**| 主要分支 | 原始`Json`传入:`primary_branch` |
|`bool` **Visibility**| 可见性 | 原始`Json`传入:`visibility` |
|`bool` **IsArchived**| 是否归档 | 原始`Json`传入:`archived` |
|`bool` **IsDisabled**| 是否禁用 | 原始`Json`传入:`disabled` |
|`bool` **vip_status**| 大会员状态 | 原始`Json`传入:`fork` |
|`string` **MainLanguage**| 主要语言 | l原始`Json`传入:`anguage` |
|`List<string>` **Topics**| 话题 | 原始`Json`传入:`topics` |
|`string` **License**| 许可证 | 原始`Json`传入:`license` |
|`int` **Stargazers**| 星星数 | 原始`Json`传入:`stargazers` |
|`int` **Forks**| Fork 数 | 原始`Json`传入:`forks` |
|`int` **OpenIssues**| 开放问题数 | 原始`Json`传入:`open_issues` |
|`int` **Watchers**| 关注者数 | 原始`Json`传入:`watchers` |
|`string` **PushedTime_ISO8601**| 最后推送时间（ISO 8601 格式） | 原始`Json`传入:`pushed_at` |
|`string` **CreatedTime_ISO8601**| 创建时间（ISO 8601 格式） | 原始`Json`传入:`created_at` |
|`string` **UpdatedTime_ISO8601**| 更新时间（ISO 8601 格式） | 原始`Json`传入:`updated_at` |
|` Dictionary<string, int>` **LanguagesStats**| 语言统计 | 原始`Json`传入:`languages` |
|`object` **Collaborators**| 协作者 | 原始`Json`传入:`collaborators` |
|`Maintainer[]` **Maintainers**| 维护者 | 原始`Json`传入:`maintainers` |
|`string` **DefaultBranchSHAHash**| 默认分支的 SHA 值 | 原始`Json`传入:`maintainers` |
|`string` **PushedTime_String**| 最后推送时间 (字符串格式) | |
|`string` **CreatedTime_String**| 创建时间 (字符串格式) | |
|`string` **UpdatedTime_Str**| 更新时间 (字符串格式) | |

#### `Maintainer` Maintainers 嵌套类

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`string` **login**| 登录名 | |
|`string` **name**| 名称 | |
|`string` **email**| 邮件 | |
|`string` **url**| URL | |
