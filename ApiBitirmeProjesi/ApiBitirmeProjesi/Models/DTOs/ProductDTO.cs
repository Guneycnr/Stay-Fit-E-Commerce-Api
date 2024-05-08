namespace ApiBitirmeProjesi.Models.DTOs;

public class ProductDTO
{
    // Bu sınıf, bir ürünü temsil eden veri transfer nesnesini (DTO) sağlar.

    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CommentLine { get; set; } = string.Empty;
    public string UsedMaterial { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string MidPhoto { get; set; } = string.Empty;
    public string LastPhoto { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int UnitStock { get; set; }
}
