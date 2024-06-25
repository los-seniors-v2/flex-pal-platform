using FlexPalPlatform.API.counseling.Application.Internal.CommandServices;
using FlexPalPlatform.API.counseling.Application.Internal.QueryServices;
using Microsoft.AspNetCore.Mvc;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Queries;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST;

[ApiController]
[Route("api/v1/coaches")]
public class CoachController(CoachCommandService coachCommandService, CoachQueryService coachQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCoach([FromBody] CreateCoachResource createCoachResource)
    {
        var createCoachCommand = CreateCoachResourceFromEntityAssembler.ToCommandFromResource(createCoachResource);
        var coach = await coachCommandService.Handle(createCoachCommand);
        if (coach is null) return BadRequest();
        var resource = CoachResourceFromEntityAssembler.ToResourceFromEntity(coach);
        return CreatedAtAction(nameof(GetCoachById), new { coachId = resource.Id }, resource);
    }

    [HttpGet("{coachId:int}")]
    public async Task<IActionResult> GetCoachById([FromRoute] int coachId)
    {
        var coach = await coachQueryService.Handle(new GetCoachByIdQuery(coachId));
        if (coach == null) return NotFound();
        var resource = CoachResourceFromEntityAssembler.ToResourceFromEntity(coach);
        return Ok(resource);
    }
}