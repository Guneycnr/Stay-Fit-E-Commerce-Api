using ApiBitirmeProjesi.Models.Authentication;

namespace ApiBitirmeProjesi.Models.Entities;

public class Order : BaseEntity<int>
{
    // Order tablosunun kolonları
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }

    // Order tablosunun ilişkileri
    public string AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }
    public int ShipperId { get; set; }
    public virtual Shipper Shipper { get; set; }

}
