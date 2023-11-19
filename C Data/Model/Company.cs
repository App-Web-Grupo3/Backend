using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Model;

public class Company : Base 
{
    
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public string? Description { get; set; }
    public string? Ruc { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? ProfilePicture { get; set; }
    public int RepresentativeId { get; set; }
    [ForeignKey("RepresentativeId")]
    public Representative Representative { get; set; }
    [JsonIgnore]
    public List<Answer> Answers { get; set; }
    [JsonIgnore]
    public List<Activities> Activities { get; set; }
}