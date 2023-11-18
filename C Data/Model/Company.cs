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
    public Representative Representative { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public int ActivitiesId { get; set; }
    public Activities Activities { get; set; }
}