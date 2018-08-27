public class UserWasValidetedEventHandler : IEventHandler<UserWasCreatedEvent>
{
    public void Handle(UserWasCreatedEvent command)
    {
        System.Console.WriteLine($"User was validated {command.Name} - event");
    }
}