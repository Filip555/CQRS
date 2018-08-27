public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IEventsBus _eventPublisher;
    public CreateUserCommandHandler(IEventsBus eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }
    public void Handle(CreateUserCommand command)
    {
        System.Console.WriteLine($"Create user {command.Name} {command.Surname} - handler");
        _eventPublisher.Publish(new UserWasCreatedEvent(command.Name));
    }
}