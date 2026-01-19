using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNET10Erudio.Rest.Model.Base;

namespace RestWithASPNET10Erudio.Rest.Model;

[Table("books")]
public class Book : BaseEntity
{
    [Required]
    [Column("title", TypeName = "varchar(250)")]
    [MaxLength(250)]
    public string Title { get; init; }
    
    [Required]
    [Column("author", TypeName = "varchar(180)")]
    [MaxLength(180)]
    public string Author { get; init; }
    
    [Required]
    [Column("price", TypeName = "decimal(18,2)")]
    public decimal Price { get; init; }
    
    [Required]
    [Column("launch_date", TypeName = "timestamp without time zone")]
    public DateTime LaunchDate { get; init; }
}