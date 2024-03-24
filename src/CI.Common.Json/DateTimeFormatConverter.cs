using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CI.Common.Json
{
    /// <summary>
    /// 时间格式转换
    /// </summary>
    public class DateTimeFormatConverter : JsonConverter<DateTime>
    {
        private readonly string DateTimeFormat;
        /// <summary>
        /// 本地化
        /// </summary>
        public CultureInfo Culture { get; set; }
        public DateTimeFormatConverter(string format = "yyyy-MM-dd HH:mm:ss")
        {
            DateTimeFormat = format;
            Culture = CultureInfo.CurrentCulture;
        }

        public override bool CanConvert(Type objectType)
        {
            return (typeof(DateTime) == objectType);
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            return DateTime.Parse(value!);
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var resultValue = value.ToString(DateTimeFormat, Culture);
            writer.WriteStringValue(resultValue);
        }





    }
}
