using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Snowflake : Flashlight
    {
        private const ConsoleColor ColorSnow = ConsoleColor.White;
        public Snowflake(Point point) : base(point)
        { }
        public Snowflake(int x, int y) : base(x, y)
        { }

        public override void Print()
        {
            var random = new Random();
            if (random.Next(0, 2) == 0)
                Console.ForegroundColor = ColorSnow;
            else
                Console.ForegroundColor = Console.BackgroundColor;
            PrintHelper.Print(Point.X, Point.Y);
        }
    }
}
