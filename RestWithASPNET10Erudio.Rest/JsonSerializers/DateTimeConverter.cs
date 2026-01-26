using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestWithASPNET10Erudio.Rest.Utils;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private static readonly string[] AcceptedFormats = new[]
    {
        "yyyy-MM-dd'T'HH:mm:ss.FFFFFFFK",
        "yyyy-MM-dd'T'HH:mm:ss",
        "yyyy-MM-dd",
        "dd/MM/yyyy",
        "MM/dd/yyyy"
    };

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var s = reader.GetString();
            if (string.IsNullOrWhiteSpace(s)) return default;

            if (DateTime.TryParse(s, out var dt)) return dt;

            if (DateTime.TryParseExact(s, AcceptedFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var dt2))
                return dt2;

            throw new JsonException($"Unable to parse '{s}' as DateTime.");
        }

        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var ticks))
        {
            return DateTime.FromFileTimeUtc(ticks);
        }

        throw new JsonException("Unexpected token when parsing DateTime.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
    }
}

