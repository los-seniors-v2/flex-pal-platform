using System.Security.Cryptography;
using System.Text.Json.Serialization;
using FlexPalPlatform.API.iam.Domain.Model.Commands;

namespace FlexPalPlatform.API.iam.Domain.Model.Aggregates;

public class User(string username, string passwordHash, string role)
{
    public int Id { get; private set; }
    public string Username { get; private set; } = username;
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    public string Role { get; private set; } = role;
    
    public User() : this(string.Empty, string.Empty, string.Empty)
    {
    }
    
   
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    public User UpdateRole(string role)
    {
        Role = role;
        return this;
    }
}