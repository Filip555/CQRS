public class DeleteUserCommand:ICommand
{
    public string Name{get;private set;}
    public DeleteUserCommand(string name)
    {
        Name = name;
    }
}