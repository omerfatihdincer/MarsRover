using MarsRover.Enums;

namespace MarsRover.Entities
{
    public class Rover : IEntity
    {
        public Plateau Plateau { get; set; }
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
    }
}
