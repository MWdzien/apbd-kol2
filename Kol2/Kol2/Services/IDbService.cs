using Kol2.DTOs;
using Kol2.Models;

namespace Kol2.Services;

public interface IDbService
{
    Task<Owner> GetOwnersData(int ownerID);
    Task<bool> DoesOwnerExist(int ownerID);
    Task<bool> DoesObjectExist(int objectID);
    Task<Kol2.Models.Object> GetObjectById(int objectId);

    Task AddOwnerWithObjects(Owner owner);
}