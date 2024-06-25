using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

public class CoachRepository(AppDbContext context) : BaseRepository<Coach>(context), ICoachRepository
{
    public async Task<Coach?> FindByEmailAddressAsync(string email)
    {
        return await Context.Set<Coach>().FirstOrDefaultAsync(c => c.Email == email);
    }
}