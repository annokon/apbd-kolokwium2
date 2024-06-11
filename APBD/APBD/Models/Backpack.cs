using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD.Models;

public class Backpack
{
    [Key]
    public int CharacterId { get; set; }
    [Key]
    public int ItemId { get; set; }
    public int Amount { get; set; }
    
    [ForeignKey(nameof(CharacterId))] 
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; } = null!;
}