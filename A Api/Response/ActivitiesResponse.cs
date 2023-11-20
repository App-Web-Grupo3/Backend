using Data.Model;

namespace UniqueTrip.Response;

public class ActivitiesResponse
{
    public string Title { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public int people { get; set; }
    public bool? Discount { get; set; }
    public float Percentage { get; set; }
    public bool? Restriction { get; set; }
    public CompanyResponse Company { get; set; }

}