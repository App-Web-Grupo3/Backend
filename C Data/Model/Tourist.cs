using System.Text.Json.Serialization;

namespace Data.Model;

public class Tourist : UserBase
{
    public int? FavoritesId { get; set; }
    public Favorites Favorites { get; set; }
    //public int? PaymentMethodId { get; set; }
    //public PaymentMethod PaymentMethod { get; set; }
    //public int? CommentId { get; set; }
    //public Comment Comment { get; set; }
    public UserRole? UserRole { get; set; }
}