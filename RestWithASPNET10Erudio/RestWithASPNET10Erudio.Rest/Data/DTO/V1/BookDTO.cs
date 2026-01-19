namespace RestWithASPNET10Erudio.Rest.Data.DTO.V1;

public class BookDTO
{
    public long Id { get; set; }
    
    public string Title { get; init; }
    
    public string Author { get; init; }
    
    public decimal Price { get; init; }
  
    public DateTime LaunchDate { get; init; }
}