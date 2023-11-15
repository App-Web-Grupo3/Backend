using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class PaymentMethodRequest
{
    //Lo que solicita ingresar al usuario
    [Required]
    [MaxLength(16)]
    public int CardNumber { get; set; }
    [Required]
    public string AccountHolderName { get; set; }
    [Required]
    [MaxLength(2)]
    public int Month { get; set; }
    [Required]
    [MaxLength(4)]
    public int Year { get; set; }
    [Required]
    [MaxLength(4)]
    public int CVC { get; set; }

    public int TouristId { get; set; }

}