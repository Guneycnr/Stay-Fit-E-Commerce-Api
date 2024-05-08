namespace ApiBitirmeProjesi.Models.Entities;

public class Shipper : BaseEntity<int>
{
    // Shiper tablosunun kolonları
    public string CompanyName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
