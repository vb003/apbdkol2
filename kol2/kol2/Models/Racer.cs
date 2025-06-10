using System.ComponentModel.DataAnnotations;

namespace kol2.Models;

public class Racer
{
    [Key]
    public int RacerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public ICollection<RaceParticipation> RaceParticipations { get; set; }
}