using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlexPalPlatform.API.iam.Application.Internal.OutboundServices.ACL;
using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace FlexPalPlatform.API.iam.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork,IExternalProfileService externalProfileService,string _jwtSecret): IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command, string firstName, string lastName, string email,
        string weight, string height, string phone)
    {
        //Encrypted password
        var user = new User(command);
        user.Password = User.EncryptPassword(command.Password);
        
        try
        {
            // Crear el perfil asociado en el contexto Profile
            var profileId = await externalProfileService.CreateProfileAsync(firstName, lastName, email, weight, height,
                phone, command.Role);

            if (profileId == 0)
            {
                throw new Exception("Failed to create profile.");
            }

            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the User: {e.Message}");
            return null;
        }
    }

    public async Task<string?> Handle(LoginUserCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user == null)
        {
            Console.WriteLine($"User not found: {command.Username}");
            return null;
        }
        if (!user.VerifyPassword(command.Password))
        {
            Console.WriteLine($"Invalid password for user: {command.Username}");
            return null;
        }
        // Generar JWT token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }

    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the User: {e.Message}");
            return null;
        }
    }
}