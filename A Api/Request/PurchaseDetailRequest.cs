using Microsoft.Build.Framework;

namespace UniqueTrip.Request;

public class PurchaseDetailRequest
{
    [Required]
    public string State{ get; set; }
    [Required]
    public int PricePaid { get; set; }
    [Required]
    public DateTime DepartureDate { get; set; }
    [Required]
    public DateTime PaymentDate { get; set; }
    public int TouristId { get; set; }
    public int ActivitiesId { get; set; }
    
}