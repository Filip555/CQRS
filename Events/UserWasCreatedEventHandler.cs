public class UserWasCreatedEventHandler : IEventHandler<UserWasCreatedEvent>
{
    public void Handle(UserWasCreatedEvent command)
    {
        System.Console.WriteLine($"User was created {command.Name} - event");
    }
}

