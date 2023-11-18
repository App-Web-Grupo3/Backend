namespace Data.Model;

public class User : Base
{
    public string? SelectedRole { get; set; }
    public int? UserRoleId { get; set; }
    public UserRole? UserRole { get; set; }
}