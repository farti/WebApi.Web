using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class UserModel
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}
