using System.Runtime.InteropServices.JavaScript;

namespace Data.Model;

public class PurchaseDetail : Base
{
    public string? State { get; set; }
    
    public int? PricePaid { get; set; }
    public DateTime? DepartureDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    
    public int TouristId { get; set; }
    public Tourist Tourist { get; set; }
    public int ActivitiesId { get; set; }
    public Activities Activities { get; set; }
}