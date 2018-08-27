using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;

namespace cqrs
{
    public class Program
    {
        static void Main(string[] args)
        {
            IoC.Cofigure();
            var commandBus = new CommandsBus();
            commandBus.Send(new CreateUserCommand("Tom","Jerry"));
        //    commandBus.Send(new DeleteUserCommand("Tom"));
        }
    }
}
