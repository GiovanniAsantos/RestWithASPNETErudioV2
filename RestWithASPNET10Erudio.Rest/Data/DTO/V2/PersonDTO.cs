using System.Text.Json.Serialization;
using RestWithASPNET10Erudio.Rest.Utils;

namespace RestWithASPNET10Erudio.Rest.Data.DTO.V2;

public class PersonDTO
{
    //[JsonPropertyOrder(3)]
    //[JsonPropertyName("code")]
    public long Id { get; set; }
    
    //[JsonPropertyOrder(4)]
    //[JsonPropertyName("first_name")]
    public string FirstName { get; init; }
    
    //[JsonPropertyOrder(5)]
    //[JsonPropertyName("last_name")]
    public string LastName { get; init; }

    //[JsonPropertyOrder(1)]
    public string Address { get; init; }
    
    //[JsonPropertyOrder(6)]
    public string Gender { get; init; }
    
    //[JsonPropertyOrder(2)]
    [JsonConverter(typeof(DateSerializer))]
    public DateTime? BirthDay { get; init; }
}