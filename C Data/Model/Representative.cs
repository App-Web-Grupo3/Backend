namespace Data.Model;

public class Representative : UserBase
{
    public UserRole? UserRole { get; set; }
    public Company Company { get; set; }
}