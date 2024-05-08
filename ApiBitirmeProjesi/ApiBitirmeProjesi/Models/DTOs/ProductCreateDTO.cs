namespace ApiBitirmeProjesi.Models.DTOs;

public class ProductCreateDTO
{
    // Bu sınıf, bir ürün oluşturma işlemi için kullanılan veri transfer nesnesini (DTO) temsil eder.

    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string UsedMaterial { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string MidPhoto { get; set; } = string.Empty;
    public string LastPhoto { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int UnitStock { get; set; }
    public int CategoryId { get; set; }
}
