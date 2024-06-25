using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.iam.Interfaces.REST.Transform;

public static class LoginCommandFromResourceAssembler
{
    public static LoginUserCommand ToCommandFromResource(LoginUserResource resource)
    {
        return new LoginUserCommand(resource.Username, resource.Password);
    } 
}