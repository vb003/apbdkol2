using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;

public class Track
{
    [Key]
    public int TrackId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "decimal")]
    [Precision(5,2)]
    public decimal LengthInKm { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; }
}