public class UserWasCreatedEvent : IEvent
{
    public string Name{get;}
    public UserWasCreatedEvent(string name)
    {
        Name = name;
    }
}