namespace UniqueTrip.Response;

public class PurchaseDetailResponse
{
    public string State { get; set; }
    public int PricePaid { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime DateCreated { get; set; }
    
 
}