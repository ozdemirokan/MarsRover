using Autofac;
using MarsRover.Manager.Managers;

namespace MarsRover.Application.Dependency
{
    public class DependencyRegister
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RoverManager>().As<IRoverManager>();
            return builder.Build();
        }
    }
}
