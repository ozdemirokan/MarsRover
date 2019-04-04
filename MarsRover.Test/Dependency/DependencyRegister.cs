using Autofac;
using MarsRover.Manager.Managers;

namespace MarsRover.Test.Dependency
{
    public class DependencyRegister
    {
        private static IContainer container { get; set; }
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RoverManager>().As<IRoverManager>();
            return builder.Build();
        }
    }
}
