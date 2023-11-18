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
    [RegularExpression(@"^\d{11}$", ErrorMessage = "El RUC debe tener 11 dígitos.")]
    public string Ruc { get; set; }
    [Required]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "El número debe tener 9 dígitos.")]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [MaxLength(100)]
    public string ProfilePicture { get; set; }
    public int AnswerId { get; set; }
    public int ActivitiesId { get; set; }
    
}