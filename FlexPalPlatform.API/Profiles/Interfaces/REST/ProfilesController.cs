using System.Net.Mime;
using FlexPalPlatform.API.Profiles.Domain.Model.Queries;
using FlexPalPlatform.API.Profiles.Domain.Services;
using FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;
using FlexPalPlatform.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FlexPalPlatform.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ProfilesController(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.Id}, profileResource);
    }
    
    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }

    [HttpPut("{profileId:int}")]
    public async Task<IActionResult> UpdateProfile(int profileId, UpdateProfileResource resource)
    {
        if (profileId != resource.Id)
        {
            return BadRequest("Profile ID in the URL and in the resource do not match.");
        }

        var updateProfileCommand = UpdateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var updatedProfile = await profileCommandService.Handle(updateProfileCommand);

        if (updatedProfile == null)
        {
            return NotFound();
        }

        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(updatedProfile);
        return Ok(profileResource);
    }
}