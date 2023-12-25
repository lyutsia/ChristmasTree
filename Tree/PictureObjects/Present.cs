using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Present : IPrintable
    {
        /// <summary> Начальная и конечная ордината банта на подарке.</summary>
        private int bowYStart, bowYEnd;

        /// <summary> Начальная и конечная абцисса банта на подарке.</summary>
        private int bowXStart, bowXEnd;

        public int PresentHeight { get; set; }

        public int PresentWidth => PresentHeight * 2;

        public int BowHeight => PresentHeight - 1;

        public ConsoleColor ColorPresent { get; set; }

        public ConsoleColor ColorBow { get; set; }

        /// <summary> Левая верхняя точка, начало области вывода подарка.</summary>
        public Point StartPoint { get; set; }

        public Present(int height, ConsoleColor colorPresent, ConsoleColor colorBow)
        {
            ColorPresent = colorPresent;
            ColorBow = colorBow;
            PresentHeight = height;

            SetBowCoordinatesInPresent();
        }

        public Present(Point startPoint, int height, ConsoleColor colorPresent, ConsoleColor colorBow) : this(height, colorPresent, colorBow)
        {
            StartPoint = startPoint;
        }

        /// <summary> Устанавливаем координаты начала и конца банта на подарке.</summary>
        private void SetBowCoordinatesInPresent()
        {
            var bowHeightInPresent = PresentHeight / 3;
            bowYStart = (PresentHeight - bowHeightInPresent) / 2;
            bowYEnd = bowYStart + bowHeightInPresent;

            bowXStart = PresentHeight - bowHeightInPresent;
            bowXEnd = bowXStart + bowHeightInPresent * 2;
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

        /// <summary> Вывод банта.</summary>
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
