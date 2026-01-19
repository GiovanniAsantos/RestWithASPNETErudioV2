
using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET10Erudio.Rest.Model.Context;

public class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) {}
    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; } 
}
