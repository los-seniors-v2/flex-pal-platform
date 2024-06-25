using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

public class DailyExerciseRepository (AppDbContext context) :   BaseRepository<DailyExercise>(context), IDailyExerciseRepository
{
    public new async Task<DailyExercise?> FindByIdAsync(int id) => await Context.Set<DailyExercise>()
        .Include(exercise => exercise.FitnessPlan)
        .FirstOrDefaultAsync(exercise => exercise.Id == id);
    
    public async Task<IEnumerable<DailyExercise>> GetAllAsync() =>
        await Context.Set<DailyExercise>()
            .Include(exercise => exercise.FitnessPlan)
            .ToListAsync();
    
    public new async Task AddAsync(DailyExercise dailyExercise) =>
        await Context.Set<DailyExercise>().AddAsync(dailyExercise);
    
    public async Task UpdateAsync(DailyExercise dailyExercise) =>
        await Task.Run(() => Context.Set<DailyExercise>().Update(dailyExercise));
    
    public async Task DeleteAsync(int id) =>
        await Task.Run(async () =>
        {
            var dailyExercise = await Context.Set<DailyExercise>().FindAsync(id);
            if (dailyExercise != null)
            {
                Context.Set<DailyExercise>().Remove(dailyExercise);
                await Context.SaveChangesAsync();
            }
        });
}