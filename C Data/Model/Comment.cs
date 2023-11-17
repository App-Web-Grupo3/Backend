using System.Text.Json.Serialization;

namespace Data.Model;

public class Comment : Base
{
    public string? Content { get; set; } //comentario
    
    public int TouristId { get; set; } //remitente
    public Tourist Tourist { get; set; }
    
    public int ActivitiesId { get; set; } //destinatario
    public Activities Activities { get; set; }
    
    public List<Answer> Responses { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }

}