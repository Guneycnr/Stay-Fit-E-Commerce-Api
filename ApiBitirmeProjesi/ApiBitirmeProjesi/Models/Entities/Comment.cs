using ApiBitirmeProjesi.Models.Authentication;

namespace ApiBitirmeProjesi.Models.Entities;

public class Comment : BaseEntity<int>
{
    // Comment tablosunun kolonu
    public string CommentLine { get; set; } = string.Empty;

    // Comment tablosunun ilişkileri
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }
}
