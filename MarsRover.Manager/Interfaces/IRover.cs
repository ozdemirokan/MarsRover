using MarsRover.Manager.Enums;

namespace MarsRover.Manager.Interfaces
{
    public interface IRover
    {
        IPlateau RoverPlateau { get; set; }
        IPosition RoverPosition { get; set; }
        Directions RoverDirection { get; set; }
    }
}
