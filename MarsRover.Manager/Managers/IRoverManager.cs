using MarsRover.Manager.Classes;

namespace MarsRover.Manager.Managers
{
    public interface IRoverManager
    {
        void Process(Rover rover, string commands);
    }
}
