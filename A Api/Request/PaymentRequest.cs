using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request;

public class PaymentRequest
{
    [Required]
    public int Month { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public int TaxInformation { get; set; }
    public int? PaymentMethodId { get; set; }


}