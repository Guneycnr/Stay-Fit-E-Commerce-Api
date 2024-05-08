namespace ApiBitirmeProjesi.Models.Entities;

public class Contact : BaseEntity<int>
{
    // Contact tablosunun kolonları
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
