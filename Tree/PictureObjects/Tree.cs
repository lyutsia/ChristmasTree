using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Tree : IPrintable
    {
        /// <summary> Величина увеличения ширины треугольника елки.</summary>
        private const int SizeIncrementWidthTriangle = 4;
        /// <summary> Величина увеличения высоты треуголника елки.</summary>
        private const int SizeIncrementHeightTriangle = 2;
        /// <summary> Максимальное случайное значение, чем больше значение, тем меньше будет фонариков.</summary>
        private const int RandomMaxValue = 5;
        /// <summary> Высота относительно треугольника елки, с которой начинается мишура.</summary>
        private const int TinselStartY = 3;

        private const ConsoleColor ColorTree = ConsoleColor.Green;
        private const ConsoleColor ColorTrunk = ConsoleColor.DarkGray;

        /// <summary> Половина ширины верхней части тругольника, так как вычисление точек идет от центра.</summary>
        private int halfWidthTopTriangle = 7;
        /// <summary> Высота треугольника елки.</summary>
        private int heightTriangle = 9;
        /// <summary> Высота мишуры.</summary>
        private int tinselHeight = 4;
        /// <summary> Текущая ордината.</summary>
        private int currentY;

        /// <summary> Количество треугольников в елке.</summary>
        public int TriangleCount { get; set; }
        /// <summary> Ордината начала елки.</summary>
        public int StartY { get; set; }
        public int TrunkHeight => TriangleCount * 2;
        public int TreeHeight { get; private set; }
        public int TrunkWidth => TrunkHeight + TrunkHeight / 2;

        public Tree(int startY, int triangleCount)
        {
            StartY = startY;
            TriangleCount = triangleCount;
        }

        public void Print()
        {
            var random = new Random();
            Console.ForegroundColor = ColorTree;

            var tinsels = new List<Tinsel>();
            var tinsel = new Tinsel();
            currentY = StartY;

            var indent = 0;
            int triangleCount = 0;
            while (triangleCount < TriangleCount)
            {
                for (int j = 0; j < heightTriangle; j++)
                {
                    for (int i = TreeWindow.CenterWidth - indent; i < TreeWindow.CenterWidth + 1 + indent; i++)
                    {
                        //случайное расположение фонариков
                        var randomNumber = random.Next(0, RandomMaxValue);
                        //вводим ограничения, чтобы фонарики не распологались слишком близко друг к другу
                        if (randomNumber == RandomMaxValue - 1 && j != 0
                            && !Picture.OnePointPictures.Any(f => Math.Abs(f.Point.X - i) <= 2 && f.Point.Y == currentY + j
                            || Math.Abs(currentY + j - f.Point.Y) <= 1 && f.Point.X == i))
                        {
                            Picture.OnePointPictures.Add(new Flashlight(new Point(i, currentY + j)));
                        }
                        else
                        {
                            PrintHelper.PrintPicturePoint(i, currentY + j);
                        }
                    }

                    SetStartEndPointsTinsel(tinsel, j, indent);

                    if (j % 2 == 0)
                        indent += 2;
                    else
                        indent++;
                }
                triangleCount++;

                tinsels.Add(tinsel);
                tinsel = new Tinsel();
                tinsel.TinselLeftRight = tinsels.Count() % 2 == 0;

                var sizeIncrementHeightTriangle = SizeIncrementHeightTriangle * triangleCount;
                tinselHeight += sizeIncrementHeightTriangle;

                currentY += heightTriangle;
                heightTriangle += sizeIncrementHeightTriangle;

                indent = halfWidthTopTriangle;
                halfWidthTopTriangle += SizeIncrementWidthTriangle;
            }

            TreeHeight = currentY - StartY;
            foreach (var tin in tinsels)
                tin.Print();
            PrintTrunk();
        }

        /// <summary> Вывод столба.</summary>
        private void PrintTrunk()
        {
            Console.ForegroundColor = ColorTrunk;
            for (int i = 0; i < TrunkWidth; i++)
            {
                for (int j = 0; j < TrunkHeight; j++)
                {
                    PrintHelper.PrintPicturePoint(TreeWindow.CenterWidth - TrunkWidth / 2 + i, TreeHeight + StartY + j);
                }
            }
        }

        /// <summary>
        /// Устанавливаем начальную или конечную точку мишуры. 
        /// </summary>
        /// <param name="tinsel"> Объект мишуры.</param>
        /// <param name="yIndex"> Текущая ордината.</param>
        /// <param name="indent"> Отступ.</param>
        private void SetStartEndPointsTinsel(Tinsel tinsel, int yIndex, int indent)
        {
            if (yIndex == TinselStartY)
            {
                tinsel.StartPoint = GetStartEndPointTinsel(true, tinsel, indent, yIndex);
            }
            else if (yIndex == TinselStartY + tinselHeight)
            {
                tinsel.EndPoint = GetStartEndPointTinsel(false, tinsel, indent, yIndex);
            }
        }

        /// <summary>
        /// Получаем начальную или конечную точку мишуры.
        /// </summary>
        /// <param name="isStart"> Начальная или конечная точка.</param>
        /// <param name="tinsel"> Объект мишуры.</param>
        /// <param name="indent"> Отступ.</param>
        /// <param name="yIndex"> Текущая ордината.</param>
        /// <returns> Полученная точка.</returns>
        private Point GetStartEndPointTinsel(bool isStart, Tinsel tinsel, int indent, int yIndex)
        {
            var indentTinsel = indent;
            if (isStart == tinsel.TinselLeftRight)
                indentTinsel = 0 - indentTinsel;

            return new Point(TreeWindow.CenterWidth + indentTinsel, currentY + yIndex);
        }
    }
}
