using System.Text.Json.Serialization;

namespace Data.Model;

public class Images : Base
{
    public string Url { get; set; }
    public int ActivitiesId { get; set; }
    [JsonIgnore]
    public Activities Activities { get; set; }
}