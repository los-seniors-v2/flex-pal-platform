using Microsoft.AspNetCore.Mvc;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST;

[ApiController]
[Route("api/v1/coaches")]
public class CoachController : ControllerBase
{
    private readonly ICoachService _coachService;

    public CoachController(ICoachService coachService)
    {
        _coachService = coachService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoach([FromBody] CreateCoachResource resource)
    {
        var command = new CreateCoachCommand(resource.FirstName, resource.LastName, resource.Email, resource.Phone, resource.Knowledge);
        var coach = await _coachService.CreateCoachAsync(command);
        if (coach == null) return BadRequest("Unable to create coach");
        return CreatedAtAction(nameof(GetCoachById), new { coachId = coach.Id }, coach);
    }

    [HttpGet("{coachId:int}")]
    public async Task<IActionResult> GetCoachById(int coachId)
    {
        var coach = await _coachService.GetCoachByIdAsync(coachId);
        if (coach == null) return NotFound();
        return Ok(coach);
    }
}