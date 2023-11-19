using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class CommentRequest
{
    [Required]
    [MaxLength(500)]
    public string Content { get; set; }
    public int TouristId {get; set; }
    public int ActivitiesId {get; set; }
    

}