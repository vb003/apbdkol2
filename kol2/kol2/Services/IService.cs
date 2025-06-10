using kol2.DTOs;

namespace kol2.Services;

public interface IService
{
    public Task<GetRacesForRacerDto> GetRacesForRacer(int racerId);
    
    public Task AddRacer(AddRacerDto addRacerDto);
}