namespace UniqueTrip.Response;

public class RepresentanteResponse
{
    //lo que se muestra al usuario
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public DateTime DateCreated { get; set; }
}