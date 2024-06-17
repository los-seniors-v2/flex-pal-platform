using FlexPalPlatform.API.iam.Domain.Model.Aggregates;

namespace FlexPalPlatform.API.iam.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}