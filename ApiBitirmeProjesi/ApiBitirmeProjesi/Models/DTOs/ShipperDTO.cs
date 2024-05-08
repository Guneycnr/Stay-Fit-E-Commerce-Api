namespace ApiBitirmeProjesi.Models.DTOs;

public class ShipperDTO
{
    // Bu sınıf, bir nakliye şirketini temsil eden veri transfer nesnesini (DTO) sağlar.

    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
