using kol2.Models;

namespace kol2.DTOs;

public class AddRacerDto
{
    public string raceName { get; set; }
    public string trackName { get; set; }
    public ICollection<AddParticipationDto> participations { get; set; }
}

public class AddParticipationDto
{
    public int racerId { get; set; }
    public int position { get; set; }
    public int finishTimeInSeconds { get; set; }
}