﻿using System.Net.Mime;
using FlexPalPlatform.API.iam.Domain.Model.Queries;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.iam.Infrastructure.Pipeline.Middleware.Attributes;
using FlexPalPlatform.API.iam.Interfaces.REST.Resources;
using FlexPalPlatform.API.iam.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
namespace FlexPalPlatform.API.iam.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService) : ControllerBase
{
    [HttpPost]
    
    

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}
