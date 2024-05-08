namespace ApiBitirmeProjesi.Models.DTOs;

public class CommentCreateDTO
{
    // Bu sınıf, bir yorum oluşturma işlemi için kullanılan veri transfer nesnesini (DTO) temsil eder.

    public int ProductId { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public string CommentLine { get; set; } = string.Empty;
}
