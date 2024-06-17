using System.Net.Mime;
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
public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new { message = "User created successfully"});
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var authenticatedUserResource = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user, authenticatedUser.token);
        return Ok(authenticatedUserResource);
    }
    
}