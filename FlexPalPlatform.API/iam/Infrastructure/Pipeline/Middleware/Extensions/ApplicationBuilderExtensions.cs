using FlexPalPlatform.API.iam.Infrastructure.Pipeline.Middleware.Components;

namespace FlexPalPlatform.API.iam.Infrastructure.Pipeline.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
    
}