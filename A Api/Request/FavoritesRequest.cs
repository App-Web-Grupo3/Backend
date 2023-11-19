using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request
{
    public class FavoritesRequest
    {
        public int? TouristId { get; set; }
        public int? ActivitiesId { get; set; }
    }
}