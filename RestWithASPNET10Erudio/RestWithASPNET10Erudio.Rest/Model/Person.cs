using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNET10Erudio.Rest.Model.Base;

namespace RestWithASPNET10Erudio.Rest.Model;
[Table("person")]
public class Person : BaseEntity
{
    [Required]
    [Column("first_name", TypeName = "varchar(80)")]
    [MaxLength(80)]
    public string FirstName { get; init; }
    
    [Required]
    [Column("last_name", TypeName = "varchar(80)")]
    [MaxLength(80)]
    public string LastName { get; init; }
    
    [Required]
    [Column("address", TypeName = "varchar(100)")]
    [MaxLength(100)]
    public string Address { get; init; }
    
    [Required]
    [Column("gender", TypeName = "varchar(6)")]
    [MaxLength(6)]
    public string Gender { get; init; }    
    
    // [NotMapped]
    // public DateTime? BirthDay { get; init; }
}