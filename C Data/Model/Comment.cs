namespace Data.Model;

public class Comment : Base
{
    public string? Content { get; set; }
    public int ActivitiesId { get; set; }
    public Activities Activities { get; set; }
    public int TouristId { get; set; }
    public Tourist Tourist { get; set; }
    public List<Answer> Answers { get; set; }

}