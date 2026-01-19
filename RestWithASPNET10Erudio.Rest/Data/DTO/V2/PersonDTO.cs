namespace RestWithASPNET10Erudio.Rest.Data.DTO.V2;

public class PersonDTO
{
    public long Id { get; set; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string Address { get; init; }
    
    public string Gender { get; init; }
    
    public DateTime? BirthDay { get; init; }
}