using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.iam.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    Task<User?> FindByRoleAsync(string role);
    bool ExistsByUsername(string username);
    
}