using Kol2.Data;
using Kol2.DTOs;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;
using Object = Kol2.Models.Object;

namespace Kol2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Owner> GetOwnersData(int ownerID)
    {
        return await _context.Owners
            .Include(e => e.Objects)
            .Where(e => e.Id == ownerID)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> DoesOwnerExist(int ownerID)
    {
        return await _context.Owners.AnyAsync(e => e.Id == ownerID);
    }

    public async Task<bool> DoesObjectExist(int objectID)
    {
        return await _context.Objects.AnyAsync(e => e.Id == objectID);
    }

    public async Task<Object> GetObjectById(int objectId)
    {
        return await _context.Objects.FirstOrDefaultAsync(e => e.Id == objectId);
    }

    public async Task AddOwnerWithObjects(Owner owner)
    {
        await _context.AddAsync(owner);
        await _context.SaveChangesAsync();
    }
    
}