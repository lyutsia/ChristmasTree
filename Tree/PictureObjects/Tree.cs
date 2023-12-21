using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Tree : IPrintable
    {
        private const int SizeIncrementWidthTriangle = 4;
        private const int SizeIncrementHeightTriangle = 2;

        private const int RandomMaxValue = 5;
        private const int TinselStartY = 3;

        private const ConsoleColor ColorTree = ConsoleColor.Green;
        private const ConsoleColor ColorTrunk = ConsoleColor.DarkGray;

        private int halfWidthTopTriangle = 7;
        private int heightTriangle = 9;
        private int tinselHeight = 4;
        private int currentTriangleStartY;

        public int TriangleCount { get; set; }
        public int StartY { get; set; }
        public int TrunkHeight { get; private set; }
        public int TreeHeight { get; private set; }
        public int TrunkWidth => TrunkHeight + TrunkHeight / 2;

        public Tree(int startY, int triangleCount)
        {
            StartY = startY;
            TriangleCount = triangleCount;
            TrunkHeight = triangleCount * 2;
        }

        public void Print()
        {
            var random = new Random();
            Console.ForegroundColor = ColorTree;

            var tinsels = new List<Tinsel>();
            var tinsel = new Tinsel();
            currentTriangleStartY = StartY;

            var indent = 0;
            int triangleCount = 0;
            while (triangleCount < TriangleCount)
            {
                for (int j = 0; j < heightTriangle; j++)
                {
                    for (int i = TreeWindow.CenterWidth - indent; i < TreeWindow.CenterWidth + 1 + indent; i++)
                    {
                        var randomNumber = random.Next(0, RandomMaxValue);

                        if (randomNumber == RandomMaxValue - 1 && j != 0
                            && !Picture.Flashlights.Any(f => Math.Abs(f.Point.X - i) <= 2 && f.Point.Y == currentTriangleStartY + j
                            || Math.Abs(currentTriangleStartY + j - f.Point.Y) <= 1 && f.Point.X == i))
                        {
                            Picture.Flashlights.Add(new Flashlight(new Point(i, currentTriangleStartY + j)));
                        }
                        else
                        {
                            PrintHelper.PrintPicturePoint(i, currentTriangleStartY + j);
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

                currentTriangleStartY += heightTriangle;
                heightTriangle += sizeIncrementHeightTriangle;

                indent = halfWidthTopTriangle;
                halfWidthTopTriangle += SizeIncrementWidthTriangle;
            }

            TreeHeight = currentTriangleStartY - StartY;
            foreach (var tin in tinsels)
                tin.Print();
            PrintTrunk();
        }

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

        private Point GetStartEndPointTinsel(bool isStart, Tinsel tinsel, int indent, int yIndex)
        {
            var indentTinsel = indent;
            if (isStart == tinsel.TinselLeftRight)
                indentTinsel = 0 - indentTinsel;

            return new Point(TreeWindow.CenterWidth + indentTinsel, currentTriangleStartY + yIndex);
        }
    }
}
