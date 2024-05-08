namespace ApiBitirmeProjesi.Models.DTOs;

public class ContactDTO
{
    // Bu sınıf, bir contactı temsil eden veri transfer nesnesini (DTO) sağlar.
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
