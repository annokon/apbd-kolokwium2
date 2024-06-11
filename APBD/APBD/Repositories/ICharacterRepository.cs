using APBD.DTOs;

namespace APBD.Repositories;

public interface ICharacterRepository
{
    Task<GetCharactersDTO?> GetCharacterAsync(int id);
    Task<bool> AddItemsToBackpackAsync(int characterId, List<int> itemIds);
}