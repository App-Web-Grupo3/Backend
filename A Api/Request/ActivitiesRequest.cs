using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class ActivitiesRequest
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
    [Required]
    public int People { get; set; }
    [Required]
    public float Price { get; set; }
    public bool? Discount { get; set; }
    public float Percentage { get; set; }
    public bool? Restriction { get; set; }
    //public int CommentId { get; set; }
    public int FavoritesId { get; set; }
    public int ImagesId { get; set; }
}