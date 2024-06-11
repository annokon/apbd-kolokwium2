using Microsoft.AspNetCore.Mvc;
using APBD.Repositories;
using APBD.DTOs;

namespace APBD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly ICharacterRepository _characterRepository;

    public CharactersController(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCharactersDTO>> GetCharacter(int id)
    {
        var character = await _characterRepository.GetCharacterAsync(id);
        if (character == null) return NotFound();
        return Ok(character);
    }

    [HttpPost("{id}/backpacks")]
    public async Task<ActionResult> AddItemsToBackpack(int id, [FromBody] List<int> itemIds)
    {
        var result = await _characterRepository.AddItemsToBackpackAsync(id, itemIds);
        if (!result) return BadRequest();
        return NoContent();
    }
}