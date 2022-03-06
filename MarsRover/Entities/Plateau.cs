namespace MarsRover.Entities
{
    public class Plateau
    {
        public Plateau(int widthEnd, int heightEnd, int widthStart = 0, int heightStart = 0)
        {
            WidthStart = widthStart;
            HeightStart = heightStart;
            WidthEnd = widthEnd;
            HeightEnd = heightEnd;
        }

        public int WidthStart { get; private set; }
        public int HeightStart { get; private set; }
        public int WidthEnd { get; private set; }
        public int HeightEnd { get; private set; }
    }
}
