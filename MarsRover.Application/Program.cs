using System;
using MarsRover.Library.Classes;
using MarsRover.Manager.Classes;
using MarsRover.Manager.Enums;
using Autofac;
using MarsRover.Manager.Managers;
using MarsRover.Application.Dependency;

namespace MarsRover.Application
{
    class Program
    {
        private static IContainer container;
        static void Main(string[] args)
        {
            // dependency injection
            container = DependencyRegister.BuildContainer();
            var roverManager = container.Resolve<IRoverManager>();

            Console.WriteLine("Input");
            Console.WriteLine();
            Console.WriteLine("5 5");
            Console.WriteLine("1 2 N");
            Console.WriteLine("LMLMLMLMM");
            Console.WriteLine();
            Console.WriteLine("3 3 E");
            Console.WriteLine("MMRMMRMRRM");
            Console.WriteLine();

            try
            {
                //First rover 
                var firstPlateau = new Plateau(new Position(5, 5));
                var firstRover = new Rover(firstPlateau, new Position(1, 2), Directions.N);
                roverManager.Process(firstRover, "LMLMLMLMM");

                //Second rover 
                Plateau secondPlateau = new Plateau(new Position(5, 5));
                Rover secondRover = new Rover(secondPlateau, new Position(3, 3), Directions.E);
                roverManager.Process(secondRover, "MMRMMRMRRM");

                Console.WriteLine("Output");
                Console.WriteLine();
                Console.WriteLine(string.Format("{0} {1} {2}", firstRover.RoverPosition.XCoordinate, firstRover.RoverPosition.YCoordinate, firstRover.RoverDirection));
                Console.WriteLine(string.Format("{0} {1} {2}", secondRover.RoverPosition.XCoordinate, secondRover.RoverPosition.YCoordinate, secondRover.RoverDirection));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                // If the input has invalid letter, handle it
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
