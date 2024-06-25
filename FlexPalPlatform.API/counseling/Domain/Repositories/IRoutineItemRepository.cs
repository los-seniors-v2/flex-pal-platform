using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Repositories;

public interface IRoutineItemRepository
{
    Task<RoutineItem?> FindByIdAsync(int id);
    Task<IEnumerable<RoutineItem>> GetAllAsync();
    Task AddAsync(RoutineItem routineItem);
    Task UpdateAsync(RoutineItem routineItem);
    Task DeleteAsync(int id);
}