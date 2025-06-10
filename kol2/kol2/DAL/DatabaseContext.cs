using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.DAL;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Seed
        modelBuilder.Entity<Racer>().HasData(
            new Racer
            {
                RacerId = 1,
                FirstName = "John",
                LastName = "Doe"
            },
            new Racer
            {
                RacerId = 2,
                FirstName = "Jane",
                LastName = "Doe"
            }
        );
        
        modelBuilder.Entity<Track>().HasData(
            new Track
            {
                TrackId = 1,
                Name = "first track",
                LengthInKm = 20
            },
            new Track
            {
                TrackId = 2,
                Name = "second track",
                LengthInKm = 33
            }
        );
        
        modelBuilder.Entity<Race>().HasData(
            new Race
            {
                RaceId = 1,
                Name = "best race",
                Location = "warsaw",
                Date = new DateTime(2019, 12, 10),
            },
            new Race
            {
                RaceId = 2,
                Name = "second best race",
                Location = "london",
                Date = new DateTime(2020, 12, 10),
            }
        );

        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace()
            {
                TrackRaceId = 1,
                TrackId = 1,
                RaceId = 1,
                Laps = 3,
                BestTimeInSeconds = 100
            },
            
            new TrackRace()
            {
                TrackRaceId = 2,
                TrackId = 2,
                RaceId = 2,
                Laps = 5,
                BestTimeInSeconds = null
            }
        );
        
        
        modelBuilder.Entity<RaceParticipation>().HasData(
            new RaceParticipation()
            {
                TrackRaceId = 1,
                RacerId = 1,
                FinishTimeInSeconds = 5,
                Position = 5
            },
            
            new RaceParticipation()
            {
                TrackRaceId = 2,
                RacerId = 1,
                FinishTimeInSeconds = 50,
                Position = 9
            }
        );

        
    }
    
}