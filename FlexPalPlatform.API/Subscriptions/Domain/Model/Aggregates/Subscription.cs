using FlexPalPlatform.API.Subscriptions.Domain.Model.Commands;
using FlexPalPlatform.API.Subscriptions.Domain.Model.ValueObjects;

namespace FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;

public partial class Subscription
{
    public Subscription()
    {
        StartDate = new StartDate();
        EndDate = new EndDate();
        Status = new MemberStatus();
        
    }

    public Subscription(DateTime startDate, DateTime endDate, bool isActive, string type)
    {
        StartDate = new StartDate(startDate);
        EndDate = new EndDate(endDate);
        Status = new MemberStatus(isActive, type);
        
    }

    public Subscription(CreateSubscriptionCommand command)
    {
        StartDate = new StartDate(command.StartDate);
        EndDate = new EndDate(command.EndDate);
        Status = new MemberStatus(command.IsActive, command.Type);
        
    }

    public int Id { get; }
    public StartDate StartDate { get; private set; }
    public EndDate EndDate { get; private set; }
    public MemberStatus Status { get; private set; }
    
    public DateTime SubscriptionStartDate => StartDate.Value;
    public DateTime SubscriptionEndDate => EndDate.Value;
    public string SubscriptionStatus => Status.IsActive ? "Active" : "Inactive";
    
    public string SubscriptionType => Status.Type;
}