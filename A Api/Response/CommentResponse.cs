using Data.Model;

namespace UniqueTrip.Response;

public class CommentResponse
{
    public string Content { get; set; }
    public int Tourist_id { get; set; }
    public int Activities_id { get; set; }
    public DateTime DateCreated { get; set; }
    public Company Company { get; set; }
}