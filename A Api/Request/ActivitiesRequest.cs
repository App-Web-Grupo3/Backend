using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class ActivitiesRequest
{
    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? Discount { get; set; }
    public float Percentage { get; set; }
    public bool Restriction { get; set; }
    public int people { get; set; }
    public float Price { get; set; }
    public int CompanyId { get; set; }
}