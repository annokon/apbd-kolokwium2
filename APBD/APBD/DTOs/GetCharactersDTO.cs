namespace APBD.DTOs;

public class GetCharactersDTO
{
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }

    public List<BackpackDTO> backpackItems { get; set; }
    public List<TitlesDTO> titles { get; set; }
}