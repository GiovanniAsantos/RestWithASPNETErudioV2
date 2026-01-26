using Newtonsoft.Json;

namespace RestWithASPNET10Erudio.Rest.Utils;

public class GenderSerializer : JsonConverter<String>
{
    
    
    public override void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override string? ReadJson(
        JsonReader reader, 
        Type typeToConvert, 
        string? existingValue, 
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}