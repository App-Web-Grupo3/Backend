namespace Data.Model;

public class Images : Base
{
    public string Url { get; set; }
    public int ActivitiesId { get; set; }
    public Activities Activities { get; set; }
}