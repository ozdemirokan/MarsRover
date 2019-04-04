using System;
using MarsRover.Manager.Classes;
using MarsRover.Manager.Enums;

namespace MarsRover.Manager.Managers
{
    public class RoverManager : IRoverManager
    {
        public void Process(Rover rover, string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft(rover);
                        break;
                    case ('R'):
                        TurnRight(rover);
                        break;
                    case ('M'):
                        Move(rover);
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
        }

        private void TurnLeft(Rover rover)
        {
            rover.RoverDirection = (rover.RoverDirection - 1) < Directions.N ? Directions.W : rover.RoverDirection - 1;
        }

        private void TurnRight(Rover rover)
        {
            rover.RoverDirection = (rover.RoverDirection + 1) > Directions.W ? Directions.N : rover.RoverDirection + 1;
        }

        private void Move(Rover rover)
        {
            if (rover.RoverDirection == Directions.N)
            {
                rover.RoverPosition.YCoordinate++;
            }
            else if (rover.RoverDirection == Directions.E)
            {
                rover.RoverPosition.XCoordinate++;
            }
            else if (rover.RoverDirection == Directions.S)
            {
                rover.RoverPosition.YCoordinate--;
            }
            else if (rover.RoverDirection == Directions.W)
            {
                rover.RoverPosition.XCoordinate--;
            }
        }
    }
}
