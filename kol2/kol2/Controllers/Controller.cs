using kol2.DTOs;
using kol2.Exceptions;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers;

[ApiController]
[Route("api")]
public class Controller : ControllerBase
{
    private readonly IService _service;

    public Controller(IService service)
    {
        _service = service;
    }
    
    // Endpoint 1:
    [HttpGet("racers/{id:int}/participations")]
    public async Task<IActionResult> GetRacesForRacer(int id)
    {
        try
        {
            var data = await _service.GetRacesForRacer(id);
            return Ok(data);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    // Endpoint 2:
    [HttpPost("track-races/participants")]
    public async Task<IActionResult> AddRacer([FromBody] AddRacerDto addRacerDto)
    {
        try
        {
            await _service.AddRacer(addRacerDto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}