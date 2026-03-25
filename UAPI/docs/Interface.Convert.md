# 常用转换方法

## 格式化 播放量/点赞量 等原始 `int` 值

> 单位为**万**

### 示例

```csharp
string request = Interface.FormatPlayCount(int _Count) 
```

* 参数选项:
    * **_Count**: 原始`int`播放量/点赞量等数据

* 返回类型: `string`
* 返回值: 格式化后的以万为单位的字符串

## Unix 时间戳转换字符串

### 示例

```csharp
string request = Interface.FormatUnixTime(object _time)
```

- 参数选项:
    - **_time**: 不指定参数类型的字符串/整数Unix时间戳.
- 返回类型: `string`
- 返回值: 以 `YYYY-MM-DD HH:mm:ss` 格式的时间字符串

## ISO 8601格式的时间转换字符串

### 示例

```csharp
string request = Interface.FormatISO8601TimeToLocal(string iso8601Time)
```

- 参数选项:
    - **iso8601Time**: ISO 8601 格式(`YYYY-MM-DDTHH:mm:ss[.fff]Z`)的时间字符串（带Z后缀，可选含毫秒）
- 返回类型: `string`
- 返回值: 以 `YYYY-MM-DD HH:mm:ss` 格式的本地时间字符串

## 识别总长时间并转换为可读字符串的时间

### 示例

```csharp
string request = Interface.FormatSecondsTime(int _time) 
```

- 参数选项:
    - **_time**: 整数时间 (秒)
- 返回类型: `string`
- 返回值: `HH:mm:ss` 格式的时间字符串

## 适用于`Newtonsoft.Json.JsonConverter`的`int`型`Json`属性转换为`bool`的字段属性

### 覆写方法
```csharp
internal class BooleanConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => objectType == typeof(bool);

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = reader.Value?.ToString()?.Trim();
        return value == "1" || value == "true";
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(value is bool b && b ? 1 : 0);
}
```

### 示例

```csharp
[JsonProperty("zhen-de-jia-de")]
[JsonConverter(typeof(BooleanConverter))]
public bool Kskbl
{
    get => cxy == 0 );
    set => cxy = value ? 1 : 0;
}

```