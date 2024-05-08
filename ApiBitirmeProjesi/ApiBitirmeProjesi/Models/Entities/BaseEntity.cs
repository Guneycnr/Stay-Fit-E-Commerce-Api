namespace ApiBitirmeProjesi.Models.Entities;

public class BaseEntity<TKey>
{
    // Tüm tablolarda olacak kolonlar
    public TKey Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}