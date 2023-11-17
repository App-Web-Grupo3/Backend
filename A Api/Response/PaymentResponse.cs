namespace UniqueTrip.Response;

public class PaymentResponse
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int Amount { get; set; }
    public int TaxInformation { get; set; }
    public int? PaymentMethodId { get; set; }
    public DateTime DateCreated { get; set; }
}