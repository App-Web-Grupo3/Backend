namespace Data.Model;

public class PaymentMethod: Base
{
    public int? CardNumber { get; set; }
    public string? AccountHolderName { get; set; }
    public int? Month { get; set; }
    public int? Year { get; set; }
    public int? CVC { get; set; }
    //public List<Tourist> Tourists { get; set; }
    
}