using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class RepresentativeRequest
{
    //Lo que solicita ingresar al usuario
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Mail { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }
    [Required]
    public string SelectedRole { get; set; }
}