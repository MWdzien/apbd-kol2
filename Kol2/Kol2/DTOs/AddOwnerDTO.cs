namespace Kol2.DTOs;

public class AddOwnerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<int> OwnerObjects { get; set; } = new List<int>();
}