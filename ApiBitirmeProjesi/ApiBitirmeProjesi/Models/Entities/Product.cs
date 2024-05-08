namespace ApiBitirmeProjesi.Models.Entities;

public class Product : BaseEntity<int>
{
    // Product tablosunun kolonları
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string UsedMaterial { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string MidPhoto { get; set; } = string.Empty;
    public string LastPhoto { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int UnitStock { get; set; }

    // Product tablosunun ilişkileri
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual List<Comment> Comments { get; set; }
}
