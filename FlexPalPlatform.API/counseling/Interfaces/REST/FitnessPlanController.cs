using Microsoft.AspNetCore.Mvc;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST;

[ApiController]
[Route("api/v1/fitness-plans")]
public class FitnessPlanController : ControllerBase
{
    private readonly IFitnessPlanService _fitnessPlanService;

    public FitnessPlanController(IFitnessPlanService fitnessPlanService)
    {
        _fitnessPlanService = fitnessPlanService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFitnessPlan([FromBody] CreateFitnessPlanResource resource)
    {
        var command = new CreateFitnessPlanCommand(resource.ProfileId, resource.CoachId);
        var fitnessPlan = await _fitnessPlanService.CreateFitnessPlanAsync(command);
        if (fitnessPlan == null)
        {
            return BadRequest("Unable to create fitness plan");
        }
        return CreatedAtAction(nameof(GetFitnessPlanById), new { fitnessPlanId = fitnessPlan.Id }, fitnessPlan);
    }

    [HttpPost("{fitnessPlanId}/routine-items")]
    public async Task<IActionResult> AddRoutineItem(int fitnessPlanId, [FromBody] AddRoutineItemResource resource)
    {
        var item = new RoutineItem(resource.Name, resource.Sets, resource.Reps, resource.Type, resource.RestTime);
        bool result = await _fitnessPlanService.AddRoutineItemToFitnessPlanAsync(fitnessPlanId, item);
        if (!result)
        {
            return BadRequest("Unable to add routine item");
        }
        return Ok();
    }

    [HttpPost("{fitnessPlanId}/nutritional-meals")]
    public async Task<IActionResult> AddNutritionalMeal(int fitnessPlanId, [FromBody] AddNutritionalMealResource resource)
    {
        var meal = new NutritionalMeal(resource.Name, resource.Weight);
        bool result = await _fitnessPlanService.AddNutritionalMealToFitnessPlanAsync(fitnessPlanId, meal);
        if (!result)
        {
            return BadRequest("Unable to add nutritional meal");
        }
        return Ok();
    }

    [HttpGet("{fitnessPlanId}")]
    public async Task<IActionResult> GetFitnessPlanById(int fitnessPlanId)
    {
        var fitnessPlan = await _fitnessPlanService.GetFitnessPlanByIdAsync(fitnessPlanId);
        if (fitnessPlan == null)
        {
            return NotFound();
        }
        return Ok(fitnessPlan);
    }
}
