using APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterTitle>()
            .HasKey(pm => new { pm.CharacterId, pm.TitleId });

        modelBuilder.Entity<Backpack>()
            .HasKey(pm => new { pm.CharacterId, pm.ItemId });


        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Item1",
                Weight = 10
            },
            new Item
            {
                Id = 2,
                Name = "Item2",
                Weight = 5
            }
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                Id = 1,
                FirstName = "Maja",
                LastName = "Nowak",
                CurrentWeight = 55,
                MaxWeight = 60
            },
            new Character
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                CurrentWeight = 70,
                MaxWeight = 80
            }
        });

        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title
            {
                Id = 1,
                Name = "Title1"
            },
            new Title
            {
                Id = 2,
                Name = "Title2"
            }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack
            {
                CharacterId = 1,
                ItemId = 2,
                Amount = 2
            },
            new Backpack
            {
                CharacterId = 2,
                ItemId = 1,
                Amount = 3
            }
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle
            {
                CharacterId = 2,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2024-05-20")
            },
            new CharacterTitle
            {
                CharacterId = 1,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2024-05-30"),
            }
        });
    }
}