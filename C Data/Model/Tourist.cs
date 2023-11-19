using System.Text.Json.Serialization;

namespace Data.Model;

public class Tourist : UserBase
{
    [JsonIgnore]
    public List<Favorites> Favorites { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; }
    public List<Comment> Comments { get; set; }
    public UserRole? UserRole { get; set; }
}