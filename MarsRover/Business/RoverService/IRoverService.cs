using MarsRover.Entities;
using MarsRover.Enums;

namespace MarsRover.Business
{
    public interface IRoverService
    {
        bool IsOutControl();
        Coordinate GetCurrentCoordinate();
        Plateau GetCurrentPlateau();
        Direction GetCurrentDirection();
        void SetPlateau(int widthEnd, int heightEnd, int widthStart = 0, int heightStart = 0);
        void SetCoordinate(int x, int y, Direction direction);
        void SetDirection(Direction direction);
    }
}
