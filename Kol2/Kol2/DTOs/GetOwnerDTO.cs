namespace Kol2.DTOs;

public class GetOwnerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<GetObjectDTO> Objects { get; set; } = null!;
}

public class GetObjectDTO
{
    public int Id { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string ObjectType { get; set; }
    public string Warehouse { get; set; }
}