using System.Collections.Generic;
using System.Linq;
using Autofac;

public interface ICommandBus
{
    void Send<T>(T Command) where T : ICommand;
}
public class CommandsBus : ICommandBus
{
    public void Send<TCommand>(TCommand command) where TCommand : ICommand
    {
        var handlers = IoC.Container.Resolve<IEnumerable<ICommandHandler<TCommand>>>().ToList();
        if (handlers.Count == 1)
        {
            handlers[0].Handle(command);
        }
        else if (handlers.Count == 0)
        {
            throw new System.Exception($"Command does not have any handler {command.GetType().Name}");
        }
        else
        {
            throw new System.Exception($"Too many registred handlers - {handlers.Count} for command {command.GetType().Name}");
        }
    }
}