using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class RepresentanteRequest
{
    //Lo que solicita ingresar al usuario
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Apellido { get; set; }
    [Required]
    public string Correo { get; set; }
    [Required]
    public string Contrasenia { get; set; }
    [Required]
    [MaxLength(9)]
    public string Telefono { get; set; }
    
}