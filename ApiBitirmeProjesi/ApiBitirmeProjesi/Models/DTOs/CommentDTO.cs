namespace ApiBitirmeProjesi.Models.DTOs;

public class CommentDTO
{
    // Bu sınıf, bir yorumu temsil eden veri transfer nesnesini (DTO) sağlar.

    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string CommentLine { get; set; } = string.Empty;
}
