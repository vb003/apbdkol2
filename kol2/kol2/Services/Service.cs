using kol2.DAL;
using kol2.DTOs;
using kol2.Exceptions;
using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services;

public class Service : IService
{
    private readonly DatabaseContext _context;

    public Service(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetRacesForRacerDto> GetRacesForRacer(int racerId)
    {
        var racer = await _context.Racers
            .Include(r => r.RaceParticipations)
            .ThenInclude (rp => rp.TrackRace)
            .ThenInclude (tr => tr.Race)
            .FirstOrDefaultAsync(r => r.RacerId == racerId);
        if (racer == null)
            throw new NotFoundException("Racer not found");

        var data = new GetRacesForRacerDto
        {
            racerId = racerId,
            firstName = racer.FirstName,
            lastName = racer.LastName,
            participations = racer.RaceParticipations
                .Select(rp => new GetParticipationsDto
                {
                    race = new GetRaceDto
                    {
                        name = rp.TrackRace.Race.Name,
                        location = rp.TrackRace.Race.Location,
                        date = rp.TrackRace.Race.Date
                    },
                    track = new GetTrackDto
                    {
                        name = rp.TrackRace.Track.Name,
                        lengthInKm = rp.TrackRace.Track.LengthInKm
                    },
                    finishTimeInSeconds = rp.FinishTimeInSeconds,
                    position = rp.Position
                }).ToList()
        };

        return data;
    }

    private async Task<Race?> GetRaceByName(string name)
    {
        return await _context.Races.FirstOrDefaultAsync(r => r.Name == name);
    }

    private async Task<Track?> GetTrackByName(string name)
    {
        return await _context.Tracks.FirstOrDefaultAsync(t => t.Name == name);
    }

    private async Task<Racer?> GetRacerById(int id)
    {
        return await _context.Racers.FirstOrDefaultAsync(r => r.RacerId == id);
    }

    private async Task<TrackRace?> GetTrackRaceById(int trackId, int raceId)
    {
        return await _context.TrackRaces.FirstOrDefaultAsync(t => t.TrackId == trackId && t.RaceId == raceId);
    }
    
    public async Task AddRacer(AddRacerDto addRacerDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var race = await GetRaceByName(addRacerDto.raceName);
            if (race == null)
                throw new NotFoundException("No race found");
            
            var track = await GetTrackByName(addRacerDto.trackName);
            if (track == null)
                throw new NotFoundException("No track found");

            var trackRace = await GetTrackRaceById(track.TrackId, race.RaceId);
            if (trackRace == null)
                throw new NotFoundException("No track-race found");

            List<RaceParticipation> rps = new List<RaceParticipation>();
            foreach (var participation in addRacerDto.participations)
            {
                var racer = GetRacerById(participation.racerId);
                if (racer == null)
                    throw new NotFoundException("No racer found");

                var rp = new RaceParticipation
                {
                    TrackRaceId = trackRace.TrackRaceId,
                    RacerId = racer.Id,
                    FinishTimeInSeconds = participation.finishTimeInSeconds,
                    Position = participation.position,
                };
                rps.Add(rp);
               // _context.RaceParticipations.Add(rp);

                if (participation.finishTimeInSeconds < trackRace.BestTimeInSeconds)
                {
                    trackRace.BestTimeInSeconds = participation.finishTimeInSeconds;
                    _context.TrackRaces.Update(trackRace);
                }
            }
            await _context.RaceParticipations.AddRangeAsync(rps);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}