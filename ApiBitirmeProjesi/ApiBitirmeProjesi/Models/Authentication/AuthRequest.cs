using System.ComponentModel.DataAnnotations;

namespace ApiBitirmeProjesi.Models.Authentication;

public class AuthRequest
{
    // Kullanıcının giriş yapması için doldurması gereken bilgiler (kendi kontrol sistemimizde) 

    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
