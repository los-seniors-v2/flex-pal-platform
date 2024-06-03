using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.Counseling.Domain.Repositories;

public interface ICoachRepository : IBaseRepository<Coach>
{
    Task<Coach?> FindByEmailAddressAsync(string email);
}