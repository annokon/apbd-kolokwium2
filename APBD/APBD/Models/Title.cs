using System.ComponentModel.DataAnnotations;

namespace APBD.Models;

public class Title
{
    [Key] 
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<CharacterTitle> CharacterTitles { get; set; }
}