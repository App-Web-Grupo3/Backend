namespace UniqueTrip.Response;

public class PaymentMethodResponse
{
    public int CardNumber { get; set; }
    public string AccountHolderName { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int CVC { get; set; }
    public int TouristId { get; set; }
}