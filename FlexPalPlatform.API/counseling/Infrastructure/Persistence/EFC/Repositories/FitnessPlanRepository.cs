using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

public class FitnessPlanRepository : BaseRepository<FitnessPlan>, IFitnessPlanRepository
{
    public FitnessPlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<FitnessPlan?> GetWithDetailsByIdAsync(int fitnessPlanId)
    {
        return await Context.Set<FitnessPlan>()
            .Include(fp => fp.RoutineItems)
            .Include(fp => fp.NutritionalMeals)
            .FirstOrDefaultAsync(fp => fp.Id == fitnessPlanId);
    }
}