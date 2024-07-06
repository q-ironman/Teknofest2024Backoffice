using SanayiGUIBackosffice.Model;

namespace SanayiGUIBackosffice.Messages
{
    public class DrawObstacleRequestMessage
    {
        public List<Point> Points { get; set; }
        public Point? StartPoint { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
