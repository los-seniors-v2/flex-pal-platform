namespace FlexPalPlatform.API.iam.Application.Internal.OutboundServices;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}