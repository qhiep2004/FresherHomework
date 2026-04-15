using System.Text.Json;
using System.Text.Json.Serialization;

namespace FresherMisa2026.WebAPI.Converters
{
    public class NullableGuidConverter : JsonConverter<Guid?>
    {
        public override Guid? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrEmpty(value))
                return Guid.Empty; // ""  Guid.Empty để ValidateRequired bắt

            if (Guid.TryParse(value, out var guid))
                return guid;

            return Guid.Empty; // không hợp lệ  Guid.Empty
        }

        public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
            => writer.WriteStringValue(value?.ToString());
    }
}
