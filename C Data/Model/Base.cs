namespace Data.Model;

public class Base
{
    public int Id { get; set; }
    public DateTime DateCreated{ get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool? IsActive { get; set; }
}