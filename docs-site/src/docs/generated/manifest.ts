import type {DocsManifest} from '../types';

export const docsManifest: DocsManifest = {
  "config": {
    "brand": {
      "name": "UAPI C# SDK",
      "github": {
        "href": "https://github.com/Rainbow-SPY/UAPI-SDK-csharp",
        "title": "Open GitHub repository",
        "openInNewTab": true
      },
      "browserTitle": "UAPI C# SDK",
      "versionMenu": {
        "enabled": false,
        "label": "Version",
        "items": []
      }
    },
    "hero": {
      "title": "UAPI C# SDK 文档",
      "description": "一个深度集成 UApi 的 C# SDK，由社区制作，旨在为了更好的体验而诞生。"
    },
    "repository": {
      "contentRoot": "..",
      "defaultBranch": "master"
    },
    "groups": [
      {
        "id": "guide",
        "title": "开始使用",
        "icon": "Rocket",
        "order": 1,
        "homeLinks": 4,
        "sources": [
          "readme",
          "developer",
          "Interface"
        ]
      },
      {
        "id": "social",
        "title": "社交平台",
        "icon": "MessageSquare",
        "order": 2,
        "homeLinks": 6,
        "sources": [
          "bilibili",
          "QQ",
          "github"
        ]
      },
      {
        "id": "games",
        "title": "游戏服务",
        "icon": "Building",
        "order": 3,
        "homeLinks": 6,
        "sources": [
          "EpicGames",
          "minecraft",
          "Steam"
        ]
      },
      {
        "id": "utility",
        "title": "通用能力",
        "icon": "Settings",
        "order": 4,
        "homeLinks": 6,
        "sources": [
          "misc",
          "network",
          "Weather",
          "hotboard"
        ]
      }
    ],
    "document": {
      "showDescription": false
    }
  },
  "groups": [
    {
      "id": "guide",
      "title": "开始使用",
      "icon": "Rocket",
      "order": 1,
      "homeLinks": 4,
      "docs": [
        "guide/overview",
        "guide/developer-develop",
        "guide/interface-convert",
        "guide/interface-common"
      ]
    },
    {
      "id": "social",
      "title": "社交平台",
      "icon": "MessageSquare",
      "order": 2,
      "homeLinks": 6,
      "docs": [
        "social/bilibili-getreplieslist",
        "social/bilibili-getvideodata",
        "social/bilibili-getuserdata",
        "social/bilibili-getarchives",
        "social/bilibili-getliveroomstatus",
        "social/qq-getgroupdata",
        "social/qq-getuserdata",
        "social/github-getrepodata"
      ]
    },
    {
      "id": "games",
      "title": "游戏服务",
      "icon": "Building",
      "order": 3,
      "homeLinks": 6,
      "docs": [
        "games/epicgames-getfreegames",
        "games/minecraft-getserverstatus",
        "games/minecraft-gethistoryname",
        "games/minecraft-getuserdata",
        "games/steam-getuserdata",
        "games/steam-steamid"
      ]
    },
    {
      "id": "utility",
      "title": "通用能力",
      "icon": "Settings",
      "order": 4,
      "homeLinks": 6,
      "docs": [
        "utility/misc-gettrackinginfo",
        "utility/misc-getlunartime",
        "utility/misc-getprogrammerhistorytoday",
        "utility/misc-getworldtime",
        "utility/misc-getphoneinfo",
        "utility/misc-getrandomnumberlist",
        "utility/misc-gettrackingcarriers",
        "utility/misc-postdatediff",
        "utility/misc-detecttrackingcarrier",
        "utility/misc-converttimestamp",
        "utility/network-getmyip",
        "utility/weather-getweather",
        "utility/hotboard-bilibili",
        "utility/hotboard-neteasemusic"
      ]
    }
  ],
  "docs": [
    {
      "slug": "guide/overview",
      "title": "UAPI C# SDK 社区版",
      "summary": "UAPI C# SDK 社区版 介绍 一个深度集成 UApi 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生. 贡献者: &nbsp;Rainbow SPY &nbsp;Shuakami License / 许可证 Copyright (©) AxT Team & UA",
      "description": "UAPI C# SDK 社区版 介绍 一个深度集成 UApi 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生. 贡献者: &nbsp;Rainbow SPY &nbsp;Shuakami License / 许可证 Copyright (©) AxT Team & UA",
      "groupId": "guide",
      "order": 0,
      "tags": [
        "readme",
        "guide"
      ],
      "excerpt": "UAPI C# SDK 社区版 介绍 一个深度集成 UApi 的C# SDK, 由社区制作, 旨在为了更好的体验而诞生. 贡献者: &nbsp;Rainbow SPY &nbsp;Shuakami License / 许可证 Copyright (©) AxT Team & UApi, Developer: Rainb",
      "headings": [
        {
          "id": "介绍",
          "text": "介绍",
          "level": 2
        },
        {
          "id": "贡献者",
          "text": "贡献者:",
          "level": 3
        },
        {
          "id": "license-许可证",
          "text": "License / 许可证",
          "level": 2
        },
        {
          "id": "目录",
          "text": "目录",
          "level": 2
        },
        {
          "id": "社交类请求",
          "text": "社交类请求",
          "level": 2
        },
        {
          "id": "bilibili-相关请求",
          "text": "bilibili 相关请求",
          "level": 3
        },
        {
          "id": "qq-相关请求",
          "text": "QQ 相关请求",
          "level": 3
        },
        {
          "id": "获取-github-仓库信息",
          "text": "获取 Github 仓库信息",
          "level": 3
        },
        {
          "id": "游戏功能性请求",
          "text": "游戏功能性请求",
          "level": 2
        },
        {
          "id": "获取epic-games每日免费游戏",
          "text": "获取Epic Games每日免费游戏",
          "level": 3
        },
        {
          "id": "获取-minecraft-玩家历史昵称",
          "text": "获取 Minecraft 玩家历史昵称",
          "level": 3
        },
        {
          "id": "获取-minecraft-服务器状态",
          "text": "获取 Minecraft 服务器状态",
          "level": 3
        },
        {
          "id": "获取-minecraft-玩家信息",
          "text": "获取 Minecraft 玩家信息",
          "level": 3
        },
        {
          "id": "获取-steam-个人用户的公开数据",
          "text": "获取 Steam 个人用户的公开数据",
          "level": 3
        },
        {
          "id": "网络类请求",
          "text": "网络类请求",
          "level": 2
        },
        {
          "id": "获取本机的公网ip地址",
          "text": "获取本机的公网IP地址",
          "level": 3
        },
        {
          "id": "杂项",
          "text": "杂项",
          "level": 2
        },
        {
          "id": "热榜请求",
          "text": "热榜请求",
          "level": 3
        },
        {
          "id": "天气请求",
          "text": "天气请求",
          "level": 3
        },
        {
          "id": "获取全球指定时区的当地时间",
          "text": "获取全球指定时区的当地时间",
          "level": 3
        },
        {
          "id": "获取手机号码的归属地信息",
          "text": "获取手机号码的归属地信息",
          "level": 3
        },
        {
          "id": "获取一组随机数字",
          "text": "获取一组随机数字",
          "level": 3
        },
        {
          "id": "获取程序员历史上的今天的事件",
          "text": "获取程序员历史上的今天的事件",
          "level": 3
        },
        {
          "id": "转换-unix-时间戳",
          "text": "转换 Unix 时间戳",
          "level": 3
        },
        {
          "id": "通过快递单号识别快递公司",
          "text": "通过快递单号识别快递公司",
          "level": 3
        },
        {
          "id": "查询农历时间",
          "text": "查询农历时间",
          "level": 3
        },
        {
          "id": "获取支持的快递公司列表",
          "text": "获取支持的快递公司列表",
          "level": 3
        },
        {
          "id": "查询快递物流信息",
          "text": "查询快递物流信息",
          "level": 3
        },
        {
          "id": "计算两个日期之间的差值",
          "text": "计算两个日期之间的差值",
          "level": 3
        },
        {
          "id": "开发环境",
          "text": "开发环境",
          "level": 2
        }
      ],
      "contentModule": "guide__overview"
    },
    {
      "slug": "guide/developer-develop",
      "title": "开发者文档 - 使用SDK开发自己的应用程序",
      "summary": "开发者文档 使用SDK开发自己的应用程序 为了让SDK更好的使用, 我们制作了这个开发文档 Copyright (C) Rainbow SPY & AxT Team 2019 2026,All rights reserved. 了解这个项目SDK 一个深度集成 UApi 的C# ",
      "description": "开发者文档 使用SDK开发自己的应用程序 为了让SDK更好的使用, 我们制作了这个开发文档 Copyright (C) Rainbow SPY & AxT Team 2019 2026,All rights reserved. 了解这个项目SDK 一个深度集成 UApi 的C# ",
      "groupId": "guide",
      "order": 999,
      "tags": [
        "developer",
        "guide"
      ],
      "excerpt": "开发者文档 使用SDK开发自己的应用程序 为了让SDK更好的使用, 我们制作了这个开发文档 Copyright (C) Rainbow SPY & AxT Team 2019 2026,All rights reserved. 了解这个项目SDK 一个深度集成 UApi 的C# SDK, 由社区制作, 旨在为了更好的体",
      "headings": [
        {
          "id": "了解这个项目sdk",
          "text": "了解这个项目SDK",
          "level": 2
        },
        {
          "id": "贡献者",
          "text": "贡献者:",
          "level": 3
        },
        {
          "id": "license-许可证",
          "text": "License / 许可证",
          "level": 3
        },
        {
          "id": "添加包",
          "text": "添加包",
          "level": 2
        },
        {
          "id": "在-nuget-cli-添加包",
          "text": "在 NuGet CLi 添加包",
          "level": 3
        },
        {
          "id": "在-dotnet-cli-添加包",
          "text": "在 dotnet CLi 添加包",
          "level": 3
        },
        {
          "id": "在-github-release-下载发行版",
          "text": "在 Github Release 下载发行版",
          "level": 3
        },
        {
          "id": "主要文件",
          "text": "主要文件",
          "level": 3
        },
        {
          "id": "开发环境",
          "text": "开发环境",
          "level": 2
        },
        {
          "id": "撰写一个基础请求方法",
          "text": "撰写一个基础请求方法",
          "level": 2
        },
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "guide__developer-develop"
    },
    {
      "slug": "guide/interface-convert",
      "title": "常用转换方法",
      "summary": "常用转换方法 格式化 播放量/点赞量 等原始 int 值 单位为 万 请求示例 参数选项: Count : 原始int播放量/点赞量等数据 返回类型: string 返回值: 格式化后的以万为单位的字符串 Unix 时间戳转换字符串 请求示例 参数选项: time : 不指定参数",
      "description": "常用转换方法 格式化 播放量/点赞量 等原始 int 值 单位为 万 请求示例 参数选项: Count : 原始int播放量/点赞量等数据 返回类型: string 返回值: 格式化后的以万为单位的字符串 Unix 时间戳转换字符串 请求示例 参数选项: time : 不指定参数",
      "groupId": "guide",
      "order": 999,
      "tags": [
        "Interface",
        "guide"
      ],
      "excerpt": "常用转换方法 格式化 播放量/点赞量 等原始 int 值 单位为 万 请求示例 参数选项: Count : 原始int播放量/点赞量等数据 返回类型: string 返回值: 格式化后的以万为单位的字符串 Unix 时间戳转换字符串 请求示例 参数选项: time : 不指定参数类型的字符串/整数Unix时间戳. 返回",
      "headings": [
        {
          "id": "格式化-播放量-点赞量-等原始-int-值",
          "text": "格式化 播放量/点赞量 等原始 `int` 值",
          "level": 2
        },
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "unix-时间戳转换字符串",
          "text": "Unix 时间戳转换字符串",
          "level": 2
        },
        {
          "id": "请求示例-1",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "iso-8601格式的时间转换字符串",
          "text": "ISO 8601格式的时间转换字符串",
          "level": 2
        },
        {
          "id": "请求示例-2",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "识别总长时间并转换为可读字符串的时间",
          "text": "识别总长时间并转换为可读字符串的时间",
          "level": 2
        },
        {
          "id": "请求示例-3",
          "text": "请求示例",
          "level": 3
        }
      ],
      "contentModule": "guide__interface-convert"
    },
    {
      "slug": "guide/interface-common",
      "title": "UAPI 常规方法内部接口",
      "summary": "UAPI 常规方法内部接口 供开发者使用 公共API获取请求 请求示例 参数选项: requestUrl : 指定要请求的API地址 type : 指定请求的方式: SendRequestType.GET和SendRequestType.POST, 默认为 GET请求. post",
      "description": "UAPI 常规方法内部接口 供开发者使用 公共API获取请求 请求示例 参数选项: requestUrl : 指定要请求的API地址 type : 指定请求的方式: SendRequestType.GET和SendRequestType.POST, 默认为 GET请求. post",
      "groupId": "guide",
      "order": 999,
      "tags": [
        "Interface",
        "guide"
      ],
      "excerpt": "UAPI 常规方法内部接口 供开发者使用 公共API获取请求 请求示例 参数选项: requestUrl : 指定要请求的API地址 type : 指定请求的方式: SendRequestType.GET和SendRequestType.POST, 默认为 GET请求. postContent : 当请求方式为POST",
      "headings": [
        {
          "id": "公共api获取请求",
          "text": "公共API获取请求",
          "level": 2
        },
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "检查是否请求成功的分析方法",
          "text": "检查是否请求成功的分析方法",
          "level": 2
        },
        {
          "id": "请求示例-1",
          "text": "请求示例",
          "level": 3
        }
      ],
      "contentModule": "guide__interface-common"
    },
    {
      "slug": "social/bilibili-getreplieslist",
      "title": "查询 bilibili 指定视频的评论数据",
      "summary": "查询 bilibili 指定视频的评论数据 此页面需要补充 请求示例 参数选项: oid: 指定要查询的目标评论区的ID对于视频，这通常就是它的 aid/bvid. sort: 指定查询视频的排序方式支持 0/time（按时间）、1/like（按点赞）、2/reply（按回复数）",
      "description": "查询 bilibili 指定视频的评论数据 此页面需要补充 请求示例 参数选项: oid: 指定要查询的目标评论区的ID对于视频，这通常就是它的 aid/bvid. sort: 指定查询视频的排序方式支持 0/time（按时间）、1/like（按点赞）、2/reply（按回复数）",
      "groupId": "social",
      "order": 999,
      "tags": [
        "bilibili",
        "social"
      ],
      "excerpt": "查询 bilibili 指定视频的评论数据 此页面需要补充 请求示例 参数选项: oid: 指定要查询的目标评论区的ID对于视频，这通常就是它的 aid/bvid. sort: 指定查询视频的排序方式支持 0/time（按时间）、1/like（按点赞）、2/reply（按回复数）、3/hot/hottest/最热（按最",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        },
        {
          "id": "评论区父级分类",
          "text": "评论区父级分类",
          "level": 3
        }
      ],
      "contentModule": "social__bilibili-getreplieslist"
    },
    {
      "slug": "social/bilibili-getvideodata",
      "title": "查询 bilibili 指定视频的数据",
      "summary": "查询 bilibili 指定视频的数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) IDType: 指定查询视频的ID格式, 可供使用的枚举如下: 枚举值 注释 : : : : AID 视频的AV号 (aid) BVID 视频的BV号 (bvid) 返回类型",
      "description": "查询 bilibili 指定视频的数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) IDType: 指定查询视频的ID格式, 可供使用的枚举如下: 枚举值 注释 : : : : AID 视频的AV号 (aid) BVID 视频的BV号 (bvid) 返回类型",
      "groupId": "social",
      "order": 999,
      "tags": [
        "bilibili",
        "social"
      ],
      "excerpt": "查询 bilibili 指定视频的数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) IDType: 指定查询视频的ID格式, 可供使用的枚举如下: 枚举值 注释 : : : : AID 视频的AV号 (aid) BVID 视频的BV号 (bvid) 返回类型: Task 返回值: VideoTyp",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "social__bilibili-getvideodata"
    },
    {
      "slug": "social/bilibili-getuserdata",
      "title": "查询 bilibili 指定用户的公开数据",
      "summary": "查询 bilibili 指定用户的公开数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) 返回类型: Task 返回值: UserType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Unautho",
      "description": "查询 bilibili 指定用户的公开数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) 返回类型: Task 返回值: UserType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Unautho",
      "groupId": "social",
      "order": 999,
      "tags": [
        "bilibili",
        "social"
      ],
      "excerpt": "查询 bilibili 指定用户的公开数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) 返回类型: Task 返回值: UserType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "social__bilibili-getuserdata"
    },
    {
      "slug": "social/bilibili-getarchives",
      "title": "查询 bilibili 指定用户的投稿数据",
      "summary": "查询 bilibili 指定用户的投稿数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) orderby: 指定以何种查询方式, 默认为 Pubdate. 可供使用的枚举有: 枚举值 注释 : : : : Pubdate 以最新发布顺序排列 Views 以播放",
      "description": "查询 bilibili 指定用户的投稿数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) orderby: 指定以何种查询方式, 默认为 Pubdate. 可供使用的枚举有: 枚举值 注释 : : : : Pubdate 以最新发布顺序排列 Views 以播放",
      "groupId": "social",
      "order": 999,
      "tags": [
        "bilibili",
        "social"
      ],
      "excerpt": "查询 bilibili 指定用户的投稿数据 请求示例 参数选项: mid: 指定要查询的用户UID(mid) orderby: 指定以何种查询方式, 默认为 Pubdate. 可供使用的枚举有: 枚举值 注释 : : : : Pubdate 以最新发布顺序排列 Views 以播放量排列 keywords: 指定一个关键",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        },
        {
          "id": "list-videos-video-嵌套类",
          "text": "`List<videos>` **Video** 嵌套类",
          "level": 3
        }
      ],
      "contentModule": "social__bilibili-getarchives"
    },
    {
      "slug": "social/bilibili-getliveroomstatus",
      "title": "查询 bilibili 指定用户的直播间数据",
      "summary": "查询 bilibili 指定用户的直播间数据 此页面需要补充 请求示例 参数选项: mid: 指定要查询的用户UID(mid) room id: 指定要查询的直播间ID, 和上述参数 mid 选其一即可. 返回类型: Task 返回值: LiveRoomType 对象 异常: I",
      "description": "查询 bilibili 指定用户的直播间数据 此页面需要补充 请求示例 参数选项: mid: 指定要查询的用户UID(mid) room id: 指定要查询的直播间ID, 和上述参数 mid 选其一即可. 返回类型: Task 返回值: LiveRoomType 对象 异常: I",
      "groupId": "social",
      "order": 999,
      "tags": [
        "bilibili",
        "social"
      ],
      "excerpt": "查询 bilibili 指定用户的直播间数据 此页面需要补充 请求示例 参数选项: mid: 指定要查询的用户UID(mid) room id: 指定要查询的直播间ID, 和上述参数 mid 选其一即可. 返回类型: Task 返回值: LiveRoomType 对象 异常: IException.General.UA",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        },
        {
          "id": "pendants-new-pendants-嵌套类",
          "text": "`Pendants` **new_pendants** 嵌套类",
          "level": 3
        },
        {
          "id": "frame-frame-嵌套类",
          "text": "`Frame` **frame** 嵌套类",
          "level": 3
        },
        {
          "id": "badge-badge-嵌套类",
          "text": "`Badge` **badge** 嵌套类",
          "level": 3
        }
      ],
      "contentModule": "social__bilibili-getliveroomstatus"
    },
    {
      "slug": "social/qq-getgroupdata",
      "title": "获取QQ群相关信息",
      "summary": "获取QQ群相关信息 请求示例 参数选项: group id: 指定要查询的群ID 返回类型: Task 返回值: GroupType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessEx",
      "description": "获取QQ群相关信息 请求示例 参数选项: group id: 指定要查询的群ID 返回类型: Task 返回值: GroupType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessEx",
      "groupId": "social",
      "order": 999,
      "tags": [
        "QQ",
        "social"
      ],
      "excerpt": "获取QQ群相关信息 请求示例 参数选项: group id: 指定要查询的群ID 返回类型: Task 返回值: GroupType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 I",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "social__qq-getgroupdata"
    },
    {
      "slug": "social/qq-getuserdata",
      "title": "获取QQ用户相关信息",
      "summary": "获取QQ用户相关信息 请求示例 参数选项: qq: 指定要查询的用户QQ号 返回类型: Task 返回值: UserType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessExcept",
      "description": "获取QQ用户相关信息 请求示例 参数选项: qq: 指定要查询的用户QQ号 返回类型: Task 返回值: UserType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessExcept",
      "groupId": "social",
      "order": 999,
      "tags": [
        "QQ",
        "social"
      ],
      "excerpt": "获取QQ用户相关信息 请求示例 参数选项: qq: 指定要查询的用户QQ号 返回类型: Task 返回值: UserType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 IExce",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "social__qq-getuserdata"
    },
    {
      "slug": "social/github-getrepodata",
      "title": "查询 github 公开仓库的数据",
      "summary": "查询 github 公开仓库的数据 请求示例 参数选项: owner and repo: 指定要查询的用户+仓库, 例: \"torvalds/linux\" 返回类型: Task 返回值: ReposType 对象 异常: IException.General.UAPIServer",
      "description": "查询 github 公开仓库的数据 请求示例 参数选项: owner and repo: 指定要查询的用户+仓库, 例: \"torvalds/linux\" 返回类型: Task 返回值: ReposType 对象 异常: IException.General.UAPIServer",
      "groupId": "social",
      "order": 999,
      "tags": [
        "github",
        "social"
      ],
      "excerpt": "查询 github 公开仓库的数据 请求示例 参数选项: owner and repo: 指定要查询的用户+仓库, 例: \"torvalds/linux\" 返回类型: Task 返回值: ReposType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Una",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "social__github-getrepodata"
    },
    {
      "slug": "games/epicgames-getfreegames",
      "title": "查询 Epic Games 当前免费游戏的数据",
      "summary": "查询 Epic Games 当前免费游戏的数据 请求示例 返回类型: Task 返回值: EpicType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权",
      "description": "查询 Epic Games 当前免费游戏的数据 请求示例 返回类型: Task 返回值: EpicType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权",
      "groupId": "games",
      "order": 999,
      "tags": [
        "EpicGames",
        "games"
      ],
      "excerpt": "查询 Epic Games 当前免费游戏的数据 请求示例 返回类型: Task 返回值: EpicType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 IException.Epi",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "games__epicgames-getfreegames"
    },
    {
      "slug": "games/minecraft-getserverstatus",
      "title": "获取 Minecraft 服务器状态",
      "summary": "获取 Minecraft 服务器状态 请求示例 参数选项: server: 指定要查询的服务器地址 port: 指定查询的服务器的端口, 默认为 25565. 返回类型: Task 返回值: ServerType 对象 异常: IException.General.UAPISer",
      "description": "获取 Minecraft 服务器状态 请求示例 参数选项: server: 指定要查询的服务器地址 port: 指定查询的服务器的端口, 默认为 25565. 返回类型: Task 返回值: ServerType 对象 异常: IException.General.UAPISer",
      "groupId": "games",
      "order": 999,
      "tags": [
        "minecraft",
        "games"
      ],
      "excerpt": "获取 Minecraft 服务器状态 请求示例 参数选项: server: 指定要查询的服务器地址 port: 指定查询的服务器的端口, 默认为 25565. 返回类型: Task 返回值: ServerType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 ",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "games__minecraft-getserverstatus"
    },
    {
      "slug": "games/minecraft-gethistoryname",
      "title": "获取 Minecraft 玩家历史昵称",
      "summary": "获取 Minecraft 玩家历史昵称 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 404等StatusCode . 请求示例 参数选项: param: 指定要查询的用户UUID或昵称 searchType: 指定查询的查找方式, 可供使",
      "description": "获取 Minecraft 玩家历史昵称 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 404等StatusCode . 请求示例 参数选项: param: 指定要查询的用户UUID或昵称 searchType: 指定查询的查找方式, 可供使",
      "groupId": "games",
      "order": 999,
      "tags": [
        "minecraft",
        "games"
      ],
      "excerpt": "获取 Minecraft 玩家历史昵称 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 404等StatusCode . 请求示例 参数选项: param: 指定要查询的用户UUID或昵称 searchType: 指定查询的查找方式, 可供使用的枚举如下: 枚举值 注释 : : :",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "以-name-查询时返回的属性列表",
          "text": "以 `name` 查询时返回的属性列表",
          "level": 3
        },
        {
          "id": "以-uuid-查询时返回的属性列表",
          "text": "以`UUID`查询时返回的属性列表",
          "level": 3
        }
      ],
      "contentModule": "games__minecraft-gethistoryname"
    },
    {
      "slug": "games/minecraft-getuserdata",
      "title": "获取 Minecraft 玩家信息",
      "summary": "获取 Minecraft 玩家信息 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 404等StatusCode . 请求示例 参数选项: username: 指定要查询的用户名 返回类型: Task 返回值: UserType 对象 异常:",
      "description": "获取 Minecraft 玩家信息 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 404等StatusCode . 请求示例 参数选项: username: 指定要查询的用户名 返回类型: Task 返回值: UserType 对象 异常:",
      "groupId": "games",
      "order": 999,
      "tags": [
        "minecraft",
        "games"
      ],
      "excerpt": "获取 Minecraft 玩家信息 所有 Minecraft 相关被请求查询的用户必须均为正版, 否则没有官方数据会返回 404等StatusCode . 请求示例 参数选项: username: 指定要查询的用户名 返回类型: Task 返回值: UserType 对象 异常: IException.General.",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "games__minecraft-getuserdata"
    },
    {
      "slug": "games/steam-getuserdata",
      "title": "获取 Steam 个人用户的公开数据",
      "summary": "获取 Steam 个人用户的公开数据 请求示例 参数选项: SteamID: 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下: ID类型 正则表达式格式 示例 : : : : STEAM ID STEAM 1:1:728234856 STEAM ID3 [U:1:1",
      "description": "获取 Steam 个人用户的公开数据 请求示例 参数选项: SteamID: 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下: ID类型 正则表达式格式 示例 : : : : STEAM ID STEAM 1:1:728234856 STEAM ID3 [U:1:1",
      "groupId": "games",
      "order": 999,
      "tags": [
        "Steam",
        "games"
      ],
      "excerpt": "获取 Steam 个人用户的公开数据 请求示例 参数选项: SteamID: 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下: ID类型 正则表达式格式 示例 : : : : STEAM ID STEAM 1:1:728234856 STEAM ID3 [U:1:1456469713] STEAM ID3",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "games__steam-getuserdata"
    },
    {
      "slug": "games/steam-steamid",
      "title": "SteamID 便携方法",
      "summary": "SteamID 便携方法 从任意 SteamID 格式中获取 Steam 好友代码 请求示例 参数选项: AnySteamID: 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下: ID类型 正则表达式格式 示例 : : : : STEAM ID STEAM 1:1:",
      "description": "SteamID 便携方法 从任意 SteamID 格式中获取 Steam 好友代码 请求示例 参数选项: AnySteamID: 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下: ID类型 正则表达式格式 示例 : : : : STEAM ID STEAM 1:1:",
      "groupId": "games",
      "order": 999,
      "tags": [
        "Steam",
        "games"
      ],
      "excerpt": "SteamID 便携方法 从任意 SteamID 格式中获取 Steam 好友代码 请求示例 参数选项: AnySteamID: 指定要查询的用户ID, 有多重枚举类型的ID可供选择, 如下: ID类型 正则表达式格式 示例 : : : : STEAM ID STEAM 1:1:728234856 STEAM ID3 ",
      "headings": [
        {
          "id": "从任意-steamid-格式中获取-steam-好友代码",
          "text": "从任意 `SteamID` 格式中获取 Steam 好友代码",
          "level": 2
        },
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "获取指定的-steam-用户的在线状态",
          "text": "获取指定的 Steam 用户的在线状态",
          "level": 2
        },
        {
          "id": "请求示例-1",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "获取指定的-steam-用户的社区可见性状态",
          "text": "获取指定的 Steam 用户的社区可见性状态",
          "level": 2
        },
        {
          "id": "请求示例-2",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "获取-steam-用户的个人资料状态",
          "text": "获取 Steam 用户的个人资料状态",
          "level": 2
        },
        {
          "id": "请求示例-3",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "将任意-steamid-转换为-steamid32",
          "text": "将任意 `SteamID` 转换为 `SteamID32`",
          "level": 2
        },
        {
          "id": "请求示例-4",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "将任意-steamid-转换为-steamid64",
          "text": "将任意 `SteamID` 转换为 `SteamID64`",
          "level": 2
        },
        {
          "id": "请求示例-5",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "将任意-steamid-转换为-steamid32-1",
          "text": "将任意 `SteamID` 转换为 `SteamID32`",
          "level": 2
        },
        {
          "id": "请求示例-6",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "将任意-steamid-转换为-steamid1",
          "text": "将任意 `SteamID` 转换为 `SteamID1`",
          "level": 2
        },
        {
          "id": "请求示例-7",
          "text": "请求示例",
          "level": 3
        },
        {
          "id": "steamid-分析器",
          "text": "`SteamID` 分析器",
          "level": 2
        },
        {
          "id": "请求示例-8",
          "text": "请求示例",
          "level": 3
        }
      ],
      "contentModule": "games__steam-steamid"
    },
    {
      "slug": "utility/misc-gettrackinginfo",
      "title": "查询快递物流信息",
      "summary": "查询快递物流信息 请求示例 参数列表 tracking number : 快递单号，通常是一串10 20位的数字或字母数字组合。 carrier code : 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。 phone : 收件人手机尾号，4位数字（可选）。",
      "description": "查询快递物流信息 请求示例 参数列表 tracking number : 快递单号，通常是一串10 20位的数字或字母数字组合。 carrier code : 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。 phone : 收件人手机尾号，4位数字（可选）。",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "查询快递物流信息 请求示例 参数列表 tracking number : 快递单号，通常是一串10 20位的数字或字母数字组合。 carrier code : 快递公司编码（可选）。不填写时系统会自动识别，填写后可加快查询速度。 phone : 收件人手机尾号，4位数字（可选）。部分快递公司需要验证手机尾号才能查询详细",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-gettrackinginfo"
    },
    {
      "slug": "utility/misc-getlunartime",
      "title": "查询农历时间",
      "summary": "查询农历时间 请求示例 参数选项: ts: Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。 timezone : 时区名称。支持 IANA 时区（如 Asia/Shanghai）和别名（Shanghai、Beijing）。默认 Asia/Shanghai",
      "description": "查询农历时间 请求示例 参数选项: ts: Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。 timezone : 时区名称。支持 IANA 时区（如 Asia/Shanghai）和别名（Shanghai、Beijing）。默认 Asia/Shanghai",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "查询农历时间 请求示例 参数选项: ts: Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。 timezone : 时区名称。支持 IANA 时区（如 Asia/Shanghai）和别名（Shanghai、Beijing）。默认 Asia/Shanghai。 返回类型: Task 返回值: Lu",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-getlunartime"
    },
    {
      "slug": "utility/misc-getprogrammerhistorytoday",
      "title": "获取程序员历史上的今天的事件",
      "summary": "获取程序员历史上的今天的事件 请求示例 返回类型: Task 返回值: HistoryTodayType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的",
      "description": "获取程序员历史上的今天的事件 请求示例 返回类型: Task 返回值: HistoryTodayType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "获取程序员历史上的今天的事件 请求示例 返回类型: Task 返回值: HistoryTodayType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 IException.Gene",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-getprogrammerhistorytoday"
    },
    {
      "slug": "utility/misc-getworldtime",
      "title": "获取全球指定时区的当地时间",
      "summary": "获取全球指定时区的当地时间 请求示例 参数选项: region: 指定要查询天气的城市, 格式为 七大洲之一/地区 或 直接输入地区 例: Asia/Shanghai, America/New York, Tokyo 返回类型: Task 返回值: WorldTimeType 对",
      "description": "获取全球指定时区的当地时间 请求示例 参数选项: region: 指定要查询天气的城市, 格式为 七大洲之一/地区 或 直接输入地区 例: Asia/Shanghai, America/New York, Tokyo 返回类型: Task 返回值: WorldTimeType 对",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "获取全球指定时区的当地时间 请求示例 参数选项: region: 指定要查询天气的城市, 格式为 七大洲之一/地区 或 直接输入地区 例: Asia/Shanghai, America/New York, Tokyo 返回类型: Task 返回值: WorldTimeType 对象 异常: IException.Gen",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-getworldtime"
    },
    {
      "slug": "utility/misc-getphoneinfo",
      "title": "获取手机号码的归属地信息",
      "summary": "获取手机号码的归属地信息 请求示例 参数选项: phoneNumber: 指定要查询的中国大陆 11 位手机号码 返回类型: Task 返回值: PhoneInfoType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 ",
      "description": "获取手机号码的归属地信息 请求示例 参数选项: phoneNumber: 指定要查询的中国大陆 11 位手机号码 返回类型: Task 返回值: PhoneInfoType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 ",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "获取手机号码的归属地信息 请求示例 参数选项: phoneNumber: 指定要查询的中国大陆 11 位手机号码 返回类型: Task 返回值: PhoneInfoType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessEx",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-getphoneinfo"
    },
    {
      "slug": "utility/misc-getrandomnumberlist",
      "title": "获取一组随机数字",
      "summary": "获取一组随机数字 请求示例 参数选项: min: 生成随机数的最小值（包含）。 max: 生成随机数的最大值（包含）。 count: 需要生成的随机数的数量。 allow repeat: 是否允许生成的多个数字中出现重复值。 allow decimal: 是否生成小（浮点）数。如",
      "description": "获取一组随机数字 请求示例 参数选项: min: 生成随机数的最小值（包含）。 max: 生成随机数的最大值（包含）。 count: 需要生成的随机数的数量。 allow repeat: 是否允许生成的多个数字中出现重复值。 allow decimal: 是否生成小（浮点）数。如",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "获取一组随机数字 请求示例 参数选项: min: 生成随机数的最小值（包含）。 max: 生成随机数的最大值（包含）。 count: 需要生成的随机数的数量。 allow repeat: 是否允许生成的多个数字中出现重复值。 allow decimal: 是否生成小（浮点）数。如果为 false，则只生成整数。 dec",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-getrandomnumberlist"
    },
    {
      "slug": "utility/misc-gettrackingcarriers",
      "title": "获取支持的快递公司列表",
      "summary": "获取支持的快递公司列表 请求示例 返回类型: Task 返回值: CarriersType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 IE",
      "description": "获取支持的快递公司列表 请求示例 返回类型: Task 返回值: CarriersType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 IE",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "获取支持的快递公司列表 请求示例 返回类型: Task 返回值: CarriersType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 IException.General.UAP",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-gettrackingcarriers"
    },
    {
      "slug": "utility/misc-postdatediff",
      "title": "计算两个日期之间的差值",
      "summary": "计算两个日期之间的差值 请求示例 参数列表 start date : 开始时间/日期 end date : 结束时间/日期 format : 时间格式, 默认为 YYYY MM DD 返回类型: Task 返回值: DateDiffType 对象 异常: IException.G",
      "description": "计算两个日期之间的差值 请求示例 参数列表 start date : 开始时间/日期 end date : 结束时间/日期 format : 时间格式, 默认为 YYYY MM DD 返回类型: Task 返回值: DateDiffType 对象 异常: IException.G",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "计算两个日期之间的差值 请求示例 参数列表 start date : 开始时间/日期 end date : 结束时间/日期 format : 时间格式, 默认为 YYYY MM DD 返回类型: Task 返回值: DateDiffType 对象 异常: IException.General.UAPIServerDow",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-postdatediff"
    },
    {
      "slug": "utility/misc-detecttrackingcarrier",
      "title": "通过快递单号识别快递公司",
      "summary": "通过快递单号识别快递公司 请求示例 参数选项: tracking number: 快递单号 返回类型: Task 返回值: DetectedCarrierType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Unaut",
      "description": "通过快递单号识别快递公司 请求示例 参数选项: tracking number: 快递单号 返回类型: Task 返回值: DetectedCarrierType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Unaut",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "通过快递单号识别快递公司 请求示例 参数选项: tracking number: 快递单号 返回类型: Task 返回值: DetectedCarrierType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessExcepti",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-detecttrackingcarrier"
    },
    {
      "slug": "utility/misc-converttimestamp",
      "title": "转换 Unix 时间戳",
      "summary": "转换 Unix 时间戳 请求示例 参数选项: ts: Unix 时间戳, 支持10位（秒）或13位（毫秒）。 返回类型: Task 返回值: TimestampType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Un",
      "description": "转换 Unix 时间戳 请求示例 参数选项: ts: Unix 时间戳, 支持10位（秒）或13位（毫秒）。 返回类型: Task 返回值: TimestampType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Un",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "misc",
        "utility"
      ],
      "excerpt": "转换 Unix 时间戳 请求示例 参数选项: ts: Unix 时间戳, 支持10位（秒）或13位（毫秒）。 返回类型: Task 返回值: TimestampType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessExce",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__misc-converttimestamp"
    },
    {
      "slug": "utility/network-getmyip",
      "title": "获取本机的公网IP地址",
      "summary": "获取本机的公网IP地址 请求示例 参数选项: commercial: 指定是否使用商业级的数据源, 默认为 false 返回类型: Task 返回值: IPType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Unau",
      "description": "获取本机的公网IP地址 请求示例 参数选项: commercial: 指定是否使用商业级的数据源, 默认为 false 返回类型: Task 返回值: IPType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 Unau",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "network",
        "utility"
      ],
      "excerpt": "获取本机的公网IP地址 请求示例 参数选项: commercial: 指定是否使用商业级的数据源, 默认为 false 返回类型: Task 返回值: IPType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessExcept",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__network-getmyip"
    },
    {
      "slug": "utility/weather-getweather",
      "title": "天气请求",
      "summary": "天气请求 请求示例 参数选项: city: 指定要查询天气的城市 adcode: 指定要查询天气的城市的高德地图的6位数字城市编码 extended: 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 false indices: 是否",
      "description": "天气请求 请求示例 参数选项: city: 指定要查询天气的城市 adcode: 指定要查询天气的城市的高德地图的6位数字城市编码 extended: 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 false indices: 是否",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "Weather",
        "utility"
      ],
      "excerpt": "天气请求 请求示例 参数选项: city: 指定要查询天气的城市 adcode: 指定要查询天气的城市的高德地图的6位数字城市编码 extended: 是否返回扩展气象字段（体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量）, 默认为 false indices: 是否返回生活指数（穿衣、紫外线、洗车、晾晒、",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__weather-getweather"
    },
    {
      "slug": "utility/hotboard-bilibili",
      "title": "查询 bilibili 热榜排名详细数据",
      "summary": "查询 bilibili 热榜排名详细数据 请求示例 返回类型: Task 返回值: bilibiliType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授",
      "description": "查询 bilibili 热榜排名详细数据 请求示例 返回类型: Task 返回值: bilibiliType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "hotboard",
        "utility"
      ],
      "excerpt": "查询 bilibili 热榜排名详细数据 请求示例 返回类型: Task 返回值: bilibiliType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 Hotboard.Hotb",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__hotboard-bilibili"
    },
    {
      "slug": "utility/hotboard-neteasemusic",
      "title": "查询网易云音乐热榜详细数据",
      "summary": "查询网易云音乐热榜详细数据 请求示例 返回类型: Task 返回值: NeteaseType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 H",
      "description": "查询网易云音乐热榜详细数据 请求示例 返回类型: Task 返回值: NeteaseType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 H",
      "groupId": "utility",
      "order": 999,
      "tags": [
        "hotboard",
        "utility"
      ],
      "excerpt": "查询网易云音乐热榜详细数据 请求示例 返回类型: Task 返回值: NeteaseType 对象 异常: IException.General.UAPIServerDown: 请求源服务器发生错误 UnauthorizedAccessException: 未经授权的请求操作 Hotboard.HotboardUpst",
      "headings": [
        {
          "id": "请求示例",
          "text": "请求示例",
          "level": 2
        },
        {
          "id": "属性列表",
          "text": "属性列表",
          "level": 2
        },
        {
          "id": "根属性",
          "text": "根属性",
          "level": 3
        }
      ],
      "contentModule": "utility__hotboard-neteasemusic"
    }
  ],
  "defaultDocSlug": "guide/overview"
};
