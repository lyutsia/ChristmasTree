using ChristmasTree.PictureObjects;
using System.Drawing;

namespace ChristmasTree
{
    public class Picture
    {
        private const int SnowHeight = 3;
        private const int PresentCount = 4;

        private const int SnowflakeCountInRow = 6;
        private const int MinIntervalSnowflake = 6;

        private const int StarHeight = 4;
        private const int TriangleCount = 3;
        private const int PresentHeight = 3;
        private const int BigSnowballHeight = 7;
        private const int PresentInterval = 6;

        private int[] BowColors = new int[] { 4, 13 };
        private int[] PresentColors = new int[] { 1, 3, 6 };

        private int pictureEnd;

        private Random random;

        public static List<Flashlight> Flashlights = new List<Flashlight>();
        public Picture()
        {
            random = new Random();
        }

        public void Display()
        {
            SnowflakePrint();

            var star = new Star(StarHeight);
            star.Print();

            var tree = new Tree(StarHeight + TreeWindow.StartHeight - 1, TriangleCount);
            tree.Print();

            pictureEnd = StarHeight + TreeWindow.StartHeight + tree.TreeHeight + tree.TrunkHeight - 1;
            var snowman = new Snowman(new Point(TreeWindow.Width / 7, pictureEnd), BigSnowballHeight);
            snowman.Print();

            PresentsPrint(tree.TrunkWidth);
            SnowPrint();
            FlickerFlashlights();
        }

        private void SnowflakePrint()
        {
            for (int j = 0; j < TreeWindow.Height; j++)
            {
                int ind = 0;
                while (ind < SnowflakeCountInRow)
                {
                    var x = random.Next(1, TreeWindow.Width - 1);
                    if (Flashlights.Any(f => Math.Abs(f.Point.X - x) <= MinIntervalSnowflake && f.Point.Y == j || f.Point.X == x && f.Point.Y == j - 1))
                        continue;
                    var snowflake = new Snowflake(x, j);
                    Flashlights.Add(snowflake);
                    snowflake.Print();
                    ind++;
                }
            }
        }

        private void PresentsPrint(int treeTrunkWidth)
        {
            var presentY = pictureEnd - PresentHeight;
            var presentLeftX = TreeWindow.CenterWidth - treeTrunkWidth / 2;
            var presentRightX = TreeWindow.CenterWidth + treeTrunkWidth / 2;

            for (int i = 0; i < PresentCount / 2; i++)
            {
                //подарки слева
                PresentPrint(ref presentLeftX, presentY, true);

                //подарки справа
                PresentPrint(ref presentRightX, presentY, false); ;
            }
        }

        private void PresentPrint(ref int presentX, int presentY, bool isLeft)
        {
            presentX = isLeft ? presentX - PresentInterval : presentX + PresentInterval;
            var bowColor = BowColors[random.Next(0, BowColors.Count())];
            var presentColor = PresentColors[random.Next(0, PresentColors.Count())];
            var present = new Present(new Point(presentX, presentY), PresentHeight, isLeft, (ConsoleColor)presentColor, (ConsoleColor)bowColor);
            present.Print();
            presentX = isLeft ? presentX - present.PresentWidth : presentX + present.PresentWidth;
        }

        private void SnowPrint()
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 0; j < SnowHeight; j++)
            {
                for (int i = 0; i < TreeWindow.Width; i++)
                {
                    PrintHelper.PrintPicturePoint(i, pictureEnd + j);
                }
            }
        }

        private void FlickerFlashlights()
        {
            while (true)
            {
                var index = random.Next(0, Flashlights.Count());
                Flashlights[index].Print();
            }
        }
    }
}
