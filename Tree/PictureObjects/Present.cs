using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Present : IPrintable
    {
        /// <summary>
        /// начальная и конечная ордината банта на подарке
        /// </summary>
        private int bowYStart, bowYEnd;
        /// <summary>
        /// начальная и конечная абцисса банта на подарке
        /// </summary>
        private int bowXStart, bowXEnd;

        public int PresentHeight { get; set; }
        public int PresentWidth => PresentHeight * 2;
        public int BowHeight { get; private set; }

        public ConsoleColor ColorPresent { get; set; }
        public ConsoleColor ColorBow { get; set; }
        /// <summary>
        /// Левая верхняя точка, начало области вывода подарка
        /// </summary>
        public Point StartPoint { get; set; }

        public Present(Point startPoint, int height, bool isLeft, ConsoleColor colorPresent, ConsoleColor colorBow)
        {
            ColorPresent = colorPresent;
            ColorBow = colorBow;
            PresentHeight = height;
            BowHeight = height - 1;

            var bowHeight = height / 3;
            bowYStart = (height - bowHeight) / 2;
            bowYEnd = bowYStart + bowHeight;

            bowXStart = height - bowHeight;
            bowXEnd = bowXStart + bowHeight * 2;

            startPoint.Y = startPoint.Y - BowHeight;
            if (isLeft)
                startPoint.X -= PresentWidth;
            StartPoint = startPoint;
        }

        public void Print()
        {
            PrintBow();
            for (int j = 0; j < PresentHeight; j++)
            {
                for (int i = 0; i < PresentWidth; i++)
                {
                    if (j >= bowYStart && j < bowYEnd || i >= bowXStart && i < bowXEnd)
                        Console.ForegroundColor = ColorBow;
                    else
                        Console.ForegroundColor = ColorPresent;

                    PrintHelper.PrintPicturePoint(StartPoint.X + i, StartPoint.Y + BowHeight + j);
                }
            }
        }

        private void PrintBow()
        {
            Console.ForegroundColor = ColorBow;
            var indent = 0;
            for (int j = 0; j < BowHeight; j++)
            {
                for (int i = indent + 1; i < PresentWidth - indent - 1; i++)
                {
                    if (i < bowXStart + indent || i >= bowXEnd - indent)
                        PrintHelper.PrintPicturePoint(StartPoint.X + i, StartPoint.Y + j);
                }
                indent++;
            }
        }
    }
}
