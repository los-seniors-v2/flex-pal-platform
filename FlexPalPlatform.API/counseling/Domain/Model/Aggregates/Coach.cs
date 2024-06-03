namespace FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;

public class Coach
{
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
}