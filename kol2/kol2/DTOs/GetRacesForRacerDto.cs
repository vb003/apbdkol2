using kol2.Models;

namespace kol2.DTOs;

public class GetRacesForRacerDto
{
    public int racerId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    
    public ICollection<GetParticipationsDto> participations { get; set; }
}

public class GetParticipationsDto
{
    public GetRaceDto race { get; set; }
    public GetTrackDto track { get; set; }
    public int laps { get; set; }
    public int finishTimeInSeconds { get; set; }
    public int position { get; set; }
}

public class GetRaceDto
{
    public string name { get; set; }
    public string location { get; set; }
    public DateTime date { get; set; }
}

public class GetTrackDto
{
    public string name { get; set; }
    public decimal lengthInKm { get; set; }
}