using Kol2.Models;
using Microsoft.EntityFrameworkCore;
using Object = Kol2.Models.Object;

namespace Kol2.Data;


public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Object> Objects { get; set; }
    public DbSet<ObjectType> ObjectTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Object>().HasData(new List<Object>
        {
            new Object()
            {
                Id = 1,
                Width = 1.5M,
                Height = 2.2M
            },
            new Object()
            {
                Id = 2,
                Width = 3.5M,
                Height = 2.4M
            },
            new Object()
            {
                Id = 3,
                Width = 44.0M,
                Height = 4.6M
            }
        });

        modelBuilder.Entity<Owner>().HasData(new List<Owner>
        {
            new Owner()
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "123456789",
            }
        });

        modelBuilder.Entity<Warehouse>().HasData(new List<Warehouse>
        {
            new Warehouse()
            {
                Id = 1,
                Name = "bw1"
            },
            new Warehouse()
            {
                Id = 2,
                Name = "bw2"
            }
        });

        modelBuilder.Entity<ObjectType>().HasData(new List<ObjectType>
        {
            new ObjectType()
            {
                Id = 1,
                Name = "exampleType"
            },
            new ObjectType()
            {
                Id = 2,
                Name = "anotherExampleType"
            }
        });
    }
}