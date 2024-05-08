namespace ApiBitirmeProjesi.Models.Entities;

public class Category : BaseEntity<int>
{
    // Category tablosunun kolonu
    public string CategoryName { get; set; } = string.Empty;

    // Category tablosunun ilişkileri
    public virtual List<Product> Products { get; set; }

}