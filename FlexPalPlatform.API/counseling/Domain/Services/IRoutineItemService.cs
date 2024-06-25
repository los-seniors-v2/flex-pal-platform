using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface IRoutineItemService
{
    Task<RoutineItem?> GetByIdAsync(int id);
    Task<IEnumerable<RoutineItem>> GetAllAsync();
    Task AddAsync(RoutineItem routineItem);
    Task UpdateAsync(RoutineItem routineItem);
    Task DeleteAsync(int id);
}