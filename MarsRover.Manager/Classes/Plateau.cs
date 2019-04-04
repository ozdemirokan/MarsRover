using MarsRover.Manager.Classes;
using MarsRover.Manager.Interfaces;

namespace MarsRover.Library.Classes
{
    public class Plateau : IPlateau
    {
        public Position PlateauPosition { get; set; }

        public Plateau(Position position)
        {
            PlateauPosition = position;
        }
    }
}
