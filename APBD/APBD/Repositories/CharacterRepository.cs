using APBD.Data;
using APBD.DTOs;
using APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly DataContext _context;

    public CharacterRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<GetCharactersDTO?> GetCharacterAsync(int id)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null) return null;

        return new GetCharactersDTO
        {
            firstName = character.FirstName,
            lastName = character.LastName,
            currentWeight = character.CurrentWeight,
            maxWeight = character.MaxWeight,
            backpackItems = character.Backpacks.Select(b => new BackpackDTO
            {
                itemName = b.Item.Name,
                itemWeight = b.Item.Weight,
                amount = b.Amount
            }).ToList(),
            titles = character.CharacterTitles.Select(ct => new TitlesDTO
            {
                title = ct.Title.Name,
                aquiredAt = ct.AcquiredAt
            }).ToList()
        };
    }

    public async Task<bool> AddItemsToBackpackAsync(int characterId, List<int> itemIds)
    {
        var character = await _context.Characters.Include(c => c.Backpacks).FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return false;

        var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();
        if (items.Count != itemIds.Count) return false;

        var totalWeight = items.Sum(i => i.Weight);
        if (character.CurrentWeight + totalWeight > character.MaxWeight) return false;

        foreach (var item in items)
        {
            var backpack = character.Backpacks.FirstOrDefault(b => b.ItemId == item.Id);
            if (backpack != null)
            {
                backpack.Amount++;
            }
            else
            {
                character.Backpacks.Add(new Backpack { CharacterId = characterId, ItemId = item.Id, Amount = 1 });
            }
            character.CurrentWeight += item.Weight;
        }

        await _context.SaveChangesAsync();
        return true;
    }

}