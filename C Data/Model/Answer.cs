namespace Data.Model;

public class Answer : Base
{
    public string response { get; set; }
    public int CommentId { get; set; }
    public Comment Comment { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }

}