using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD.Models;

public class CharacterTitle
{
    [Key]
    public int CharacterId { get; set; }
    [Key] 
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }

    [ForeignKey(nameof(CharacterId))] 
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; } = null!;
}