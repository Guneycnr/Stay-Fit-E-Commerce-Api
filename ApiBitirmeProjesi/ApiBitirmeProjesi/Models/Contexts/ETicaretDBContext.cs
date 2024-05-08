using ApiBitirmeProjesi.Models.Authentication;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiBitirmeProjesi.Models.Contexts;

public class ETicaretDbContext : IdentityDbContext<AppUser>
{
    public ETicaretDbContext(DbContextOptions options) : base(options)
    {

    }

    // Veri tabanında tabloları oluşturan bölüm 
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Contact> Contacts { get; set; }


    // Configurationlar ile koyduğumuz kuralların hepsini içeri ekleyen bölüm
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
