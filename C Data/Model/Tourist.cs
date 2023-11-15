using System.Text.Json.Serialization;

namespace Data.Model;

public class Tourist : Base
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Mail { get; set; }
    public string? Password { get; set; }
    public string Phone { get; set; }
    public List<Comment>? Comments { get; set; }
    
    [JsonIgnore]
    public Favorites Favorites { get; set; }
    
    [JsonIgnore]
    public List<PaymentMethod> PaymentMethod { get; set; }
}