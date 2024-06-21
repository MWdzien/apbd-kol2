using System.Transactions;
using Kol2.DTOs;
using Kol2.Models;
using Kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Object = Kol2.Models.Object;

namespace Kol2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OwnersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OwnersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{ownerID}")]
    public async Task<IActionResult> GetOwnerData(int ownerID)
    {
        if (!await _dbService.DoesOwnerExist(ownerID)) return NotFound($"Owner with given ID: {ownerID} doesn't exist");

        var owner = await _dbService.GetOwnersData(ownerID);

        var ownerData = new GetOwnerDTO()
        {
            FirstName = owner.FirstName,
            LastName = owner.LastName,
            PhoneNumber = owner.PhoneNumber,
            Objects = owner.Objects.Select(o => new GetObjectDTO()
            {
                Id = o.Id,
                Width = o.Width,
                Height = o.Height,
                ObjectType = o.ObjectType.Name,
                Warehouse = o.Warehouse.Name
            }).ToList()
        };
        return Ok(ownerData);
    }

    [HttpPost]
    public async Task<IActionResult> AddOwnerWithObjects(AddOwnerDTO newOwner)
    {

        var objects = new HashSet<Object>();
        foreach (var ownerObject in newOwner.OwnerObjects)
        {
            if (!await _dbService.DoesObjectExist(ownerObject)) 
                return NotFound($"Object with given ID: {ownerObject} doesn't exist");
            
            
            var obj = await _dbService.GetObjectById(ownerObject);
        }

        var owner = new Owner()
        {
            Id = 1,
            FirstName = newOwner.FirstName,
            LastName = newOwner.LastName,
            PhoneNumber = newOwner.PhoneNumber,
            Objects = objects
        };

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddOwnerWithObjects(owner);
            
            scope.Complete();
        }

        return Created();
    }
    
}