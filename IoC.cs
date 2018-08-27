using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;

public static class IoC
{
    public static IContainer Container { get; set; }
    public static void Cofigure()
    {
        var builder = new ContainerBuilder();
        var dataAccess = Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(dataAccess)
            .Where(x => x.IsAssignableTo<ICommandHandler>())
            .AsImplementedInterfaces();

        builder.Register<Func<Type, ICommandHandler>>(c =>
        {
            var ctx = c.Resolve<IComponentContext>();

            return t =>
            {
                var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                return (ICommandHandler)ctx.Resolve(handlerType);
            };
        });


        builder.RegisterAssemblyTypes(dataAccess)
            .Where(x => x.IsAssignableTo<IEventHandler>())
            .AsImplementedInterfaces();
 
        builder.Register<Func<Type, IEnumerable<IEventHandler>>>(c =>
        {
            var ctx = c.Resolve<IComponentContext>();
            return t =>
            {
                var handlerType = typeof(IEventHandler<>).MakeGenericType(t);
                var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                return (IEnumerable<IEventHandler>)ctx.Resolve(handlersCollectionType);
            };
        });
 
        builder.RegisterType<EventsBus>()
            .AsImplementedInterfaces();
        Container = builder.Build();
    }
}
