using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

public class FitnessPlanRepository(AppDbContext context) : BaseRepository<FitnessPlan>(context), IFitnessPlanRepository
{
    public async Task<FitnessPlan?> FindByIdWithRoutineItemsAsync(int id)
    {
        return await Context.Set<FitnessPlan>()
            .Include(fp => fp.RoutineItems)
            .Include(fp => fp.NutritionalMeals)
            .Include(fp => fp.DailyExercises)
            .FirstOrDefaultAsync(fp => fp.Id == id);
    }
}