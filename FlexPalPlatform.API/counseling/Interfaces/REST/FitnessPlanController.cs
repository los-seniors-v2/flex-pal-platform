using FlexPalPlatform.API.counseling.Application.Internal.CommandServices;
using FlexPalPlatform.API.counseling.Application.Internal.QueryServices;
using Microsoft.AspNetCore.Mvc;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Model.Queries;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST;

[ApiController]
[Route("api/v1/fitness-plans")]
public class FitnessPlanController(FitnessPlanCommandService fitnessPlanCommandService, FitnessPlanQueryService fitnessPlanQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFitnessPlan([FromBody] CreateFitnessPlanResource createFitnessPlanResource)
    {
        var createFitnessPlanCommand = CreateFitnessPlanResourceFromEntityAssembler.ToCommandFromResource(createFitnessPlanResource);
        var fitnessPlan = await fitnessPlanCommandService.Handle(createFitnessPlanCommand);
        if (fitnessPlan is null) return BadRequest();
        var resource = FitnessPlanResourceFromEntityAssembler.ToResourceFromEntity(fitnessPlan);
        return CreatedAtAction(nameof(GetFitnessPlanById), new { fitnessPlanId = resource.Id }, resource);
    }

    [HttpPost("{fitnessPlanId}/routine-items")]
    public async Task<IActionResult> AddRoutineItem([FromBody] AddRoutineItemToFitnessPlanResource addRoutineItemToFitnessPlanResource,
        [FromRoute] int fitnessPlanId)
    {
        var addRoutineItemToFitnessPlanCommand = AddRoutineItemToFitnessPlanCommandFromResourceAssembler
            .ToCommandFromResource(addRoutineItemToFitnessPlanResource, fitnessPlanId);
        var fitnessPlan = await fitnessPlanCommandService.Handle(addRoutineItemToFitnessPlanCommand);
        if (fitnessPlan == null) return NotFound();
        var resource = FitnessPlanResourceFromEntityAssembler.ToResourceFromEntity(fitnessPlan);
        return CreatedAtAction(nameof(GetFitnessPlanById), new { fitnessPlanId = resource.Id }, resource);
    }

    [HttpPost("{fitnessPlanId}/nutritional-meals")]
    public async Task<IActionResult> AddNutritionalMeal([FromBody] AddNutritionMealToFitnessPlanResource addNutritionMealToFitnessPlanResource,
        [FromRoute] int fitnessPlanId)
    {
        var addNutritionalMealToFitnessPlanCommand = AddNutritionalMealCommandFromResourceAssembler
            .ToCommandFromResource(addNutritionMealToFitnessPlanResource, fitnessPlanId);
        var fitnessPlan = await fitnessPlanCommandService.Handle(addNutritionalMealToFitnessPlanCommand);
        if (fitnessPlan == null) return NotFound();
        var resource = FitnessPlanResourceFromEntityAssembler.ToResourceFromEntity(fitnessPlan);
        return CreatedAtAction(nameof(GetFitnessPlanById), new { fitnessPlanId = resource.Id }, resource);
    }
    
    [HttpPost("{fitnessPlanId}/daily-exercises")]
    public async Task<IActionResult> AddDailyExercise([FromBody] AddDailyExerciseToFitnessPlanResource addDailyExerciseToFitnessPlanResource,
        [FromRoute] int fitnessPlanId)
    {
        var addDailyExerciseToFitnessPlanCommand = AddDailyExerciseCommandFromResourceAssembler
            .ToCommandFromResource(addDailyExerciseToFitnessPlanResource, fitnessPlanId);
        var fitnessPlan = await fitnessPlanCommandService.Handle(addDailyExerciseToFitnessPlanCommand);
        if (fitnessPlan == null) return NotFound();
        var resource = FitnessPlanResourceFromEntityAssembler.ToResourceFromEntity(fitnessPlan);
        return CreatedAtAction(nameof(GetFitnessPlanById), new { fitnessPlanId = resource.Id }, resource);
    }
    
    

    [HttpGet("{fitnessPlanId}")]
    public async Task<IActionResult> GetFitnessPlanById(int fitnessPlanId)
    {
        var fitnessPlan = await fitnessPlanQueryService.Handle(new GetFitnessPlanByIdQuery(fitnessPlanId));
        if (fitnessPlan == null) return NotFound();
        var resource = FitnessPlanResourceFromEntityAssembler.ToResourceFromEntity(fitnessPlan);
        return Ok(resource);
    }
}