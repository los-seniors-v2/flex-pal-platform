using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.iam.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    } 
}