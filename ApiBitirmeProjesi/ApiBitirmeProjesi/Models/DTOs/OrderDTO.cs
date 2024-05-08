namespace ApiBitirmeProjesi.Models.DTOs;

public class OrderDTO
{
    // Bu sınıf, bir siparişi temsil eden veri transfer nesnesini (DTO) sağlar.

    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Adres { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
}
