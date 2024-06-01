using System.Net.Mime;
using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Domain.Model.Queries;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.iam.Interfaces.REST.Resources;
using FlexPalPlatform.API.iam.Interfaces.REST.Transform;
using FlexPalPlatform.API.Profiles.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FlexPalPlatform.API.iam.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService): ControllerBase
{
    //Prubea crea perfil
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new {userId = userResource.Id}, userResource);
    }
    
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
    
    //Register
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserResource resource)
    {
        var createUserCommand = new CreateUserCommand(resource.UserName, resource.Password, resource.Role);
        var user = await userCommandService.Handle(createUserCommand, resource.FirstName, resource.LastName, resource.Email, resource.Weight, resource.Height, resource.Phone);
        
        if (user == null) return BadRequest("An error occurred while creating the user.");

        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = userResource.Id }, userResource);
    }
}
