namespace Data.Model;

public class Comment : Base
{
    public string? comment { get; set; }
    public int TouristId { get; set; }
    public Tourist Tourist { get; set; }
    public int ActiviesId { get; set; }
    public Activities Activities { get; set; }
    public List<Answer> Responses { get; set; }
}