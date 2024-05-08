using ApiBitirmeProjesi.Models.Authentication;

namespace ApiBitirmeProjesi.Models.DTOs;

public class AppUserDTO
{
    // Bu sınıf, bir kullanıcı nesnesinin veri transfer işlemleri için kullanılan veri transfer nesnesini (DTO) temsil eder.
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string Adres { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
