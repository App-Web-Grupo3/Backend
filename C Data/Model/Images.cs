using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Images : Base
{
    public string Url { get; set; }
    public string Description { get; set; }
    public int ActivitiesId { get; set; }
    [ForeignKey("ActivitiesId")]
    public Activities Activities { get; set; }
}