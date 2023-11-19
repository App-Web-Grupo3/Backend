using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Favorites : Base
{
    public int TouristId { get; set; }
    [ForeignKey("TouristId")]
    public Tourist Tourist { get; set; }
    public int ActivitiesId { get; set; }
    [ForeignKey("ActivitiesId")]
    public Activities Activities { get; set; }
}