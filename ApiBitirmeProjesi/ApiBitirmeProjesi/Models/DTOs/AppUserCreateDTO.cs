using ApiBitirmeProjesi.Models.Authentication;

namespace ApiBitirmeProjesi.Models.DTOs;

public class AppUserCreateDTO
{
    // Bu sınıf, yeni kullanıcıların oluşturulması için kullanılan veri transfer nesnesini (DTO) temsil eder. Kullanıcı bilgilerini içerir ve yeni bir kullanıcı oluştururken girilmesi gereken bilgileri sağlar.
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string Adres { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
