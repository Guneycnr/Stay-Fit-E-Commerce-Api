using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApiBitirmeProjesi.Models.Authentication;

public class AppUser : IdentityUser
{
    // AppUser tablosunun kolonları
    public Role Role { get; set; }
    public string Adres { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    // AppUser Tablosunun ilişkisi
    public virtual List<Comment> Comments { get; set; }
    public virtual List<Order> Orders { get; set; }
}
