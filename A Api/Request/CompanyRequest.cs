using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class CompanyRequest
{
    [Required]
    public string Name{ get; set; }
    [Required]
    public string Mail { get; set; }
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
    [Required]
    public string Ruc { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [MaxLength(100)]
    public string ProfilePicture { get; set; }
    public int? RepresentativeId { get; set; }
    
}