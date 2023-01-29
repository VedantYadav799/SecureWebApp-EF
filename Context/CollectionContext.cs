using Microsoft.EntityFrameworkCore;
using Authentication.Entites;

namespace ProductsWebAPI.Contexts
{
    public class CollectionContext:DbContext{
    public DbSet<User> users {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conString="server=localhost; database=webdb; user=root; password='1234512345'";
        optionsBuilder.UseMySQL(conString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity => 
        {
          entity.HasKey(e => e.Id);
          entity.Property(e => e.FirstName).IsRequired();
          entity.Property(e => e.LastName).IsRequired();
          entity.Property(e => e.Password).IsRequired();
          entity.Property(e => e.Username).IsRequired();
        });
    }
    }
}