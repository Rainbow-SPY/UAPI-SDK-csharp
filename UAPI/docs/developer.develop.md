# 开发者文档 - 使用SDK开发自己的应用程序

为了让SDK更好的使用, 我们制作了这个开发文档

## 撰写一个基础请求方法

### 请求示例

```csharp
using System.Collections.Generic; // List<T>类
using UAPI; // UAPI 核心请求类
using System.Threading.Tasks; // Task 等待任务类
using System;// 处理Exception

bilibili.LiveRoomType request = await bilibili.GetLiveroomStatus.AsLiveroomID("22637261");// 以直播间ID作为传入参
Console.WriteLine($"直播间标题: {(string.IsNullOrEmpty(request.title) ? "未开播" : request.title)}");
// 输出: 
//		直播间标题: 康神开播了?!真的假的?!
// 或
// 		直播间标题: 未开播
```

* 参数选项&返回类型&返回值: 详见 [Github - Rainbow-SPY/UAPI-SDK-csharp/docs/各个方法的开发文档](https://github.com/Rainbow-SPY/UAPI-SDK-csharp/blob/master/UAPI/docs)

> [!TIP] 
>
> 如何查找?
>
> 开发文档和接口的源代码同名, 直接按照源代码文件名搜索相关的开发文档

**现在你已经学会了请求接口了, 







## 属性列表

### 根属性

| 属性值 | 注释 | 备注 |
|:------|:----|:-----|
|`` ****|  | |
|`` ****|  | |
|`` ****|  | |

___
#### `$` **$** 嵌套类

| 属性值 | 注释 | 示例 | 备注 |
|:------|-----|:-----|-----|
|`` ****|  | |
|`` ****|  | |
|`` ****|  | |
|`` ****|  | |
