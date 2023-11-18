namespace Data.Model;

public class Answer : Base
{
    public string response { get; set; }
    //public List<Comment> Comments { get; set; }
    public List<Company> Companies { get; set; }
}