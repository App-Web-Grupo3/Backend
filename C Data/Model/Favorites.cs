namespace Data.Model;

public class Favorites : Base
{
    public List<Tourist> Tourists { get; set; }
    public List<Activities> Activities { get; set; }
}