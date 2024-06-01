namespace FlexPalPlatform.API.Profiles.Interfaces.ACL.Services;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, string weight, string height, string phone, string role);
}