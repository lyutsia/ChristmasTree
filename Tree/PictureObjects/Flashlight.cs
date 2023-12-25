using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Flashlight : OnePointPicture, IPrintable
    {
        public Flashlight(Point point)
        {
            Point = point;
        }

        public Flashlight(int x, int y)
        {
            Point = new Point(x, y);
        }

        public void Print()
        {
            var random = new Random();
            int colorNumber;
            do
            {
                colorNumber = random.Next(3, 15);
            }
            while (colorNumber == 7 || colorNumber == 8 || colorNumber == 10);//исключаем некоторые цвета
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            PrintHelper.PrintFlashlight(Point.X, Point.Y);
        }
    }
}
