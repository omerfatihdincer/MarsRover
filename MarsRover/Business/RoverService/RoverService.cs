using MarsRover.Entities;
using MarsRover.Enums;

namespace MarsRover.Business
{
    public class RoverService :  IRoverService
    {
        private Rover Rover { get; set; }

        public RoverService()
        {
            if (Rover is null)
            {
                Rover = new Rover();
            }
        }

        public bool IsOutControl()
        {
            var currentPlateau = GetCurrentPlateau();
            var currentLocation = GetCurrentCoordinate();
            return
                   currentPlateau.WidthStart <= currentLocation.X &&
                   currentLocation.X <= currentPlateau.WidthEnd &&
                   currentPlateau.HeightStart <= currentLocation.Y &&
                   currentLocation.Y <= currentPlateau.WidthEnd;
        }

        public Coordinate GetCurrentCoordinate()
        {
            return this.Rover.Coordinate;
        }

        public Plateau GetCurrentPlateau()
        {
            return this.Rover.Plateau;
        }

        public Direction GetCurrentDirection()
        {
            return this.Rover.Direction;
        }

        public void SetPlateau(int widthEnd, int heightEnd, int widthStart = 0, int heightStart = 0)
        {
            this.Rover.Plateau = new Plateau(widthEnd, heightEnd, widthStart, heightStart);
        }

        public void SetCoordinate(int x, int y, Direction direction)
        {

            if (this.Rover.Coordinate != null)
            {
                this.Rover.Coordinate.X = x;
                this.Rover.Coordinate.Y = y;
            }
            else
            {
                this.Rover.Coordinate = new Coordinate(x, y);
            }
            this.Rover.Direction = direction;
        }

        public void SetDirection( Direction direction)
        {
            this.Rover.Direction = direction;
        }
    }
}
