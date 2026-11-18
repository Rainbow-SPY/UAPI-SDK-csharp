namespace UAPI.v2.Core;

internal class BooleanConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => objectType == typeof(bool);

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var value = reader.Value?.ToString()?.Trim();
        return value is "1" or "true";
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) =>
        writer.WriteValue(value is bool b && b ? 1 : 0);
}