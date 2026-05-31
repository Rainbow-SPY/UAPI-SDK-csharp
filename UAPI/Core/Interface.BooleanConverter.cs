using Newtonsoft.Json;

namespace UAPI
{
    public partial class Interface
    {
        internal class BooleanConverter : JsonConverter
        {
            public override bool CanConvert(System.Type objectType) => objectType == typeof(bool);

            public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                var value = reader.Value?.ToString().Trim();
                return value == "1" || value == "true";
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
                writer.WriteValue(value is bool b && b ? 1 : 0);
        }
    }
}