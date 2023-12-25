using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Tinsel : IPrintable
    {
        /// <summary> Координаты точки начала мишуры.</summary>
        public Point StartPoint { get; set; }

        /// <summary> Координаты точки конца мишуры.</summary>
        public Point EndPoint { get; set; }

        public ConsoleColor Color { get; set; } = ConsoleColor.DarkMagenta;

        /// <summary> Мишура идет с лева на право или с права на лево.</summary>
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

            var widthTinsel = Math.Abs(EndPoint.X - StartPoint.X) / (EndPoint.Y - StartPoint.Y);
            var step = 1;
            if (!TinselLeftRight)
            {
                widthTinsel = 0 - widthTinsel;
                step = 0 - step;
            }

            var x = StartPoint.X;
            var y = StartPoint.Y;
            while (y <= EndPoint.Y)
            {
                for (var i = x; GetCondition(x, i, widthTinsel); i += step)
                    PrintHelper.PrintPicturePoint(i, y);
                x += widthTinsel;
                y++;
            }
        }

        /// <summary>
        /// Условие окончания цикла.
        /// </summary>
        /// <param name="startX"> Начало вывода мишуры на текущей высоте.</param>
        /// <param name="index"> Текущий индекс в цикле.</param>
        /// <param name="widthTinsel"> Ширина мишуры.</param>
        /// <returns> Продолжается ли цикл.</returns>
        private bool GetCondition(int startX, int index, int widthTinsel) => TinselLeftRight ? index < startX + widthTinsel && index <= EndPoint.X
                                                                                        : index > startX + widthTinsel && index >= EndPoint.X;
    }
}
