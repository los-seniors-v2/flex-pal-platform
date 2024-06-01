using System.Security.Cryptography;
using FlexPalPlatform.API.iam.Domain.Model.Commands;

namespace FlexPalPlatform.API.iam.Domain.Model.Aggregates;

public partial class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; set; }
    public string Role { get; private set; }
    
    public User()
    {
        this.Username = string.Empty;
        this.Password = string.Empty;
        this.Role = string.Empty;
    }

    public User(CreateUserCommand command)
    {
        this.Username = command.Username;
        this.Password = command.Password;
        this.Role = command.Role;
    }
    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, this.Password);
    }
    public static string EncryptPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}