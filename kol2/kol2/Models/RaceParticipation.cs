using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;

[Table("Race_Participation")]
[PrimaryKey(nameof(TrackRaceId),nameof(RacerId))]
public class RaceParticipation
{
    public int TrackRaceId { get; set; }
    [ForeignKey(nameof(TrackRaceId))]
    public TrackRace TrackRace { get; set; }
    
    public int RacerId { get; set; }
    [ForeignKey(nameof(RacerId))]
    public Racer Racer { get; set; }
    
    [Required]
    public int FinishTimeInSeconds { get; set; }
    
    [Required]
    public int Position { get; set; }
}