using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CI.Common.Json
{
    public class EnumPropertyConverter : JsonConverter<Enum>
    {
        private readonly Type type;
        public EnumPropertyConverter(Type type)
        {
            this.type = type;
        }
        public override bool CanConvert(Type typeToConvert)
        {
            var isok = typeToConvert.IsEnum;
            return isok;
        }

        public override Enum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
        {
            string fieldName = type.Name;
            writer.WriteNumberValue(Convert.ToInt32(value));
            writer.WritePropertyName(fieldName + "Text");
            writer.WriteStringValue(value.ToString());
        }
    }
}
