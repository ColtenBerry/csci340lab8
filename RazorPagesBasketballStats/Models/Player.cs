using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;

namespace RazorPagesBasketballStats.Models;

public class Player
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    public string Name { get; set; } = string.Empty;
    [RegularExpression(@"^[A-Z]*$")]  
    [Required]
    [StringLength(2)] 
    public string Position {get; set;} = string.Empty;
    [RegularExpression(@"^[0-9]*$")]
    public int Number { get; set; }

    public int? FGM { get; set; }

    public int? FGA { get; set; }

    public int? FTM { get; set; }

    public int? FTA {get; set;}
}