namespace ApiBitirmeProjesi.Models.DTOs;

public class OrderCreateDTO
{
    // Bu sınıf, bir sipariş oluşturma işlemi için kullanılan veri transfer nesnesini (DTO) temsil eder.

    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public int ShipperId { get; set; }
}
