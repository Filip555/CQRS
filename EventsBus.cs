using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

public interface IEventsBus
{
    void Publish<T>(T @event) where T : IEvent;
}

public class EventsBus : IEventsBus
{
    public void Publish<T>(T @event) where T : IEvent
    {
        var handlers = IoC.Container.Resolve<IEnumerable<IEventHandler<T>>>().ToList();

        handlers.ForEach(h=>h.Handle(@event));
        //Parallel.ForEach(handlers, h => h.Handle(@event));
    }
}