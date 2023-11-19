using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class UserBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string SelectedRole { get; set; }
    public DateTime DateCreated{ get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool? IsActive { get; set; }

}