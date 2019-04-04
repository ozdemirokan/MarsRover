using System;
using Autofac;
using MarsRover.Library.Classes;
using MarsRover.Manager.Classes;
using MarsRover.Manager.Enums;
using MarsRover.Manager.Managers;
using MarsRover.Test.Dependency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        private IContainer container;
        private IRoverManager _roverManager;

        protected void CloseIoC()
        {
            container.Dispose();
        }

        [TestInitialize]
        public void Setup()
        {
            container = DependencyRegister.BuildContainer();
            _roverManager = container.Resolve<IRoverManager>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _roverManager = null;
            CloseIoC();
        }

        /// <summary>
        /// Test method for first rover output
        /// </summary>
        [TestMethod]
        public void FirstRoverCheckOutput()
        {
            var plateau = new Plateau(new Position(5, 5));
            var firstRover = new Rover(plateau, new Position(1, 2), Directions.N);
            _roverManager.Process(firstRover, "LMLMLMLMM");
            var output = string.Format("{0} {1} {2}", firstRover.RoverPosition.XCoordinate, firstRover.RoverPosition.YCoordinate, firstRover.RoverDirection);
            Assert.AreEqual(output, "1 3 N");
        }

        /// <summary>
        /// Test method for second rover output
        /// </summary>
        [TestMethod]
        public void SecondRoverCheckOutput()
        {
            var plateau = new Plateau(new Position(5, 5));
            var secondRover = new Rover(plateau, new Position(3, 3), Directions.E);
            _roverManager.Process(secondRover, "MMRMMRMRRM");
            var output = string.Format("{0} {1} {2}", secondRover.RoverPosition.XCoordinate, secondRover.RoverPosition.YCoordinate, secondRover.RoverDirection);
            Assert.AreEqual(output, "5 1 E");
            Assert.AreEqual("5 5", string.Format("{0} {1}", secondRover.RoverPlateau.PlateauPosition.XCoordinate, secondRover.RoverPlateau.PlateauPosition.YCoordinate));
        }

        /// <summary>
        /// Test method for incorrect input
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectInput()
        {
            var plateau = new Plateau(new Position(5, 5));
            var firstRover = new Rover(plateau, new Position(1, 2), Directions.N);
            var output = string.Format("{0} {1} {2}", firstRover.RoverPosition.XCoordinate, firstRover.RoverPosition.YCoordinate, firstRover.RoverDirection);
            _roverManager.Process(firstRover, "LMAMMM");
            Assert.AreEqual(output, "1 4 E");
        }

    }
}
