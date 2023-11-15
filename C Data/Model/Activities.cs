using System.Text.Json.Serialization;

namespace Data.Model;

public class Activities : Base
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? Discount { get; set; }
    public float Percentage { get; set; }
    public bool Restriction { get; set; }
    public int People { get; set; }
    public float Price { get; set; }
    
    public List<Comment> Comments { get; set; }
    
    [JsonIgnore]
    public Favorites Favorites { get; set; }
    
    //public int CompanyId { get; set; }
    //public Company Company { get; set; }
    //public List<Comment> Comments { get; set; }
}