namespace FlexPalPlatform.API.iam.Application.Internal.OutboundServices.ACL;

public interface IExternalProfileService
{
    public Task<int> CreateProfileAsync(string firstName, string lastName, string email, string weight, string height, string phone, string role);
}