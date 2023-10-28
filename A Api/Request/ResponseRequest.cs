using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class ResponseRequest
{
    [Required]
    [MaxLength(50)]
    public string response{ get; set; }
    public int CommentId { get; set; }
    public int CompanyId { get; set; }
}