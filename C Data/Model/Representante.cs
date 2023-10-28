namespace Data.Model;

public class Representante : Base
{

    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Correo { get; set; }
    public string? Contrasenia { get; set; }
    public string? Telefono { get; set; }
    public List<Company> Companies { get; set; }
    
}