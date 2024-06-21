using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class ObjectType
{
    [Key] 
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
}