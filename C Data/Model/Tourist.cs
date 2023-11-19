using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Model;

public class Tourist : UserBase
{
    public UserRole? UserRole { get; set; }
    public List<Favorites> Favorites { get; set; }
    public List<Comment> Comments { get; set; }
    //public List<PaymentMethod> PaymentMethods { get; set; }
    public List<PurchaseDetail> PurchaseDetails { get; set; }

}