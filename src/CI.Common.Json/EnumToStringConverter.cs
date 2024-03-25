using System.Text.Json;
using System.Text.Json.Serialization;

namespace CI.Common.Json
{
    public class EnumToStringConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new EnumPropertyConverter(typeToConvert);
        }
    }
}
