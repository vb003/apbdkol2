using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;

[Table("Track_Race")]
public class TrackRace
{
    [Key]
    public int TrackRaceId { get; set; }
    
    [Required]
    public int TrackId { get; set; }
    [ForeignKey(nameof(TrackId))]
    public Track Track { get; set; }
    
    [Required]
    public int RaceId { get; set; }
    [ForeignKey(nameof(RaceId))]
    public Race Race { get; set; }
    
    [Required]
    public int Laps { get; set; }
    
    public int? BestTimeInSeconds { get; set; }
    
    public ICollection<RaceParticipation> RaceParticipations { get; set; }
}