using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Surging.Core.CPlatform.Serialization.JsonConverters
{
   public class DateTimeNullJsonConverter : JsonConverter<DateTime?>
    {
        private readonly string _dateFormatString;
        public DateTimeNullJsonConverter()
        {
            _dateFormatString = "yyyy-MM-dd HH:mm:ss";
        }

        public DateTimeNullJsonConverter(string dateFormatString)
        {
            _dateFormatString = dateFormatString;
        }

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {  
            return string.IsNullOrEmpty(reader.GetString()) ? default(DateTime) : DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString(_dateFormatString));
        }
    }
}
