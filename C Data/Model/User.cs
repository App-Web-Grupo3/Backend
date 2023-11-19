using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class User : Base
{
    public string? SelectedRole { get; set; }
    public int? UserRoleId { get; set; }
    [ForeignKey("UserRoleId")]
    public UserRole? UserRole { get; set; }
}