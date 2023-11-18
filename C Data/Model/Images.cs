namespace Data.Model;

public class Images : Base
{
    public string Url { get; set; }
    public string Description { get; set; }
    public List<Activities> Activities { get; set; }
}