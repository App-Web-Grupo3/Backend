using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Answer : Base
{
    public string response { get; set; }
    public int CommentId { get; set; }
    [ForeignKey("CommentId")]
    public Comment Commment { get; set; }
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }
}