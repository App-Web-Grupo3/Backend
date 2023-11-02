using System.ComponentModel.DataAnnotations;

namespace UniqueTrip.Request
{
    public class FavoritesRequest
    {
        [Required]
        public int Tourist_id { get; set; }

        [Required]
        public int Activities_id { get; set; }

    }
}