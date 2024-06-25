using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

public class NutritionalMealRepository(AppDbContext context) : BaseRepository<NutritionalMeal>(context), INutritionalMealRepository
{
    public new async Task<NutritionalMeal?> FindByIdAsync(int id) => await Context.Set<NutritionalMeal>()
        .Include(meal => meal.FitnessPlan)
        .FirstOrDefaultAsync(meal => meal.Id == id);

    public async Task<IEnumerable<NutritionalMeal>> GetAllAsync() =>
        await Context.Set<NutritionalMeal>()
            .Include(meal => meal.FitnessPlan)
            .ToListAsync();
    public new async Task AddAsync(NutritionalMeal nutritionalMeal) =>
        await Context.Set<NutritionalMeal>().AddAsync(nutritionalMeal);

    public async Task UpdateAsync(NutritionalMeal nutritionalMeal) =>
        await Task.Run(() => Context.Set<NutritionalMeal>().Update(nutritionalMeal));

    public async Task DeleteAsync(int id) =>
        await Task.Run(async () =>
        {
            var nutritionalMeal = await Context.Set<NutritionalMeal>().FindAsync(id);
            if (nutritionalMeal != null)
            {
                Context.Set<NutritionalMeal>().Remove(nutritionalMeal);
                await Context.SaveChangesAsync();
            }
        });
}
