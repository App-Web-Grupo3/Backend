using System.Text.Json.Serialization;

namespace Data.Model;

public class Tourist : UserBase
{
    public int? FavoritesId { get; set; }
    public Favorites Favorites { get; set; }
    public UserRole? UserRole { get; set; }

    public List<Comment> Comments { get; set; }

    public List<PurchaseDetail> PurchaseDetails { get; set; }

}