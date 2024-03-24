using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CI.Common.Json
{
    /// <summary>
    /// 时间格式转换
    /// </summary>
    public class DateTimeIsNullFormatConverter : JsonConverter<DateTime?>
    {
        private readonly string DateTimeFormat;
        /// <summary>
        /// 本地化
        /// </summary>
        public CultureInfo Culture { get; set; }
        public DateTimeIsNullFormatConverter(string format = "yyyy-MM-dd HH:mm:ss")
        {
            DateTimeFormat = format;
            Culture = CultureInfo.CurrentCulture;
        }

        public override bool CanConvert(Type objectType)
        {
            return (typeof(DateTime?) == objectType);
        }


        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            bool flag = IsNullable(typeToConvert);
            string? value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                if (!flag)
                {
                    throw new InvalidDataException();
                }
                return null;
            }

            return DateTime.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                return;
            }
            var resultValue = value.Value.ToString(DateTimeFormat, Culture);
            writer.WriteStringValue(resultValue);
        }


        private static bool IsNullable(Type objectType)
        {
            if (objectType.IsGenericType)
            {
                return objectType.GetGenericTypeDefinition() == typeof(Nullable<>);
            }

            return false;
        }

    }

}
