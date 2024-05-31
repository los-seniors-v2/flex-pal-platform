
using FlexPalPlatform.API.Profiles.Domain.Model.Commands;
using FlexPalPlatform.API.Profiles.Domain.Model.ValueObjects;

namespace FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Role = new RoleType();
        Phone= new PhoneNumber();
    }
    
    public Profile(string firstName, string lastName, string email,string phone, string role)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Phone = new PhoneNumber(phone);
        Role = new RoleType(role);
    }

    public Profile(CreateProfileCommand command)
    {
        Name= new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Role = new RoleType(command.Role);
    }
    
    
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public RoleType Role { get;private set; }
    
    public PhoneNumber Phone { get; private set; }
    
    public string FullName => Name.FullName;
    
    public string EmailAddress => Email.Address;

    public string PhoneNumber => Phone.Number;
    
    public string RoleType => Role.Role;
    
    public void Update(UpdateProfileCommand command)
    {
        Email = new EmailAddress(command.Email);
        Phone = new PhoneNumber(command.Phone);
    }
    
}