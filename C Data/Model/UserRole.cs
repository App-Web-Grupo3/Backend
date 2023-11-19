using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class UserRole : Base
{
    public string? RoleType { get; set; }
    public List<User>? Users { get; set; }
    public int? TouristId { get; set; }
    [ForeignKey("TouristId")]
    public Tourist? Tourist { get; set; }
    public int? RepresentativeId { get; set; }
    [ForeignKey("RepresentativeId")]
    public Representative? Representative { get; set; }
}