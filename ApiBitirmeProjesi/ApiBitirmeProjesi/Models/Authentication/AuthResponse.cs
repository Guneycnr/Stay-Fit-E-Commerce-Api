namespace ApiBitirmeProjesi.Models.Authentication;

public class AuthResponse
{
    // Giriş yapan kullanıcıya döndüğümüz bilgiler (kendi kontrol sistemimizde) 
    public string id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string Token { get; set; } = string.Empty;
}
