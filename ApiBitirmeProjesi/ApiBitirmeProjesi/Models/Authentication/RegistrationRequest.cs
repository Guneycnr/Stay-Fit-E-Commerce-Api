using System.ComponentModel.DataAnnotations;

namespace ApiBitirmeProjesi.Models.Authentication;

public class RegistrationRequest
{
    // Kullanıcının kayıt olması için doldurması gereken bilgier (kendi kontrol sistemimizde) 
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
