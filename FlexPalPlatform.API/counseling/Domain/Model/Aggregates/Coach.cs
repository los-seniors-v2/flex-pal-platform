using System.ComponentModel.DataAnnotations;

using FlexPalPlatform.API.Counseling.Domain.Model.Commands;

namespace FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;

public class Coach
{
    [Key]
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Knowledge { get; private set; }

    public Coach(string firstName, string lastName, string email, string phone, string knowledge)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Knowledge = knowledge;
    }

    public Coach(CreateCoachCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        Phone = command.Phone;
        Knowledge = command.Knowledge;
    }
}