using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Tinsel : IPrintable
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkMagenta;
        /// <summary>
        /// мишура идет с лева на право или с права на лево
        /// </summary>
        public bool TinselLeftRight { get; set; } = true;

        public Tinsel() { }
        public Tinsel(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public void Print()
        {
            Console.ForegroundColor = Color;

            var difference = Math.Abs(EndPoint.X - StartPoint.X) / (EndPoint.Y - StartPoint.Y);
            var step = 1;
            if (!TinselLeftRight)
            {
                difference = 0 - difference;
                step = 0 - step;
            }

            var x = StartPoint.X;
            var y = StartPoint.Y;
            while (y <= EndPoint.Y)
            {
                for (var i = x; GetCondition(x, i, difference, TinselLeftRight); i += step)
                    PrintHelper.PrintPicturePoint(i, y);
                x += difference;
                y++;
            }
        }

        /// <summary>
        /// условие окончания цикла
        /// </summary>
        /// <param name="x"></param>
        /// <param name="index"></param>
        /// <param name="difference"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        private bool GetCondition(int x, int index, int difference, bool increment) => increment ? index < x + difference && index <= EndPoint.X
                                                                                        : index > x + difference && index >= EndPoint.X;
    }
}
