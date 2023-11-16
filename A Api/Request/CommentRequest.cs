using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class CommentRequest
{
    [Required]
    [MaxLength(500)]
    public string Content { get; set; }
    [Required]
    public int Tourist_id { get; set; }
    [Required]
    public int Activities_id { get; set; }

}