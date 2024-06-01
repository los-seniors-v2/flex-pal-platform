using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Queries;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;

namespace FlexPalPlatform.API.iam.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository):IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
    
    public async Task<User?> Handle(GetUserByUsername query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}