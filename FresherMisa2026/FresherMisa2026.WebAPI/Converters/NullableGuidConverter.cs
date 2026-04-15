using System.Text.Json;
using System.Text.Json.Serialization;

namespace FresherMisa2026.WebAPI.Converters
{
    public class NullableGuidConverter : JsonConverter<Guid?>
    {
        public override Guid? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            var value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
                return null;                    // → sẽ vào Required

            if (Guid.TryParse(value.Trim(), out var guid))
                return guid;

            // Sai định dạng → trả về một giá trị đặc biệt để sau này phân biệt
            return Guid.Empty;   // Chúng ta sẽ xử lý riêng ở Validate
        }

        public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
        {
            if (value.HasValue && value.Value != Guid.Empty)
                writer.WriteStringValue(value.Value.ToString("D"));
            else
                writer.WriteNullValue();
        }
    }
}