using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

public class RoutineItemRepository(AppDbContext context) : BaseRepository<RoutineItem>(context), IRoutineItemRepository
{
    public new async Task<RoutineItem?> FindByIdAsync(int id) => await Context.Set<RoutineItem>()
        .Include(item => item.FitnessPlan)
        .FirstOrDefaultAsync(routineItem => routineItem.Id == id);

    public async Task<IEnumerable<RoutineItem>> GetAllAsync() => await Context.Set<RoutineItem>()
        .Include(item => item.FitnessPlan)
        .ToListAsync();

    public async Task UpdateAsync(RoutineItem routineItem) => await Task.Run(() =>
        Context.Set<RoutineItem>().Update(routineItem));

    public async Task DeleteAsync(int id) => await Task.Run(async () =>
    {
        var routineItem = await Context.Set<RoutineItem>().FindAsync(id);
        if (routineItem != null)
        {
            Context.Set<RoutineItem>().Remove(routineItem);
            await Context.SaveChangesAsync();
        }
    });
}