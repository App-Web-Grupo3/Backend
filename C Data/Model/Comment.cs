using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Comment : Base
{
    public string? Content { get; set; }
    public int ActivitiesId { get; set; }
    [ForeignKey("ActivitiesId")]
    public Activities Activities { get; set; }
    public int TouristId { get; set; }
    [ForeignKey("TouristId")]
    public Tourist Tourist { get; set; }
    public List<Answer> Answers { get; set; }

}