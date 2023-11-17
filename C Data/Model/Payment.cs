namespace Data.Model;

public class Payment: Base
{

    public int? Month { get; set; }
    public int? Year { get; set; }
    public int? Amount { get; set; }
    
    public int? TaxInformation { get; set; }
    
    public int? PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }

}