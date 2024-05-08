namespace ApiBitirmeProjesi.Models.DTOs;

public class ContactCreateDTO
{
    // Bu sınıf, bir contact oluşturma işlemi için kullanılan veri transfer nesnesini (DTO) temsil eder.
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
