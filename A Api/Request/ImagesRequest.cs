using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class ImagesRequest
{
    [Required]
    public string Url { get; set; }
    [Required]
    public string Description { get; set; }
    public int ActivitiesId { get; set; }
}