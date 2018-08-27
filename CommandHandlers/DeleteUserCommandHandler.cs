public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    public void Handle(DeleteUserCommand command)
    {
        System.Console.WriteLine($"Delete user {command.Name} - handler");
    }
}