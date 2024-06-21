using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Owner
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)] 
    public string FirstName { get; set; }
    [MaxLength(50)] 
    public string LastName { get; set; }
    [MaxLength(9)] 
    public string PhoneNumber { get; set; }

    public ICollection<Object> Objects { get; set; } = new HashSet<Object>();
}