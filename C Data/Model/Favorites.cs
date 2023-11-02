namespace Data.Model;

public class Favorites : Base
{
    public int TouristId { get; set; }
    public Tourist Tourist { get; set; }
    public int ActivitiesId { get; set; }
    public Activities Activities { get; set; }
}