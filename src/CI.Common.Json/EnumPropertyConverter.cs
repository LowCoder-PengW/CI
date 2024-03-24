using System.Text.Json;
using System.Text.Json.Serialization;

namespace CI.Common.Json
{
    public class EnumPropertyConverter : JsonConverter<Enum>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var isok = typeToConvert.IsEnum;
            return isok;
        }

        public override Enum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
        {

            writer.WriteNumberValue(Convert.ToInt32(value));
            var fieldName = Enum.GetName(value.GetType(), value);
            writer.WritePropertyName(fieldName + "Text");
            writer.WriteStringValue(value.ToString());
        }
    }
}
