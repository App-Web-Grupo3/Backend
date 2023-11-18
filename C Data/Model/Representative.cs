namespace Data.Model;

public class Representative : UserBase
{
    public int? CompanyId { get; set; }
    public Company Company { get; set; }
    public UserRole? UserRole { get; set; }
}