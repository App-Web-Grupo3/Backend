using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class UserLoginRequest
{
    [Required]
    public string Mail { get; set; }
    
    [Required]
    public string Password { get; set; }
}