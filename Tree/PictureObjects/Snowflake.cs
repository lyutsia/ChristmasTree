using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Snowflake : OnePointPicture, IPrintable

    {
        private const ConsoleColor ColorSnow = ConsoleColor.White;

        public Snowflake(Point point)
        {
            Point = point;
        }

        public Snowflake(int x, int y)
        {
            Point = new Point(x, y);
        }

        public void Print()
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
