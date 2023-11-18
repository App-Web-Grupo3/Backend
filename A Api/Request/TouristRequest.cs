using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UniqueTrip.Request;

public class TouristRequest
{
    [Required]
    public string Name{ get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Mail { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }
    [Required]
    public string SelectedRole { get; set; }
    public int? FavoritesId { get; set; }
    //public int? PaymentMethodId { get; set; }
    //public int? CommentId { get; set; }
}